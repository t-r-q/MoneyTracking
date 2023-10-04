


using MoneyTracking;

TestAp ts = new TestAp();
ts.Run();

/*

MoneyTracker tracker = new MoneyTracker();


tracker.LoadDataFromFile();

bool isRunning = true;

while (isRunning)
{
    Console.WriteLine("Money Tracking Application");
    Console.WriteLine("1. Add Item");
    Console.WriteLine("2. Edit Item");
    Console.WriteLine("3. Remove Item");
    Console.WriteLine("4. Display Items");
    Console.WriteLine("5. Save and Quit");
    Console.Write("Enter your choice: ");
    string choice = Console.ReadLine();

    switch (choice)
    {
        case "1":
            // Implement logic to add a new item
            break;
        case "2":
            // Implement logic to edit an existing item
            break;
        case "3":
            // Implement logic to remove an item
            break;
        case "4":
            // Implement logic to display items
            tracker.DisplayItems();
            break;
        case "5":
            tracker.SaveDataToFile();
            isRunning = false;
            break;
        default:
            Console.WriteLine("Invalid choice. Please try again.");
            break;
    }
}

class MoneyItem
{
    public string Title { get; set; }
    public decimal Amount { get; set; }
    public string Month { get; set; }

    public MoneyItem(string title, decimal amount, string month)
    {
        Title = title;
        Amount = amount;
        Month = month;
    }

    public override string ToString()
    {
        return $"Title: {Title}, Amount: {Amount}, Month: {Month}";
    }
}

class MoneyTracker
{
    private List<MoneyItem> items = new List<MoneyItem>();
    private string dataFilePath = "moneydata.txt";

    public void AddItem(MoneyItem item)
    {
        items.Add(item);
    }

    public void EditItem(int index, MoneyItem newItem)
    {
        if (index >= 0 && index < items.Count)
        {
            items[index] = newItem;
        }
    }

    public void RemoveItem(int index)
    {
        if (index >= 0 && index < items.Count)
        {
            items.RemoveAt(index);
        }
    }

    public void DisplayItems()
    {
        foreach (var item in items)
        {
            Console.WriteLine(item);
        }
    }

    public void SaveDataToFile()
    {
        using (StreamWriter writer = new StreamWriter(dataFilePath))
        {
            foreach (var item in items)
            {
                writer.WriteLine($"{item.Title},{item.Amount},{item.Month}");
            }
        }
    }
    public void LoadDataFromFile()
    {
        if (File.Exists(dataFilePath))
        {
            items.Clear();
            string[] lines = File.ReadAllLines(dataFilePath);
            foreach (string line in lines)
            {
                string[] parts = line.Split(',');
                if (parts.Length == 3)
                {
                    string title = parts[0];
                    decimal amount = decimal.Parse(parts[1]);
                    string month = parts[2];
                    MoneyItem item = new MoneyItem(title, amount, month);
                    items.Add(item);
                }
            }
        }
    }
}

*/