
namespace MoneyTracking;

internal class Bank
{
    private Customer bCustomer;
    private static Bank instance = new Bank();

    private Bank()
    {
    }

    public static Bank Instance
    {
        get { return instance; }
    }

    public bool CreateNewCustomer(string cID, string cName)
    {
        bCustomer = bCustomer.createNewCustomer(cID, cName);
        return bCustomer != null;
    }

    public string GetName()
    {
        return bCustomer.GetCstmName();
    }

    public string AccountSummary()
    {
        return bCustomer.AccountsSummary();
    }

    public string GetCustomerNr()
    {
        return bCustomer.GetCstmId();
    }

    public int GetNumOfAccounts()
    {
        return bCustomer.getNumAccountsOfCustomer();
    }

    public int GetTotalAssets()
    {
        return bCustomer.getTotalAssets();
    }

    public string PrintAccountNumbers()
    {
        return bCustomer.printAccountNr();
    }

    public bool CheckListAccount(string eAb)
    {
        return bCustomer.checkArrAccount(eAb);
    }

    public void DischargeCustomer()
    {
        bCustomer = null;
    }

    public bool CreateNewAccount(decimal balance, decimal credit, string type)
    {
        return bCustomer.setNewAccount(bCustomer.GetCstmId(), (float)balance, (float)credit, type);
    }

    public bool DeleteAccount(string xNum)
    {
        return bCustomer.quitAccount(xNum);
    }

    public bool Deposit(string xNm, decimal xmount)
    {
        return bCustomer.depositAmountToAccount(xNm, (float)xmount);
    }

    public bool Withdrawal(string xNm, decimal xmount)
    {
        return bCustomer.withdrawFromAccount(xNm, (float)xmount);
    }

    public bool NewCredit(string xNm, decimal xmount)
    {
        return bCustomer.changeCreditLimit(xNm, (float)xmount);
    }

    public void WriteToFile()
    {
        bCustomer.saveToFile();
    }

    public bool LoadFromFile(string id)
    {
        bCustomer = Customer.loadFromFile(id);
        return (bCustomer != null);
    }

    public List<Customer> GetCustomersList()
    {
        List<Customer> customersList = new List<Customer>();
        if (bCustomer != null)
        {
            customersList.Add(bCustomer);
        }
        return customersList;
    }

    internal string getAccountInfo(string userAccount)
    {
        return bCustomer.getAccountInfo(userAccount);
    }
}
