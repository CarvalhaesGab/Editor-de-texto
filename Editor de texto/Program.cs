using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextEditor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Menu();
        }

        static void Menu()
        {
            Console.Clear();
            Console.WriteLine("O que voce deseja fazer?");
            Console.WriteLine("1 - Abrir arquivo");
            Console.WriteLine("2 - Criar novo arquivo");
            Console.WriteLine("0 - Sair");
            short option = short.Parse(Console.ReadLine());

            switch (option)
            {
                case 0: System.Environment.Exit(0); break;
                case 1: abrir(); break;
                case 2: Criar(); break;
                default: Menu(); break;
            }
        }
        static void abrir()
        {
            Console.Clear();
            Console.WriteLine("Qual o caminho do arquivo?");
            String path = Console.ReadLine();

            using (var arquivo = new StreamReader(path))
            {
                string texto = arquivo.ReadToEnd(); //ReadToEnd Ler aquivo ate o final//
                Console.WriteLine(texto);
            }

            Console.WriteLine("");
            Console.ReadLine();
            Menu();
        }

        static void Criar()
        {
            Console.Clear();
            Console.WriteLine("Digite seu texto abaixo: (ESC para sair)");
            Console.WriteLine("------------------------");
            string texto = "";

            do
            {
                texto += Console.ReadLine();
                texto += Environment.NewLine;
            }
            while (Console.ReadKey().Key != ConsoleKey.Escape); // Enquanto o usuario nao digitar a tecla ESC (escape), nao saira do programa //

            Salvar(texto);

            Console.ReadKey();
        }
        static void Salvar(string Texto)
        {
            Console.Clear();
            Console.WriteLine("Digite o caminho que deseja salvar o arquivo:");
            var path = Console.ReadLine();

            using (var arquivo = new StreamWriter(path))
            {
                arquivo.Write(Texto);
            }

            Console.WriteLine($"O arquivo foi salvo com sucesso em {path}");
            Console.ReadLine();
            Menu();
        }

    }
}
