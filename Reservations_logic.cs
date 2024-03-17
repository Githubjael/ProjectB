class ReservationLogic
{
    private static List<ReservationDataModel> _reservation = new List<ReservationDataModel>(){};

    // voor nu adden we alleen maar reservations naar de prive lijst
    public static void AddReservationToList(ReservationDataModel reservation)
    {
        _reservation.Add(reservation);
        ReservationDataAccess.WriteToJson(_reservation);
    }
    // en deze lijst sturen we op een of andere manier naar json
    // We roepen een method vanuit ReservationDataAccess (de write to json method)
}
