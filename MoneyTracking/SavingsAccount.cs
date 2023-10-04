using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyTracking
{
    public class SavingsAccount : Account
    {
        private float t_Balance;
        private int timesCountUsed;
        private const int maximum = 4;
        private const float def_Interest = 2.0f;
        protected float interest;

        public SavingsAccount(string acnt, float crnt_Blnc, int vCounter = 0) : base(acnt, crnt_Blnc)
        {
            t_Balance = crnt_Blnc;
            timesCountUsed = vCounter;
            interest = def_Interest;
        }

        public override void depositInB(float currBalance)
        {
            t_Balance += currBalance;
        }

        public override bool withdrawB(float drawn)
        {
            bool done = false;

            if (t_Balance >= drawn && timesCountUsed < maximum)
            {
                t_Balance -= drawn;
                timesCountUsed++;
                done = true;
            }

            return done;
        }

        public override string getAccountType()
        {
            return "Savings account";
        }

        public override double getInterest()
        {
            return interest;
        }

        public override int getMaxWithdrawals()
        {
            return maximum;
        }

        public override int getNrOfWithdrawals()
        {
            return timesCountUsed;
        }

        public override string print()
        {
            string DELIM = "\n";
            string showResult = "";

            showResult += "Account Type: " + getAccountType() + DELIM;
            showResult += "Account Number: " + getAccountNum() + DELIM;
            showResult += "Balance: " + Convert.ToInt32(getBalance()) + DELIM;
            showResult += "Interest: " + Convert.ToInt32(getInterest()) + ".0%" + DELIM;
            showResult += "Max annual withdrawals: " + Convert.ToInt32(getMaxWithdrawals()) + DELIM;
            showResult += "Made withdrawals this year: " + Convert.ToInt32(timesCountUsed) + DELIM;
            showResult += "-------------------------------" + DELIM;

            return showResult;
        }
    }
}
