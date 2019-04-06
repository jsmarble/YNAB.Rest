# YNAB.Rest
A .NET client for the YNAB REST API, using the [Refit REST library](https://github.com/reactiveui/refit). All REST methods are asynchronous and awaitable.

## Getting Started
1. Install the [Nuget package](https://www.nuget.org/packages/YNAB.Rest/) or compile the code.
2. Import the namespace `YNAB.Rest`.
3. Create an IApiClient by calling `ApiClientFactory.Create([accessToken])`.
4. Start coding!

### Example Code
```cs
string accessToken = "secret_api_access_token";
var api = ApiClientFactory.Create(accessToken);
var budgetsResponse = await api.GetBudgets();
var budgets = budgetsResponse.Data.Budgets;
```

### Response Objects
All methods return a response object that has a `Data` property containing the data from the REST API call. In this example, the response object contains a `Data` property that has a `Budgets` property with a list of Budgets.

This structure follows the convention of the [YNAB REST API](https://api.youneedabudget.com/v1).

## Project Status
This is a new project. There are plenty of opportunities for improvement.

### What Works
GET Budgets, Accounts, Categories, Transactions, Scheduled Transactions
POST/PUT Transactions

### What Needs To Be Done
GET Payees, Payee Locations, Months
Implement Delta Requests

## License
This code is [licensed under the MIT License](LICENSE). Use of this code requires consent to the terms of the license.
