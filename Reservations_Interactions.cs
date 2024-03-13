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

    }
}
