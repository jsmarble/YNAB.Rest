using Refit;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using YNAB.Rest;

namespace YNAB.RestConsole
{
    class Program
    {
        private const string ACCESS_TOKEN_FILE = "accessToken";

        public static async Task Main(string[] args)
        {
            try
            {
                HttpClientHandler httpClientHandler = new HttpClientHandler();

                //to intercept traffic with http toolkit (https://httptoolkit.com)
                httpClientHandler.ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;
                httpClientHandler.Proxy = new WebProxy("http://localhost:8000");

                string token = await GetAccessToken();

                var api = ApiClientFactory.Create(token, () => new HttpClient(httpClientHandler));
                var budgetsResponse = await api.GetBudgets();
                var budgets = budgetsResponse.Data.Budgets;

                if (budgets.Count == 0)
                    throw new InvalidOperationException("No budgets found!");

                Console.WriteLine($"Found {budgets.Count} budgets!");
                Console.WriteLine();

                budgets.ToList().ForEach(b => Console.WriteLine(b.Name));
                Console.WriteLine();

                var budget = budgets.FirstOrDefault(x => x.Name == "Dev Budget");
                Console.WriteLine($"Reading budget {budget.Name} ({budget.Id})");
                Console.WriteLine();

                var budgetDetails = await api.GetBudget(budget.Id, 115);
                Console.WriteLine($"server knowledge: {budgetDetails.Data.ServerKnowledge}");
                Console.WriteLine();

                var accountsResponse = await api.GetAccounts(budget.Id);
                var accounts = accountsResponse.Data.Accounts;
                Console.WriteLine($"Found {accounts.Count} accounts!");
                Console.WriteLine();

                var account = accounts.OrderByDescending(x => x.Balance).FirstOrDefault();
                Console.WriteLine($"Reading account {account.Name} ({account.Id}) with balance {account.Balance.YnabIntToDecimal()}");
                Console.WriteLine();

                var transactionsResponse = await api.GetTransactionsByAccount(budget.Id, account.Id);
                var transactions = transactionsResponse.Data.Transactions;
                Console.WriteLine($"Found {transactions.Count} transactions!");
                Console.WriteLine();

                transactions.ToList().ForEach(x => Console.WriteLine($"{x.Id} | {x.PayeeName} | {x.CategoryName} | {x.Memo} | {x.Amount.YnabIntToDecimal():C2} | {x.FlagColor}"));

                transactions = new List<Transaction>
                {
                    new Transaction
                    {
                         PayeeName = "Test1",
                         Amount = Convert.ToInt32(108.41 * 1000),
                         Memo = "This is test 1",
                         AccountId = account.Id,
                         Date = DateTime.Today.AddDays(-2),
                         Cleared = ClearedStatus.Cleared
                    },
                    new Transaction
                    {
                         PayeeName="Test2",
                         Amount = Convert.ToInt32(208.42 * 1000),
                         Memo="This is test 2",
                         AccountId = account.Id,
                         Date = DateTime.Today.AddDays(-3),
                         Cleared = ClearedStatus.Uncleared
                    },
                    new Transaction
                    {
                         PayeeName = "Test3",
                         Amount = Convert.ToInt32(308.43 * 1000),
                         Memo = "This is test 3",
                         AccountId = account.Id,
                         Date = DateTime.Today.AddDays(-4),
                         Cleared = ClearedStatus.Uncleared
                    }
                };

                Console.WriteLine($"Posting {transactions.Count} transactions ...");
                PostBulkTransactions bulk = new PostBulkTransactions { Transactions = transactions };
                var result = await api.PostBulkTransactions(budget.Id, bulk);
                Console.WriteLine("Duplicate import IDs: " + string.Join(", ", result.Data.Bulk.DuplicateImportIds));
                Console.WriteLine("Transaction IDs: " + string.Join(", ", result.Data.Bulk.TransactionIds));

                Console.WriteLine("Posting a single transaction ...");
                TransactionBody post = new TransactionBody
                {
                    Transaction = new Transaction
                    {
                        PayeeName = "Test123",
                        Amount = Convert.ToInt32(123.45 * 1000),
                        Memo = "This is test 123",
                        AccountId = account.Id,
                        Date = DateTime.Today.AddDays(-1),
                        Cleared = ClearedStatus.Cleared
                    }
                };
                var t = (await api.PostTransaction(budget.Id, post)).Data.Transaction;
                Console.WriteLine($"Posted Transaction with ID {t.Id}.");

                t.Memo = "updated through PUT";
                await api.PutTransaction(budget.Id, t.Id, new TransactionBody { Transaction = t });

                var payeesResponse = await api.GetPayees(budget.Id);
                var payees = payeesResponse.Data.Payees;
                Console.WriteLine($"Found {payees.Count} payees!");
                Console.WriteLine();

                payees.ToList().ForEach(p => Console.WriteLine($"{p.Id} | {p.Name}"));

                Console.WriteLine($"Fetching Categories...");
                var categoryResponse = await api.GetCategories(budget.Id);
                var categoryGroups = categoryResponse.Data.CategoryGroups;
                Console.WriteLine($"Found {categoryGroups.Count} category groups!");
                Console.WriteLine();
                categoryGroups.ToList().ForEach(p => Console.WriteLine($"{p.Id} | {p.Name}"));
                var categories = categoryGroups.SelectMany(p => p.Categories).OrderBy(x => x.CategoryGroupId).ThenBy(x => x.Name).ToList();
                Console.WriteLine($"Found {categories.Count} categories!");
                Console.WriteLine();
                categories.ToList().ForEach(p => Console.WriteLine($"{p.Id} | {p.Name}"));

                var catWithGoal = categories.FirstOrDefault(x => x.GoalType.HasValue);
                var catWithoutGoal = categories.FirstOrDefault(x => !x.GoalType.HasValue);
                if (catWithGoal != null)
                    Console.WriteLine($"{catWithGoal.Id} | {catWithGoal.GoalType} | {catWithGoal.GoalTargetMonth}");
                else
                    Console.WriteLine("No category with goals!");

                if (catWithoutGoal != null)
                    Console.WriteLine($"{catWithoutGoal.Id} | {catWithoutGoal.GoalType} | {catWithoutGoal.GoalTargetMonth}");
                else
                    await Console.Out.WriteLineAsync("No category without goals!");

                Console.WriteLine("Getting scheduled transactions...");
                var scheduledTransactionsResponse = await api.GetScheduledTransactions(budget.Id);
                var scheduledTransactions = scheduledTransactionsResponse.Data.ScheduledTransactions.Where(x => !x.Deleted).ToList();
                Console.WriteLine($"Found {scheduledTransactions.Count} scheduled transactions!");
                Console.WriteLine();

                scheduledTransactions.ToList().ForEach(x => Console.WriteLine($"{x.Id} | {x.PayeeId} | {x.CategoryId} | {x.Amount.YnabLongToDecimal():C2} | {x.FlagColor}"));
            }
            catch (ApiException apiEx)
            {
                Console.WriteLine("Error: " + apiEx.Content);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            Console.WriteLine();
            Console.WriteLine("Press Enter to exit ...");
            Console.ReadLine();
        }

        private static async Task<string> GetAccessToken()
        {
            string apiToken = null;

            if (File.Exists(ACCESS_TOKEN_FILE))
            {
                apiToken = await File.ReadAllTextAsync(ACCESS_TOKEN_FILE);
                apiToken = apiToken.Trim();
            }
            else
            {
                Console.Write("YNAB API Access Token: ");
                apiToken = Console.ReadLine();
            }

            return apiToken;
        }
    }
}
