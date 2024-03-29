public class Tables
{
    public string ID;
    public string Type;
    public bool Reserved;
    // public int Amount;
    public Tables(int id, string type)
    {
        if (type == "2 persons table")
        {
            ID = $"{id}A";
        }
        else if (type == "4 persons table")
        {
            ID = $"{id}B";
        }
        else if (type == "6 persons table")
        {
            ID = $"{id}C";
        }
        Type = type;
        Reserved = false;
    }
    public bool IsTableReserved(int chosenYear, int chosenMonth, int chosenDay, int chosenHour )
    {
        return true;
    }
}
