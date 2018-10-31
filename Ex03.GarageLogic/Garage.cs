using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Garage
    {
        private Dictionary<string, GarageClient> m_VehiclsInGarage;

        public Garage()
        {
            m_VehiclsInGarage = new Dictionary<string, GarageClient>();
        }

        public Dictionary<string, GarageClient> VehiclsInGarage
        {
            get { return m_VehiclsInGarage; }
            set { m_VehiclsInGarage = value; }
        }
           
        public void AddVehicleToGarage(GarageClient i_Vehicle)
        {
                 GarageClient vehicle;

                if(m_VehiclsInGarage.ContainsKey(i_Vehicle.Vehicle.LicenseNumber))
                {
                    m_VehiclsInGarage.TryGetValue(i_Vehicle.Vehicle.LicenseNumber, out vehicle);
                    vehicle.VehicleState = eVehicleState.WorkingOn;
                }
                else
                {
                    m_VehiclsInGarage.Add(i_Vehicle.Vehicle.LicenseNumber, i_Vehicle);
                }
        }

        public bool ChangeVehicleState(string i_LicenseNumber, eVehicleState i_State)
        {
            GarageClient vehicle;
            bool changed = false;
            
            if (CheckIfVehicleExists(i_LicenseNumber))
            {
                m_VehiclsInGarage.TryGetValue(i_LicenseNumber, out vehicle);
                vehicle.VehicleState = i_State;
                changed = true;
            }

            return changed;
        }

        public bool InflateWheelsToMax(string i_LicenseNumber)
        {
            GarageClient vehicle;
            bool changed = false;

            if (CheckIfVehicleExists(i_LicenseNumber))
            {
                m_VehiclsInGarage.TryGetValue(i_LicenseNumber, out vehicle);
                foreach (Wheel wheel in vehicle.Vehicle.Wheels)
                {
                    wheel.Inflating(wheel.MaximumAirPressure - wheel.CurrentAirPressure);
                }

                changed = true;
            }

            return changed;
        }

        public List<string> LicenseOfVehiclsInGarage(eVehicleState i_State)
        {
            List<string> licenseOfVehiclsState = new List<string>();
            if (checkIfGarageContainVehicles())
            {
                foreach (KeyValuePair<string, GarageClient> vehicle in m_VehiclsInGarage)
                {
                    if (vehicle.Value.VehicleState == i_State)
                    {
                        licenseOfVehiclsState.Add(vehicle.Key);
                    }
                }
            }

            return licenseOfVehiclsState;
        }

        public List<string> LicenseOfVehiclsInGarage()
        {
            List<string> licenseOfVehiclsState = new List<string>();
            if (checkIfGarageContainVehicles())
            {
                foreach (KeyValuePair<string, GarageClient> vehicle in m_VehiclsInGarage)
                {
                    licenseOfVehiclsState.Add(vehicle.Key);
                }
            }

            return licenseOfVehiclsState;
        }

        public GarageClient GetVehicleInGarage(string i_LicenseNumber)
        {
            GarageClient vehicle;

            if (CheckIfVehicleExists(i_LicenseNumber))
            {
                m_VehiclsInGarage.TryGetValue(i_LicenseNumber, out vehicle);
            }
            else
            {
                vehicle = null;
            }

            return vehicle;
        }

        public bool CheckIfVehicleNotExists(string i_LicenseNumber)
        {
                if (m_VehiclsInGarage.ContainsKey(i_LicenseNumber))
                {
                    throw new Exception("Vehicle already exists");
                }
                     
            return true;
        }

        public bool CheckIfVehicleExists(string i_LicenseNumber)
        {
                if (!m_VehiclsInGarage.ContainsKey(i_LicenseNumber))
                {
                    throw new Exception("Vehicle does not exists");
                }
            
            return true;
        }

        private bool checkIfGarageContainVehicles()
        {
            bool contains = true;
            if(m_VehiclsInGarage.Count == 0)
            {
                contains = false;
            }

            return contains;
        }
    }
}