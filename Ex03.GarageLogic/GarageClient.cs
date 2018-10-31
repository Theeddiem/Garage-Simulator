using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class GarageClient
    {
        private readonly string r_OwnerName;
        private string m_OwnerPhoneNumber;
        private eVehicleState m_VehicleState;
        private Vehicle m_Vehicle;

        public GarageClient(string i_OwnerName, string i_OwnerPhoneNumber, Vehicle i_Vehicle)
        {
            r_OwnerName = i_OwnerName;
            m_OwnerPhoneNumber = i_OwnerPhoneNumber;
            m_VehicleState = eVehicleState.WorkingOn;
            m_Vehicle = i_Vehicle;
        }

        public string OwnerName
        {
            get { return r_OwnerName; }
        }

        public string OwnerPhoneNumber
        {
            get { return m_OwnerPhoneNumber; }
            set { m_OwnerPhoneNumber = value; }
        }

        public eVehicleState VehicleState
        {
            get { return m_VehicleState; }
            set { m_VehicleState = value; }
        }

        public Vehicle Vehicle
        {
            get { return m_Vehicle; }
        }

        public override string ToString()
        {
            return string.Format(
@"Owner name: {0}
Vehicle State in Garage: {1}
{2}",
OwnerName, 
VehicleState,
Vehicle);
        }
    }

    // $G$ CSS-999 (-3) Each enum/class/struct which is not nested should be in a separate file.
    public enum eVehicleState : byte
    {
        WorkingOn = 1,
        Fixed,
        Paid
    }
}