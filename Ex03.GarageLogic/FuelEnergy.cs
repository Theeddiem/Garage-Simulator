using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class FuelEnergy : Energy
    {
        private readonly eFuelType r_FuelType;
        private readonly float r_MaxFuelCapacityInLiters;
        private float m_CurrentFuelAvailableInLiters;

        public FuelEnergy(eFuelType i_FuelType, float i_EnergyLeftPrecentage, float i_MaxFuelCapacityInLiters)
        {
            r_FuelType = i_FuelType;
            m_CurrentFuelAvailableInLiters = (i_MaxFuelCapacityInLiters * i_EnergyLeftPrecentage) / 100;
            r_MaxFuelCapacityInLiters = i_MaxFuelCapacityInLiters;
        }

        public void FillFuel(float i_FuelInLiters, eFuelType i_FuelType)
        {
            if (r_FuelType == i_FuelType)
            {
                if (m_CurrentFuelAvailableInLiters + i_FuelInLiters <= r_MaxFuelCapacityInLiters && i_FuelInLiters > 0)
                {
                    m_CurrentFuelAvailableInLiters += i_FuelInLiters;
                }
                else
                {
                    throw new ValueOutOfRangeException(r_MaxFuelCapacityInLiters - m_CurrentFuelAvailableInLiters, 0);
                }
            }
            else
            {
                throw new ArgumentException();
            }
        }

        public eFuelType FuelType
        {
            get { return r_FuelType; }
        }

        public float CurrentFuelAvailableInLiters
        {
            get { return m_CurrentFuelAvailableInLiters; }
            set { m_CurrentFuelAvailableInLiters = value; }
        }

        public float MaxFuelCapacityInLiters
        {
            get { return r_MaxFuelCapacityInLiters; }
        }

        public override string ToString()
        {
            return string.Format("Fuel Energy{3}Fuel Type{0}{3}Current Fuel Available: {1} Liters{3}Max Fuel Capacity: {2} Liters", r_FuelType, m_CurrentFuelAvailableInLiters, r_MaxFuelCapacityInLiters, Environment.NewLine);
        }
    }

    public enum eFuelType : byte
    {
        Octan95 = 1,
        Octan96,
        Octan98,
        Soler
    }
}