using System.Text.Json.Serialization;
public class ReservationDataModel
// [{Date: {"datum":{{}, {}, {}, {}}, {"datum": {{}, ...}}]
{
    [JsonPropertyName("Table")]
    public Tables Table {get; set;}

    [JsonPropertyName("Guest ID")]
    public int GuestID {get; set;}

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

    public ReservationDataModel(Tables Table, int gastID, string date, string firstName, string lastName, string emailAddress, string phoneNumber)
    {
        this.Table = Table;
        GuestID = gastID;
        FirstName = firstName;
        LastName = lastName;
        Date = date;
        EmailAddress = emailAddress;
        PhoneNumber = phoneNumber;
    }
}
