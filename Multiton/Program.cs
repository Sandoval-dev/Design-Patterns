using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multiton
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Camera camera1 = Camera.GetCamera("NIKON");
            Camera camera2 = Camera.GetCamera("NIKON2");
            Camera camera3 = Camera.GetCamera("NIKON3");
            Camera camera4 = Camera.GetCamera("NIKON4");
            Camera camera5 = Camera.GetCamera("NIKON5");

            Console.WriteLine(camera1.Id);
            Console.WriteLine(camera2.Id);
            Console.WriteLine(camera3.Id);
            Console.WriteLine(camera4.Id);
            Console.WriteLine(camera5.Id);

            Console.ReadLine();
        }
    }

    class Camera
    {
        static Dictionary<string, Camera> cameras = new Dictionary<string, Camera>();
        static object _lock=new object();
        public Guid Id { get; set; }
        private string brand;

        private Camera()
        {
            Id= Guid.NewGuid();
        }

        public static Camera GetCamera(string brand)
        {
            lock (_lock)
            {
                if (!cameras.ContainsKey(brand))
                {
                    cameras.Add(brand, new Camera());
                }
            }
            return cameras[brand];
        }
    }
}
