using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyTracking
{
    public class LongSavingsAccount : Account
    {
        private float t_Balance;
        private int maximum = 1;
        private float interest = 2.0f;
        private int timesCounterUsed;

        public LongSavingsAccount()
        {
        }

        public LongSavingsAccount(string acnt, float crnt_Blnc, int vCounter = 0) : base(acnt)
        {
            t_Balance = crnt_Blnc;
            timesCounterUsed = vCounter;
        }

        public override void depositInB(float currBalance)
        {
            t_Balance += currBalance;
        }

        public override bool withdrawB(float drawn)
        {
            bool done = false;
            if (t_Balance >= drawn && timesCounterUsed < maximum)
            {
                t_Balance -= drawn;
                done = true;
                timesCounterUsed++;
            }
            return done;
        }

        public override string getAccountType()
        {
            return "Longterm savings account";
        }

        public override double getInterest()
        {
            double lRate;
            lRate = interest + +2.0; // SavingsAccount.getCredit(); // Räntan på insatt kapital är alltid 2.0% högre än på Savings account
            return lRate;
        }

        public int getTimesCounterUsed()
        {
            return timesCounterUsed;
        }

        public void setTimesCounterUsed(int tiCounter)
        {
            timesCounterUsed = tiCounter;
        }

        public override string print()
        {
            string DELIM = "\n";
            string showResult = "";

            showResult += "Account Type: " + getAccountType() + DELIM;
            // showResult += "Account Number: " + getAccountNum() + DELIM;
            showResult += "Balance: " + (int)t_Balance + DELIM;
            showResult += "Interest: " + (int)getInterest() + ".0%" + DELIM;
            showResult += "Max annual withdrawals: " + (int)getMaxWithdrawals() + DELIM;
            showResult += "Made withdrawals this year: " + (int)timesCounterUsed + DELIM;
            showResult += "-------------------------------" + DELIM;
            return showResult;
        }
    }
}
