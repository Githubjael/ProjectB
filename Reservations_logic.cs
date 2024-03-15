// Guest class 
public class Guest
{
    public int ID { get; set; }
    public string Name { get; set; }
    public int AmountOfGuests { get; set; }
}

// Reservation class 
public class Reservation
{
    public int ReservationID { get; set; }
    public List<Guest> Guests { get; set; }
    public int TableNumber { get; set; }
    public DateTime ReservationDate { get; set; }
}

// in deze class verbindt ik de reservatieID met de GuestID, en geef ik ze een tafel (de tafels zijn voor nu gewoon steeds +1 
// maar dat gaat nog aanepast worden en dan krijgen ze een tafelnummer voor de specifieke hoeveelheid guests.
public class ReservationService
{
    private List<Reservation> reservations = new List<Reservation>();
    private int nextTableNumber = 1; 

    public void MakeReservation(List<Guest> guests, DateTime reservationDate)
    {
        var reservation = new Reservation
        {
            ReservationID = reservations.Count + 1,
            Guests = guests,
            TableNumber = nextTableNumber++, 
            ReservationDate = reservationDate
        };
        reservations.Add(reservation);
    }
}
