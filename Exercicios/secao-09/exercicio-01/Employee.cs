using System;
using System.Globalization;

namespace Secao9.exercicio_01
{
    class Employee
    {
        public string Name { get; private set; }
        public int Hours { get; private set; }
        public double ValuePerHour { get; private set; }

        public Employee(string Name, int Hours, double ValuePerHour)
        {
            this.Name = Name;
            this.Hours = Hours;
            this.ValuePerHour = ValuePerHour;
        }
        public virtual double Payment => Hours * ValuePerHour;
    }

    class OutsourcedEmployee : Employee
    {
        public double AdditionalCharge { get; private set; }
        const double BONUS = 1.1; //110% -> (100 + 10) / 100 = 11/10 = 1.1

        public OutsourcedEmployee(string Name, int Hours, double ValuePerHour, double AdditionalCharge) 
            : base(Name, Hours, ValuePerHour) => this.AdditionalCharge = AdditionalCharge;
        public override double Payment => (Hours * ValuePerHour) + (AdditionalCharge * BONUS);
    }
}