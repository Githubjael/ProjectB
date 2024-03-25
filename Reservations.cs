
// Deze bestand is de Interactie/Presentatie laag
using System.Threading.Channels;

public class Reservation
{
    // Maandenlijst, later gaat elke maand zn lijst krijgen
    // Elke x wanneer een dag vol is, dan gaat de nummer van die dag uit de lijst.

    // Zelfde geld voor AvailableHours, elke dag zal zijn eigen lijst hebben

    public static List<int> unavailableTableIDs = new List<int>(); // als eerst maak ik een lijst om de gebruikte tafel IDs later op te slaan
    
    public static List<int> unavailableGuestIDs = new List<int>(); // ook maak ik een lijst om de gebruikte Guests IDs op te slaan

    public static Dictionary<int, int> tableAssignments = new Dictionary<int, int>(); // daarna maak ik een dictionary om de gastenIDSs te koppelen aan tafelIDs   
    
    public static List<string> AvailableTablesIDs = new List<string>(); //Om tafels op te slaan die available zijn.

    public static int GenerateRandomGuestID()
    {
        Random random = new Random();
        int guestID;

        // ik maak een loop om een unieke guest ID te krijgen
        do
        {
            guestID = random.Next(16); // voor nu even 16 guest IDs
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
            tableID = random.Next(16); // voor nu even 16 tafels  // 8x 2-persoons // 5x 4-persoons // 2x 6-persoons
        } while (unavailableTableIDs.Contains(tableID));

        // ik voeg hier ff de tableID toe aan mijn lijst van gebruikte table IDs
        unavailableTableIDs.Add(tableID);

        return tableID;
    }
    public static void MakeReservation()
    {
        // Vraag om Voornaam
        string FirstName;
        do{
        System.Console.WriteLine("What is your first name?");
        FirstName = Console.ReadLine();
        } while (!CheckReservationInfo.CheckFirstName(FirstName));


        // Vraag achternaam
        string LastName;
        do{
        System.Console.WriteLine("What is your last name?");
        LastName = Console.ReadLine();
        } while(!CheckReservationInfo.CheckLastName(LastName));

        // Vraag telefoonnummer
        string PhoneNumber;
        do{
        System.Console.WriteLine("What is your phone number?");
        PhoneNumber = Console.ReadLine();
        } while (!CheckReservationInfo.CheckPhoneNumber(PhoneNumber));

        string EmailAddress;
        // Vraag emailadres
        do{
        System.Console.WriteLine("What is your email address?");
        EmailAddress = Console.ReadLine();
        } while (!CheckReservationInfo.CheckEmailAddress(EmailAddress));


        // Vraag in welke maand de gast wilt komen
        System.Console.WriteLine("What month would you like to book? Enter number of month.");
        int ChosenMonth = Convert.ToInt32(Console.ReadLine());

        // Welke Dag
        // vraag de gebruiker om een dag te kiezen
        Console.WriteLine($"Available days for booking are:\n{string.Join(", ", DisplayMonthList.GiveListBasedOnMonth(ChosenMonth))}.\nChoose a day.");
        int ChosenDay = Convert.ToInt32(Console.ReadLine());

        // Vraag hoeveel Personen komen
        System.Console.WriteLine("How many guests are coming including yourself?");
        int AmountOfGuests = Convert.ToInt32(Console.ReadLine());

        // toon de reserveringsinformatie
        Console.WriteLine($"Your reservation details:\n{ChosenDay}/{ChosenMonth}/2024, for {AmountOfGuests} guests");

        // most importantly de ids maken voor je gasten
        int guestID = GenerateRandomGuestID();
        int tableID = GenerateRandomTableID();
        
        Console.WriteLine("Do you confirm your reservation?");
        string confirmation = Console.ReadLine().ToLower();
        if (confirmation == "y")
        {
            Console.WriteLine("Your reservation is confirmed.");
        }
        else
        {
            CancelReservation(guestID);
        }

        PopulateTables();
        foreach (Tables tafel in TableTracker)
        {
            tafel.ID = tableID;
        }
        // ik koppel de guest and table ids in mijn dictionarie
        tableAssignments.Add(guestID, tableID);

        // We maken een object van de Reservering om in een lijst te dumpen om naar json te sturen
        ReservationDataModel Reservation = new ReservationDataModel(guestID, tableID, $"{ChosenDay}/{ChosenMonth}/2024", FirstName, LastName, EmailAddress, PhoneNumber);
        // $"{ChosenDay}/{ChosenMonth}/2024"
        ReservationLogic.AddReservationToList(Reservation);

        // bevestig de reservering aan de gebruiker
        Console.WriteLine($"Your reservation is confirmed. Your table number = {tableID}.\nThank you for choosing our restaurant, we look forward to serving you!");
    }

}
