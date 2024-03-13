public class Reservation{
    public string Name;
    public string Date;
    public string Time;
    public int SizeParty;

    public Reservation(string name, string date, string time, int sizeParty)
    {
        Name = name;
        Date = date;
        Time = time;
        SizeParty = sizeParty;
    }

    public void MakeReservation()
    {
    
        List<int> availableDays = new List<int>();
    
    
        Console.WriteLine("How many people are you coming with?");
        int guessAmount = Convert.ToInt32(Console.ReadLine());
    
    
        Console.WriteLine("What month would you like to come?");
        string monthChoice = Console.ReadLine();
    
    
        Console.WriteLine($"These are the avalaible days in {monthChoice} for a reservation with {guessAmount} people:");
        Console.WriteLine(availableDays);
    
        Console.WriteLine("What day would you like to come?");
        int dayChoice = Convert.ToInt32(Console.ReadLine());
    
        Console.WriteLine("These are the available times to reservate a table on your chosen day:");
        Console.WriteLine("available days implemented");
    
        Console.WriteLine("Chooce a tijdstip:");
        string timeChoice = Console.ReadLine();
    
        Console.WriteLine("Do you confirm the reservation with the chosen date? y/n");
        string reservationConfirmation = Console.ReadLine();
    
    
    }

    }
}
