using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    internal class Car : Vehicle
    {
        private readonly eDoorsAmount r_DoorsAmount;
        private eCarColor m_Color;

        internal Car(List<Wheel> i_Wheels, string i_Model, string i_LicenseNumber, Energy i_EnergyType, float i_EnergyLeftPrecentage, eCarColor i_Color, eDoorsAmount i_DoorsAmount) : base(i_Model, i_LicenseNumber, i_EnergyType, i_EnergyLeftPrecentage)
        {
            m_Color = i_Color;
            r_DoorsAmount = i_DoorsAmount;
            m_Wheels = i_Wheels;
        }

        public eCarColor CarColor
        {
            get { return m_Color; }
            set { m_Color = value; }
        }

        public eDoorsAmount DoorsAmount
        {
            get { return r_DoorsAmount; }
        }

        public override string ToString()
        {
            return string.Format(
                @"{0}
Car Color:{1}
Doors Amount:{2}",
base.ToString(),
CarColor,
DoorsAmount);
        }
    }

    public enum eDoorsAmount : byte
    {
        TwoDoors = 2,
        ThreeDoors,
        FourDoors,
        FiveDoors
    }

    public enum eCarColor : byte
    {
        Grey = 1,
        White,
        Green,
        Purple
    }
}