using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{
    class Program
    {
        static void Main(string[] args)
        {
            var personalCar=new PersonalCar { Make="BMW",HirePrice=2500, Type="Sedan"};

            SpecialOffer specialOffer=new SpecialOffer(personalCar);
            Console.WriteLine("Concrete: " + personalCar.HirePrice);
            Console.WriteLine("Special offer: " + specialOffer.HirePrice);


            Console.ReadLine();
        }
    }

    abstract class CarBase
    {
        public abstract string Make { get; set; }
        public abstract string Type { get; set; }
        public abstract decimal HirePrice { get; set; }
    }

    class PersonalCar : CarBase
    {
        public override string Make { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public override string Type { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public override decimal HirePrice { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }

    class CommercialCar : CarBase
    {
        public override string Make { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public override string Type { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public override decimal HirePrice { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }

    abstract class CarDecoratorBase : CarBase
    {
        private CarBase _carBase;

        public CarDecoratorBase(CarBase carBase)
        {
            _carBase = carBase;
        }
    }

    class SpecialOffer : CarDecoratorBase
    {
        public SpecialOffer(CarBase carBase) : base(carBase)
        {

        }

        public override string Make { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public override string Type { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public override decimal HirePrice { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }


}
