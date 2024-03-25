class CheckReservationInfo
{
    // Check of alle characters in voornaam letter zijn
    public static bool CheckFirstName(string FirstName)
    {
        foreach(char letter in FirstName)
        {
            if (!Char.IsLetter(letter))
            {
                return false;
            }
        }
        return true;
    }

    // check of alle characters in achternaam letters zijn
    public static bool CheckLastName(string LastName)
    {
        foreach(char letter in LastName)
        {
            if (!Char.IsLetter(letter))
            {
                return false;
            }
        }
        return true;
    }

    // check of alle characters in telefoonnummer nummers zijn

    public static bool CheckPhoneNumber(string PhoneNumber)
    {
        foreach(char number in PhoneNumber)
        {
            if (!Char.IsNumber(number))
            {
                return false;
            }
        }
        return true;
    }

    // check of emailadres een '@' en '.' bevat

    public static bool CheckEmailAddress(string EmailAddress)
    {
        if (EmailAddress.Contains("@") && EmailAddress.Contains("."))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
