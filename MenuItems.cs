public class MenuItem{
    public string Name { get; set; }
    public double Price { get; set; }
    public bool IsFish { get; set; }
    public bool IsMeat { get; set; }
    public bool IsVegetarian { get; set; }
    public bool IsDrink { get; set; }

    public MenuItem(string name, double price, bool isFish, bool isMeat, bool isVegetarian, bool isDrink)
    {
        Name = name;
        Price = price;
        IsFish = isFish;
        IsMeat = isMeat;
        IsVegetarian = isVegetarian;
        IsDrink = isDrink;
    }

    //fish, meat vegan, vegatarian and drinks




}
