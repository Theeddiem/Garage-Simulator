using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class ValueOutOfRangeException : Exception
    {
        private float m_MaxValue;
        private float m_MinValue;
     
        public ValueOutOfRangeException(float i_MaxValue, float i_MinValue) : base(string.Format("Value out of range the maximum is: {0} and the minimun is: {1}", i_MaxValue, i_MinValue))
        {
            m_MaxValue = i_MaxValue;
            m_MinValue = i_MinValue;
        }

        public override string Message => base.Message;
    }
}