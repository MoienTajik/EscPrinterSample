using System;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using EscPrinterTest.Printer;

namespace EscPrinterTest
{
    class Program
    {
        private static async Task Main()
        {
            const string ipAddress = "192.168.1.240";
            const int portNumber = 9100;

            EscPrinter printer = new EscPrinter(ipAddress, portNumber);

            string currentExecutionPath = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            string imagePath = Path.Combine(currentExecutionPath, "HelloWorld.png");

            await printer.Print(imagePath);

            Console.WriteLine("Image printed successfully !!");
            Console.ReadKey();
        }
    }
}