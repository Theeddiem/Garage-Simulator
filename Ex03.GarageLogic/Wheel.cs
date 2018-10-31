using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Wheel
    {
        private readonly string r_ManufacturerName;
        private readonly float r_MaximumAirPressure;
        private float m_CurrentAirPressure;
        
        public Wheel(string i_ManufacturerName, float i_MaximumAirPressure)
        {
            r_ManufacturerName = i_ManufacturerName;
            r_MaximumAirPressure = i_MaximumAirPressure;
        }

        public float CurrentAirPressure
        {
            get { return m_CurrentAirPressure; }
            set { m_CurrentAirPressure = value; }
        }

        public string ManufacturerName
        {
            get { return r_ManufacturerName; }
        }

        public float MaximumAirPressure
        {
            get { return r_MaximumAirPressure; }
        }

        public void Inflating(float i_AirToAdd)
        {
            if (i_AirToAdd + m_CurrentAirPressure <= r_MaximumAirPressure && i_AirToAdd >= 0)
            {
                m_CurrentAirPressure += i_AirToAdd;
            }
            else
            {
                throw new ValueOutOfRangeException(r_MaximumAirPressure - m_CurrentAirPressure, 0);
            }
        }

        public override string ToString()
        {
            return string.Format("Manufacturer Name: {0}{3}Maximum Air Pressure: {1}{3}Current Air Pressure: {2}", r_ManufacturerName, r_MaximumAirPressure, m_CurrentAirPressure, Environment.NewLine);
        }
    }
}