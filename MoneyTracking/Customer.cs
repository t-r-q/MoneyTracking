using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyTracking
{
    public class Customer
    {
        private List<Account> arrAccount = new List<Account>();
        protected string customID;
        protected string customName;

        protected Customer(string cstmId, string cstmName)
        {
            customID = cstmId;
            customName = cstmName;
        }

        public string GetCstmName() { return customName; }
        public string GetCstmId() { return customID; }


        public bool checkArrAccount(string eAb)
        {
            return arrAccount.Any(account => eAb == account.getAccountNum());
        }

        public bool setNewAccount(string nr, float bal, float cred, string typ)
        {
            string nrAccount = ""; // Account number
            string typeAccount; // Account type
            Account newAcc;
            string ch;
            int sizeArr = arrAccount.Count; // size of array

            if (arrAccount.Count == 0)
            {
                nrAccount = nr + "-0";
            }
            else
            {
                for (int i = 0; i < sizeArr; ++i)
                {

                    string nr_per = arrAccount[i].getAccountNum();
                    string st = i.ToString(); // change integer to string
                    ch = nr_per.Last().ToString(); // get last item from string
                    if (ch != st)
                    {
                        nrAccount = nr + "-" + st;
                        break;
                    }
                    else
                    {
                        st = Convert.ToString(i + 1); // change integer to string
                        nrAccount = nr + "-" + st;
                    }
                }
            }

            if (typ == "Transaction account")
            {
                newAcc = new TransactionAccount(nrAccount, bal, cred);
            }
            else if (typ == "Longterm savings account")
            {
                newAcc = new LongSavingsAccount(nrAccount, bal, ((int)cred));
            }
            else
            {
                newAcc = new SavingsAccount(nrAccount, bal, ((int)cred));
            }

            arrAccount.Add(newAcc);
            return true;
        }

        public int getNumAccountsOfCustomer()
        {
            return arrAccount.Count;
        }

        public string getAccountInfo(string num)
        {
            string infoAc = string.Empty;
            foreach (var xAccount in arrAccount)
            {
                if (num == xAccount.getAccountNum())
                {
                    infoAc = xAccount.print();
                }
            }

            return infoAc;
        }

        public int getTotalAssets()
        {
            int totalAssets = 0;
            foreach (var element in arrAccount)
            {
                totalAssets += (int)element.getBalance();
            }
            return totalAssets;
        }

        public Customer createNewCustomer(string cID, string cName)
        {
            return new Customer(cID, cName);
        }

        public bool quitAccount(string nurRow)
        {
            var account = arrAccount.FirstOrDefault(account => account.getAccountNum() == nurRow);
            if (account != null)
            {
                arrAccount.Remove(account);
                return true;
            }
            return false;
        }

        public bool withdrawFromAccount(string acountNum, float amount)
        {
            var account = arrAccount.FirstOrDefault(account => account.getAccountNum() == acountNum);
            if (account != null)
            {
                if (account.hasCredit())
                {
                    account.withdrawB(amount);
                    return true;
                }
                else if (account.getNrOfWithdrawals() < account.getMaxWithdrawals())
                {
                    account.withdrawB(amount);
                    return true;
                }
            }
            return false;
        }

        public bool depositAmountToAccount(string acountNum, float amount)
        {
            var account = arrAccount.FirstOrDefault(account => account.getAccountNum() == acountNum);
            if (account != null)
            {
                account.depositInB(amount);
                return true;
            }
            return false;
        }

        public bool changeCreditLimit(string acountNum, float newCredit)
        {
            var account = arrAccount.FirstOrDefault(account => account.getAccountNum() == acountNum && account.getAccountType() == "Transaction account");
            if (account != null)
            {
                account.changeGrantedCredit(newCredit);
                return true;
            }
            return false;
        }

        public string AccountsSummary()
        {
            StringBuilder summeryAccounts = new StringBuilder();
            int balances = 0, credits = 0;

            foreach (var element in arrAccount)
            {
                summeryAccounts.Append(element.print());
                balances += (int)element.getBalance();
                if (element.hasCredit())
                {
                    credits = (int)element.getCurrentCredit();
                }
            }
            summeryAccounts.Append(" ... Total ... \n");
            summeryAccounts.Append("Balance: " + balances + "\n");
            summeryAccounts.Append("Credit: " + credits + "\n");
            summeryAccounts.Append("Disposable: " + (balances + credits) + "\n");
            summeryAccounts.Append(" ------------------------------------ \n");
            return summeryAccounts.ToString();
        }

        public string printAccountNr()
        {
            StringBuilder accountsNr = new StringBuilder();
            foreach (var nr in arrAccount)
            {
                accountsNr.Append(nr.getAccountNum() + "\n");
            }
            return accountsNr.ToString();
        }

        public static Customer loadFromFile(string id)
        {
            string tmpAcNr, nm, cId, sTyp; // Customer cus;
            float tmpBalance; int tmpCredit;
            Customer customer = new Customer("", "");
            string path = "../db/" + id + ".knt";
            // string path = Path.GetFullPath(pat);
            if (File.Exists(path))
            {
                using (StreamReader inFile = new StreamReader(path))
            {
                nm = inFile.ReadLine();
                cId = inFile.ReadLine();
                while ((tmpAcNr = inFile.ReadLine()) != null)
                {
                    sTyp = inFile.ReadLine();
                    tmpBalance = float.Parse(inFile.ReadLine());
                    tmpCredit = int.Parse(inFile.ReadLine());

                    customer.customName = nm;
                    customer.customID = cId;

                    if (sTyp == "Transaction account")
                    {
                        customer.arrAccount.Add(new TransactionAccount(tmpAcNr, tmpBalance, tmpCredit));
                    }
                    else if (sTyp == "Longterm savings account")
                    {
                        customer.arrAccount.Add(new LongSavingsAccount(tmpAcNr, tmpBalance, tmpCredit));
                    }
                    else
                    {
                        customer.arrAccount.Add(new SavingsAccount(tmpAcNr, tmpBalance, tmpCredit));
                    }
                }
            }
        }
            return customer;
        }

        public void saveToFile()
        {
            string path = "../db/";

            using (StreamWriter outFile = new StreamWriter(path + customID + ".knt"))
            {
                outFile.WriteLine(customName);
                outFile.WriteLine(customID);

                foreach (var acoCus in arrAccount)
                {
                    if (acoCus.hasCredit())
                    {
                        outFile.WriteLine(acoCus.getAccountNum());
                        outFile.WriteLine(acoCus.getAccountType());
                        outFile.WriteLine(acoCus.getBalance());
                        outFile.WriteLine(acoCus.getCurrentCredit());
                    }
                    else
                    {
                        outFile.WriteLine(acoCus.getAccountNum());
                        outFile.WriteLine(acoCus.getAccountType());
                        outFile.WriteLine(acoCus.getBalance());
                        outFile.WriteLine(acoCus.getNrOfWithdrawals());
                    }
                }
            }
        }
    }
}
