using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Qlc.Net
{
    public class RpcClient : IQlcNetClient
    {
        private readonly JsonSerializerSettings jsonSerializerSettings;
        private readonly JsonSerializer jsonSerializer;
        private readonly Uri uri;

        public RpcClient(Uri uri, JsonSerializerSettings jsonSerializerSettings)
        {
            this.jsonSerializerSettings = jsonSerializerSettings ?? throw new ArgumentNullException(nameof(jsonSerializerSettings));
            this.jsonSerializer = JsonSerializer.Create(jsonSerializerSettings);
            this.uri = uri ?? throw new ArgumentNullException(nameof(uri));
        }

        public async Task<QlcResponse<T>> GetResponseAsync<T>(QlcRequest request)
        {
            var validatedResponse = await this.GetValidatedResponse(request).ConfigureAwait(false);

            if (!validatedResponse.IsSuccess) return new QlcResponse<T>(default, validatedResponse.RawData, validatedResponse.Error);

            if (validatedResponse.Data is JObject)
            {
                var wrappedError = validatedResponse.Data["error"]?.Value<string>("message");
                if (wrappedError != null)
                {
                    var errorMessage = $"Error {validatedResponse.Data["error"]?.Value<int>("code")} : {wrappedError}";
                    return new QlcResponse<T>(default, validatedResponse.RawData, errorMessage) { Id = validatedResponse.Data.Value<int>("id") };
                }
            }

            try
            {
                var response = new QlcResponse<T>(validatedResponse.Data["result"].ToObject<T>(jsonSerializer), validatedResponse.RawData, null);
                response.Id = validatedResponse.Data.Value<int>("id");
                return response;
            }
            catch (Exception ex)
            {
                return new QlcResponse<T>(default, validatedResponse.RawData, $"Could not serialize json to {typeof(T).Name} : {ex.ToString()}");
            }
        }

        private async Task<QlcResponse<JToken>> GetValidatedResponse(QlcRequest request)
        {
            var rawResponse = await this.GetRawResponse(request).ConfigureAwait(false);

            if (!rawResponse.IsSuccess) return new QlcResponse<JToken>(null, rawResponse.Data, rawResponse.Error);

            try
            {
                return new QlcResponse<JToken>(JToken.Parse(rawResponse.Data), rawResponse.Data, null);
            }
            catch (JsonReaderException jre)
            {
                var errorMessage = $"JsonReaderException: {jre.Message}, Path: {jre.Path}, Line: {jre.LineNumber}, Position: {jre.LinePosition}. Raw data: {rawResponse.Data}";
                return new QlcResponse<JToken>(null, rawResponse.Data, errorMessage);
            }
            catch (JsonSerializationException jse)
            {
                var errorMessage = $"JsonSerializationException: {jse.Message}. Data: {rawResponse.Data}";
                return new QlcResponse<JToken>(null, rawResponse.Data, errorMessage);
            }
            catch (Exception ex)
            {
                var errorMessage = $"Unexpected Json exception: {ex.Message}. Data: {rawResponse.Data}";
                return new QlcResponse<JToken>(null, rawResponse.Data, errorMessage);
            }
        }

        private async Task<QlcResponse<string>> GetRawResponse(QlcRequest request)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var requestMessage = new HttpRequestMessage();
                    requestMessage.RequestUri = uri;
                    requestMessage.Method = new HttpMethod("POST");
                    var requestMessageContent = JsonConvert.SerializeObject(request, jsonSerializerSettings);
                    requestMessage.Content = new StringContent(requestMessageContent, Encoding.UTF8, "application/json");

                    var response = await client.SendAsync(requestMessage);
                    var content = await response.Content.ReadAsStringAsync();

                    return new QlcResponse<string>(content, null, null);
                }
            }
            catch (Exception ex)
            {
                return new QlcResponse<string>(null, null, $"Error contacting {this.uri.AbsoluteUri} : {ex.ToString()}");
            }
        }
    }
}
