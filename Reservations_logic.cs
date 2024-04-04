public class ReservationLogic
{
    public static List<ReservationDataModel> _reservation = new List<ReservationDataModel>(){};

    //  voor nu adden we alleen maar reservations naar de prive lijst
    public static void AddReservationFromJson()
    {
        if (ReservationDataAccess.ReadFromJson() != null){
        foreach(ReservationDataModel reservation in ReservationDataAccess.ReadFromJson())
        {
            _reservation.Add(reservation);
        }
    }
    }
    public static void AddReservationToList(ReservationDataModel reservation)
    {
        _reservation.Add(reservation);
        ReservationDataAccess.WriteToJson(_reservation);
    }
    //  en deze lijst sturen we op een of andere manier naar json
    //  We roepen een method vanuit ReservationDataAccess (de write to json method)

    public static void CancelReservation(int guestID)
    {
        //  ik maak beneden een methode om de reservatie te vinden die gekoppeld is aan guestiD
        ReservationDataModel reservationToRemove = FindReservationByGuestID(guestID);

        if (reservationToRemove != null)
        {
        //  als eerst verwijder ik de reservatie van de list.
            reservationToRemove.Table.Cancelled();
            _reservation.Remove(reservationToRemove);

        //   ik sla de nieuwe lijst van reserveringen in de json op, dus de lijst zonder de gecancelde reservaties
            ReservationDataAccess.WriteToJson(_reservation);

        //   ook voeg ik de tafel ID weer terug naar beschikbare tafels daarvoor gebruik ik ff een korte methode (die ik beneden maak)
            string tableID = reservationToRemove.Table.ID;
            // AddAvailableTable(tableID);
            Console.WriteLine("Reservation is cancelled.");
        }
        else
        {
            Console.WriteLine("Reservation is not found.");
        }
    }

    //  korte methode om ff de reservatie op basis van guest ID te vinden.
    public static ReservationDataModel FindReservationByGuestID(int guestID)
    {
        foreach (ReservationDataModel reservation in _reservation)  //deze loop gaat door de reservaties in de lijst , totdat hij de reservatie tegenkomt die gebonden is aan de guestID die hij uit de parameter krijgt.
        {
        if (reservation.GuestID == guestID)
        {
            return reservation;
        }
        }
        return null; //null == geen reservatie gevonden
    }

    // check of tafel bezet is
    public static bool CheckReservedTable(string ID, string Date, string Time)
    {
        foreach(ReservationDataModel reservation in _reservation)
        {
            if(reservation.Table.ID == ID && reservation.Date == Date && reservation.Time == Time)
            {
                return true;
            }
        }
        return false;
    }
}
