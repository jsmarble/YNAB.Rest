using Refit;
using System;
using System.Threading.Tasks;

namespace YNAB.Rest
{
    /// <summary>
    /// An interface containing the REST methods available in the YNAB API.
    /// </summary>
    public interface IApiClient
    {
        /// <summary>
        /// Gets all Accounts for the specified Budget.
        /// </summary>
        /// <param name="budgetId">The ID of the Budget.</param>
        /// <returns>An ApiResponse object containing the list of Accounts in the Data property.</returns>
        [Get("/budgets/{budgetId}/accounts")]
        Task<ApiResponse<AccountsData>> GetAccounts(string budgetId);

        /// <summary>
        /// Gets a single Account for the specified Budget and account ID.
        /// </summary>
        /// <param name="budgetId">The ID of the Budget.</param>
        /// <param name="accountId">The ID of the Account.</param>
        /// <returns>An ApiResponse object containing the Account in the Data property.</returns>
        [Get("/budgets/{budgetId}/accounts/{accountId}")]
        Task<ApiResponse<AccountData>> GetAccount(string budgetId, string accountId);

        /// <summary>
        /// Gets all budgets.
        /// </summary>
        /// <returns>An ApiResponse object containing the list of Budgets in the Data property.</returns>
        [Get("/budgets")]
        Task<ApiResponse<BudgetsData>> GetBudgets();

        /// <summary>
        /// Gets a single Budget for the specified Budget ID.
        /// </summary>
        /// <param name="budgetId">The ID of the Budget.</param>
        /// <returns>An ApiResponse object containing the Budget in the Data property.</returns>
        [Get("/budgets/{budgetId}")]
        Task<ApiResponse<BudgetData>> GetBudget(string budgetId);

        /// <summary>
        /// Gets all Categories for the specified Budget.
        /// </summary>
        /// <param name="budgetId">The ID of the Budget.</param>
        /// <returns>An ApiResponse object containing the list of Categories in the Data property.</returns>
        [Get("/budgets/{budgetId}/categories")]
        Task<ApiResponse<CategoriesData>> GetCategories(string budgetId);

        /// <summary>
        /// Gets a single Category for the specified Budget and category ID.
        /// </summary>
        /// <param name="budgetId">The ID of the Budget.</param>
        /// <param name="categoryId">The ID of the Category.</param>
        /// <returns>An ApiResponse object containing the list of Accounts in the Data property.</returns>
        [Get("/budgets/{budgetId}/categories/{categoryId}")]
        Task<ApiResponse<CategoryData>> GetCategory(string budgetId, string categoryId);

        /// <summary>
        /// Gets all Transactions for the specified Budget.
        /// </summary>
        /// <param name="budgetId">The ID of the Budget.</param>
        /// <returns>An ApiResponse object containing the list of Transactions in the Data property.</returns>
        [Get("/budgets/{budgetId}/transactions")]
        Task<ApiResponse<TransactionsData>> GetTransactions(string budgetId);

        /// <summary>
        /// Gets all Transactions for the specified Budget and Account.
        /// </summary>
        /// <param name="budgetId">The ID of the Budget.</param>
        /// <param name="accountId">The ID of the Account.</param>
        /// <returns>An ApiResponse object containing the list of Transactions in the Data property.</returns>
        [Get("/budgets/{budgetId}/accounts/{accountId}/transactions")]
        Task<ApiResponse<TransactionsData>> GetTransactionsByAccount(string budgetId, string accountId);

        /// <summary>
        /// Gets all Transactions for the specified Budget and Category.
        /// </summary>
        /// <param name="budgetId">The ID of the Budget.</param>
        /// <param name="categoryId">The ID of the Category.</param>
        /// <returns>An ApiResponse object containing the list of accounts in the Data property.</returns>
        [Get("/budgets/{budgetId}/categories/{categoryId}/transactions")]
        Task<ApiResponse<TransactionsData>> GetTransactionsByCategory(string budgetId, string categoryId);

        /// <summary>
        /// Gets a single Transaction for the specified Budget and Transaction ID.
        /// </summary>
        /// <param name="budgetId">The ID of the Budget.</param>
        /// <param name="transactionId">The ID of the Transaction</param>
        /// <returns>An ApiResponse object containing the list of accounts in the Data property.</returns>
        [Get("/budgets/{budgetId}/transactions/{transactionId}")]
        Task<ApiResponse<TransactionData>> GetTransaction(string budgetId, string transactionId);
    }
}
