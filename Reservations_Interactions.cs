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

    public void MakeReservation(){
        System.Console.WriteLine("Succesfully made the reservation!");
        //save it somewhere
        //round sizeparty up to 2, 4 or 6
        //if higher make it into multible reservations
        //for example if sizeparty is 10 table is 6 and 4
        //if sizeparty is 11 table is 6 and 6


    }
}
