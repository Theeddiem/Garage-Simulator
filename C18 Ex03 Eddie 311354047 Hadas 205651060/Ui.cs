using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ex03.GarageLogic;

namespace C18_Ex03_Eddie_311354047_Hadas_205651060
{
    public class Ui
    {
        private const string k_TryAgainMsg = "not a good input, please enter again:";
        private const string k_NoVehiclesMsg = "There are no vehicles in the garage";
        private Garage m_Garage;

        public Ui()
        {
            m_Garage = new Garage();
        }

        public void Run()
        {
            const string menu = @"Hello, What would you like to do?
1) Add a new vehicle to the garage
2) Show all vehicles in the garage
3) Change state of a vehicle in the garage
4) Inflate wheels to maximum
5) Fill fuel for a vehicle
6) Charage battery for a vehicle
7) Show Information about a specific vehicle
Q To Exit";
            Console.WriteLine(menu);
            bool running = chooseOption();

            while (running)
            {
                bool toContinue = backToMenu();

                if (toContinue)
                {
                    Console.WriteLine(menu);
                    running = chooseOption();
                }
                else
                {
                    break;
                }
            }

            Console.WriteLine("Goodbye!");
        }

        private bool backToMenu()
        {
            bool toContinue;

            Console.WriteLine("Would you like to go back to the menu? if yes write true else false ");
            while (!bool.TryParse(Console.ReadLine(), out toContinue))
            {
                Console.WriteLine(k_TryAgainMsg);
            }

            Console.Clear();

            return toContinue;
        }

        private bool chooseOption()
        {
            bool running = true;
            switch (Console.ReadLine())
            {
                case "1":
                    Console.Clear();
                    addAVehicleToGarage();
                    break;
                case "2":
                    Console.Clear();
                    showAllVehiclesInGarage();
                    break;
                case "3":
                    Console.Clear();
                    changeStateOfVehicleInGarage();
                    break;
                case "4":
                    Console.Clear();
                    inflateWheelsToMax();
                    break;
                case "5":
                    Console.Clear();
                    fillFuelForVehicle();
                    break;
                case "6":
                    Console.Clear();
                    charageBatteryForVehicle();
                    break;
                case "7":
                    Console.Clear();
                    showInfoSpecificVehicle();
                    break;
                case "Q":
                case "q":
                    running = false;
                    break;
                default:
                    Console.WriteLine(k_TryAgainMsg);
                    chooseOption();
                    break;
            }

            return running;
        }

        private string getCustomerLicenseNumber()
        {
            Console.WriteLine("please enter License number:");
            string licenseNumber = Console.ReadLine();

            return licenseNumber;
        }

        private bool checkIfUserWantToTryAagain()
        {
            Console.WriteLine("would you like to try again? if yes write true else write false");
            bool tryAgain;

            while (!bool.TryParse(Console.ReadLine(), out tryAgain))
            {
                Console.WriteLine(k_TryAgainMsg);
            }

            return tryAgain;
        }

        private string findVehicleInGarage()
        {
            bool trying = true;
            string licenseNumber = null;
            if (m_Garage.VehiclsInGarage != null)
            {
                while (trying)
                {
                    try
                    {
                        licenseNumber = getCustomerLicenseNumber();
                        m_Garage.CheckIfVehicleExists(licenseNumber);
                        trying = false;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        trying = checkIfUserWantToTryAagain();
                        licenseNumber = null;
                    }
                }
            }

            return licenseNumber;
        }

        private void addAVehicleToGarage()
        {
            try
            {
                Vehicle vehicle = getVehicleFromUser();
                string name = getCustomerName();
                string phoneNumber = getCustomerPhoneNumber();
                GarageClient vehicleToGarage = new GarageClient(name, phoneNumber, vehicle);
                m_Garage.AddVehicleToGarage(vehicleToGarage);
                Console.WriteLine("Your Vehicle has been added to the garage!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private string getCustomerPhoneNumber()
        {
            Console.WriteLine("please enter customer Phone Number:");
            return Console.ReadLine();
        }

        private string getCustomerName()
        {
            Console.WriteLine("please enter customer name:");
            return Console.ReadLine();
        }

        private Vehicle getVehicleFromUser()
        {
            Vehicle vehicle = null;
            eVehicleType vehicleType = getCustomerVehicleType();
            bool isElectric = getCustomerEnergyType();
            bool VehicleIsSuppourted = checkSuppourtVehicle(vehicleType, isElectric);

            if (VehicleIsSuppourted)
            {
                string licenseNumber = getCustomerLicenseNumber();

                m_Garage.CheckIfVehicleNotExists(licenseNumber);
                string model = getVehicleModel();
                float energyPrectange = getEnergyPrectange();

                switch (vehicleType)
                {
                    case eVehicleType.Motorcycle:
                        vehicle = getInputForMotorcycle(isElectric, licenseNumber, model, energyPrectange);
                        break;
                    case eVehicleType.Car:
                        vehicle = getInputForCar(isElectric, licenseNumber, model, energyPrectange);
                        break;
                    case eVehicleType.Truck:
                        vehicle = getInputForTruck(licenseNumber, model, energyPrectange);
                        break;
                }
            }

            return vehicle;
        }

        private Vehicle getInputForMotorcycle(bool i_IsElectric, string i_LicenseNumber, string i_Model, float i_EnergyPrectange)
        {
            const int k_AmountOfWheelsInAMotorcyle = 2;
            const int k_MaxAirPressureInAMotorcyle = 28;

            List<Wheel> wheels = inputWheelsSet(k_AmountOfWheelsInAMotorcyle, k_MaxAirPressureInAMotorcyle);
            eMotorcycleLicenseType motorcycleLicenseType = getmotorcycleLicenseType();
            int engineCapacity = getEngineCapacity();

            return Creation.CreateMotorcycle(i_IsElectric, i_LicenseNumber, i_Model, i_EnergyPrectange, wheels, motorcycleLicenseType, engineCapacity);
        }

        private Vehicle getInputForCar(bool i_IsElectric, string i_LicenseNumber, string i_Model, float i_EnergyPrectange)
        {
            const int k_AmountOfWheelsInACar = 4;
            const int k_MaxAirPressureInACar = 30;

            List<Wheel> wheels = inputWheelsSet(k_AmountOfWheelsInACar, k_MaxAirPressureInACar);
            eCarColor carColor = getCarColor();
            eDoorsAmount doorsAmount = getDoorsAmount();

            return Creation.CreateCar(i_IsElectric, i_LicenseNumber, i_Model, i_EnergyPrectange, wheels, carColor, doorsAmount);
        }

        private Vehicle getInputForTruck(string i_LicenseNumber, string i_Model, float i_EnergyPrectange)
        {
            const int k_AmountOfWheelsInATruck = 16;
            const int k_MaxAirPressureInATruck = 32;

            List<Wheel> wheels = inputWheelsSet(k_AmountOfWheelsInATruck, k_MaxAirPressureInATruck);
            bool cabinIsCooled = getCabinState();
            float cabinCapacity = getcabinCapacity();

            return Creation.CreateTruck(i_LicenseNumber, i_Model, i_EnergyPrectange, wheels, cabinIsCooled, cabinCapacity);
        }

        private float getEnergyPrectange()
        {
            Console.WriteLine("Please enter current energy prectange in the vehicle");
            float energyPrectange;
            while (!float.TryParse(Console.ReadLine(), out energyPrectange) || energyPrectange < 0 || energyPrectange > 100)
            {
                Console.WriteLine(k_TryAgainMsg);
            }

            return energyPrectange;
        }

        private bool checkSuppourtVehicle(eVehicleType i_VehicleType, bool i_IsElectric)
        {
            if (i_VehicleType == eVehicleType.Truck && i_IsElectric)
            {
                throw new Exception("we suppourt only fuel truck");
            }

            return true;
        }

        private bool getCabinState()
        {
            bool cabinState;
            Console.WriteLine("Pleaser enter true if the cabin of the truck is cooled, else false");

            while (!bool.TryParse(Console.ReadLine(), out cabinState))
            {
                Console.WriteLine(k_TryAgainMsg);
            }

            return cabinState;
        }

        private float getcabinCapacity()
        {
            float cabinCapacity;
            Console.WriteLine("Enter the cabin capacity of the truck");

            while (!float.TryParse(Console.ReadLine(), out cabinCapacity) || cabinCapacity < 0)
            {
                Console.WriteLine(k_TryAgainMsg);
            }

            return cabinCapacity;
        }

        private eCarColor getCarColor()
        {
            Console.WriteLine("Please enter the car color");
            enumRequestMsg(typeof(eCarColor), 1);
            string inputCarColor = getInputForEnum(typeof(eCarColor));

            return (eCarColor)Enum.Parse(typeof(eCarColor), inputCarColor, true);
        }

        private eDoorsAmount getDoorsAmount()
        {
            Console.WriteLine("Please enter how many doors in the car");
            enumRequestMsg(typeof(eDoorsAmount), 2);
            string inputDoorsAmount = getInputForEnum(typeof(eDoorsAmount));

            return (eDoorsAmount)Enum.Parse(typeof(eDoorsAmount), inputDoorsAmount, true);
        }

        private List<Wheel> inputWheelsSet(int i_NumOfWheels, float i_MaxAirPresseure)
        {
            List<Wheel> wheelsList = new List<Wheel>();

            for (int i = 0; i < i_NumOfWheels; i++)
            {
                string wheelsManufactureName = getWheelManufactureName(i + 1);
                Wheel wheel = Creation.CreateWeel(wheelsManufactureName, i_MaxAirPresseure);
                bool inflate = false;

                while (!inflate)
                {
                    try
                    {
                        float wheelsCurrentAirPressure = getWheelsCurrentAirPressure(i + 1, i_MaxAirPresseure);
                        wheel.Inflating(wheelsCurrentAirPressure);
                        inflate = true;
                    }
                    catch (ValueOutOfRangeException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }

                wheelsList.Add(wheel);
            }

            return wheelsList;
        }

        private int getEngineCapacity()
        {
            Console.WriteLine("Enter Engine Capacity:");
            int engineCapacity;

            while (!int.TryParse(Console.ReadLine(), out engineCapacity) || engineCapacity < 0)
            {
                Console.WriteLine(k_TryAgainMsg);
            }

            return engineCapacity;
        }

        private eMotorcycleLicenseType getmotorcycleLicenseType()
        {
            enumRequestMsg(typeof(eMotorcycleLicenseType), 1);
            string inputLicenseTypeChoice = getInputForEnum(typeof(eMotorcycleLicenseType));

            return (eMotorcycleLicenseType)Enum.Parse(typeof(eMotorcycleLicenseType), inputLicenseTypeChoice, true);
        }

        private string getWheelManufactureName(int i_WheelNumber)
        {
            Console.WriteLine(string.Format("Enter wheel {0} manufacture name:", i_WheelNumber));
            return Console.ReadLine();
        }

        private float getWheelsCurrentAirPressure(int i_WheelNumber, float i_MaxAirPressure)
        {
            Console.WriteLine(string.Format("Enter Wheel {0} Air Pressure (max is {1}):", i_WheelNumber, i_MaxAirPressure));
            float currentAirPressure;

            while (!float.TryParse(Console.ReadLine(), out currentAirPressure))
            {
                Console.WriteLine(k_TryAgainMsg);
            }

            return currentAirPressure;
        }

        private string getVehicleModel()
        {
            Console.WriteLine("Enter Vehicle Model:");
            return Console.ReadLine();
        }

        private bool getCustomerEnergyType()
        {
            bool isElectric;

            Console.WriteLine("is it electric? if yes write true else write false");
            while (!bool.TryParse(Console.ReadLine(), out isElectric))
            {
                Console.WriteLine(k_TryAgainMsg);
            }

            return isElectric;
        }

        private eVehicleType getCustomerVehicleType()
        {
            enumRequestMsg(typeof(eVehicleType), 1);
            string inputVehicleType = getInputForEnum(typeof(eVehicleType));

            return (eVehicleType)Enum.Parse(typeof(eVehicleType), inputVehicleType, true);
        }

        private void showAllVehiclesInGarage()
        {
            if (m_Garage.VehiclsInGarage != null)
            {
                List<string> vehiclesList = getChosenTypeVehiclesList();

                if (vehiclesList != null)
                {
                    Console.WriteLine("Vehicle's license chosen in garage:");
                    foreach (string vehicleLicense in vehiclesList)
                    {
                        Console.WriteLine(vehicleLicense);
                    }
                }
            }
            else
            {
                Console.WriteLine(k_NoVehiclesMsg);
            }
        }

        private List<string> getChosenTypeVehiclesList()
        {
            List<string> vehiclesList;

            if (checkIfToFilterVehiclesList())
            {
                vehiclesList = getFilteredVehicles();
            }
            else
            {
                vehiclesList = m_Garage.LicenseOfVehiclsInGarage();
            }

            return vehiclesList;
        }

        private bool checkIfToFilterVehiclesList()
        {
            bool toFilter;
            Console.WriteLine("do you want to filter the vehicles by state in garage? if yes write true else false");

            while (!bool.TryParse(Console.ReadLine(), out toFilter))
            {
                Console.WriteLine(k_TryAgainMsg);
            }

            return toFilter;
        }

        private List<string> getFilteredVehicles()
        {
            List<string> filteredVehiclesList = null;
            enumRequestMsg(typeof(eVehicleState), 1);
            string filter = getInputForEnum(typeof(eVehicleState));
            eVehicleState state = (eVehicleState)Enum.Parse(typeof(eVehicleState), filter, true);
            filteredVehiclesList = m_Garage.LicenseOfVehiclsInGarage(state);

            return filteredVehiclesList;
        }

        private void changeStateOfVehicleInGarage()
        {
            string inputLicenseNumber = findVehicleInGarage();
            if (inputLicenseNumber != null)
            {
                GarageClient currentVehicle = m_Garage.GetVehicleInGarage(inputLicenseNumber);
                Console.WriteLine("The vehicle was found and his current state is: {0}", currentVehicle.VehicleState);
                Console.WriteLine("Enter The state new state of the vehicle");
                enumRequestMsg(typeof(eVehicleState), 1);
                string inputVehicleState = getInputForEnum(typeof(eVehicleState));

                eVehicleState state = (eVehicleState)Enum.Parse(typeof(eVehicleState), inputVehicleState, true);
                try
                {
                    m_Garage.ChangeVehicleState(inputLicenseNumber, state);
                    Console.WriteLine("The vehicle was found and his new state is: {0}", currentVehicle.VehicleState);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private void inflateWheelsToMax()
        {
            string licenseNumber = findVehicleInGarage();
            if (licenseNumber != null)
            {
                m_Garage.InflateWheelsToMax(licenseNumber);
                Console.WriteLine("The vehicle weels are successfully have been filled to max");
            }
        }

        private void fillFuelForVehicle()
        {
            string inputLicenseNumber = findVehicleInGarage();
            if (inputLicenseNumber != null)
            {
                GarageClient currentVehicle = m_Garage.GetVehicleInGarage(inputLicenseNumber);
                if (currentVehicle.Vehicle.EnergyType.Equals(typeof(FuelEnergy)))
                {
                    {
                        Console.WriteLine("The vehicle was found and the current fuel is: {0} liters", (currentVehicle.Vehicle.EnergyType as FuelEnergy).CurrentFuelAvailableInLiters);
                        enumRequestMsg(typeof(eFuelType), 1);
                        string fuelTypeStr = getInputForEnum(typeof(eFuelType));
                        eFuelType fuelType = (eFuelType)Enum.Parse(typeof(eFuelType), fuelTypeStr, true);
                        Console.WriteLine("Enter the amount of fuel you would like to fill");
                        float fuelToFill = getEnergyToFill();
                        try
                        {
                            (currentVehicle.Vehicle.EnergyType as FuelEnergy).FillFuel(fuelToFill, fuelType);
                            currentVehicle.Vehicle.UpdateEnergyLeftPrecentage();
                            Console.WriteLine("The vehicle was successfully filled and the current fuel is: {0} liters", (currentVehicle.Vehicle.EnergyType as FuelEnergy).CurrentFuelAvailableInLiters);
                        }
                        catch (ValueOutOfRangeException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        catch (ArgumentException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }
                }
                else
                {
                    Console.WriteLine("this vehicle is not based on fuel");
                }
            }
        }

        private void charageBatteryForVehicle()
        {
            string inputLicenseNumber = findVehicleInGarage();
            if (inputLicenseNumber != null)
            {
                GarageClient currentVehicle = m_Garage.GetVehicleInGarage(inputLicenseNumber);
                if (currentVehicle.Vehicle.EnergyType.Equals(typeof(ElectricEnergy)))
                {
                    Console.WriteLine("The vehicle was found and the current battery is: {0} hours", (currentVehicle.Vehicle.EnergyType as ElectricEnergy).CurrentBatteryAvailableInHours);
                    Console.WriteLine("Enter the amount of minutes you would like to charge :");
                    float minutesToFill = getEnergyToFill();
                    try
                    {
                        (currentVehicle.Vehicle.EnergyType as ElectricEnergy).ChargeBattery(minutesToFill / 60);
                        currentVehicle.Vehicle.UpdateEnergyLeftPrecentage();
                    }
                    catch (ValueOutOfRangeException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    catch (ArgumentException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                else
                {
                    Console.WriteLine("this vehicle is not based on electricity");
                }
            }
        }

        private float getEnergyToFill()
        {
            float energyToFill;
            string userInput = Console.ReadLine();

            while (!float.TryParse(userInput, out energyToFill) || energyToFill < 0)
            {
                Console.WriteLine(k_TryAgainMsg);
                userInput = Console.ReadLine();
            }

            return energyToFill;
        }

        private void showInfoSpecificVehicle()
        {
            string licenseNumber = findVehicleInGarage();
            if (licenseNumber != null)
            {
                GarageClient vehicle = m_Garage.GetVehicleInGarage(licenseNumber);
                Console.WriteLine(vehicle.ToString());
            }
        }

        private string getInputForEnum(Type i_EnumType)
        {
            string userInput = Console.ReadLine();
            byte filterByte;

            while (!byte.TryParse(userInput, out filterByte) || !Enum.IsDefined(i_EnumType, filterByte))
            {
                Console.WriteLine(k_TryAgainMsg);
                userInput = Console.ReadLine();
            }

            return userInput;
        }

        private void enumRequestMsg(Type i_EnumType, byte i_Count)
        {
            string[] names = Enum.GetNames(i_EnumType);

            foreach (string eType in names)
            {
                Console.WriteLine("{0} - press {1}", eType, i_Count++);
            }
        }
    }
}