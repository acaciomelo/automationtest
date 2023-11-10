using System;
namespace Inclusion_Cloud___Automation_Test
{
	public class DerivedClass : BaseClass
	{
        public DerivedClass(int prop1, string prop2, double prop3) : base(prop1, prop2, prop3)
        {
            
        }

        public static new void ClassMethod()
        {
            Console.WriteLine("ClassMethod in DerivedClass");
        }

        public new void InstanceMethod()
        {
            Console.WriteLine("InstanceMethod in DerivedClass");
        }
    }
}

