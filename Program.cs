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
                    string reservationName = Console.ReadLine();
                    System.Console.WriteLine("On what day would you like to make a reservation?");
                    string reservationDate = Console.ReadLine();
                    //check if valid date, so in future and good format and on a day resto is open
                    //if not, ask question again
                    System.Console.WriteLine("At what time would you like to make the reservation?");
                    string reservationTime = Console.ReadLine();
                    //check if valid time, so good format and during opening time on that day
                    //if not, ask question again
                    Reservation reservation = new Reservation(reservationName, reservationDate, reservationTime);
                    reservation.MakeReservation();
                    break;

                case "2":
                    Console.WriteLine("On what day would you like to cancel the reservation?");
                    string userDate = Console.ReadLine();
                    Console.WriteLine("What is the name of the reservation?");
                    string userNameForCancel = Console.ReadLine();
                    //remove the reservation on that day with that name from the place where its saved


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
