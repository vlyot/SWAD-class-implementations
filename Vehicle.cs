// Evan Goh
{
    public class Vehicle
{
    public string RegistrationNumber { get; set; }
    public bool IsVerified { get; set; }
    public List<Booking> Bookings { get; set; } = new List<Booking>();

    public bool HasScheduleClash(string newSchedule)
    {
        var newTimes = newSchedule.Split('-');
        var newStart = TimeSpan.Parse(newTimes[0]);
        var newEnd = TimeSpan.Parse(newTimes[1]);

        foreach (var booking in Bookings)
        {
            var times = booking.Schedule.Split('-');
            var start = TimeSpan.Parse(times[0]);
            var end = TimeSpan.Parse(times[1]);

            if ((newStart < end) && (newEnd > start))
            {
                return true;
            }
        }

        return false;
    }
}

public class Booking
{
    public string Availability { get; set; }
    public int Capacity { get; set; }
    public string Schedule { get; set; }
    public string Type { get; set; }
}
}

//Xavier Lian 
public class Car
{
    public int CarId { get; set; }
    public string Model { get; set; }
    public string VehicleType { get; set; }
}