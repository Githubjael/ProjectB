using System.Text.Json;

static class AccountsAccess
{
    private static string _path = Path.GetFullPath(
        Path.Combine(Environment.CurrentDirectory, @"DataSources/accounts.json"));

    public static List<AccountModel> LoadAll()
    {
        string json = File.ReadAllText(_path);
        return JsonSerializer.Deserialize<List<AccountModel>>(json);
    }

    public static void WriteAll(List<AccountModel> accounts)
    {
        var options = new JsonSerializerOptions { WriteIndented = true };
        string json = JsonSerializer.Serialize(accounts, options);
        File.WriteAllText(_path, json);
    }
}
