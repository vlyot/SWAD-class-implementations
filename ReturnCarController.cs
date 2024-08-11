// Xavier Lian
public class ReturnCarController
{
    private readonly List<string> iCarStations = new List<string>
    {
        "Downtown Station",
        "Airport Station",
        "Mall Station"
    };

    private readonly string unavailableStation = "Mall Station"; // Example of an unavailable station
    private readonly string availablePreferredLocation = "Tampines"; // Preferred location

    public bool CheckLocationCapacity(string location)
    {
        // Return true if the location is not the specific unavailable station or if it's the valid preferred location
        return !(location == unavailableStation || (location != availablePreferredLocation && !iCarStations.Contains(location)));
    }

    public void DisplayLocationAvailability(bool isAvailable)
    {
        Console.WriteLine(isAvailable ? "Location is available" : "Location is full, please choose another one");
    }

    public bool ValidateReturnCarTime(DateTime returnTime)
    {
        // Just a stub - in real implementation, compare with booking times
        return returnTime <= DateTime.Now;
    }

    public double CalculateDamageFees(Car car, string notesForDamage)
    {
        // Placeholder for damage fee calculation
        return notesForDamage.Length * 10; // Simplified calculation
    }

    public void NotifyCarOwner(Car car, double fees)
    {
        Console.WriteLine($"Notifying car owner about the return of car {car.Model} with fees {fees}");
    }

    public string GetReturnLocation()
    {
        Console.WriteLine("Choose return location:");
        Console.WriteLine("1. iCar Station");
        Console.WriteLine("2. Preferred Location");
        Console.Write("Select an option (1 or 2): ");
        string choice = Console.ReadLine();

        if (choice == "1")
        {
            while (true)
            {
                Console.WriteLine("Choose an iCar Station:");
                for (int i = 0; i < iCarStations.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {iCarStations[i]}");
                }

                Console.Write("Select an iCar Station (1, 2, or 3): ");
                string stationChoice = Console.ReadLine();
                string selectedStation = null;

                if (stationChoice == "1")
                {
                    selectedStation = iCarStations[0];
                }
                else if (stationChoice == "2")
                {
                    selectedStation = iCarStations[1];
                }
                else if (stationChoice == "3")
                {
                    selectedStation = iCarStations[2];
                }
                else
                {
                    Console.WriteLine("Invalid choice, please select a valid iCar Station.");
                    continue; // Prompt the user again if the choice is invalid
                }

                if (!CheckLocationCapacity(selectedStation))
                {
                    Console.WriteLine("Location is full, please choose another one.");
                    continue; // Allow the user to choose another location
                }

                Console.WriteLine($"Location '{selectedStation}' is available.");
                return selectedStation;
            }
        }
        else if (choice == "2")
        {
            while (true)
            {
                Console.Write("Enter preferred location: ");
                string preferredLocation = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(preferredLocation))
                {
                    Console.WriteLine("Location cannot be empty.");
                    continue;
                }

                if (CheckLocationCapacity(preferredLocation))
                {
                    Console.WriteLine($"Preferred location '{preferredLocation}' is available.");
                    return preferredLocation;
                }
                else
                {
                    Console.WriteLine("Location is full, please choose another one.");
                }
            }
        }
        else
        {
            Console.WriteLine("Invalid choice, defaulting to Downtown Station.");
            return iCarStations[0]; // Default option if the choice is invalid
        }
    }


}