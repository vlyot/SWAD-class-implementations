// BookingController - Ng Kai Chong ONLY - responsible for the business logic 
//related to managing bookings. It includes methods that manipulate Booking instances, 
//such as creating, updating, retrieving, and deleting bookings.

public class BookingController
    {
        private List<Booking> bookings;
        private List<Car> cars;

        public BookingController(List<Booking> bookings, List<Car> cars)
        {
            this.bookings = bookings;
            this.cars = cars;
        }

        public void AddCar(Car car)
        {
            cars.Add(car);
        }

            public Car GetCar(int carID)
    {
        return cars.FirstOrDefault(c => c.CarID == carID);
    }

        public List<Car> SearchCars(string location, string carType, double minPrice, double maxPrice, bool? isAvailable)
        {
            return cars.Where(car =>
                (string.IsNullOrEmpty(location) || car.Location.Equals(location, StringComparison.OrdinalIgnoreCase)) &&
                (string.IsNullOrEmpty(carType) || car.CarType.Equals(carType, StringComparison.OrdinalIgnoreCase)) &&
                car.PricePerDay >= minPrice && car.PricePerDay <= maxPrice &&
                (!isAvailable.HasValue || car.IsAvailable == isAvailable.Value)
            ).ToList();
        }

        public double CalculatePrice(int carID, DateTime pickupDate, DateTime returnDate)
        {
            Car car = cars.FirstOrDefault(c => c.CarID == carID);
            if (car != null)
            {
                TimeSpan rentalPeriod = returnDate - pickupDate;
                return rentalPeriod.TotalDays * car.PricePerDay;
            }
            return 0;
        }

        public Booking CreateBooking(int renterID, int carID, DateTime pickupDate, DateTime returnDate, string paymentInfo)
        {
            double price = CalculatePrice(carID, pickupDate, returnDate);
            Booking newBooking = new Booking(Program.nextBookingID++, renterID, carID, pickupDate, returnDate, price, paymentInfo, "Confirmed", "");
            bookings.Add(newBooking);
            UpdateCarAvailability(carID, false);
            return newBooking;
        }

        public Booking GetBooking(int bookingID)
        {
            return bookings.FirstOrDefault(b => b.BookingID == bookingID);
        }


        
        public void UpdateRentalRate(int carID, double newRate)
        {
            Car car = cars.FirstOrDefault(c => c.CarID == carID);
            if (car != null)
            {
                car.PricePerDay = newRate;
            }
        }

        public void UpdateCarAvailability(int carID, bool isAvailable)
        {
            Car car = cars.FirstOrDefault(c => c.CarID == carID);
            if (car != null)
            {
                car.IsAvailable = isAvailable;
            }
        }

        public void WithdrawCar(int carID)
{
    var carToRemove = cars.FirstOrDefault(c => c.CarID == carID);
    if (carToRemove != null)
    {
        cars.Remove(carToRemove);

        // Notify renters with upcoming bookings
        var upcomingBookings = bookings.Where(b => b.CarID == carID && b.PickupDate > DateTime.Now).ToList();
        foreach (var booking in upcomingBookings)
        {
            // You can replace this with actual notification logic
            Console.WriteLine($"Notification sent to renter with Booking ID: {booking.BookingID} about car withdrawal.");
            bookings.Remove(booking); // Remove the booking since the car is withdrawn
        }

        // Log the withdrawal
        Console.WriteLine($"Car ID: {carID} has been withdrawn from the platform.");

        // Update the cars file
        UpdateCarsFile();

        // Update the bookings file to remove associated bookings
        UpdateBookingHistoryFile();
    }
    else
    {
        Console.WriteLine("Car ID not found.");
    }
}

private void UpdateCarsFile()
{
    List<string> lines = new List<string>();
    foreach (var car in cars)
    {
        lines.Add($"{car.CarID},{car.Brand},{car.Model},{car.CarType},{car.PricePerDay},{car.Location},{car.IsAvailable}");
    }
    File.WriteAllLines("cars.txt", lines);
}

private void UpdateBookingHistoryFile()
{
    List<string> lines = new List<string>();
    foreach (var booking in bookings)
    {
        lines.Add($"{booking.BookingID},{booking.RenterID},{booking.CarID},{booking.PickupDate},{booking.ReturnDate},{booking.Price},{booking.PaymentInfo},{booking.BookingStatus},{booking.Feedback}");
    }
    File.WriteAllLines("bookingHistory.txt", lines);
}

    }