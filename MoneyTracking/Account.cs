using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyTracking
{
  
    public abstract class Account
    {
        protected string account_Num;
        protected float current_Balance;
        protected float a_Credit;
        protected string accoutType;

        public Account()
        {
            a_Credit = approved_Credit;
        }

        public Account(string acnt, float crnt_Blnc = 0)
        {
            account_Num = acnt;
            current_Balance = crnt_Blnc;
            a_Credit = approved_Credit;
        }

        public virtual void depositInB(float currentBalance)
        {
            current_Balance += currentBalance;
        }

        public abstract bool withdrawB(float drawn);

        public void setCredit(float aCredit)
        {
            // Implement as needed in derived classes
        }

        public void setInterest(double intere)
        {
            // Implement as needed in derived classes
        }

        public void setAccountType(string typ)
        {
            accoutType = typ;
        }

        public void setAccountNum(string acntNum)
        {
            account_Num = acntNum;
        }

        public string getAccountNum()
        {
            return account_Num;
        }

        public float getBalance()
        {
            return current_Balance;
        }

        public virtual float getCurrentCredit()
        {
            return 0;
        }

        public void changeGrantedCredit(float approvedCredit)
        {
            a_Credit = approvedCredit;
        }

        public float getUseableAmount()
        {
            return current_Balance + a_Credit;
        }

        public abstract string getAccountType();

        public virtual float getDisposable()
        {
            return current_Balance;
        }

        public virtual int getMaxWithdrawals()
        {
            return 0;
        }

        public virtual int getNrOfWithdrawals()
        {
            return 0;
        }

        public virtual double getInterest()
        {
            return 0;
        }

        public virtual bool hasCredit()
        {
            return false;
        }

        public virtual bool hasInterest()
        {
            return false;
        }

        public virtual bool hasMaxWithdrawals()
        {
            return false;
        }

        public abstract string print();

       public const float approved_Credit = 0.00f; // Default size
    } 
}
