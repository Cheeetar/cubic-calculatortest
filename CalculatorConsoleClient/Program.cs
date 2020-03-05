using CalculatorTest.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Repository.CalculatorConsoleClient;
using System;

namespace CalculatorConsoleClient
{
    class Program
    {
        private static readonly InMemoryDatabaseRoot _InMemoryDatabaseRoot = new InMemoryDatabaseRoot();
        private const string FIRST_INPUT_PROMPT = "Please input the first number.";
        private static readonly CalculatorWebClient _CalculatorWebClient = new CalculatorWebClient();

        private static ConsoleDiagnosticsContext SetupDatabase()
        {
            var dbContextOptions = new DbContextOptionsBuilder<ConsoleDiagnosticsContext>()
                .UseInMemoryDatabase(databaseName: "ConsoleClientLogs", databaseRoot: _InMemoryDatabaseRoot)
                .Options;
            return new ConsoleDiagnosticsContext(dbContextOptions);
        }

        static void Main(string[] args)
        {
            using (var diagnosticsContext = SetupDatabase())
            {
                var logger = new EFLogger(diagnosticsContext);
                Console.WriteLine("Welcome to Calculator World!");
                while (true)
                {
                    Console.WriteLine();
                    PrintMainMenu();
                    var input = Console.ReadKey().KeyChar;
                    Console.WriteLine();
                    SelectOption(input, logger, out bool quitting);
                    if (quitting)
                    {
                        Console.WriteLine("Thank you for visiting Calculator World!");
                        Console.WriteLine("Press the any key to exit!");
                        Console.ReadKey();
                        return;
                    }
                }
            }
        }

        private static void PrintMainMenu()
        {
            Console.WriteLine("Please select an operation:");
            Console.WriteLine("Add: 0");
            Console.WriteLine("Subtract: 1");
            Console.WriteLine("Multiply: 2");
            Console.WriteLine("Divide: 3");
            Console.WriteLine("Quit: 4");
        }

        private static void SelectOption(char selection, IDiagnostics diagnosticsLogger, out bool quitting)
        {
            quitting = false;
            switch (selection)
            {
                case '0':
                    diagnosticsLogger.LogIntResult(Add());
                    break;
                case '1':
                    diagnosticsLogger.LogIntResult(Subtract());
                    break;
                case '2':
                    diagnosticsLogger.LogIntResult(Multiply());
                    break;
                case '3':
                    diagnosticsLogger.LogIntResult(Divide());
                    break;
                case '4':
                    quitting = true;
                    break;
                default:
                    Console.WriteLine("That was an invalid selection!");
                    Console.WriteLine("CTRL+C to exit if you are stuck!");
                    break;
            }
        }

        private static int Add()
        {
            var left = GetIntInput(FIRST_INPUT_PROMPT);
            var right = GetIntInput("Please input the number to add to the first number.");
            return _CalculatorWebClient.Add(left, right);
        }

        private static int Subtract()
        {
            var left = GetIntInput(FIRST_INPUT_PROMPT);
            var right = GetIntInput("Please input the number to subtract from the first number.");
            return left - right;
        }

        private static int Multiply()
        {
            var left = GetIntInput(FIRST_INPUT_PROMPT);
            var right = GetIntInput("Please input the number to multiply the first number by.");
            return left * right;
        }

        private static int Divide()
        {
            var left = GetIntInput(FIRST_INPUT_PROMPT);
            var right = GetIntInput("Please input the number to divide the first number by.");
            return left / right;
        }

        private static int GetIntInput(string prompt)
        {
            while (true)
            {
                Console.WriteLine(prompt);
                var result = Console.ReadLine();
                if (int.TryParse(result, out var input))
                {
                    return input;
                }
                else
                {
                    Console.WriteLine("Error! Must be an integer input.");
                }
            }
        }
    }
}
