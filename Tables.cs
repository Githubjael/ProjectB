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
    public bool IsTableReserved(List<ReservationDataModel> _reservation, int chosenYear, int chosenMonth, int chosenDay, int chosenHour )
    {
        // Als er geen overlappingen zijn, is de tafel beschikbaar
        return true;
    }
}
