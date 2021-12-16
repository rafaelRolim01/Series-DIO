using System;
using Series.Classes;
using Series.Enum;

namespace Series
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        listaSerie();
                        break;
                    case "2":
                        InserirSerie();
                        break;
                    case "3":
                        AtualizarSerie();
                        break;
                    case "4":
                        ExcluirSerie();
                        break;
                    case "5":
                        VisualizarSerie();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                        break;
                }

                opcaoUsuario = ObterOpcaoUsuario();

            }

            Console.WriteLine("Obrigado por utilizar nossos serviços!");
            Console.WriteLine();
        }

        private static void ExcluirSerie()
        {
            Console.Write("Digite o Id da Série: ");
            int idSerie = int.Parse(Console.ReadLine());

            repositorio.Exclui(idSerie);

            var serie = repositorio.RetornaPorId(idSerie);

            Console.WriteLine(serie);
        }

        private static void VisualizarSerie()
        {
            Console.Write("Digite o Id da Série: ");
            int idSerie = int.Parse(Console.ReadLine());
        }

        private static void AtualizarSerie()
        {
            Console.Write("Digite o id da serie: ");
            int idSerie = int.Parse(Console.ReadLine());

            foreach (int i in Enum.Genero.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.Genero.GetName(typeof(Genero), i));
            }
            Console.Write("Digite o Genero entre as Opcões acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o Titulo da Série: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o Ano da Inicio da Série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a descrição da Série: ");
            string entradaDescricao = Console.ReadLine();

            Serie atualizaSerie = new Serie(id: idSerie,
                                            genero: (Genero)entradaGenero,
                                            titulo: entradaTitulo,
                                            ano: entradaAno,
                                            descricao: entradaDescricao); 
            
            repositorio.Atualiza(idSerie, atualizaSerie);
        }

        private static void listaSerie()
        {
            Console.WriteLine("Listar Séries");

            var lista = repositorio.Lista();

            if(lista.Count == 0)
            {
                Console.WriteLine("Nenhuma Série Encontrada.");
                return;
            }

            foreach (var serie in lista)
            {
                var excluido = serie.RetornaExcluido();
                
                Console.WriteLine("#ID {0}: - {1} - {2}", serie.RetornaId(), serie.RetornaTitulo(), (excluido ? "Excluido" : ""));
            }
        }

        private static void InserirSerie()
        {
            Console.WriteLine("Inserir Nova Série");

            foreach (int i in Enum.Genero.GetValues(typeof(Genero)))
            {
                System.Console.WriteLine("{0} - {1}", i, Enum.Genero.GetName(typeof(Genero), i));
            }

            Console.Write("Digite o Genero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o Titulo da Série: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o Ano de Lançamento: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a Descrição da Série: ");
            string entradaDescricao = Console.ReadLine();

            Serie novaSerie = new Serie (id: repositorio.ProximoId(),
                                         genero: (Genero)entradaGenero,
                                         titulo: entradaTitulo,
                                         ano: entradaAno,
                                         descricao: entradaDescricao);

            repositorio.Insere(novaSerie);
        }


        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.Write("#################### - ");
            Console.Write("SÉRIES - ");
            Console.WriteLine("####################");
            Console.WriteLine("Informe a Opção desejada:");
            Console.WriteLine("1- Listar Séries");
            Console.WriteLine("2- Inserir nova Série");
            Console.WriteLine("3- Atualizar Série");
            Console.WriteLine("4- Excluir Série");
            Console.WriteLine("5- Visualizar Série");
            Console.WriteLine("C- Limpar Tela");
            Console.WriteLine("X- Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}
