class CheckReservationInfo
{
    // Check of alle characters in voornaam letter zijn
    public static bool CheckFirstName(string FirstName)
    {
        if (string.IsNullOrEmpty(FirstName))
        {
            Console.WriteLine("*You must fill something in.");
            return false;
        }
        foreach(char letter in FirstName)
        {
            if (!Char.IsLetter(letter))
            {
                Console.WriteLine("*Your first name must only contain letters.");
                return false;
            }
        }
        return true;
    }

    // check of alle characters in achternaam letters zijn
    public static bool CheckLastName(string LastName)
    {
        if (string.IsNullOrEmpty(LastName))
        {
            Console.WriteLine("*You must fill something in.");
            return false;
        }
        foreach(char letter in LastName)
        {
            if (!Char.IsLetter(letter))
            {
                if (!Char.IsWhiteSpace(letter)){
                Console.WriteLine("*Your last name must only contain letters.");
                return false;
                }
            }
        }
        return true;
    }

    // check of alle characters in telefoonnummer nummers zijn
    // telefoon nummer moet niet kleiner of groter zijn dan 10
    public static bool CheckPhoneNumber(string PhoneNumber)
    {
        if (string.IsNullOrEmpty(PhoneNumber))
        {
            System.Console.WriteLine("*You must fill something in.");
            return false;
        }
        foreach(char number in PhoneNumber)
        {
            if (!Char.IsNumber(number))
            {
                System.Console.WriteLine("*Your phone number must only contain numbers.");
                return false;
            }
        }
        if (PhoneNumber.Length != 10)
        {
            System.Console.WriteLine("*Your phone number must contain 10 numbers.");
            return false;
        }
        return true;
    }

    // check of emailadres een '@' en '.' bevat
    // ook nog met yahoo, gmail, hotmail etc etc dat moet ook nog containen
    public static bool CheckEmailAddress(string EmailAddress)
    {
        if (EmailAddress.Contains("@") && EmailAddress.Contains("."))
        {
            return true;
        }
        else
        {
            System.Console.WriteLine("*Your email address must contain '@' and '.'");
            return false;
        }
    }

// Check ook of de maand nog niet voorbij is he
    public static bool CheckChosenMonth(string ChosenMonth)
    {
        if (string.IsNullOrEmpty(ChosenMonth))
        {
            System.Console.WriteLine("*You must fill something in.");
            return false;
        }
        try{
            Convert.ToInt32(ChosenMonth);
        }
        catch (Exception){
            System.Console.WriteLine($"*'{ChosenMonth}' is not a valid number.");
            return false;
        }
        if (Convert.ToInt32(ChosenMonth) < DateTime.Now.Month)
        {
            System.Console.WriteLine("*This month comes before the current month.");
            return false;
        }
        return true;   
    }
    public static bool CheckChosenDay(string ChosenDay, int ChosenMonth)
    {
        if (string.IsNullOrEmpty(ChosenDay))
        {
            System.Console.WriteLine("*You must fill something in.");
            return false;
        }
            // dit gaat later according to month
            // zegmaar februari 28, andere maanden 30, andere maanden tot 31 als je het snapt
            try{
                Convert.ToInt32(ChosenDay);
            }
            catch (Exception){
                System.Console.WriteLine($"*'{ChosenDay}' is not a valid number.");
                return false;
            }
            if (Convert.ToInt32(ChosenDay) < DisplayMonthList.GiveListBasedOnMonth(ChosenMonth)[1])
            {
                System.Console.WriteLine("*That is not a valid number.");
                return false;
            }
            else if (Convert.ToInt32(ChosenDay) > DisplayMonthList.GiveListBasedOnMonth(ChosenMonth)[DisplayMonthList.GiveListBasedOnMonth(ChosenMonth).Count - 1])
            {
                System.Console.WriteLine("*That is not a valid number.");
                return false;
            }
            return true; 
        }

        public static bool CheckGuests(string Guests)
        {
            try{
                Convert.ToInt32(Guests);
            }
            catch(Exception)
            {
                System.Console.WriteLine("*You must only type in numbers.");
                return false;
            }
            return true;
        }
    }
