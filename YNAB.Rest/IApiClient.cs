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
        /// <param name="lastKnowledgeOfServer">(Optional) Only the data that has changed since the last knowledge of server will be included in the response.</param>
        /// <returns>An ApiResponse object containing the list of Accounts in the Data property.</returns>
        [Get("/budgets/{budgetId}/accounts?last_knowledge_of_server={lastKnowledgeOfServer}")]
        Task<ApiResponse<AccountsData>> GetAccounts(string budgetId, long lastKnowledgeOfServer = 0);

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
        /// <param name="lastKnowledgeOfServer">(Optional) Only the data that has changed since the last knowledge of server will be included in the response.</param>
        /// <returns>An ApiResponse object containing the Budget in the Data property.</returns>
        [Get("/budgets/{budgetId}?last_knowledge_of_server={lastKnowledgeOfServer}")]
        Task<ApiResponse<BudgetData>> GetBudget(string budgetId, long lastKnowledgeOfServer = 0);

        /// <summary>
        /// Gets all Categories for the specified Budget.
        /// </summary>
        /// <param name="budgetId">The ID of the Budget.</param>
        /// <param name="lastKnowledgeOfServer">(Optional) Only the data that has changed since the last knowledge of server will be included in the response.</param>
        /// <returns>An ApiResponse object containing the list of Categories in the Data property.</returns>
        [Get("/budgets/{budgetId}/categories?last_knowledge_of_server={lastKnowledgeOfServer}")]
        Task<ApiResponse<CategoriesData>> GetCategories(string budgetId, long lastKnowledgeOfServer = 0);

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
        /// <param name="lastKnowledgeOfServer">(Optional) Only the data that has changed since the last knowledge of server will be included in the response.</param>
        /// <returns>An ApiResponse object containing the list of Transactions in the Data property.</returns>
        [Get("/budgets/{budgetId}/transactions?last_knowledge_of_server={lastKnowledgeOfServer}")]
        Task<ApiResponse<TransactionsData>> GetTransactions(string budgetId, long lastKnowledgeOfServer = 0);

        /// <summary>
        /// Gets all Transactions from the specified Budget that occured on or after a specified date.
        /// </summary>
        /// <param name="budgetId">The ID of the Budget</param>
        /// <param name="sinceDate">The ISO start date. For example: 2018-03-01</param>
        /// <param name="lastKnowledgeOfServer">(Optional) Only the data that has changed since the last knowledge of server will be included in the response.</param>
        /// <returns></returns>
        [Get("/budgets/{budgetId}/transactions?since_date={sinceDate}&last_knowledge_of_server={lastKnowledgeOfServer}")]
        Task<ApiResponse<TransactionsData>> GetTransactions(string budgetId, string sinceDate, long lastKnowledgeOfServer = 0);


        /// <summary>
        /// Gets all Transactions for the specified Budget and Account.
        /// </summary>
        /// <param name="budgetId">The ID of the Budget.</param>
        /// <param name="accountId">The ID of the Account.</param>
        /// <returns>An ApiResponse object containing the list of Transactions in the Data property.</returns>
        [Get("/budgets/{budgetId}/accounts/{accountId}/transactions")]
        Task<ApiResponse<TransactionsData>> GetTransactionsByAccount(string budgetId, string accountId);


        /// <summary>
        /// Gets all Transactions for the specified Budget and Account that occured on or after a specified date.
        /// </summary>
        /// <param name="budgetId">The ID of the Budget.</param>
        /// <param name="accountId">The ID of the Account.</param>
        /// <param name="sinceDate">The ISO start date. For example: 2018-03-01</param>
        /// <returns>An ApiResponse object containing the list of Transactions in the Data property.</returns>
        [Get("/budgets/{budgetId}/accounts/{accountId}/transactions?since_date={sinceDate}")]
        Task<ApiResponse<TransactionsData>> GetTransactionsByAccount(string budgetId, string accountId, string sinceDate);


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
        /// <param name="transactionId">The ID of the Transaction.</param>
        /// <returns>An ApiResponse object containing the list of accounts in the Data property.</returns>
        [Get("/budgets/{budgetId}/transactions/{transactionId}")]
        Task<ApiResponse<TransactionData>> GetTransaction(string budgetId, string transactionId);

        /// <summary>
        /// Creates a single Transaction in the specified Budget.
        /// </summary>
        /// <param name="budgetId">The ID of the Budget.</param>
        /// <param name="transaction">The Transaction.</param>
        /// <returns>A response containing the created Transaction.</returns>
        [Post("/budgets/{budgetId}/transactions")]
        Task<ApiResponse<TransactionBody>> PostTransaction(string budgetId, [Body] TransactionBody transaction);

        /// <summary>
        /// Creates multiple Transactions in the specified Budget.
        /// </summary>
        /// <param name="budgetId">The ID of the Budget.</param>
        /// <param name="transactions">The Transactions.</param>
        /// <returns>A response containing the results of the bulk create.</returns>
        [Post("/budgets/{budgetId}/transactions/bulk")]
        Task<ApiResponse<PostBulkTransactionsData>> PostBulkTransactions(string budgetId, [Body] PostBulkTransactions transactions);

        /// <summary>
        /// Imports available transactions on all linked accounts for the given budget.
        /// </summary>
        /// <param name="budgetId">The ID of the Budget.</param>
        /// <returns>A response containing the transaction ids that have been imported..</returns>
        [Post("/budgets/{budgetId}/transactions/import")]
        Task<ApiResponse<PostImportTransactionsData>> PostImportTransactions(string budgetId);

        /// <summary>
        /// Updates a single Transaction in the specified Budget.
        /// </summary>
        /// <param name="budgetId">The ID of the Budget.</param>
        /// <param name="transactionId">The ID of the Transaction.</param>
        /// <param name="transaction">The Transaction.</param>
        /// <returns>A response containing the updated Transaction.</returns>
        [Put("/budgets/{budgetId}/transactions/{transactionId}")]
        Task<ApiResponse<TransactionBody>> PutTransaction(string budgetId, string transactionId, [Body] TransactionBody transaction);

        /// <summary>
        /// Gets a list of payees in the specified Budget.
        /// </summary>
        /// <param name="budgetId">The ID of the Budget.</param>
        /// <param name="lastKnowledgeOfServer">(Optional) Only the data that has changed since the last knowledge of server will be included in the response.</param>
        /// <returns>An ApiResponse object containing the list of payees in the Data property.</returns>
        [Get("/budgets/{budgetId}/payees?last_knowledge_of_server={lastKnowledgeOfServer}")]
        Task<ApiResponse<PayeesData>> GetPayees(string budgetId, long lastKnowledgeOfServer = 0);

        /// <summary>
        /// Gets a single payee in the specified Budget.
        /// </summary>
        /// <param name="budgetId">The ID of the Budget.</param>
        /// <param name="payeeId">The ID of the Payee.</param>
        /// <returns>An ApiResponse object containing a single payee in the Data property.</returns>
        [Get("/budgets/{budgetId/payees/{payeeId}")]
        Task<ApiResponse<PayeeData>> GetPayee(string budgetId, string payeeId);

        /// <summary>
        /// Gets a list of payee locations in the specified Budget.
        /// </summary>
        /// <param name="budgetId">The ID of the Budget.</param>
        /// <returns>An ApiResponse object containing a list of payee locations in the Data Property.</returns>
        [Get ("/budgets/{budgetId}/payee_locations")]
        Task<ApiResponse<PayeeLocationsData>> GetPayeeLocations(string budgetId);

        /// <summary>
        /// Gets a single payee location in the specified Budget.
        /// </summary>
        /// <param name="budgetId">The ID of the Budget.</param>
        /// <param name="payeeLocationId">The ID of the Payee Location</param>
        /// <returns>An ApiResponse object containing a single payee location in the Data Property.</returns>
        [Get ("/budgets/{budgetId}/payee_locations/{payeeLocationId}")]
        Task<ApiResponse<PayeeLocationsData>> GetPayeeLocation(string budgetId, string payeeLocationId);

        /// <summary>
        /// Gets a list of locations for a payee.
        /// </summary>
        /// <param name="budgetId">The ID of the Budget.</param>
        /// <param name="payeeId">The ID of the Payee.</param>
        /// <returns>An ApiResponse object containing a list of locations for a payee</returns>
        [Get ("/budgets/{budgetId}/payees/{payeeId}/payee_locations")]
        Task<ApiResponse<PayeeLocationsData>> GetLocationsForPayee(string budgetId, string payeeId);

        /// <summary>
        /// Gets a single month in the specified Budget.
        /// </summary>
        /// <param name="budgetId">The ID of the Budget.</param>
        /// <param name="month">The month to retrieve.</param>
        /// <returns> An ApiResponse object containing data for a month</returns>
        [Get ("/budgets/{budgetId}/months/{month}")]
        Task<ApiResponse<MonthData>> GetMonth(string budgetId, string month);

        /// <summary>
        /// Gets a list of months in the specific Budget.
        /// </summary>
        /// <param name="budgetId">The ID of the Budget.</param>
        /// <param name="lastKnowledgeOfServer">(Optional) Only the data that has changed since the last knowledge of server will be included in the response.</param>
        /// <returns> An ApiResponse object containing a list of months for a budget</returns>
        [Get ("/budgets/{budgetId}/months?last_knowledge_of_server={lastKnowledgeOfServer}")]
        Task<ApiResponse<MonthsData>> GetMonths(string budgetId, long lastKnowledgeOfServer = 0);

        /// <summary>
        /// Gets a list of scheduled transactions in the specific Budget.
        /// </summary>
        /// <param name="budgetId">The ID of the budget.</param>
        /// <param name="lastKnowledgeOfServer">(Optional) Only the data that has changed since the last knowledge of server will be included in the response.</param>
        /// <returns>An ApiResponse object containing a list of scheduled transactions in the Data property</returns>
        [Get("/budgets/{budgetId}/scheduled_transactions?last_knowledge_of_server={lastKnowledgeOfServer}")]
        Task<ApiResponse<ScheduledTransactionsData>> GetScheduledTransactions(string budgetId, long lastKnowledgeOfServer = 0);

        /// <summary>
        /// Gets a single scheduled transaction in the specific Budget.
        /// </summary>
        /// <param name="budgetId">The ID of the Budget</param>
        /// <param name="scheduledTransactionId">The ID of the scheduled transaction</param>
        /// <returns>An ApiResponse object containing a scheduled transaction in the Data property</returns>
        [Get("/budgets/{budgetId}/scheduled_transactions/{scheduledTransactionId")]
        Task<ApiResponse<ScheduledTransactionData>> GetScheduledTransaction(string budgetId, string scheduledTransactionId);

    }
}
