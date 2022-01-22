using System;

namespace DIO.Series
{
    public class ViewFilme
    {
        static FilmeRepositorio repositorio = new FilmeRepositorio();
        public static void Acoes()
        {
            
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarFilmes();
                        break;
                    case "2":
                        InserirFilme();
                        break;
                    case "3":
                        AtualizarFilme();
                        break;
                    case "4":
                        ExcluirFilme();
                        break;
                    case "5":
                        VisualizarFilme();
                        break;
                    case "C":
                        Console.Clear();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }

                opcaoUsuario = ObterOpcaoUsuario();
            }

            Program.Iniciar();
        }

        private static void ExcluirFilme()
        {
            Console.Write("Digite o id do filme: ");
            int indiceFilme = int.Parse(Console.ReadLine());

            repositorio.Exclui(indiceFilme);
        }
        private static void VisualizarFilme()
        {
            Console.Write("Digite o id da Filme: ");
            int indiceFilme = int.Parse(Console.ReadLine());

            var Filme = repositorio.RetornaPorId(indiceFilme);

            Console.WriteLine(Filme);
        }
        private static void AtualizarFilme()
        {
            Console.Write("Digite o id do filme: ");
            int indiceFilme = int.Parse(Console.ReadLine());

            // https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=netcore-3.1
            // https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=netcore-3.1
            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.Write("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o Título da Filme: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o Ano de Início da Filme: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a Descrição da Filme: ");
            string entradaDescricao = Console.ReadLine();

            Filme atualizaFilme = new Filme(id: indiceFilme,
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao);

            repositorio.Atualiza(indiceFilme, atualizaFilme);
        }
        private static void ListarFilmes()
        {
            Console.WriteLine("Listar filmes");

            var lista = repositorio.Lista();

            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhuma filme cadastrada.");
                return;
            }

            foreach (var Filme in lista)
            {
                var excluido = Filme.retornaExcluido();

                Console.WriteLine("#ID {0}: - {1} {2}", Filme.retornaId(), Filme.retornaTitulo(), (excluido ? "*Excluído*" : ""));
            }
        }
        private static void InserirFilme()
        {
            Console.WriteLine("Inserir novo filme");

            // https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=netcore-3.1
            // https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=netcore-3.1
            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.Write("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o Título da Filme: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o Ano de Início da Filme: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a Descrição da Filme: ");
            string entradaDescricao = Console.ReadLine();

            Filme novaFilme = new Filme(id: repositorio.ProximoId(),
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao);

            repositorio.Insere(novaFilme);
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("DIO Filmes a seu dispor!!!");
            Console.WriteLine("Informe a opção desejada:");

            Console.WriteLine("1- Listar Filmes");
            Console.WriteLine("2- Inserir nova Filme");
            Console.WriteLine("3- Atualizar Filme");
            Console.WriteLine("4- Excluir Filme");
            Console.WriteLine("5- Visualizar Filme");
            Console.WriteLine("C- Limpar Tela");
            Console.WriteLine("X- Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}
   