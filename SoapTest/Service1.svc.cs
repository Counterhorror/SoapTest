using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using MathCalc;

namespace SoapTest
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }
        private MathCalc.Calculations _calc = new Calculations();

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;

        }

        public double SuperCalc(double value1, double value2, out double value3, out double value4, out double value5)
        {
            value3 = value1 - value2;
            value4 = value1 * value2;
            value5 = value1 / value2;
            return value1 + value2;
        }

        public double DllCalc(double value1, double value2, out double Sub, out double Div, out double Mul)
        {
            Sub = _calc.Subtraction(value1, value2);
            Div = _calc.Divide(value1, value2);
            Mul = _calc.Multiply(value1, value2);
            return _calc.Addition(value1, value2);
        }
    }
}
