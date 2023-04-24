using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace quick_test
{
    class Device
    {
        public string Name;
        public Device(string name)
        {
            this.Name = name;
        }
    }

    class Adapter
    {
        public Adapter()
        {
        }

        public async Task<Device> GetDeviceAsync(string name)
        {
            Device result = new Device(name);
            await Task.Delay(150);
            return null;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            MainAsync().Wait();
        }

        static async Task MainAsync()
        {
            Adapter adapter = new Adapter();

            Device device = await adapter.GetDeviceAsync("Test");

            Console.WriteLine($"Create {device.Name} Device");
        }
    }
}
