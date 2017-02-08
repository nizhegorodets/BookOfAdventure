using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace core
{

    class Program
    {
        static void Main(string[] args)
        {
            gameContext gContext = new gameContext();
            gContext.init();
            thread thread1 = new thread();
            thread1.setID(1);
            thread thread2 = new thread();
            thread2.setID(2);
            thread thread3 = new thread();
            thread3.setID(3);

            gContext.addThreads(thread1);
            gContext.addThreads(thread2);

            try
            {
                gContext.deleteActiveThreads(thread3);
                gContext.deleteThreads(ref thread3);
            }
            catch (coreErrors error)
            {
                error.print();
            }
            
        }
    }
}
