using System.Globalization;

namespace Secao8.exercicio_01
{
    class Program
    {
        static void Main(string[] args)
        {
            Department department = new Department(GetInput("Enter department's name: "));
            Console.WriteLine("Enter worker data:");
            Worker worker = new Worker(
                GetInput("Name: "),
                GetInput("Level (Junior/MidLevel/Senior): "),
                double.Parse(GetInput("Base salary: "), CultureInfo.InvariantCulture)
            );
            department.Workers.Add(worker);

            int NumberOfContracts = int.Parse(GetInput("How many contracts to this worker? "));
            for (int index = 0; index < NumberOfContracts; index++)
            {
                Console.WriteLine($"Enter #{index + 1} contract data:");
                worker.AddContract(CreateContract);
            }

            DateTime date = DateTime.Parse(GetInput("Enter month and year to calculate income (MM/YYYY): "));
            double income = worker.Income(date);
            Console.Write($"Name: {worker.Name}\nDepartment: {department.Name}\nIncome for {date.ToString("MM/yyyy")}: {income:F2}");
        }

        static HourContract CreateContract => new HourContract(
            DateTime.Parse(GetInput("Date (DD/MM/YYYY): ")),
            double.Parse(GetInput("Value per hour: "), CultureInfo.InvariantCulture),
            int.Parse(GetInput("Duration (hours): "))
        );
        static string GetInput(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine();
        }
    }

    public class Department
    {
        public string Name { get; private set; }
        public List<Worker> Workers = new List<Worker>();

        public Department(string Name)
        {
            this.Name = Name;
        }
    }

    public class Worker
    {
        public string Name { get; private set; }
        public WorkerLevel Level { get; private set; }
        public double BaseSalary { get; private set; }
        private List<HourContract> Contracts = new List<HourContract>();

        public Worker(string Name, string Level, double BaseSalary)
        {
            this.Name = Name;
            this.Level = StringToWorkerLevel(Level);
            this.BaseSalary = BaseSalary;
        }
        
        static WorkerLevel StringToWorkerLevel(string level)
        {
            switch (level)
            {
                case "Junior":
                    return WorkerLevel.JUNIOR;
                case "MidLevel":
                    return WorkerLevel.MID_LEVEL;
                case "Senior":
                    return WorkerLevel.SENIOR;
                default:
                    return WorkerLevel.JUNIOR;

            }
        }
        public void AddContract(HourContract contract) => Contracts.Add(contract);
        public void RemoveContract(HourContract contract) => Contracts.Remove(contract);
        public double Income(DateTime date)
        {
            double TotalIncome = BaseSalary;
            foreach (HourContract contract in Contracts)
                if(contract.Date.ToString("MM/yyyy") == date.ToString("MM/yyyy")) TotalIncome += contract.TotalValue;

            return TotalIncome;
        }
    }

    public class HourContract
    {
        public DateTime Date { get; private set; }
        public double ValuePerHour { get; private set; }
        public int Hours { get; private set; }

        public HourContract(DateTime Date, double ValuePerHour, int Hours)
        {
            this.Date = Date;
            this.ValuePerHour = ValuePerHour;
            this.Hours = Hours;
        }
        public double TotalValue => ValuePerHour * Hours;
    }

    public enum WorkerLevel
    {
        JUNIOR = 1,
        MID_LEVEL = 2,
        SENIOR = 3
    }
}