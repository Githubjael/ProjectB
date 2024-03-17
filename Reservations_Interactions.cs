
// Deze bestand is de Interactie/Presentatie laag
public class Reservation
{
    // Maandenlijst, later gaat elke maand zn lijst krijgen
    // Elke x wanneer een dag vol is, dan gaat de nummer van die dag uit de lijst.
    public static List<int> Month = new List<int>()
    {
        1, 2, 3, 4, 5, 6, 7,
        8, 9, 10, 11, 12, 13, 14,
        15, 16, 17, 18, 19, 20, 21,
        22, 23, 24, 25, 26, 27, 28,
        29, 30, 31
    };
    // Zelfde geld voor AvailableHours, elke dag zal zijn eigen lijst hebben
    public static List<string> AvailableHours = new List<string>()
    {
        "10:00", "10:30", "17:00", "18:00", "19:30", "20:00"
    };

    public static List<int> unavailableTableIDs = new List<int>(); // als eerst maak ik een lijst om de gebruikte tafel IDs later op te slaan
    
    public static List<int> unavailableGuestIDs = new List<int>(); // ook maak ik een lijst om de gebruikte Guests IDs op te slaan

    public static Dictionary<int, int> tableAssignments = new Dictionary<int, int>(); // daarna maak ik een dictionary om de gastenIDSs te koppelen aan tafelIDs   

    public static int GenerateRandomGuestID()
    {
        Random random = new Random();
        int guestID;

        // ik maak een loop om een unieke guest ID te krijgen
        do
        {
            guestID = random.Next(20); // voor nu even 20 guest IDs
        } while (unavailableGuestIDs.Contains(guestID));

        // ik voeg hier ff de guestID toe aan mijn lijst van gebruikte guest IDs
        unavailableGuestIDs.Add(guestID);

        return guestID;
    }
        public static int GenerateRandomTableID()
    {
        Random random = new Random();
        int tableID;

        // ik maak een loop om een unieke tafel ID te krijgen
        do
        {
            tableID = random.Next(20); // voor nu even 20 tafels  // 10x 2-persoons // 5x 4-persoons // 5x 6-persoons
        } while (unavailableTableIDs.Contains(tableID));

        // ik voeg hier ff de tableID toe aan mijn lijst van gebruikte table IDs
        unavailableTableIDs.Add(tableID);

        return tableID;
    }
    public static void MakeReservation()
    {
        // vraag de gebruiker met hoeveel personen hij/zij komt
        Console.WriteLine("How many people are coming with you?");
        int amountOfGuests = Convert.ToInt32(Console.ReadLine());

        // vraag de gebruiker in welke maand hij/zij wil boeken
        Console.WriteLine("In what month would you like to book? Enter the number of that month.");
        int numberOfMonth = Convert.ToInt32(Console.ReadLine());

        // vraag de gebruiker om een dag te kiezen
        Console.WriteLine($"Available days for booking are:\n{string.Join(", ", Month)}.\nChoose a day.");
        int chosenDay = Convert.ToInt32(Console.ReadLine());

        // vraag de gebruiker om een tijd te kiezen
        Console.WriteLine($"Available hours for booking are:\n{string.Join(", ", AvailableHours)}\nChoose a time");
        string chosenTime = Console.ReadLine();

        // toon de reserveringsinformatie
        Console.WriteLine($"Your reservation details:\n{chosenDay}/{numberOfMonth}/2024 at {chosenTime} for {amountOfGuests} guests");

        // vraag om persoonlijke gegevens van de gebruiker
        Console.WriteLine("What is your phone number?");
        string phoneNumber = Console.ReadLine();

        Console.WriteLine("What is your Email?");
        string email = Console.ReadLine();

        // most importantly de ids maken voor je gasten
        int guestID = GenerateRandomGuestID();
        int tableID = GenerateRandomTableID();

        // ik koppel de guest and table ids in mijn dictionarie
        tableAssignments.Add(guestID, tableID);

        // We maken een object van de Reservering om in een lijst te dumpen om naar json te sturen
        ReservationDataModel Reservation = new ReservationDataModel(guestID, tableID, $"{chosenDay}/{numberOfMonth}/2024 {chosenTime}", email, phoneNumber);
        ReservationLogic.AddReservationToList(Reservation);

        // bevestig de reservering aan de gebruiker
        Console.WriteLine($"Your reservation is confirmed. Your table number = {tableID}.\nThank you for choosing our restaurant, we look forward to serving you!");
    }

}
