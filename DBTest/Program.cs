using DBTest.Context;
using DBTest.Models;
using DBTest;

namespace Program
{
    public class Program
    {

        public static void Main()
        {
            var t1 = new Testing();
            t1.ReadTest();
            t1.CreateTest();
        }
        
       
    }


}
