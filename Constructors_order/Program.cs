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
    internal class Program2
    {
        static void Main(string[] args)
        {
            MyClass c = new MyClass();

        }
    }
    /// <summary>
    /// 1. Static field BaseClass
    /// 2. Static constructor BaseClass
    /// 3. Static field inherited
    /// 4. Static constructor inherited
    /// 5. instance field inherited
    /// 6. instance field BaseClass
    /// 7. instance constructor BaseClass
    /// 8. instance constructor inherited
    /// </summary>

    class MyClass : MyBaseClass
    {
        private string Name = "Name";
        private static string  StatName = "StatName";
        private string Description;
        public MyClass()
        {
            Name = "ConstrName";
            Description = "Descir";
        }
        static MyClass()
        {
            StatName = "StaNameConstr";
        }

        public override void ahoj()
        {
            Description.ToString();
        }


    }


    class MyBaseClass
    {
        private string BaseName = "BaseName";
        private static string BaseStatName = "BaseStatName";
        public MyBaseClass()
        {
            BaseName = "BaseConstrName";
            //ahoj(); // CRASH not init yet
        }
        static MyBaseClass()
        {
            BaseStatName = "BaseStaticConstrName";
        }

        public virtual void ahoj() //DO NOT CALL FROM CONSTRUCTOR
        {

        }
    }

}