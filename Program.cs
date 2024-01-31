using System;


namespace DIO.Series

{
    class program
    {
        static SerieRepository repository = new SerieRepository();
        static void Main(string[] args)
        {
            string opcaoUsuario = obterOpcaoUsuario();
            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListSeries();
                        break;
                    case "2":
                        InserirSerie();
                        break;
                    case "3":
                        //updateSerie();
                        break;
                    case "4":
                        //deleteSerie();
                        break;
                    case "5":
                        //ReturnById();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                opcaoUsuario = obterOpcaoUsuario();
            }

        }

        private static string obterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("As Series estão a seu dispor!");
            Console.WriteLine("Informe a opção desejada:");

            Console.WriteLine("1 - Listar Séries");
            Console.WriteLine("2 - Inserir nova Série");
            Console.WriteLine("3 - Atualizar Série");
            Console.WriteLine("4 - Excluir Série");
            Console.WriteLine("5 - Visualizar Série");
            Console.WriteLine("C - Limpar Tela");
            Console.WriteLine("X - Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }

        private static void ListSeries()
        {
            Console.WriteLine("List series");
            var list = repository.Lista();

            if (list.Count == 0)
            {
                Console.WriteLine("No serie founded !");
                return;
            }

            foreach (var serie in list)
            {
                Console.WriteLine("#ID {0}: - {1}", serie.retornarId(), serie.retornarTitulo());
            }

        }

        private static void InserirSerie()
        {
            Console.WriteLine("Inserir nova série");

            foreach (var i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.Write("Digite o genêro entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o titulo da Série: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o Ano de Inicio da Série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a Descrição da Série: ");
            string entradaDescricao = Console.ReadLine();

            Serie novaSerie = new Serie(repository.NextId(),
                                        (Genero)entradaGenero,
                                        entradaTitulo,
                                        entradaDescricao,
                                        entradaAno);

            repository.Insert(novaSerie);
            
        }


    }
}