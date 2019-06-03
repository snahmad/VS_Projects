using System;
using System.Collections.Generic;
using System.Text;

namespace XUnitTestProject1
{
    public class MathsHelper
    {
        public int add(ISerial serial)
        {
            return serial.getFirst() + serial.getSecond();
        }
    }
    public interface ISerial
    {
        int getFirst();
        int getSecond();
    }
}
