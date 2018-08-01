using Refit;
using System;
using System.Threading.Tasks;

namespace YNAB.Rest
{
    public interface IApiClient
    {
        [Get("/budgets/{budgetId}/accounts")]
        Task<ApiResponse<AccountsData>> GetAccounts(string budgetId, [Header("Authorization")] string authorization);

        [Get("/budgets/{budgetId}/accounts/{accountId}")]
        Task<ApiResponse<AccountData>> GetAccount(string budgetId, string accountId, [Header("Authorization")] string authorization);

        [Get("/budgets")]
        Task<ApiResponse<BudgetsData>> GetBudgets([Header("Authorization")] string authorization);

        [Get("/budgets/{budgetId}")]
        Task<ApiResponse<BudgetData>> GetBudget(string budgetId, [Header("Authorization")] string authorization);

        [Get("/budgets/{budgetId}/categories")]
        Task<ApiResponse<CategoriesData>> GetCategories(string budgetId, [Header("Authorization")] string authorization);

        [Get("/budgets/{budgetId}/categories/{categoryId}")]
        Task<ApiResponse<CategoryData>> GetCategory(string budgetId, string categoryId, [Header("Authorization")] string authorization);

        [Get("/budgets/{budgetId}/transactions")]
        Task<ApiResponse<TransactionsData>> GetTransactions(string budgetId, [Header("Authorization")] string authorization);

        [Get("/budgets/{budgetId}/accounts/{accountId}/transactions")]
        Task<ApiResponse<TransactionsData>> GetTransactionsByAccount(string budgetId, string accountId, [Header("Authorization")] string authorization);

        [Get("/budgets/{budgetId}/categories/{categoryId}/transactions")]
        Task<ApiResponse<TransactionsData>> GetTransactionsByCategory(string budgetId, string categoryId, [Header("Authorization")] string authorization);

        [Get("/budgets/{budgetId}/transactions/{transactionId}")]
        Task<ApiResponse<TransactionData>> GetTransaction(string budgetId, string transactionId, [Header("Authorization")] string authorization);
    }
}
