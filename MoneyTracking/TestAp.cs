namespace MoneyTracking
{
    internal class TestAp
    {
        private bool doItAgain = true;
          private Bank bankCustomers = Bank.Instance;
          private Menu menu = new Menu();
          

        public void Run()
        {
            do
            {
                menu.ClearList();
                menu.SetTitleMenu("Menu");
                menu.AddItem("Quit.", true);
                menu.AddItem("Load customer from file.", true);
                menu.AddItem("Create new Customer.", true);
                menu.PrintMenuItems();
                Console.WriteLine("Enter your choice: ");

                switch (GetMenuChoice())
                {
                    case 2:
                        {
                            LoadCustomerFromFile();
                            break;
                        }
                    case 3:
                        {
                            DischargeData();
                            if (CreateCustomer())
                            {
                                GetMenuOption();
                            }
                            break;
                        }
                    case 1:
                        {
                            doItAgain = false;
                            break;
                        }
                }
            } while (doItAgain);
        }

        public int GetMenuChoice()
        {
            int userChoice;
            while (!int.TryParse(Console.ReadLine(), out userChoice) || userChoice < 0)
            {
                Console.WriteLine("Invalid Value! Enter from the list");
            }
            return userChoice;
        }

        public void CreateAccount()
        {
            decimal xBalance, xCredit = 0;
            int xSize;
            string typAcc;
            bool done = false;

            xSize = bankCustomers.GetNumOfAccounts();
            if (xSize == 3)
            {
                Console.WriteLine("You already have the maximum number of accounts!");
            }
            else
            {
                Console.WriteLine("Which Type of account do you want!(choose number of Account 1-3)");
                Console.WriteLine("1 - Transaction account.");
                Console.WriteLine("2 - Savings account.");
                Console.WriteLine("3 - Longterm savings account.");
                int varCh = GetMenuChoice();

                switch (varCh)
                {
                    case 1:
                        {
                            typAcc = "Transaction account";
                            break;
                        }
                    case 2:
                        {
                            typAcc = "Savings account";
                            break;
                        }
                    case 3:
                        {
                            typAcc = "Longterm savings account";
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Invalid choice");
                            return;
                        }
                }

                Console.WriteLine("Input Balance: ");
                xBalance = decimal.Parse(Console.ReadLine());

                if (varCh == 1)
                {
                    Console.WriteLine("Input Credit: ");
                    xCredit = decimal.Parse(Console.ReadLine());
                }
                else
                {
                    xCredit = 0;
                }

                done = bankCustomers.CreateNewAccount(xBalance, xCredit, typAcc);
            }

            if (done)
            {
                Console.WriteLine("The Account Added.");
            }
            else
            {
                Console.WriteLine("Sorry, The account was not added.");
            }
        }

        public bool CreateCustomer()
        {
            string perNr, perName;
            bool vResult;

            Console.WriteLine("Input the Person's Number: ");
            perNr = Console.ReadLine();
            Console.WriteLine("Input the Person's Name: ");
            perName = Console.ReadLine();

            vResult = bankCustomers.CreateNewCustomer(perNr, perName);
            if (vResult)
            {
                Console.WriteLine("The Person Added.");
                Console.ReadLine(); // To pause after displaying the message
                GetMenuOption();
            }
            else
            {
                Console.WriteLine("Sorry, The Person was not added.");
            }
            return vResult;
        }

        public void LoadCustomerFromFile()
        {
            string perNr;
            bool readIt;

            Console.WriteLine("Input the Person Number: ");
            perNr = Console.ReadLine();
            readIt = bankCustomers.LoadFromFile(perNr);
            if (readIt)
            {
                Console.WriteLine("Uploading has been done.");
            }
            else
            {
                Console.WriteLine("Sorry, Not Exist in DB!");
            }
            GetMenuOption();
        }

        public void GetCustomerName()
        {
            Console.WriteLine("Customer name is " + bankCustomers.GetName());
        }

        public void GetCustomerNumber()
        {
            Console.WriteLine("Customer number is " + bankCustomers.GetCustomerNr());
        }

        public void NumberOfAccounts()
        {
            Console.WriteLine("Customer has " + bankCustomers.GetNumOfAccounts() + " Accounts.");
        }

        public void AccountsNrs()
        {
            Console.WriteLine("Your Account numbers are:");
            Console.WriteLine(bankCustomers.PrintAccountNumbers());
        }

        public void GetTotalAsset()
        {
            Console.WriteLine("Your Total assets are: " + bankCustomers.GetTotalAssets() + ".");
        }

        public void AccountInform()
        {
            string userAccount;
            bool checkNum;

            Console.WriteLine("Your Account(s):");
            Console.WriteLine(bankCustomers.PrintAccountNumbers());

            Console.WriteLine("Which account do you want information for?");
            userAccount = Console.ReadLine();
            checkNum = bankCustomers.CheckListAccount(userAccount);
            if (checkNum)
            {
                Console.WriteLine(bankCustomers.getAccountInfo(userAccount));
            }
            else
            {
                Console.WriteLine("Sorry, Account number is not correct.");
            }
        }

        public void DoWithdraw()
        {
            string uAccount;
            int amounts;

            Console.WriteLine("Your Account(s):");
            Console.WriteLine(bankCustomers.PrintAccountNumbers());

            Console.WriteLine("Which account do you want to withdraw from?");
            uAccount = Console.ReadLine();

            Console.WriteLine("Amount to withdraw?");
            amounts = int.Parse(Console.ReadLine());

            bool doneWith = bankCustomers.Withdrawal(uAccount, amounts);
            if (doneWith)
            {
                Console.WriteLine(amounts + " had been withdrawn from your account.");
            }
            else
            {
                Console.WriteLine("Sorry, there is an error. The operation did not complete.");
            }
        }

        public void DoDeposit()
        {
            string userAccount;
            int amounts;

            Console.WriteLine("Your Account(s):");
            Console.WriteLine(bankCustomers.PrintAccountNumbers());

            Console.WriteLine("Which account do you want to deposit into?");
            userAccount = Console.ReadLine();

            Console.WriteLine("Amount to deposit?");
            amounts = int.Parse(Console.ReadLine());

            bool done = bankCustomers.Deposit(userAccount, amounts);
            if (done)
            {
                Console.WriteLine(amounts + " had been deposited into your account.");
            }
            else
            {
                Console.WriteLine("Sorry, there is an error. The operation did not complete.");
            }
        }

        public void NewCredit()
        {
            string usAccount;
            int amounts;

            Console.WriteLine("Your Account(s):");
            Console.WriteLine(bankCustomers.PrintAccountNumbers());

            Console.WriteLine("Which account do you want to change credit for?");
            usAccount = Console.ReadLine();

            Console.WriteLine("What is the new credit amount?");
            amounts = int.Parse(Console.ReadLine());

            bool doneIT = bankCustomers.NewCredit(usAccount, amounts);
            if (doneIT)
            {
                Console.WriteLine(amounts + " The credit has been changed.");
            }
            else
            {
                Console.WriteLine("Sorry, there is an error. The operation did not complete.");
            }
        }

        public void AccountsSummery()
        {
            Console.WriteLine(bankCustomers.AccountSummary());
        }

        public void DeleteAccount()
        {
            string userAccount;

            Console.WriteLine("Your Account(s):");
            Console.WriteLine(bankCustomers.PrintAccountNumbers());

            Console.WriteLine("Enter the account number you want to delete:");
            userAccount = Console.ReadLine();

            bool aco = bankCustomers.DeleteAccount(userAccount);
            if (aco)
            {
                Console.WriteLine("The Account has been deleted.");
            }
            else
            {
                Console.WriteLine("Sorry, there is an error.");
            }
        }

        public void DischargeData()
        {
            bankCustomers.DischargeCustomer();
        }

        public void ShowMenu()
        {
            menu.ClearList();
            menu.SetTitleMenu("Customer Account Menu");
            menu.AddItem("Exit", true);
            menu.AddItem("Change customer.", true);
            menu.AddItem("Create new account.", true);
            menu.AddItem("Customer name.", true);
            menu.AddItem("Customer number", true);
            menu.AddItem("Number of accounts", true);
            menu.AddItem("Account Numbers.", true);
            menu.AddItem("Total assets.", true);
            menu.AddItem("Account info.", true);
            menu.AddItem("Withdraw.", true);
            menu.AddItem("Deposit.", true);
            menu.AddItem("Set credit.", true);
            menu.AddItem("Accounts summery.", true);
            menu.AddItem("Delete account.", true);
            menu.PrintMenuItems();
        }

        public void GetMenuOption()
        {
            do
            {
                ShowMenu();
                Console.WriteLine("Enter your choice: ");

                switch (GetMenuChoice())
                {
                    case 2:
                        {
                            bankCustomers.WriteToFile();
                            DischargeData();
                            Run();
                            Console.ReadLine();
                            break;
                        }
                    case 3:
                        {
                            CreateAccount();
                            Console.ReadLine();
                            break;
                        }
                    case 4:
                        {
                            GetCustomerName();
                            Console.ReadLine();
                            break;
                        }
                    case 5:
                        {
                            GetCustomerNumber();
                            Console.ReadLine();
                            break;
                        }
                    case 6:
                        {
                            NumberOfAccounts();
                            Console.ReadLine();
                            break;
                        }
                    case 7:
                        {
                            AccountsNrs();
                            Console.ReadLine();
                            break;
                        }
                    case 8:
                        {
                            GetTotalAsset();
                            Console.ReadLine();
                            break;
                        }
                    case 9:
                        {
                            AccountInform();
                            Console.ReadLine();
                            break;
                        }
                    case 10:
                        {
                            DoWithdraw();
                            Console.ReadLine();
                            break;
                        }
                    case 11:
                        {
                            DoDeposit();
                            Console.ReadLine();
                            break;
                        }
                    case 12:
                        {
                            NewCredit();
                            Console.ReadLine();
                            break;
                        }
                    case 13:
                        {
                            AccountsSummery();
                            Console.ReadLine();
                            break;
                        }
                    case 14:
                        {
                            DeleteAccount();
                            Console.ReadLine();
                            break;
                        }
                    case 1:
                        {
                            bankCustomers.WriteToFile();
                            doItAgain = false;
                            break;
                        }
                }
            } while (doItAgain);
        }

    }
}