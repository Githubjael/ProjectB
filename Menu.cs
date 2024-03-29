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

    public string ChangeItem(string name)
    {
        foreach (var item in Items)
        {
            if (name == item.Name)
            {
                Console.WriteLine("What would you like to change?");
                Console.WriteLine("[1] Name\n[2] Price\n[3] Type");
                bool validChoice = false;
                while (!validChoice)
                {
                    string itemChange = Console.ReadLine();
                    switch (itemChange)
                    {
                        case "1":
                            validChoice = true;
                            Console.WriteLine($"What is the new name of the {item.Name}?");
                            string itemName = Console.ReadLine();
                            item.Name = itemName;
                            return "Successfully changed!";
                            
                        case "2":
                            validChoice = true;
                            Console.WriteLine($"What is the new price of the {item.Name}?");
                            double itemPrice = Convert.ToInt32(Console.ReadLine());
                            item.Price = itemPrice;
                            return "Succesfully changed!";
                            
                        case "3":
                            validChoice = true;
                            Console.WriteLine("Is it meat? (true/false)");
                            bool isMeat = Convert.ToBoolean(Console.ReadLine());
                            Console.WriteLine("Is it fish? (true/false)");
                            bool isFish = Convert.ToBoolean(Console.ReadLine());
                            Console.WriteLine("Is it vegetarian? (true/false)");
                            bool isVegetarian = Convert.ToBoolean(Console.ReadLine());
                            Console.WriteLine("Is it a drink? (true/false)");
                            bool isDrink = Convert.ToBoolean(Console.ReadLine());
                            item.IsMeat = isMeat;
                            item.IsFish = isFish;
                            item.IsVegetarian = isVegetarian;
                            item.IsDrink = isDrink;
                            return "Succesfully changed!";
                            
                        default:
                            Console.WriteLine("Invalid choice. Please enter 1, 2, or 3.");
                            break;
                    }
                }
            }
        }
        return $"Item {name} not found.";
    }


public void DisplayMenu(string category)
{
    //check what category is asked
    switch (category.ToLower())
    {
        case "fish":
            Console.WriteLine("---Fish---"); //prints once what item its printing
            foreach (var item in Items)
            {
                if (item.IsFish)
                {
                    Console.WriteLine($"{item.Name}: ${item.Price}"); //prints every item name and price that is fish
                }
            }
            break;
        case "meat":
            Console.WriteLine("---Meat---"); //prints once what item its printing
            foreach (var item in Items)
            {
                if (item.IsMeat)
                {
                    Console.WriteLine($"{item.Name}: ${item.Price}"); //prints every item name and price that is meat
                }
            }
            break;
        case "vegetarian":
            Console.WriteLine("---Vegetarian---"); //prints once what item its printing
            foreach (var item in Items)
            {
                if (item.IsVegetarian)
                {
                    Console.WriteLine($"{item.Name}: ${item.Price}"); //prints every item name and price that is veg
                }
            }
            break;
        case "drinks":
            Console.WriteLine("---Drinks---"); //prints once what item its printing
            foreach (var item in Items)
            {
                if (item.IsDrink)
                {
                    Console.WriteLine($"{item.Name}: ${item.Price}"); //prints every item name and price that is drink
                }
            }
            break;
        default:
            Console.WriteLine("Invalid category."); //if incorrect category is given it stops the method
            break;
    }
}
}
