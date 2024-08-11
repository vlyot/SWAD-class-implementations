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