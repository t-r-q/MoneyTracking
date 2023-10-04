namespace MoneyTracking
{
internal class Menu
{
    private List<MenuItem> menuList = new List<MenuItem>();
    private string titleMenu;

    public Menu()
    {
    }

    public Menu(List<MenuItem> mnuList, string titlMenu)
    {
        menuList = mnuList;
        titleMenu = titlMenu;
    }

    public List<MenuItem> GetMenuList()
    {
        return menuList;
    }

    public void SetMenuList(List<MenuItem> menuList)
    {
        this.menuList = menuList;
    }

    public string GetTitleMenu()
    {
        return titleMenu;
    }

    public void SetTitleMenu(string titleMenu)
    {
        this.titleMenu = titleMenu;
    }

    public void AddItem(string menuText, bool enabled)
    {
        MenuItem mi = new MenuItem(menuText, enabled);
        menuList.Add(mi);
    }

    public void PrintMenuItems()
    {
        int numVar = 0;
        foreach (var itm in menuList)
        {
            if (itm.IsOption)
            {
                numVar++;
                Console.WriteLine($"{numVar} - {itm.Menutext}");
            }
        }
    }

    public int GetMenuChoice()
    {
        int userChoice;
        int sizeList = menuList.Count;
        while (!int.TryParse(Console.ReadLine(), out userChoice) || userChoice < 0 || userChoice > sizeList)
        {
            Console.WriteLine("Invalid Value! Enter from the list");
        }
        return userChoice;
    }

    public void ClearList()
    {
        menuList.Clear();
    }
}



}
