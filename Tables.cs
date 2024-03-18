class Tables
{
    public int ID;
    public string Type;
    public bool Reserved;
    // public int Amount;
    public Tables(int id, string type)
    {
        ID = id;
        Type = type;
        Reserved = false;
        // Amount = amount;
    }
    public void IsReserved()
    {
        Reserved = true;
    }
}
