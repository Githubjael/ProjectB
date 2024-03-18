using System.Security.Cryptography.X509Certificates;

public class Program
{
    public static void Main()
    {
        
        bool exit = false;
        //info abt restaurant, can be changed by manager
        RestaurantInfo resto1 = new RestaurantInfo("Wijnhaven 107", "email", 06372382);

        while (!exit)
        {
            System.Console.WriteLine($"Adress: {resto1.Adress}\nEmail: {resto1.Email}\nPhone number: {resto1.Phone_number}");
            Console.WriteLine("[1] Make a reservation");
            Console.WriteLine("[2] View the menu");
            Console.WriteLine("[3] Exit");
            Console.WriteLine("[4] Login as manager");
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
                
                case "4":
                //check login and password
                    bool exit2 = false;
                    while (!exit2)
                    {
                    Console.WriteLine("[1] Change the restaurant info");
                    Console.WriteLine("[2] Change the menu"); // do later
                    Console.WriteLine("[3] Exit");
                    Console.Write("Enter your choice: ");
                    string choice_manager = Console.ReadLine(); 
                    
                    switch (choice_manager)
                    {
                        case "1":
                            Console.WriteLine("What is the current addres?");
                            string restaurant_adress = Console.ReadLine();
                            Console.WriteLine("What is the current email");
                            string restaurant_email = Console.ReadLine();
                            Console.WriteLine("What is the current phone number?");
                            int phone_number = Convert.ToInt32(Console.ReadLine());
                            resto1.Adress = restaurant_adress;
                            resto1.Email = restaurant_email;
                            resto1.Phone_number = phone_number;

                            break;
                        
                        case "2":
                            break;
                        case "3":
                            Console.WriteLine("Exited the program");
                            exit2 = true; 
                            break;
                        case "4":
                            break;
                    }
                }
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please choose a number between 1 and 3");
                    break;
            }
        }
    }
}
