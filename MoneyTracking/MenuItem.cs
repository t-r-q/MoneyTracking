public class MenuItem
{
    private string menutext;
    private bool option;

    public MenuItem()
    {
    }

    public MenuItem(string menutext, bool option)
    {
        this.menutext = menutext;
        this.option = option;
    }

    public string Menutext
    {
        get { return menutext; }
        set { menutext = value; }
    }

    public bool IsOption
    {
        get { return option; }
        set { option = value; }
    }


}