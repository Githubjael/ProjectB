private static Dictionary<DateTime, string> reservations = new Dictionary<DateTime, string>();

public class Reservations{
    public string Name;

    public Reservations(string name)
    {
        Name = name;
    }

    public void MakeReservation()
    {
        Console.WriteLine("Enter the desired date and time (in the format, '2024-03-15 19:00'): ");
        string inputDateTime = Console.ReadLine();
        
        if (DateTime.TryParse(inputDateTime, out DateTime reservationDateTime))
        {
            if (!reservations.ContainsKey(reservationDateTime))
            {
                Console.Write("Voer uw naam in: ");
                string guestName = Console.ReadLine();
                reservations.Add(reservationDateTime, guestName);
                Console.WriteLine($"Reservering op {reservationDateTime} voor {guestName} is gemaakt.");
            }
            else
            {
                Console.WriteLine("Deze tijd is al gereserveerd. Kies een andere tijd.");
            }
        }
        else
        {
            Console.WriteLine("Ongeldige datum- en tijdnotatie. Probeer opnieuw.");
        }
    }
}
