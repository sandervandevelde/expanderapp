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
            mcp23017x20.WriteByte(Register.IODIR, 0b0000_0000, Port.PortA);
            mcp23017x20.WriteByte(Register.IODIR, 0b0000_0000, Port.PortB);

            var connectionSettingsx24 = new I2cConnectionSettings(1, 0x24);
            var i2cDevicex24 = I2cDevice.Create(connectionSettingsx24);
            var mcp23017x24 = new Mcp23017(i2cDevicex24);
            mcp23017x24.WriteByte(Register.IODIR, 0b0000_0000, Port.PortA);
            mcp23017x24.WriteByte(Register.IODIR, 0b0000_0000, Port.PortB);


            while (true)
            {
                byte dataPortAswitch20 = mcp23017x20.ReadByte(Register.GPIO, Port.PortA);
                byte dataPortBswitch20 = mcp23017x20.ReadByte(Register.GPIO, Port.PortB);

                Console.WriteLine($"Port A = {dataPortAswitch20:D3} - Port B = {dataPortBswitch20:D3}");

                mcp23017x24.WriteByte(Register.GPIO, dataPortAswitch20, Port.PortA);
                mcp23017x24.WriteByte(Register.GPIO, dataPortBswitch20, Port.PortB);
                   
                Task.Delay(5000).Wait();
            }
        }
    }
}