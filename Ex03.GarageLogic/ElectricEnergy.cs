using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class ElectricEnergy : Energy
    {
        private readonly float r_MaxBatteryCapacityInHours;
        private float m_CurrentBatteryAvailableInHours;

        public ElectricEnergy(float i_EnergyLeftPrecentage, float i_MaxBatteryCapacityInHours)
        {
            m_CurrentBatteryAvailableInHours = (i_MaxBatteryCapacityInHours * i_EnergyLeftPrecentage) / 100;
            r_MaxBatteryCapacityInHours = i_MaxBatteryCapacityInHours;
        }

        public void ChargeBattery(float i_BatteryHoursToAdd)
        {
            if (m_CurrentBatteryAvailableInHours + i_BatteryHoursToAdd <= r_MaxBatteryCapacityInHours && i_BatteryHoursToAdd > 0)
            {
                m_CurrentBatteryAvailableInHours += i_BatteryHoursToAdd;
            }
            else
            {
                throw new ValueOutOfRangeException(r_MaxBatteryCapacityInHours - m_CurrentBatteryAvailableInHours, 0);
            }
        }

        public float CurrentBatteryAvailableInHours
        {
            get { return m_CurrentBatteryAvailableInHours; }
            set { m_CurrentBatteryAvailableInHours = value; }
        }

        public float MaxBatteryCapacityInHours
        {
            get { return r_MaxBatteryCapacityInHours; }
        }

        public override string ToString()
        {
            return string.Format("Electirc Energy{2}Current battery Available: {0} hours{2}Max battery Capacity: {1} hours", m_CurrentBatteryAvailableInHours, r_MaxBatteryCapacityInHours, Environment.NewLine);
        }
    }
}