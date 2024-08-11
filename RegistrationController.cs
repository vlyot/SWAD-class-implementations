// Evan Goh

    public class RegistrationController
    {
        private static readonly string presetEmail = "evan@gmail.com";
        private static readonly string presetPassword = "E123";

        public bool ValidateEmailAndPassword(string email, string password)
        {
            // Logic to validate email and password
            return email == presetEmail && password == presetPassword;
        }

        public bool ValidateVehicleRegistrationNumber(string vehicleRegNo)
        {
            // Logic to validate vehicle registration number
            return true;
        }

        public bool ValidateAvailabilityCapacityScheduleType(string availability, int capacity, string schedule, string type)
        {
            // Logic to validate availability, capacity, schedule, and type
            return true;
        }

        public void FinalReviewAndSaveInformation(CarOwner carOwner, Vehicle vehicle)
        {
            // Logic to perform final review and save information
            Console.WriteLine("Final review completed. Information saved.");
        }

        public void SendVerificationEmail(string email)
        {
            // Logic to send verification email
            // Console.WriteLine($"Verification email sent to {email}"); // Removed
        }
    }
