namespace Secao11.exercicio_01
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string summaryPath = @"..\..\..\Exercicios\secao-11\exercicio-01\summary.csv";
                List<Product> products = new List<Product>();

                using (StreamReader sr = File.OpenText(summaryPath))
                {
                    while (!sr.EndOfStream)
                    {
                        string[] line = sr.ReadLine().Split(',');
                        products.Add(new Product(line[0], line[1], line[2]));
                    }
                }

                string path = Path.GetDirectoryName(summaryPath);
                Directory.CreateDirectory(path + @"\out");
                string outPath = path + @"\out\" + Path.GetFileName(summaryPath);

                using (StreamWriter sw = File.AppendText(outPath))
                {
                    foreach (Product product in products)
                    {
                        sw.WriteLine(product.ToString());
                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine($"Exception: {e}");
            }
            finally
            {
                Console.WriteLine($"Process executed");
            }
        }
    }
}