# qlc.Net
A feature complete and easy to use QLC .Net SDK

## Example

```csharp
var client = new QlcClient();



foreach(var account in response.Data)
{
    //Do something with account
    accountId = account.Id;
}
```

Each method exists in a synchronous and asynchronous version for easy integration in both single and multithreaded applications.



