using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    internal class Motorcycle : Vehicle
    {
        private readonly int r_EngineCapacity;
        private eMotorcycleLicenseType m_MotorcycleLicenseType;

        internal Motorcycle(List<Wheel> i_Wheels, string i_Model, string i_LicenseNumber, Energy i_EnergyType, float i_EnergyLeftPrecentage, eMotorcycleLicenseType i_MotorcycleLicenseType, int i_EngineCapacity) : base(i_Model, i_LicenseNumber, i_EnergyType, i_EnergyLeftPrecentage)
        {
            m_MotorcycleLicenseType = i_MotorcycleLicenseType;
            r_EngineCapacity = i_EngineCapacity;
            m_Wheels = i_Wheels;
        }

        public int EngineCapacity
        {
            get { return r_EngineCapacity; }
        }

        public eMotorcycleLicenseType MotorcycleLicenseType
        {
            get { return m_MotorcycleLicenseType; }
            set { m_MotorcycleLicenseType = value; }
        }

        public override string ToString()
        {
            return string.Format(
@"{0}
Motorcycle License Type: {1}
Engine Capacity: {2}",
base.ToString(),
MotorcycleLicenseType,
EngineCapacity);
        }
    }

    public enum eMotorcycleLicenseType : byte
    {
        A1 = 1,
        A2,
        AB,
        B
    }
}