//YX BELOW

public class PaymentGateway
{
    public bool VerifyPaymentInformation(string cardDetails)
    {
        // Check if card details are valid
        return ValidateCard(cardDetails);
    }

    public bool ProcessPaymentTransaction(Payment payment)
    {
        payment.ProcessPayment();
        return payment.IsSuccessful;
    }

    public static bool ValidateCard(string cardDetails)
    {
        var validCards = new HashSet<string>
        {
            "1234", // Example credit card number
            "4321432143214321", // Example credit card number
            "340000000000009",  // Example credit card number
            "30000000000004"    // Example credit card number
        };

        return validCards.Contains(cardDetails);
    }
}