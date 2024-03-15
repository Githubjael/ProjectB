class Reservation
{
    public static new List<int> Month = new List<int>(){
     1, 2, 3, 4, 5, 6, 7,
     8, 9, 10, 11, 12, 13, 14,
     15, 16, 17, 18, 19, 20, 21,
     22, 23, 24, 25, 26, 27, 28,
     29, 30, 31};
    public static new List<string> AvailableHours = new List<string>(){"10:00", "10:30", "17:00", "18:00", "19:30", "20:00"};


    

    public static List<int> unavailableIDs = new List<int>(); // ik maak een lijst om de ids die bezet zijn opteslaan.

    public static int GenerateRandomID()
    {
        Random random = new Random();
        int guestID;

        // ik maak een loop om een nieuwe id te krijgen totdat er een unique id is die niet in mijn 'gebruikte ids lijst' zit.
        do
        {
            guestID = random.Next(20); // random ID , voor nu ff 20 ids , kan nog veranderen
        } while (unavailableIDs.Contains(guestID)); // zolang die id in de  gebruikte lijst zit blijft het doorgaan.

        // de gebruikte ids voeg ik toe aan de lijst.
        unavailableIDs.Add(guestID);

        return guestID;
    }

    
    public static void MakeReservation(){
        // Vraag de user met hoeveel personen die gaat komen
        Console.WriteLine("How many people are coming with you?");
        int AmountOfGuests = Convert.ToInt32(Console.ReadLine());

        // Vraag de user in welke maan die wilt komen
        Console.WriteLine("In what month would you like to book? Enter the number of that month.");
        // We vragen de nummer van de maand om het voor even simpel te houden
        int NumberOfMonth = Convert.ToInt32(Console.ReadLine());

        // Beschikbare dagen van deze maand weergeven in een lijst
        System.Console.WriteLine($"Available days for booking are:\n{string. Join(", ", Month)}.\nChoose a day.");
        int ChosenDay = Convert.ToInt32(Console.ReadLine());

        // Beschikbare tijden op gekozen dag:
        System.Console.WriteLine($"Available hours for booking are:\n{string. Join(", ", AvailableHours)}\nChoose a time");
        string ChosenTime = Console.ReadLine();

        // Reserverings informatie weergeven ter bevestiging. User heeft nog GEEN recht op aanpassing
        System.Console.WriteLine($"Your reservation details:\n{ChosenDay}/{NumberOfMonth}/2024 at {ChosenTime} for {AmountOfGuests} guests");
        // Deze informatie gaan we later opslaan in een object

        //Persoonlijke gegevens opvragen van user
        System.Console.WriteLine("What is your phone number?");
        string PhoneNumber = Console.ReadLine();

        System.Console.WriteLine("What is your Email?");
        string Email = Console.ReadLine();

        // vervolgens geven we de user een guestID voor zijn reservering, d.m.v. een randomgenerator.
        int guestID = GenerateRandomID();

        // Later gaan we de user vragen om de reservering te  bevestigen maar voor nu even dit:
        System.Console.WriteLine($"Your reservation is confirmed. Your table ID = {guestID}.\nThank you for choosing our restaurant, we look forward to serve you!");
        // Hierna maken we een Reservation object aan met alle details van de reservation en stoppen we die in json
    }


    public static void Main()
    {
        MakeReservation();
    } 

    
}

