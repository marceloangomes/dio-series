using System;

namespace DIO.Series
{
    class Program
    {
        
        static void Main(string[] args)
        {
			Iniciar();
		}


		public static void Iniciar()
		{
			Console.WriteLine("1 - Cadastro de Filmes");
            Console.WriteLine("2 - Cadastro de Séries");
            Console.WriteLine("X- Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            var volta = false;

			while (!volta && opcaoUsuario.ToUpper() != "X")
            {
                volta=true;
                switch (opcaoUsuario)
                {
                    case "1":
                        ViewFilme.Acoes();
                        break;
                    case "2":
                        ViewSerie.Acoes();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
               
            }
            if(!volta)
            {
			    Console.WriteLine("Obrigado por utilizar nossos serviços.");
                Console.ReadLine();
            }

        }
        
    }
}
