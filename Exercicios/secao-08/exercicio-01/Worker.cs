namespace Secao8.exercicio_01
{
    public class Worker
    {
        public Department Department { get; private set; }
        public string Name { get; private set; }
        public WorkerLevel Level { get; private set; }
        public double BaseSalary { get; private set; }
        private List<HourContract> Contracts = new List<HourContract>();

        public Worker(string DepartmentName, string Name, string Level, double BaseSalary)
        {
            this.Department = new Department(DepartmentName);
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
                if (contract.Date.ToString("MM/yyyy") == date.ToString("MM/yyyy")) TotalIncome += contract.TotalValue;

            return TotalIncome;
        }
    }

    public enum WorkerLevel : int
    {
        JUNIOR = 0,
        MID_LEVEL = 1,
        SENIOR = 2
    }
}