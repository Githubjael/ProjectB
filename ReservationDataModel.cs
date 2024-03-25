using System.Text.Json.Serialization;
class ReservationDataModel
// [{Date: {"datum":{{}, {}, {}, {}}, {"datum": {{}, ...}}]
{
    [JsonPropertyName("Guest ID")]
    public int GuestID {get; set;}

    [JsonPropertyName("Table ID")]
    public int TableID {get; set;}

    [JsonPropertyName("Date")]
    public string Date {get; set;}

    [JsonPropertyName("First name")]
    public string FirstName {get; set;}

    [JsonPropertyName("Last name")]

    public string LastName {get; set;}

    [JsonPropertyName("Email address")]
    public string EmailAddress {get; set;}

    [JsonPropertyName("Phone number")]
    public string PhoneNumber {get; set;}

    public ReservationDataModel(int guestID, int tableID, string date, string firstName, string lastName, string emailAddress, string phoneNumber)
    {
        GuestID = guestID;
        TableID = tableID;
        FirstName = firstName;
        LastName = lastName;
        Date = date;
        EmailAddress = emailAddress;
        PhoneNumber = phoneNumber;
    }
}
