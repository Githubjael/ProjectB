public class Menu
{
    public List<MenuItem> Items { get; set; }

    public Menu()
    {
                Items = new List<MenuItem>
        {
            //bool order fish, meat, vegetarian, drink (use this to sort)
            new MenuItem("Salmon", 15.99, true, false, false, false),
            new MenuItem("Steak", 12.99, false, true, false, false),
            new MenuItem("Caesar Salad", 8.99, false, false, true, false),
            new MenuItem("Soda", 2.49, false, false, false, true),
            new MenuItem("Iced Tea", 1.99, false, false, false, true)
        };
    }

     public void AddItem(MenuItem item)
    {
        Items.Add(item);
    }

      public string RemoveItem(string name){
        foreach (var item in Items)
        {
            if (name == item.Name){
                Items.Remove(item);
                return $"Succesfully removed item";
            }
        }
        return $"Could not find {name}";
    }



    public void DisplayMenu()
    {
        Console.WriteLine("---------Menu----------");
        foreach (var item in Items)
        {
            Console.WriteLine($"{item.Name}: ${item.Price}");
        }
    }
}
