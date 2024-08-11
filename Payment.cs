//YX BELOW
public enum PaymentType
{
    CreditCard,
    DebitCard,
    DigitalWallet
}

public class Payment
{
    public int PaymentId { get; set; }
    public decimal Amount { get; set; }
    public DateTime PaymentDate { get; set; }
    public PaymentType PaymentMethod { get; set; }
    public bool IsSuccessful { get; set; }

    public Payment(int paymentId, PaymentType paymentMethod, decimal amount, bool isSuccessful)
    {
        PaymentId = paymentId;
        PaymentMethod = paymentMethod;
        Amount = amount;
        PaymentDate = DateTime.Now;
        IsSuccessful = isSuccessful;
    }

    public void ProcessPayment()
    {
        // Simulate payment processing
        Console.WriteLine($"Processing payment of ${Amount} using {PaymentMethod}...");
        // Assume payment is always successful if amount matches booking cost
        IsSuccessful = true;
    }

    public void RecordPaymentTransaction()
    {
        // Record the payment transaction details
        Console.WriteLine($"Payment transaction recorded: Amount: ${Amount}, Method: {PaymentMethod}, Date: {PaymentDate.ToShortDateString()}");
    }
}

// Xavier Lian 
public class PaymentService
{
    private readonly string validCardNumber = "4111111111111111"; // Visa test number
    private readonly string validExpiryDate = "12/2030"; // A future expiry date
    private readonly string validCVV = "123"; // A commonly used CVV for testing

    public bool VerifyCardDetails(string cardNumber, string expiryDate, string cvv)
    {
        return IsValidCardNumber(cardNumber) && !IsCardExpired(expiryDate) && IsValidCVV(cvv) && AreDetailsPredefinedValid(cardNumber, expiryDate, cvv);
    }

    private bool AreDetailsPredefinedValid(string cardNumber, string expiryDate, string cvv)
    {
        return cardNumber == validCardNumber && expiryDate == validExpiryDate && cvv == validCVV;
    }

    private bool IsValidCardNumber(string cardNumber)
    {
        return cardNumber.Length == 16;
    }

    private bool IsCardExpired(string expiryDate)
    {
        DateTime expiry;
        if (DateTime.TryParse(expiryDate, out expiry))
        {
            return DateTime.Now > expiry;
        }
        return false;
    }

    private bool IsValidCVV(string cvv)
    {
        return cvv.Length == 3;
    }

    public bool ProcessPayment(double amount)
    {
        Console.WriteLine($"Processing payment: {amount}");
        return true;
    }

    public bool ProcessPaymentViaPayNow(double amount, string mobileNumber)
    {
        Console.WriteLine($"Processing PayNow payment of {amount} to mobile {mobileNumber}");
        return true;
    }
}