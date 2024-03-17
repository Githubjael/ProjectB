public class Program
{
    public static void Main()
    {
        bool exit = false;
        //info abt restaurant, can be changed by manager
        Console.WriteLine("add later");

        while (!exit)
        {
            Console.WriteLine("[1] Make a reservation");
            Console.WriteLine("[2] View the menu");
            Console.WriteLine("[3] Exit");
            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Reservation.MakeReservation();
                    foreach(var kvp in Reservation.tableAssignments)
                    {
                        // ik display even alle guestsIDS and table ids die bezet zijn // gwn een overzicht voor ons & omte checken of het werkt.
                        Console.WriteLine($"GuestID: {kvp.Key}, TableID: {kvp.Value}");
                    }
                    break;

                case "2":
                    Console.WriteLine("Show the menu");
                    break;

                case "3":
                    Console.WriteLine("Exited the program");
                    exit = true;  
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please choose a number between 1 and 3");
                    break;
            }
        }
    }
}
