using System.Text.Json.Serialization;
class ReservationDataModel
{
    [JsonPropertyName("Guest ID")]
    public int GuestID {get; set;}

    [JsonPropertyName("Table ID")]
    public int TableID {get; set;}

    [JsonPropertyName("Date")]
    public string Date {get; set;}

    [JsonPropertyName("Email address")]
    public string EmailAddress {get; set;}

    [JsonPropertyName("Phone number")]
    public string PhoneNumber {get; set;}
    public ReservationDataModel(int guestID, int tableID, string date, string emailAddress, string phoneNumber)
    {
        GuestID = guestID;
        TableID = tableID;
        Date = date;
        EmailAddress = emailAddress;
        PhoneNumber = phoneNumber;
    }
}
