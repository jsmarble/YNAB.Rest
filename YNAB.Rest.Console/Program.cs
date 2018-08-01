using Refit;
using System;
using System.IO;
using System.Linq;
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
                string token = await GetAccessToken();

                var api = ApiClient.Create(token);
                var budgetsResponse = await api.GetBudgets();
                var budgets = budgetsResponse.Data.Budgets;

                if (budgets.Count == 0)
                    throw new InvalidOperationException("No budgets found!");

                Console.WriteLine($"Found {budgets.Count} budgets!");
                Console.WriteLine();

                budgets.ToList().ForEach(b => Console.WriteLine(b.Name));
                Console.WriteLine();

                var budget = budgets.OrderByDescending(x => x.LastModifiedOn).FirstOrDefault();
                Console.WriteLine($"Reading budget {budget.Name}");
                Console.WriteLine();

                var accountsResponse = await api.GetAccounts(budget.Id);
                var accounts = accountsResponse.Data.Accounts;
                Console.WriteLine($"Found {accounts.Count} accounts!");
                Console.WriteLine();

                var account = accounts.OrderByDescending(x => x.Balance).FirstOrDefault();
                Console.WriteLine($"Reading account {account.Name} with balance {account.Balance.YnabIntToDecimal()}");
                Console.WriteLine();

                var transactionsResponse = await api.GetTransactionsByAccount(budget.Id, account.Id);
                var transactions = transactionsResponse.Data.Transactions;
                Console.WriteLine($"Found {transactions.Count} transactions!");
                Console.WriteLine();

                transactions.ToList().ForEach(x => Console.WriteLine($"{x.PayeeName} | {x.CategoryName} | {x.Memo} | {x.Amount.YnabIntToDecimal():C2} | {x.FlagColor}"));
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
