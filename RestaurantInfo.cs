public class RestaurantInfo{
    public string Adress{get; set;}
    public string Email{get; set;}
    public int Phone_number{get; set;}

    public RestaurantInfo(string adress, string email, int phone_number)
    {
        this.Adress = adress;
        this.Email = email;
        this.Phone_number = phone_number;
    }

}