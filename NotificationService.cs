public static class NotificationService
{
    //methods - ng kai chong
    public static void Notify(int renterID, int carOwnerID, string message)
    {
        Console.WriteLine($"Notification to Renter (ID: {renterID}): {message}");
        Console.WriteLine($"Notification to Car Owner (ID: {carOwnerID}): {message}");
    }
    // methods - evan goh
    public void SendSuccessNotification(string email)
    {
        // Logic to send success notification
        Console.WriteLine($"Success notification sent to {email}");
    }

    // methods - Xavier Lian 
    public class NotificationService
    {
        public void SendReturnCarSuccessNotification(Renter renter)
        {
            Console.WriteLine($"Return process completed successfully for renter: {renter.Email}");
        }
    }
}




//YX BELOW

public class Notification
{
    public void SendPaymentSuccess(string recipient)
    {
        Console.WriteLine($"Payment confirmation sent to {recipient}.");
    }
}