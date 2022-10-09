using System.Xml.Linq;

namespace Constructors_order
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MyClass c = new MyClass();

        }
    }


    class MyClass : MyBaseClass
    {
        private string Name = "Name";
        private static string  StatName = "StatName";
        public MyClass()
        {
            Name = "ConstrName";
        }
        static MyClass()
        {
            StatName = "StaNameConstr";
        }
    }


    class MyBaseClass
    {
        private string BaseName = "BaseName";
        private static string BaseStatName = "BaseStatName";
        public MyBaseClass()
        {
            BaseName = "BaseConstrName";

        }
        static MyBaseClass()
        {
            BaseStatName = "BaseStaticConstrName";
        }
    }

}