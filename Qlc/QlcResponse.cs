using Newtonsoft.Json;

namespace Qlc
{
    public class QlcResponse<T>
    {
        public string Error { get; set; }
        public bool IsSuccess => string.IsNullOrEmpty(Error);
        public T Data { get; set; }
        public string RawData { get; set; }
        public int Id { get; set; }

        public QlcResponse(T data, string rawData, string error)
        {
            this.Data = data;
            this.RawData = rawData;
            this.Error = error;
            this.Id = -1;
        }
    }
}
