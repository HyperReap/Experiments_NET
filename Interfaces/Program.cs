using System.Xml.Linq;

namespace Constructors_order
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MyClass c = new MyClass();
            c.DoStuff();

            (c as A).DoStuff();
            (c as B).DoStuff();
            (c as B).Another();

            
            
        }
    }
}

class MyClass : A, B
{
    public void Another()
    {
        throw new NotImplementedException();
    }

    public void Another2() // MUST BE IMPLEMENTED NO default implementation
    {
        throw new NotImplementedException();
    }

    public void DoStuff()
    {
        Console.WriteLine("Class");
        //base.DoStuff();  NOT WORKING

    }
    void A.DoStuff()
    {
        Console.WriteLine("A but in class");
    }
}

interface A
{
    public void DoStuff();
}

interface B
{
    public void DoStuff();
    public void Another();
    public void Another2();

}