using ExeFixacao_MetodosAbstratos.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace ExeFixacao_MetodosAbstratos
{
    class Program
    {
        static void Main(string[] args)
        {
            List<TaxPayer> lista = new List<TaxPayer>();
            Console.Write("Enter the number of tax payers: ");
            int qtd = int.Parse(Console.ReadLine());
            for (int i = 1; i <= qtd; i++)
            {
                Console.WriteLine();
                Console.WriteLine($"Tax payer #{i} data:");
                Console.Write("Individual or Company (i/c)? ");
                char resposta = char.Parse(Console.ReadLine());
                Console.Write("Name: ");
                string nome = Console.ReadLine();
                Console.Write("Anual income: ");
                double ganhoAnual = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                if (resposta == 'i')
                {
                    Console.Write("Health expenditures: ");
                    double gastoComSaude = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                    lista.Add(new Individual(nome, ganhoAnual, gastoComSaude));
                }
                else
                {
                    Console.Write("Number of employees: ");
                    int qtdEmpregados = int.Parse(Console.ReadLine());
                    lista.Add(new Company(nome, ganhoAnual, qtdEmpregados));
                }
            }

            Console.WriteLine();
            Console.WriteLine("TAXES PAID");
            double soma = 0;
            foreach (TaxPayer item in lista)
            {
                Console.WriteLine(item.Name +": $ " + item.Tax().ToString("F2"),CultureInfo.InvariantCulture);
                soma += item.Tax();
            }
            Console.WriteLine();
            Console.WriteLine("TOTAL TAXES: $ " + soma.ToString("F2",CultureInfo.InvariantCulture));
        }
    }
}
