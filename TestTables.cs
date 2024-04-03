// public class TestTables
// {
//     static List<Tables> TableTracker = new List<Tables>() { }; // nodig om alle tafels op een lijstje te hebben en om staus binnen de tafels te veranderen
//     static List<string> ChoicesOfTableAvailable = new List<string>() {
//         "2 persons table",
//         "4 persons table",
//         "6 persons table",
//         "8 persons table",
//     };//keuzes voor type tafels
//     static string choice;//de gekozen table type
//     static bool exit = false; // bool voor de tafelkeuzeloop
//     static void Main()
//     {
//         PopulateTables();/* maakt 40 tafels/ 17 2-persons table/ 10 4-persons tables/ 8 6-persons tables/ 5 8-persons table*/ 
//         while(!exit)
//         {
//             Console.WriteLine(@"Choose a table to reserve:(1-4)
// 1) 2 persons table
// 2) 4 persons table
// 3) 6 persons table
// 4) 8 persons table");
//             choice = Console.ReadLine();
//             switch (choice)
//             {
//                 case "1":
//                     Console.WriteLine("You have chosen: '2 persons table'");
//                     Sure(); // nodig om de user te vragen als ie zeker is van hen keuze
//                     break;
//                 case "2":
//                     System.Console.WriteLine("You have chosen: '4 persons table'");
//                     Sure();
//                     break;
//                 case "3":
//                     System.Console.WriteLine("You have chosen: '6 persons table'");
//                     Sure();
//                     break;
//                 case "4":
//                     System.Console.WriteLine("You have chosen: '8 persons table'");
//                     Sure();
//                     break;
//                 default:
//                     System.Console.WriteLine("invalid choice. Please try again!");
//                     break;
//             }
//         }
//     }
//     public static void PrintList()
//     {
//         /* onderstaande code schrijft een lijstje van tafels en hen fields in de console*/
//         foreach (Tables table in TableTracker)
//         {
//             Console.WriteLine(table.ID);
//             Console.WriteLine(table.Type);
//             Console.WriteLine(table.Reserved);
//             Console.WriteLine("#########");
//         }
//         System.Console.WriteLine("unreserved tables: " + TableTracker.Count);
        
//     }
//     public static void FindAndReserve(string tabletype)
//     {
//         /*
//         de method find de eerste instantie van een tafel met de correct type
//         en maakt de field Reserved naar true.
//         */
//         var found = TableTracker.Find(x => x.Type.Contains(tabletype));
//         // Console.WriteLine("table reserved status " + found.Reserved);
//         found.Reserved = true;
//         PrintList();
//     }
//     public static void Sure()
//     {
//         Console.WriteLine("Are you sure?(y/n)");
//         string sure = Console.ReadLine().ToLower();
//         switch(sure)
//         {
//             case "y":
//                 Console.WriteLine("Thank you!");
//                 if (choice == "1")
//                 {
//                     FindAndReserve(ChoicesOfTableAvailable[0]);
//                 }
//                 else if (choice == "2")
//                 {
//                     FindAndReserve(ChoicesOfTableAvailable[1]);
//                 }
//                 else if (choice == "3")
//                 {
//                     FindAndReserve(ChoicesOfTableAvailable[2]);
//                 }
//                 else if (choice == "4")
//                 {
//                     FindAndReserve(ChoicesOfTableAvailable[3]);
//                 }
//                 exit = true;
//                 break;
//             case "n":
//                 break;
//             default:
//                 System.Console.WriteLine("Invalid choice try again");
//                 break;
//         }
//     }
//     public static void PopulateTables()
//     {
//         for (int i = 1; i <= 17; i++)
//         {
//             TableTracker.Add(new Tables(i, "2 persons table"));
//         }
//         for (int j = 18; j <= 27; j++)
//         {
//             TableTracker.Add(new Tables(j, "4 persons table"));
//         }
//         for (int j = 28; j <= 35; j++)
//         {
//             TableTracker.Add(new Tables(j, "6 persons table"));
//         }
//         for (int k = 36; k <= 40; k++)
//         {
//             TableTracker.Add(new Tables(k, "8 persons table"));
//         }
//     }
// }