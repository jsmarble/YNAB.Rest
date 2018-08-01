# YNAB.Rest
A .NET client for the YNAB REST API, using the [Refit REST library](https://github.com/reactiveui/refit).

## Getting Started
1. Install the [Nuget package](https://www.nuget.org/packages/YNAB.Rest/)
2. Import the namespace `YNAB.Rest`.
3. Create an IApiClient by calling `ApiClient.Create()`.
4. Start coding!

```cs
string accessToken = "secret_api_access_token";
var api = ApiClient.Create();
var budgetsResponse = await api.GetBudgets(accessToken);
var budgets = budgetsResponse.Data.Budgets;
```
