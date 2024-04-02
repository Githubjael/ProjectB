class ReservedTable
{

    public static List<Tables> TableTracker = new List<Tables>() { }; // nodig om alle tafels op een lijstje te hebben en om staus binnen de tafels te veranderen

    public static void PopulateTables() // deze moet in Reservations logische laag + info halen over gereserveerde tafels uit json
    {
        for (int i = 1; i <= 8; i++)
        {
            TableTracker.Add(new Tables(Convert.ToString(i), "2 persons table"));
        }
        for (int j = 9; j <= 14 ; j++)
        {
            TableTracker.Add(new Tables(Convert.ToString(j), "4 persons table"));
        }
        for (int j = 15; j <= 16; j++)
        {
            TableTracker.Add(new Tables(Convert.ToString(j), "6 persons table"));
        }
    }
    public static List<Tables> AssignTable(int AmountOfGuests)
    {
            // tableAssignments.Add(guestID, tableID);
            // Maak hier een functie van in ReservedTable.cs!!!!!!
            List<Tables> ChosenTables = new List<Tables>();
                int ToBeSeated = AmountOfGuests;
                List<int> TableTypes = new List<int>()
                {
                    Capacity = 2
                };
                bool Loop = true;
                int ToReserve;
                do
                {
                    if (ToBeSeated > 6)
                    {
                        Console.WriteLine($"Choose a Table to reserve(1-3):");
                        Console.WriteLine($"1) 2 persons table");
                        Console.WriteLine($"2) 4 persons table");
                        Console.WriteLine($"3) 6 persons table");
                    }
                    else if (ToBeSeated < 6)
                    {
                        Console.WriteLine($"Choose a Table to reserve(1-3):");
                        Console.WriteLine($"1) 2 persons table");
                        Console.WriteLine($"2) 4 persons table");
                    }
                    else if (ToBeSeated < 3)
                    {
                        Console.WriteLine($"Choose a Table to reserve(1-3):");
                        Console.WriteLine($"1) 2 persons table");
                    }
                    string answer = Console.ReadLine();
                    if (string.IsNullOrEmpty(answer))
                    {
                        Console.WriteLine("Invalid input. You must enter '1', '2', '3' .");
                    }
                    else if(answer != "1" && answer != "2" && answer != "3")
                    {
                        Console.WriteLine("Invalid input. You must enter '1', '2', '3' .");
                    }
                    if (answer == "3")
                    {
                        ToBeSeated -= 6;
                        Console.WriteLine("Thank you!");
                    }
                    else if (answer == "2")
                    {
                        ToBeSeated -= 4;
                        Console.WriteLine("Thank you!");
                    }
                    else if(answer == "1")
                    {
                        ToBeSeated -= 2;
                        Console.WriteLine("Thank you!");
                    }
                    ToReserve = Convert.ToInt16(answer);
                    TableTypes.Add(ToReserve);
                } while(ToBeSeated > 0);
                foreach(int type in TableTypes)
                {
                    var tabletype = type switch
                    {
                        1 => "2 persons table",
                        2 => "4 persons table",
                        3 => "6 persons table",
                    };
                    var found = TableTracker.Find(x => x.Type.Contains(tabletype) && x.Reserved == false);
                    found.Reserved = true;
                    ChosenTables.Add(found);
                }
            return ChosenTables;
    }
    public static void CheckIfTableReserved(int month){
        // zet tafels in alle dagen van het jaar op vol als ze dat zijn
        int day = 1;
        int Count = 1;
        foreach (Tables table in TableTracker)
        {
            // kijk hier na of alle tafles op die datum vol zijn
            if (ReservationLogic.CheckReservedTable(table.ID, $"{day}/{month}/2024"))
            {
                table.IsReserved();
                Count++; //checked aantal gereserveerde tafels op die dag
            }
            if (Count == TableTracker.Count)
            {
                DisplayMonthList.MonthList.Remove(day);
            }
            if (day == DateTime.DaysInMonth(DateTime.Now.Year, month)){
                break;
            }
            day++;
        }
    }   

}
