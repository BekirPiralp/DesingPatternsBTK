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
            Camera camera2 = Camera.GetCamera("NIKON");
            Camera camera3 = Camera.GetCamera("CANON");
            Camera camera4 = Camera.GetCamera("CANON");

            Console.WriteLine("Camera 1 brand : "+camera1.brand+" "+"id : "+camera1.Id);
            Console.WriteLine("Camera 2 brand : "+camera2.brand+" "+"id : "+camera2.Id);
            Console.WriteLine("Camera 3 brand : "+camera3.brand+" "+"id : "+camera3.Id);
            Console.WriteLine("Camera 4 brand : "+camera4.brand+" "+"id : "+camera4.Id);

            Console.ReadLine();
        }
    }

    class Camera
    {
        static Dictionary<string, Camera> _cameras = new Dictionary<string, Camera>();

        static object _lock = new object();

        public string brand { get; private set; }

        public Guid Id { get; private set; } //brand e göre tek nesne oluştuğunu göstermek için

        private Camera()
        {
            Id = Guid.NewGuid();
        }

        public static Camera GetCamera(string brand)
        {
            lock (_lock)
            {
                if (!_cameras.ContainsKey(brand))
                {
                    _cameras.Add(brand, new Camera { brand=brand});
                }
            }
            return _cameras[brand];
        }
    }
}
