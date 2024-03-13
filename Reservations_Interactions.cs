public class Reservation{
    public string Name;
    public string Date;
    public string Time;

    public Reservation(string name, string date, string time)
    {
        Name = name;
        Date = date;
        Time = time;
    }

    public void MakeReservation(){
        System.Console.WriteLine("Succesfully made the reservation!");
        //save it somewhere

    }
}
