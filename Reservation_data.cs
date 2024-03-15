// indeze class worden de reservaties opgeslagen.
public class ReservationsInfo
{
    private List<Reservation> reservations = new List<Reservation>();

    public void AddReservation(Reservation reservation)
    {
        reservations.Add(reservation);
    }

    public List<Reservation> GetReservations()
    {
        return reservations;
    }
}
