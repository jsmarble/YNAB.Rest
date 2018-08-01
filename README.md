# YNAB.Rest
A .NET client for the YNAB REST API, using the [Refit REST library](https://github.com/reactiveui/refit).

## Getting Started
1. Install the [Nuget package](https://www.nuget.org/packages/YNAB.Rest/) or compile the code.
2. Import the namespace `YNAB.Rest`.
3. Create an IApiClient by calling `ApiClient.Create([accessToken])`.
4. Start coding!

### Example Code
```cs
string accessToken = "secret_api_access_token";
var api = ApiClient.Create(accessToken);
var budgetsResponse = await api.GetBudgets();
var budgets = budgetsResponse.Data.Budgets;
```

### Response Objects
All methods return a response object that has a `Data` property containing the data from the REST API call. In this example, the response object contains a `Data` property that has a `Budgets` property with a list of Budgets.

This structure follows the convention of the [YNAB REST API](https://api.youneedabudget.com/v1).
