public class Menu
{
    public List<MenuItem> Items { get; set; }

    public Menu()
    {
        Items = new List<MenuItem>();
    }

     public void AddItem(MenuItem item)
    {
        Items.Add(item);
    }

    public void DisplayMenu()
    {
        Console.WriteLine("Menu:");
        foreach (var item in Items)
        {
            Console.WriteLine($"{item.Name}: ${item.Price}");
        }
    }
}
