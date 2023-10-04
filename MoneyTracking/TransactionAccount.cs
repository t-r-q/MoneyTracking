using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyTracking
{
    public class TransactionAccount : Account
    {
        private float t_Balance;
        private float t_Credit;

        public TransactionAccount()
        {
        }

        public TransactionAccount(string acntNR, float crnt_Blnc, float credit = 0) : base(acntNR)
        {
            t_Balance = crnt_Blnc;
            t_Credit = credit;
        }

        public override void depositInB(float currBalance)
        {
            t_Balance += currBalance;
        }

        public override bool withdrawB(float drawn)
        {
            bool done = false;
            float cd = getUseableAmount();
            if (cd >= drawn)
            {
                t_Balance -= drawn;
                done = true;
            }
            return done;
        }

        public override string getAccountType()
        {
            return "Transaction account";
        }

        public override double getInterest()
        {
            // Return interest for transaction accounts (you can adjust this logic if needed)
            return 0;
        }

        public override string print()
        {
            string DELIM = "\n";
            string showResult = "";

            showResult += "Account Type: " + getAccountType() + DELIM;
            // showResult += "Account Number: " + getAccountNum() + DELIM;
            showResult += "Balance: " + (int)t_Balance + DELIM;
            showResult += "Credit: " + (int)t_Credit + DELIM;
            showResult += "Disposable: " + (int)(t_Balance + t_Credit) + DELIM;
            showResult += "------------------------------- \n";

            return showResult;
        }
    }
}
