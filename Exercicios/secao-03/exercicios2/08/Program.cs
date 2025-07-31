using System;
using System.Runtime.CompilerServices;

namespace Secao3
{
    class Ex2_8
    {
        static void Main8(string[] args)
        {
            Console.Write("Digite um salário: R$ ");
            float number = float.Parse(Console.ReadLine(), System.Globalization.CultureInfo.InvariantCulture);
            float taxes = Calc_Total_Taxes(number);
            System.Console.WriteLine($"Imposto a pagar: R$ {taxes:F2}");
        }

        static float Old_Calc_Taxes(float salary)
        {
            float taxes = 0.0f;
            if (salary <= 2000.00f)
            {
                taxes = 0.0f;
                return taxes;
            }
            salary -= 2000.00f;

            if (salary <= 1000.00f)
            {
                taxes = salary * 0.08f;
                return taxes;
            }
            taxes += 1000.00f * 0.08f;
            salary -= 1000.00f;

            if (salary <= 1500.00f)
            {
                taxes += salary * 0.18f;
                return taxes;
            }
            taxes += 1500.00f * 0.18f;
            salary -= 1500.00f;

            taxes += salary * 0.28f;

            return taxes;
        }

        static readonly float[] tax_brackets = [2000.00f, 1000.00f, 1500.00f, 0.00f];
        static readonly float[] tax_rates = [0.0f, 0.08f, 0.18f, 0.28f];
        static float Calc_Total_Taxes(float salary)
        {
            float taxes = 0.0f;
            for (int i = 0; i < tax_brackets.Length; i++)
            {
                (taxes, salary) = Calc_Taxes(salary, taxes, i);
                if (salary <= 0.0f) break;
            }
            return taxes;
        }

        static (float, float) Calc_Taxes(float salary, float taxes, int i)
        {
            if (salary <= tax_brackets[i] || tax_brackets[i] == 0.0f)
            {
                taxes += salary * tax_rates[i];
                return (taxes, 0.0f);
            }
            taxes += tax_brackets[i] * tax_rates[i];
            return (taxes, salary - tax_brackets[i]);
        }
    }
}