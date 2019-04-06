using System.Threading.Tasks;
using Refit;

namespace YNAB.Rest {
    /// <summary>
    /// An interface containing the REST methods available in the YNAB API.
    /// </summary>
    public interface IApiClient {
        /// <summary>
        /// Gets all Accounts for the specified Budget.
        /// </summary>
        /// <param name="budgetId">The ID of the Budget.</param>
        /// <returns>An ApiResponse object containing the list of Accounts in the Data property.</returns>
        [Get ("/budgets/{budgetId}/accounts")]
        Task<ApiResponse<AccountsData>> GetAccounts (string budgetId);

        /// <summary>
        /// Gets a single Account for the specified Budget and account ID.
        /// </summary>
        /// <param name="budgetId">The ID of the Budget.</param>
        /// <param name="accountId">The ID of the Account.</param>
        /// <returns>An ApiResponse object containing the Account in the Data property.</returns>
        [Get ("/budgets/{budgetId}/accounts/{accountId}")]
        Task<ApiResponse<AccountData>> GetAccount (string budgetId, string accountId);

        /// <summary>
        /// Gets all budgets.
        /// </summary>
        /// <returns>An ApiResponse object containing the list of Budgets in the Data property.</returns>
        [Get ("/budgets")]
        Task<ApiResponse<BudgetsData>> GetBudgets ();

        /// <summary>
        /// Gets a single Budget for the specified Budget ID.
        /// </summary>
        /// <param name="budgetId">The ID of the Budget.</param>
        /// <returns>An ApiResponse object containing the Budget in the Data property.</returns>
        [Get ("/budgets/{budgetId}")]
        Task<ApiResponse<BudgetData>> GetBudget (string budgetId);

        /// <summary>
        /// Gets all Categories for the specified Budget.
        /// </summary>
        /// <param name="budgetId">The ID of the Budget.</param>
        /// <returns>An ApiResponse object containing the list of Categories in the Data property.</returns>
        [Get ("/budgets/{budgetId}/categories")]
        Task<ApiResponse<CategoriesData>> GetCategories (string budgetId);

        /// <summary>
        /// Gets a single Category for the specified Budget and category ID.
        /// </summary>
        /// <param name="budgetId">The ID of the Budget.</param>
        /// <param name="categoryId">The ID of the Category.</param>
        /// <returns>An ApiResponse object containing the list of Accounts in the Data property.</returns>
        [Get ("/budgets/{budgetId}/categories/{categoryId}")]
        Task<ApiResponse<CategoryData>> GetCategory (string budgetId, string categoryId);

        /// <summary>
        /// Gets all Transactions for the specified Budget.
        /// </summary>
        /// <param name="budgetId">The ID of the Budget.</param>
        /// <returns>An ApiResponse object containing the list of Transactions in the Data property.</returns>
        [Get ("/budgets/{budgetId}/transactions")]
        Task<ApiResponse<TransactionsData>> GetTransactions (string budgetId);

        /// <summary>
        /// Gets all Transactions for the specified Budget and Account.
        /// </summary>
        /// <param name="budgetId">The ID of the Budget.</param>
        /// <param name="accountId">The ID of the Account.</param>
        /// <returns>An ApiResponse object containing the list of Transactions in the Data property.</returns>
        [Get ("/budgets/{budgetId}/accounts/{accountId}/transactions")]
        Task<ApiResponse<TransactionsData>> GetTransactionsByAccount (string budgetId, string accountId);

        /// <summary>
        /// Gets all Transactions for the specified Budget and Category.
        /// </summary>
        /// <param name="budgetId">The ID of the Budget.</param>
        /// <param name="categoryId">The ID of the Category.</param>
        /// <returns>An ApiResponse object containing the list of accounts in the Data property.</returns>
        [Get ("/budgets/{budgetId}/categories/{categoryId}/transactions")]
        Task<ApiResponse<TransactionsData>> GetTransactionsByCategory (string budgetId, string categoryId);

        /// <summary>
        /// Gets a single Transaction for the specified Budget and Transaction ID.
        /// </summary>
        /// <param name="budgetId">The ID of the Budget.</param>
        /// <param name="transactionId">The ID of the Transaction.</param>
        /// <returns>An ApiResponse object containing the list of accounts in the Data property.</returns>
        [Get ("/budgets/{budgetId}/transactions/{transactionId}")]
        Task<ApiResponse<TransactionData>> GetTransaction (string budgetId, string transactionId);

        /// <summary>
        /// Creates a single Transaction in the specified Budget.
        /// </summary>
        /// <param name="budgetId">The ID of the Budget.</param>
        /// <param name="transaction">The Transaction.</param>
        /// <returns>A response containing the created Transaction.</returns>
        [Post ("/budgets/{budgetId}/transactions")]
        Task<ApiResponse<TransactionBody>> PostTransaction (string budgetId, [Body] TransactionBody transaction);

        /// <summary>
        /// Creates multiple Transactions in the specified Budget.
        /// </summary>
        /// <param name="budgetId">The ID of the Budget.</param>
        /// <param name="transactions">The Transactions.</param>
        /// <returns>A response containing the results of the bulk create.</returns>
        [Post ("/budgets/{budgetId}/transactions/bulk")]
        Task<ApiResponse<PostBulkTransactionsData>> PostBulkTransactions (string budgetId, [Body] PostBulkTransactions transactions);

        /// <summary>
        /// Updates a single Transaction in the specified Budget.
        /// </summary>
        /// <param name="budgetId">The ID of the Budget.</param>
        /// <param name="transactionId">The ID of the Transaction.</param>
        /// <param name="transaction">The Transaction.</param>
        /// <returns>A response containing the updated Transaction.</returns>
        [Put ("/budgets/{budgetId}/transactions/{transactionId}")]
        Task<ApiResponse<TransactionBody>> PutTransaction (string budgetId, string transactionId, [Body] TransactionBody transaction);

        /// <summary>
        /// Gets a list of payees in the specified Budget.
        /// </summary>
        /// <param name="budgetId">The ID of the Budget.</param>
        /// <returns>An ApiResponse object containing the list of payees in the Data property.</returns>
        [Get ("/budgets/{budgetId}/payees")]
        Task<ApiResponse<PayeesData>> GetPayees (string budgetId);

        /// <summary>
        /// Gets a single payee in the specified Budget.
        /// </summary>
        /// <param name="budgetId">The ID of the Budget.</param>
        /// <param name="payeeId">The ID of the Payee.</param>
        /// <returns>An ApiResponse object containing a single payee in the Data property.</returns>
        [Get ("/budgets/{budgetId}/payees/{payeeId}")]
        Task<ApiResponse<PayeeData>> GetPayee (string budgetId, string payeeId);

        /// <summary>
        /// Lists payee locations for the specified Budget.
        /// </summary>
        /// <param name="budgetId">The ID of the Budget.</param>
        /// <returns>An ApiResponse object containing a list of payee locations in the Data Property.</returns>
        [Get ("/budgets/{budgetId}/payee_locations")]
        Task<ApiResponse<PayeeLocationsData>> GetPayeeLocations (string budgetId);

        /// <summary>
        /// Lists payee locations for the specified Budget.
        /// </summary>
        /// <param name="budgetId">The ID of the Budget.</param>
        /// <param name="payeeLocationId">The ID of the Payee Location</param>
        /// <returns>An ApiResponse object containing a single payee location in the Data Property.</returns>
        [Get ("/budgets/{budgetId}/payee_locations/{payeeLocationId}")]
        Task<ApiResponse<PayeeLocationsData>> GetPayeeLocation (string budgetId, string payeeLocationId);

        /// <summary>
        /// Lists locations for a payee.
        /// </summary>
        /// <param name="budgetId">The ID of the Budget.</param>
        /// <param name="payeeId">The ID of the Payee.</param>
        /// <reurns>An ApiResponse object containing a list of locations for a payee</returns>
        [Get ("/budgets/{budgetId}/payees/{payeeId}/payee_locations")]
        Task<ApiResponse<PayeeLocationsData>> GetLocationsForPayee (string budgetId, string payeeId);
    }
}
