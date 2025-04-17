using System;
using System.Threading;

namespace CalculusCalculator
/*
 * NOTE:
 * This program can only answer Limits and Derivatives
 * I am not going to code other topics like Integrals, Series, etc.
 * Because I suck at calculus
 * Hope you enjoy this program
 */
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Calculus Calculator";

            while (true)
            {
                DisplayHeader();
                ShowMainMenu();
                ProcessMenuChoice();

                Console.WriteLine("\nPress any key to continue or ESC to exit...");
                if (Console.ReadKey(true).Key == ConsoleKey.Escape)
                {
                    PlaySuccessSound();
                    Console.Clear();
                    Console.WriteLine("\nThank you for using the Calculus Calculator!");
                    Console.WriteLine("Hope you passed on the finals\n");
                    Console.WriteLine("Made by _Bunccep");
                    Thread.Sleep(1500);
                    break;
                }
                Console.Clear();
            }
        }

        static void DisplayHeader()
        {
            Console.ResetColor();
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(@"CALCULUS SUCKS CALCULUS SUCKS CALCULUS SUCKS CALCULUS SUCKS CALCULUS SUCKS");
            Console.WriteLine(@"CALCULUS SUCKS CALCULUS SUCKS CALCULUS SUCKS CALCULUS SUCKS CALCULUS SUCKS");
            Console.WriteLine(@"CALCULUS SUCKS CALCULUS SUCKS CALCULUS SUCKS CALCULUS SUCKS CALCULUS SUCKS");
            Console.WriteLine(@"CALCULUS SUCKS CALCULUS SUCKS CALCULUS SUCKS CALCULUS SUCKS CALCULUS SUCKS");
            Console.WriteLine(@"CALCULUS SUCKS CALCULUS SUCKS CALCULUS SUCKS CALCULUS SUCKS CALCULUS SUCKS");
            Console.WriteLine(@"CALCULUS SUCKS CALCULUS SUCKS CALCULUS SUCKS CALCULUS SUCKS CALCULUS SUCKS");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("Welcome to the Calculus Calculator!");
            Console.WriteLine("===================================\n");
            Console.ResetColor();
        }

        static void ShowMainMenu()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Please select an operation:");
            Console.WriteLine("<><><><><><><><><><><><><>");
            Console.WriteLine("1. Calculate Limit");
            Console.WriteLine("2. Calculate Derivative");
            Console.WriteLine("3. Exit");
            Console.WriteLine();
            Console.Write("Enter your topic (1-3): ");
            Console.ResetColor();
        }

        static void ProcessMenuChoice()
        {
            PlayInteractionSound();

            if (!int.TryParse(Console.ReadLine(), out int choice) || choice < 1 || choice > 3)
            {
                PlayErrorSound();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nThat thing don't even exist. Please try again.");
                Console.ResetColor();
                Thread.Sleep(1000);
                return;
            }

            switch (choice)
            {
                case 1:
                    CalculateLimit();
                    break;
                case 2:
                    CalculateDerivative();
                    break;
                case 3:
                    Environment.Exit(0);
                    break;
            }
        }

        static void CalculateLimit()
        {
            Console.Clear();
            DisplayHeader();

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Limit Calculation");
            Console.WriteLine("><><><><><><><><>\n");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("Enter the function");
            Console.WriteLine("Using 'x' as a variable");
            Console.WriteLine("ex. |(x^2 - 1)/(x - 1) ");
            string function = Console.ReadLine();

            Console.Write("Enter the value x approaches (ex.| 1, inf, -inf): ");
            string approachValue = Console.ReadLine();

            PlayProcessingSound();

            // Simulate calculation
            Thread.Sleep(1500);

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Calculating: lim(x→{0}) {1}", approachValue, function);

            string result = SolveLimit(function, approachValue);

            Console.WriteLine("Result: " + result);
            Console.ResetColor();

            PlaySuccessSound();
        }

        static void CalculateDerivative()
        {
            Console.Clear();
            DisplayHeader();

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Derivative Calculation");
            Console.WriteLine("><><><><><><><><><><><>\n");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("Enter the function");
            Console.WriteLine("Using 'x' as a variable");
            Console.WriteLine("ex. |x^2 + 3x + 2): ");
            string function = Console.ReadLine();

            Console.Write("Enter the order of derivative (1 for first derivative, 2 for second, etc.): ");
            if (!int.TryParse(Console.ReadLine(), out int order) || order < 1)
            {
                PlayErrorSound();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nInvalid order! Please enter a positive integer.");
                Console.ResetColor();
                Thread.Sleep(1500);
                return;
            }

            PlayProcessingSound();

            // Simulate calculation
            Thread.Sleep(1500);

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Calculating: d{0}/{1}x{0} ({2})", order == 1 ? "" : "^" + order, order, function);

            // This is a simplified example - a real implementation would need a proper parser
            string result = SolveDerivative(function, order);

            Console.WriteLine("Result: " + result);
            Console.ResetColor();

            PlaySuccessSound();
        }

        static string SolveLimit(string function, string approachValue)
        {
            // a proper expression parser and limit solver

            try
            {
                // Some common limits
                if (function.Contains("sin(x)/x") && approachValue == "0")
                    return "1";

                if (function.Contains("(x^2 - 1)/(x - 1)") && approachValue == "1")
                    return "2";

                if (approachValue == "inf" || approachValue == "-inf")
                {
                    if (function.Contains("1/x"))
                        return "0";

                    if (function.Contains("x^"))
                        return approachValue;
                }

                // Try direct substitution
                if (double.TryParse(approachValue, out double a))
                {
                    // This is just for demonstration - don't actually evaluate like this
                    function = function.Replace("x", approachValue);

                    // simplified evaluation
                    if (function.Contains("/0") && !function.Contains("0/0"))
                        return approachValue == "0" ? "∞" : "Undefined (division by zero duhhh)";

                    return EvaluateSimpleExpression(function);
                }

                return "Could not determine limit automatically. sabihin kay prof.";
            }
            catch
            {
                return "Could not determine limit automatically. sumbong kay batman.";
            }
        }

        static string SolveDerivative(string function, int order)
        {
            // only simplified version - a real implementation would need
            // a proper expression parser and derivative solver
            /*
             * I did google because I don't know how to calculate these
             */

            try
            {
                string result = function;

                for (int i = 0; i < order; i++)
                {
                    result = ComputeSimpleDerivative(result);
                }

                return SimplifyExpression(result);
            }
            catch
            {
                return "Could not compute derivative automatically. Go get a job.";
            }
        }

        static string ComputeSimpleDerivative(string function)
        {
            // just handle power rules
            if (function.Contains("x^"))
            {
                int caretPos = function.IndexOf('^');
                if (int.TryParse(function.Substring(caretPos + 1), out int power))
                {
                    return $"{power}x^{power - 1}";
                }
            }

            // for the simple cases
            if (function == "x") return "1";
            if (function == "sin(x)") return "cos(x)";
            if (function == "cos(x)") return "-sin(x)";
            if (function == "e^x") return "e^x";
            if (function == "ln(x)") return "1/x";

            // Default response for unsupported functions
            return $"(derivative of {function})";
        }

        static string SimplifyExpression(string expr)
        {
            // simplification for demonstration
            if (expr == "1x^0") return "1";
            if (expr == "1x^1") return "x";
            return expr;
        }

        static string EvaluateSimpleExpression(string expr)
        {
            // Use a proper expression evaluator
            // imitate like a proper solver

            if (expr.Contains("^"))
            {
                var parts = expr.Split('^');
                if (double.TryParse(parts[0], out double b) && double.TryParse(parts[1], out double e))
                {
                    return Math.Pow(b, e).ToString();
                }
            }

            if (expr.Contains("*"))
            {
                var parts = expr.Split('*');
                if (double.TryParse(parts[0], out double a) && double.TryParse(parts[1], out double b))
                {
                    return (a * b).ToString();
                }
            }

            if (expr.Contains("+"))
            {
                var parts = expr.Split('+');
                if (double.TryParse(parts[0], out double a) && double.TryParse(parts[1], out double b))
                {
                    return (a + b).ToString();
                }
            }

            return expr; // Return as-is if we can't evaluate
        }

        // for sound effects cuz I'm too lazy to import MP3s
        static void PlayInteractionSound()
        {
            Console.Beep(800, 100);
        }

        static void PlayProcessingSound()
        {
            Console.Beep(600, 100);
            Console.Beep(700, 100);
        }

        static void PlaySuccessSound()
        {
            Console.Beep(1000, 150);
            Console.Beep(1200, 150);
        }

        static void PlayErrorSound()
        {
            Console.Beep(300, 300);
            Console.Beep(200, 300);
        }
    }
}
