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
        // ik maaaak een date tijd object met de gekozen datum en tijd van de user.
        DateTime chosenDateTime = new DateTime(chosenYear, chosenMonth, chosenDay, chosenHour, 0, 0);

        // daarna maakik een loop door elke reservering te gaan, om overlappingen van tijden te controleren.
        foreach (var reservation in _reservation)
        {
            // ik verander de reserveringsdate naar een Datetime object.
            DateTime reservationDateTime = DateTime.Parse(reservation.Date);

            // ik controleer of de reservering op dezelfde dag valt
            if (reservationDateTime.Date == chosenDateTime.Date)
            {
                // ik kijk of er een overlap is in de reserveringstijden, als eerst bepaal ik de eindtijd van de rservatie, door een uurtje toe te voegen aan de datetime.
                DateTime reservationEndDateTime = reservationDateTime.AddHours(1); // ik denk dat elke reservering minstens 1 uur duurt dus vandaar die 1.
                if (chosenDateTime >= reservationDateTime && chosenDateTime < reservationEndDateTime)
                {
                    // De tijden overlappen (de tafel is door een ander gereserveerd op dat moment.) Dus de tafel is niet beschikbaar
                    return false;
                }
            }
        }

        // Als er geen overlappingen zijn, is de tafel beschikbaar
        return true;
    }
}
