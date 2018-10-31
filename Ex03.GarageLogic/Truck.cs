using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    internal class Truck : Vehicle
    {
        private readonly float r_CabinCapacity;
        private bool m_CabinIsCooled;
    
        internal Truck(List<Wheel> i_Wheels, string i_Model, string i_LicenseNumber, Energy i_EnergyType, float i_EnergyLeftPrecentage, bool i_CabinIsCooled, float i_CabinCapacity) : base(i_Model, i_LicenseNumber, i_EnergyType, i_EnergyLeftPrecentage)
        {
            m_CabinIsCooled = i_CabinIsCooled;
            r_CabinCapacity = i_CabinCapacity;
            m_Wheels = i_Wheels;
        }

        public float CabinCapacity
        {
            get { return r_CabinCapacity; }
        }

        public bool CabinIsCooled
        {
            get { return m_CabinIsCooled; }
            set { m_CabinIsCooled = value; }
        }

        public override string ToString()
        {
            return string.Format(
@"{0}
CabinIsCooled: {1}
Cabin Capacity: {2}", 
base.ToString(),
CabinIsCooled,
CabinCapacity);
        }
    }
}