static class ReservedTable
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
        for (int k = 15; k <= 16; k++)
        {
            TableTracker.Add(new Tables(Convert.ToString(k), "6 persons table"));
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
                // bool Loop = true;
                int ToReserve;
                do
                {
                    if (ToBeSeated >= 6)
                    {
                        Console.WriteLine($"Choose a Table to reserve(1-3):");
                        Console.WriteLine($"1) 2 persons table");
                        Console.WriteLine($"2) 4 persons table");
                        Console.WriteLine($"3) 6 persons table");
                    }
                    else if (ToBeSeated >= 3)
                    {
                        Console.WriteLine($"Choose a Table to reserve(1-3):");
                        Console.WriteLine($"1) 2 persons table");
                        Console.WriteLine($"2) 4 persons table");
                    }
                    else if (ToBeSeated >= 1)
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
                        ToReserve = Convert.ToInt16(answer);
                        TableTypes.Add(ToReserve);
                    }
                    else if (answer == "2")
                    {
                        ToBeSeated -= 4;
                        Console.WriteLine("Thank you!");
                        ToReserve = Convert.ToInt16(answer);
                        TableTypes.Add(ToReserve);
                    }
                    else if(answer == "1")
                    {
                        ToBeSeated -= 2;
                        Console.WriteLine("Thank you!");
                        ToReserve = Convert.ToInt16(answer);
                        TableTypes.Add(ToReserve);
                    }
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
    public static void CheckIfTableReserved(int day, int month){
        // zet tafels in alle dagen van het jaar op vol als ze dat zijn
        string time = "10:00";
        int TimeCount = 0; // kijkt of tijdstip vol is
        foreach (Tables table in TableTracker)
        {
            // kijk hier na of alle tafles op die tijdstip vol zijn
            if (ReservationLogic.CheckReservedTable(table.ID, $"{day}/{month}/2024", time))
            {
                table.IsReserved();
                TimeCount++; //checked aantal gereserveerde tafels op die dag
            }
            if (TimeCount >= TableTracker.Count){
                DisplayDayList.GiveListBasedOnDay(day, month).Remove(time);
               //Remove from list 
            }
            // if (DayCount >= TableTracker.Count)
            // {
            //     DisplayMonthList.MonthList.Remove(day);
            // } ----> GEBEURD IN DisplayDayList

            switch (time){
                case "10:00":
                time = "10:30";
                break;
                case "10:30":
                time = "11:00";
                break;
                case "11:00":
                time = "11:30";
                break;
                case "11:30":
                time = "12:00";
                break;
                case "12:00":
                time = "12:30";
                break;
                case "12:30":
                time = "13:00";
                break;
                case "13:00":
                time = "13:30";
                break;
                case "13:30":
                time = "14:00";
                break;
                case "14:30":
                time = "15:00";
                break;
                case "15:00":
                time = "15:30";
                break;
                case "15:30":
                time = "16:00";
                break;
                case "16:00":
                time = "16:30";
                break;
                case "16:30":
                time = "17:00";
                break;
            }
        }
    }   

}
