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
