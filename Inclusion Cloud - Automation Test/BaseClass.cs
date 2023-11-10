using System;
namespace Inclusion_Cloud___Automation_Test
{
	public class BaseClass
	{
        public int Property1 { get; private set; }
        public string Property2 { get; private set; }
        public double Property3 { get; private set; }

        public BaseClass(int prop1, string prop2, double prop3)
        {
            Property1 = prop1;
            Property2 = prop2;
            Property3 = prop3;
        }

        public static void ClassMethod()
        {
            // Empty class method
        }

        public void InstanceMethod()
        {
            // Empty instance method
        }
    }
}

