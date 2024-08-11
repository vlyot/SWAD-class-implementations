 public class Booking
    {
        //Ng Kai Chong
        public int BookingID { get; set; }
        public int RenterID { get; set; }
        public int CarID { get; set; }
        public DateTime PickupDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public double Price { get; set; }
        public string PaymentInfo { get; set; }
        public string BookingStatus { get; set; }
        public string Feedback { get; set; }

//Constructor - Global
public Booking(int bookingID, int renterID, int carID, DateTime pickupDate, DateTime returnDate, double price, string paymentInfo, string bookingStatus, string feedback)
{
    BookingID = bookingID;
    RenterID = renterID;
    CarID = carID;
    PickupDate = pickupDate;
    ReturnDate = returnDate;
    Price = price;
    PaymentInfo = paymentInfo;
    BookingStatus = bookingStatus;
    Feedback = feedback;
}

//Methods - Ng Kai Chong
        public Car GetCarDetails(BookingController bookingController)
        {
            return bookingController.GetCar(CarID);
        }
    }



    //YX BELOW
    public class Booking
{
    public int BookingId { get; set; }
    public string CarType { get; set; }
    public DateTime BookingDate { get; set; }
    public decimal Cost { get; set; }

    public Booking(int bookingId, string carType, DateTime bookingDate, decimal cost)
    {
        BookingId = bookingId;
        CarType = carType;
        BookingDate = bookingDate;
        Cost = cost;
    }

    public override string ToString()
    {
        return $"Booking ID: {BookingId}, Car Type: {CarType}, Date: {BookingDate.ToShortDateString()}, Cost: ${Cost}";
    }
}