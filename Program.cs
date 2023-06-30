namespace ATM_Simulation_App
{
    internal class Program
    {
       
        static void Main(string[] args)
        {
            ATM atm = new ATM();
            atm.RegisterAccount();
            MakeTransaction(atm);
            Console.ReadKey();

        }
        public static void MakeTransaction(ATM aTM)
        {
            //ATM aTM = new ATM();
            // Asking user for card number
            Console.WriteLine("Please enter your Card Number");
            int cardNumber = Convert.ToInt32(Console.ReadLine());

            // Asking user for pin
            Console.WriteLine("Please enter your Pin");
            string pin = ReadMaskedInput();
            //int pin = Convert.ToInt32(Console.ReadLine());
            // Accepting the amount to be withdrawn from the user

            if (aTM.VerifyCard(cardNumber))
            {
                if (aTM.VerifyPIN(cardNumber, pin))
                {
                    // Positive verification
                    Console.WriteLine("PIN verified. Please select an option:");
                    Console.WriteLine("1. Check cash availability");
                    Console.WriteLine("2. View previous transactions");
                    Console.WriteLine("3. Withdraw cash (Fast)");
                    Console.WriteLine("4. Withdraw cash (Custom)");
                    int option = Convert.ToInt32(Console.ReadLine());

                    switch (option)
                    {
                        case 1:
                            // Check cash availability logic
                            aTM.CheckBalance(cardNumber);
                            break;
                        case 2:
                            // View previous transactions logic
                            aTM.PrintBankStatement(cardNumber);
                            break;
                        case 3:
                            // Check if transaction limit is not exceeded
                            aTM.CheckTheNumberOfTransaction(cardNumber);

                            // Accepting the amount to be withdrawn from the user
                            Console.WriteLine("Please enter the Amount to Withdraw");
                            decimal withdrawalAmount = Convert.ToDecimal(Console.ReadLine()); ;
                            Withdrawal fastWithdrawal = new FastWithdrawal(withdrawalAmount);
                            aTM.WithdrawCash(cardNumber, withdrawalAmount, fastWithdrawal);
                            break;
                        case 4:
                            // Check if transaction limit is not exceeded
                            aTM.CheckTheNumberOfTransaction(cardNumber);

                            Console.WriteLine("Please enter the Amount to Withdraw");
                            withdrawalAmount = Convert.ToDecimal(Console.ReadLine()); ;
                            Withdrawal customWithdrawal = new CustomWithdrawal(withdrawalAmount);

                            aTM.WithdrawCash(cardNumber, withdrawalAmount, customWithdrawal);
                            break;
                        default:
                            Console.WriteLine("Invalid option.");
                            break;

                    }
                    
                }
                else
                {
                    // Negative verification
                    Console.WriteLine("Invalid PIN.");
                }
            }
            else
            {
                Console.WriteLine("Invalid card number.");
            }

            RepeatTransaction(cardNumber, aTM);
        }

        //repeat transaction
        public static void RepeatTransaction(int cardNumber, ATM aTM)
        {
            // Taking another action
            Console.WriteLine("Please select an option:");
            Console.WriteLine("1. Perform Another Transaction");
            Console.WriteLine("2. End Trasaction");
           int option = Convert.ToInt32(Console.ReadLine());

            switch (option)
            {
                case 1:
                    // Asking user for pin
                    Console.WriteLine("Please enter your Pin");
                   string pin = ReadMaskedInput();
                    if (aTM.VerifyPIN(cardNumber, pin))
                    {
                        // Positive verification
                        Console.WriteLine("PIN verified. Please select an option:");
                        Console.WriteLine("1. Check cash availability");
                        Console.WriteLine("2. View previous transactions");
                        Console.WriteLine("3. Withdraw cash (Fast)");
                        Console.WriteLine("4. Withdraw cash (Custom)");
                        option = Convert.ToInt32(Console.ReadLine());
                        decimal withdrawalAmount = 0;
                        switch (option)
                        {
                            case 1:
                                // Check cash availability logic
                                aTM.CheckBalance(cardNumber);
                                break;
                            case 2:
                                // View previous transactions logic
                                aTM.PrintBankStatement(cardNumber);
                                break;
                            case 3:
                                // Check if transaction limit is not exceeded
                                if (aTM.CheckTheNumberOfTransaction(cardNumber))
                                {
                                    // Accepting the amount to be withdrawn from the user
                                    Console.WriteLine("Please enter the Amount to Withdraw");
                                    withdrawalAmount = Convert.ToDecimal(Console.ReadLine()); ;
                                    Withdrawal fastWithdrawal = new FastWithdrawal(withdrawalAmount);
                                    aTM.WithdrawCash(cardNumber, withdrawalAmount, fastWithdrawal);

                                }
                                else
                                {
                                    Console.WriteLine("Sorry you have exceeded your transaction limit for the today");

                                }

                                break;
                            case 4:
                                // Check if transaction limit is not exceeded
                                if (aTM.CheckTheNumberOfTransaction(cardNumber))
                                {
                                    Console.WriteLine("Please enter the Amount to Withdraw");
                                    withdrawalAmount = Convert.ToDecimal(Console.ReadLine()); ;
                                    Withdrawal customWithdrawal = new CustomWithdrawal(withdrawalAmount);

                                    aTM.WithdrawCash(cardNumber, withdrawalAmount, customWithdrawal);
                                }
                                else
                                {
                                    Console.WriteLine("Sorry you have exceeded your transaction limit for the today");

                                }
                                break;
                            default:
                                Console.WriteLine("Invalid option.");
                                break;

                        }
                    }
                    RepeatTransaction(cardNumber,aTM);

                    break;
                case 2:
                    // end transactions 
                    Console.WriteLine("Thanks for doing Business with us.");
                    break;

                default:
                    Console.WriteLine("Invalid option.");
                    break;
            }
        }
       public static string ReadMaskedInput()
        {
            string input = string.Empty;
            ConsoleKeyInfo keyInfo;

            do
            {
                keyInfo = Console.ReadKey(true);
                // Ignore non-character keys such as Enter or Backspace
                if (keyInfo.Key != ConsoleKey.Enter && keyInfo.Key != ConsoleKey.Backspace)
                {
                    // Append the character to the input string
                    input += keyInfo.KeyChar;

                    // Display a masked character (e.g., asterisk) instead of the actual character
                    Console.Write("*");
                }
                else if (keyInfo.Key == ConsoleKey.Backspace && input.Length > 0)
                {
                    // Remove the last character from the input string and console
                    input = input.Remove(input.Length - 1);
                    Console.Write("\b \b");
                }

            } while (keyInfo.Key != ConsoleKey.Enter);

            Console.WriteLine(); // Move to the next line after Enter is pressed
            return input;
        }

    }
}