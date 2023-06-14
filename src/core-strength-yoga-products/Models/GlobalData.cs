namespace core_strength_yoga_products.Models;

public static class GlobalData
{
    public static string Username { get; set; }
    public static string JWT { get; set; }
    public static bool isSignedIn { get; set; }

    public static void EndSession()
    {
        // Logic to end the session
        Username = null;
        JWT = null;
        isSignedIn = false;
    }
    
}

