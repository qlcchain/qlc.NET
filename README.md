# qlc.Net
A feature complete and easy to use QLC .Net SDK

## Example

```csharp
var client = new QlcClient();

var accountInfoResponse = await client.GetAccountInfoAsync("qlc_123...");

foreach(var token in accountInfoResponse.Data.Tokens)
{
    Console.WriteLine($"{token.TokenName} - {token.Balance}");
}
```

Each method exists in a synchronous and asynchronous version for easy integration in both single and multithreaded applications.



