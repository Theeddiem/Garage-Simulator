using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public static class Creation//
    {
        private const int k_FuelMotorcyleTank = 5;
        private const float k_ElectricMotorcyleBattery = 3.2f;
        private const int k_FuelCarTank = 48;
        private const float k_ElectricCarBattery = 4.8f;
        private const int k_FuelCarTrunk = 105;

        public static Wheel CreateWeel(string i_WheelsManufactureName, float i_MaxAirPresseure)
        {
            Wheel wheel = new Wheel(i_WheelsManufactureName, i_MaxAirPresseure);

            return wheel;
        }

        public static Vehicle CreateMotorcycle(bool i_IsElectric, string i_LicenseNumber, string i_Model, float i_EnergyLeftPrectange, List<Wheel> i_WheelsForMotorcycle, eMotorcycleLicenseType i_MotorcycleLicenseType, int i_EngineCapacity)
        { 
            Energy MotorcycleEnergy;

            if (i_IsElectric)
            {
                MotorcycleEnergy = new ElectricEnergy(i_EnergyLeftPrectange, k_ElectricMotorcyleBattery);
            }
            else
            {
                MotorcycleEnergy = new FuelEnergy(eFuelType.Octan95, i_EnergyLeftPrectange, k_FuelMotorcyleTank);
            }

            Vehicle Motorcycle = new Motorcycle(i_WheelsForMotorcycle, i_Model, i_LicenseNumber, MotorcycleEnergy, i_EnergyLeftPrectange, i_MotorcycleLicenseType, i_EngineCapacity);

            return Motorcycle;
        }

        public static Vehicle CreateCar(bool i_IsElectric, string i_LicenseNumber, string i_Model, float i_EnergyLeftPrectange, List<Wheel> i_WheelsForCar, eCarColor i_CarColor, eDoorsAmount i_DoorsAmount)
        {
            Energy CarEnergy;
            if (i_IsElectric)
            {
                CarEnergy = new ElectricEnergy(i_EnergyLeftPrectange, k_ElectricCarBattery);
            }
            else
            {
                CarEnergy = new FuelEnergy(eFuelType.Octan96, i_EnergyLeftPrectange, k_FuelCarTank);
            }

            Vehicle Car = new Car(i_WheelsForCar, i_Model, i_LicenseNumber, CarEnergy, i_EnergyLeftPrectange, i_CarColor, i_DoorsAmount);

            return Car;
        }

        public static Vehicle CreateTruck(string i_LicenseNumber, string i_Model, float i_EnergyLeftPrectange, List<Wheel> i_WheelsForTruck, bool i_CabinIsCooled, float i_CabinCapacity) 
        {
            Energy TruckEnergy = new FuelEnergy(eFuelType.Soler, i_EnergyLeftPrectange, k_FuelCarTrunk);
            Vehicle Truck = new Truck(i_WheelsForTruck, i_Model, i_LicenseNumber, TruckEnergy, i_EnergyLeftPrectange, i_CabinIsCooled, i_CabinCapacity);

            return Truck;
        }
    }

    public enum eVehicleType : byte
    {
        Motorcycle = 1,
        Car,
        Truck
    }
}