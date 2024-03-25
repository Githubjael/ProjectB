public class Program
 {
    public static void Main()
    {
        bool exit = false;
        //  info abt restaurant, can be changed by manager
        RestaurantInfo resto1 = new RestaurantInfo("Wijnhaven 107\n 3011 WN Rotterdam", "email", 06372382);
        Menu menu = new Menu();
        while (!exit)
    {
        System.Console.WriteLine($"Adress: {resto1.Adress}\nEmail: {resto1.Email}\nPhone number: {resto1.Phone_number}");
        Console.WriteLine("[1] Make a reservation");
        Console.WriteLine("[2] View the menu");
        Console.WriteLine("[3] Exit");
        Console.WriteLine("[4] Login as manager");
        Console.WriteLine("[5] Cancel a reservation");
        Console.Write("Enter your choice: ");
        string choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                Reservation.MakeReservation();
                foreach(var kvp in Reservation.tableAssignments)
                {
                //   ik display even alle guestsIDS and table ids die bezet zijn  gwn een overzicht voor ons & omte checken of het werkt.
                    Console.WriteLine($"GuestID: {kvp.Key}, TableID: {kvp.Value}");
                }
                break;

            case "2":
                menu.DisplayMenu();
                break;

            case "3":
                Console.WriteLine("Exited the program");
                exit = true;  
                break;
        
            case "4":

            case "5":
            Console.WriteLine("Enter your Guest ID:");
            int guestid = Convert.ToInt32(Console.ReadLine());
            ReservationLogic.CancelReservation(guestid);
            Console.WriteLine("Your Reservation has been cancelled succesfully!");

        //  check login and password
                bool exitManager = false;
                while (!exitManager)
                {
                Console.WriteLine("[1] Change the restaurant info");
                Console.WriteLine("[2] Change the menu"); 
                Console.WriteLine("[3] See all reservations");  //do later
                Console.WriteLine("[4] Exit");
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
                        string phone_number = Console.ReadLine();
                        resto1.Adress = restaurant_adress;
                        resto1.Email = restaurant_email;
                        resto1.Phone_number = Convert.ToInt32(phone_number);
                        System.Console.WriteLine("Succesfully changed the restaurant info!");

                        break;
                
                    case "2":
                //  make it another while loop and a menu
                //  options are view menu, remove from menu and add to menu
                        bool exitMenuManager = false;
                        while (!exitMenuManager)
                        {
                            Console.WriteLine("[1] View the menu");
                            Console.WriteLine("[2] Add item to the menu");
                            Console.WriteLine("[3] Remove item from the menu");
                            Console.WriteLine("[4] Exit");
                            Console.Write("Enter your choice: ");
                            string menuManagerChoice = Console.ReadLine();

                            switch (menuManagerChoice)
                            {
                                case "1":
                            //  add the ability to sort here
                                    menu.DisplayMenu();
                                    break;

                                case "2":
                                    Console.WriteLine("What is the name of the item?");
                                    string itemName = Console.ReadLine();
                                    Console.WriteLine("What is the price of the item?");
                                    double price = Convert.ToInt32(Console.ReadLine());
                                    Console.WriteLine("Is it meat? (true/false)");
                                    bool isMeat = Convert.ToBoolean(Console.ReadLine());
                                    Console.WriteLine("Is it fish? (true/false)");
                                    bool isFish = Convert.ToBoolean(Console.ReadLine());
                                    Console.WriteLine("Is it vegetarian? (true/false)");
                                    bool isVegetarian = Convert.ToBoolean(Console.ReadLine());
                                    Console.WriteLine("Is it a drink? (true/false)");
                                    bool isDrink = Convert.ToBoolean(Console.ReadLine());

                                    MenuItem newItem = new MenuItem(itemName, price, isFish, isMeat, isVegetarian, isDrink);
                                    menu.AddItem(newItem);
                                    Console.WriteLine("Item added to the menu successfully!");
                                    break;

                                case "3":
                                //   Remove item from the menu
                                        Console.WriteLine("What is the name of the item you want to remove?");
                                        string itemToRemove = Console.ReadLine();
                                        System.Console.WriteLine(menu.RemoveItem(itemToRemove));
                                    break;

                                case "4":
                                    exitMenuManager = true;
                                    break;


        default:
            Console.WriteLine("Invalid choice. Please choose a number between 1 and 4");
            break;
                    }
                }
                break;

                    case "3":
                //  see an overview of all reservations

                        break;
                    case "4":
                        Console.WriteLine("Exited the program");
                        exitManager = true; 
                        break;
                }
            }
                break;

            default:
                Console.WriteLine("Invalid choice. Please choose a number between 1 and 4");
                break;
        }
    }
    }
}
