// Deze bestand is de Interactie/Presentatie laag
public class Reservation
{

    public static List<int> unavailableTableIDs = new List<int>(); // als eerst maak ik een lijst om de gebruikte tafel IDs later op te slaan
    public static List<int> unavailableGuestIDs = new List<int>(); // ook maak ik een lijst om de gebruikte Guests IDs op te slaan
    public static Dictionary<int, int> tableAssignments = new Dictionary<int, int>(); // daarna maak ik een dictionary om de gastenIDSs te koppelen aan tafelIDs   
    public static List<string> AvailableTablesIDs = new List<string>(); //Om tafels op te slaan die available zijn.
    public static List<Tables> TableTracker = new List<Tables>() { }; // nodig om alle tafels op een lijstje te hebben en om staus binnen de tafels te veranderen

    public static void PopulateTables()
    {
        for (int i = 1; i <= 8; i++)
        {
            TableTracker.Add(new Tables(i, "2 persons table"));
        }
        for (int j = 9; j <= 14 ; j++)
        {
            TableTracker.Add(new Tables(j, "4 persons table"));
        }
        for (int j = 15; j <= 16; j++)
        {
            TableTracker.Add(new Tables(j, "6 persons table"));
        }
    }
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

        string ChosenMonth;
        do{
            // Vraag in welke maand de gast wilt komen
            Console.WriteLine("What month would you like to book? Enter number of month.");
            ChosenMonth = Console.ReadLine();
        } while (!CheckReservationInfo.CheckChosenMonth(ChosenMonth));

        // vraag de gebruiker om een dag te kiezen
        int ChosenMonthINT = Convert.ToInt32(ChosenMonth);
        Console.WriteLine($"Available days for booking are:\n{string.Join(", ", DisplayMonthList.GiveListBasedOnMonth(ChosenMonthINT))}.\nChoose a day.");
        int ChosenDay = Convert.ToInt32(Console.ReadLine());

        // Vraag hoeveel Personen komen
        System.Console.WriteLine("How many guests are coming including yourself?");
        int AmountOfGuests = Convert.ToInt32(Console.ReadLine());

        // toon de reserveringsinformatie
        Console.WriteLine($"Your reservation details:\n{ChosenDay}/{ChosenMonth}/2024, for {AmountOfGuests} guests");

        // most importantly de ids maken voor je gasten
        int guestID = GenerateRandomGuestID();
        int tableID = GenerateRandomTableID();
        PopulateTables();

        string confirmation;
        bool valid = false; 
        do
        {
            Console.WriteLine("Do you confirm your reservation? y/n");
            confirmation = Console.ReadLine().ToLower();

            if (string.IsNullOrEmpty(confirmation))
            {
                Console.WriteLine("Invalid input. You must enter 'y' (yes) or 'n' (no)");
            }
            else if (!confirmation.All(char.IsLetter))
            {
                Console.WriteLine("Invalid input. You must enter 'y' (yes) or 'n' (no)");
            }
            else
            {
                valid = true; 
            }
        } while (!valid);

        if (confirmation == "y")
        {
            tableAssignments.Add(guestID, tableID);

            var tabletype = AmountOfGuests switch
            {
                1 => "2 persons table",
                2 => "2 persons table",
                3 => "4 persons table",
                4 => "4 persons table",
                5 => "6 persons table",
                6 => "6 persons table",
                _ => "?"
            };

            var found = TableTracker.Find(x=>x.Type.Contains(tabletype));
            found.GuestID = guestID;
            found.Reserved = true;

            // We maken een object van de Reservering om in een lijst te dumpen om naar json te sturen
            ReservationDataModel Reservation = new ReservationDataModel(found, $"{ChosenDay}/{ChosenMonth}/2024", FirstName, LastName, EmailAddress, PhoneNumber);
            ReservationLogic.AddReservationToList(Reservation);

            // bevestig de reservering aan de gebruiker
            Console.WriteLine($"Your reservation is confirmed.\nThank you for choosing our restaurant, we look forward to serving you!");
            Console.WriteLine($"Your Guest ID {Reservation.Table.GuestID}, Your table number = {tableID}");
        }
        else if (confirmation == "n")
        {
            Console.WriteLine("Your reservation is not confirmed, Bye!.");
        }


    }

}
