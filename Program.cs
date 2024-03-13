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
            Console.WriteLine("[2] Cancel a reservation");
            Console.WriteLine("[3] View the menu");
            Console.WriteLine("[4] Exit");
            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.WriteLine("What is going to be the name of the reservation?");
                    string userName = Console.ReadLine();
                    Reservations reservation = new Reservations(userName);
                    reservation.MakeReservation();
                    break;

                case "2":
                    Console.WriteLine("Implement cancelling the reservation");
                    break;

                case "3":
                    Console.WriteLine("Show the menu");
                    break;

                case "4":
                    Console.WriteLine("Exited the program");
                    exit = true;  
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please choose a number between 1 and 4");
                    break;
            }
        }
    }
}
