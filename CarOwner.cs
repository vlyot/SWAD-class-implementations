// Evan Goh
    
{
    public class CarOwner
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public Dashboard Dashboard { get; set; }

        public void InputEmailAndPassword(string email, string password)
        {
            Email = email;
            Password = password;
        }

        public void InputVehicleRegistrationNumber(string vehicleRegNo)
        {
            // Logic to input vehicle registration number
        }

        public void InputVehicleInformation(string availability, int capacity, string schedule, string type)
        {
            // Logic to input vehicle information
        }
    }
}
