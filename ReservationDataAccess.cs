using Newtonsoft.Json;

class ReservationDataAccess
{
    // voor nu schrijven we alle reservations naar json
    // er wordt nog niet nagekeken of de dagen/maanden/tafels etc etc available zijn 
    // en reservations kunnen nog niet worden geannuleerd
    public static void WriteToJson(List<ReservationDataModel> ReservationList)
    {
        string fileName = @"C:\Users\User\Documents\Project-B\Reservations.Json";
        // write to json
        StreamWriter writer = new(fileName);
        string List2Json = JsonConvert.SerializeObject(ReservationList);
        writer.Write(List2Json);
        writer.Close();
        // write to json
    }
}
