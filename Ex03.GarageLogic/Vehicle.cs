using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        protected readonly string r_Model;
        protected readonly string r_LicenseNumber;
        protected readonly Energy r_EnergyType;
        protected float m_EnergyLeftPrecentage;
        protected List<Wheel> m_Wheels;
      
        internal Vehicle(string i_Model, string i_LicenseNumber, Energy i_EnergyType, float i_EnergyLeftPrecentage)
        {
            r_Model = i_Model;
            r_LicenseNumber = i_LicenseNumber;
            r_EnergyType = i_EnergyType;
            m_EnergyLeftPrecentage = i_EnergyLeftPrecentage;
        }

        public static List<Wheel> MakeWheelsSet(int i_NumberOfWheels, string i_ManufacturerName, float i_CurrentAirPressure, float i_MaximumAirPressure)
        {
            List<Wheel> wheelList = new List<Wheel>();

            for (int i = 0; i < i_NumberOfWheels; i++)
            {
                Wheel wheel = new Wheel(i_ManufacturerName, i_MaximumAirPressure);
                wheelList.Add(wheel);
            }

            return wheelList;
        }

        public void UpdateEnergyLeftPrecentage()
        {
            if(r_EnergyType.Equals(typeof(FuelEnergy)))
            {
                m_EnergyLeftPrecentage = ((r_EnergyType as FuelEnergy).CurrentFuelAvailableInLiters * 100) / (r_EnergyType as FuelEnergy).MaxFuelCapacityInLiters;
            }
            else
            {
                m_EnergyLeftPrecentage = ((r_EnergyType as ElectricEnergy).CurrentBatteryAvailableInHours * 100) / (r_EnergyType as ElectricEnergy).MaxBatteryCapacityInHours;
            }
       }
      
        public string Model
        {
            get { return r_Model; }
        }

        public string LicenseNumber
        {
            get { return r_LicenseNumber; }
        }

        public float EnergyLeftPrecentage
        {
            get { return m_EnergyLeftPrecentage; }
        }

        public List<Wheel> Wheels
        {
            get { return m_Wheels; }
            set { m_Wheels = value; }
        }

        public Energy EnergyType
        {
            get { return r_EnergyType; }
        }

        public override string ToString()
        {
            StringBuilder wheels = new StringBuilder(string.Format("Wheels in vehicle:{0}", Environment.NewLine));

            foreach (Wheel wheel in Wheels)
            {
                wheels.Append(string.Format("{0}{1}", wheel.ToString(), Environment.NewLine));
            }

            return string.Format(
@"License number:{0}
Model: {1}
{2}{3}",
LicenseNumber,
Model,
wheels,
EnergyType);
        }
    }
}