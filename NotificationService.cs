    public static class NotificationService
    {
        //methods - ng kai chong
        public static void Notify(int renterID, int carOwnerID, string message)
        {
            Console.WriteLine($"Notification to Renter (ID: {renterID}): {message}");
            Console.WriteLine($"Notification to Car Owner (ID: {carOwnerID}): {message}");
        }
    }