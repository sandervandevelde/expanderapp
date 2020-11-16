using Iot.Device.Mcp23xxx;
using System;
using System.Device.I2c;
using System.Threading.Tasks;

namespace ExpanderConsoleApp
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var connectionSettingsx20 = new I2cConnectionSettings(1, 0x20);
            var i2cDevicex20 = I2cDevice.Create(connectionSettingsx20);
            var mcp23017x20 = new Mcp23017(i2cDevicex20);

            var connectionSettingsx24 = new I2cConnectionSettings(1, 0x24);
            var i2cDevicex24 = I2cDevice.Create(connectionSettingsx24);
            var mcp23017x24 = new Mcp23017(i2cDevicex24);

            while (true)
            {
                byte dataPortAswitch = mcp23017x20.ReadByte(Register.GPIO, Port.PortA);
                byte dataPortBswitch = mcp23017x20.ReadByte(Register.GPIO, Port.PortB);

                Console.WriteLine($"Port A = {dataPortAswitch:D3} - Port B = {dataPortBswitch:D3}");

                Task.Delay(200);
            }
        }
    }
}