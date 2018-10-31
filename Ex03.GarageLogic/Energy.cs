using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public abstract class Energy
    {
        public new bool Equals(object obj)
        {
            bool equals = false;
            if (obj.Equals(this.GetType()))
            {
                equals = true;
            }

            return equals;
        }
    }
}