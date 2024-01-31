using System;

namespace DIO.Series
{
    class Program
    {
        static SerieRepository repository = new SerieRepository();

        static void Main(string[] args)
        {
            string userOption = GetUserOption();
            while (userOption.ToUpper() != "X")
            {
                switch (userOption)
                {
                    case "1":
                        ListSeries();
                        break;
                    case "2":
                        InsertSerie();
                        break;
                    case "3":
                        UpdateSerie();
                        break;
                    case "4":
                        DeleteSerie();
                        break;
                    case "5":
                        ViewByID();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                userOption = GetUserOption();
            }

        }

        private static string GetUserOption()
        {
            Console.WriteLine();
            Console.WriteLine("Series are at your disposal!");
            Console.WriteLine("Choose an option:");

            Console.WriteLine("1 - List Series");
            Console.WriteLine("2 - Insert New Series");
            Console.WriteLine("3 - Update Series");
            Console.WriteLine("4 - Delete Series");
            Console.WriteLine("5 - View Series by ID");
            Console.WriteLine("C - Clear Screen");
            Console.WriteLine("X - Exit");
            Console.WriteLine();

            string userOption = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return userOption;
        }

        private static void ListSeries()
        {
            Console.WriteLine("List series");
            var list = repository.List();

            if (list.Count == 0)
            {
                Console.WriteLine("No series found!");
                return;
            }

            foreach (var serie in list)
            {
                var deleted = serie.returnDeleted();
                Console.WriteLine("#ID {0}: - {1} - {2}", serie.ReturnId(), serie.ReturnTitle(), deleted ? "*Excluido*" : "");
            }

        }

        private static void InsertSerie()
        {
            Console.WriteLine("Insert new series");

            foreach (var i in Enum.GetValues(typeof(Genre)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genre), i));
            }
            Console.Write("Enter the genre from the options above: ");
            int genreInput = int.Parse(Console.ReadLine());

            Console.Write("Enter the title of the series: ");
            string titleInput = Console.ReadLine();

            Console.Write("Enter the Year of the Series Start: ");
            int yearInput = int.Parse(Console.ReadLine());

            Console.Write("Enter the Description of the Series: ");
            string descriptionInput = Console.ReadLine();

            Serie newSerie = new Serie(repository.NextId(),
                                        (Genre)genreInput,
                                        titleInput,
                                        descriptionInput,
                                        yearInput);

            repository.Insert(newSerie);
        }

        private static void UpdateSerie()
        {
            Console.WriteLine("Enter the ID of the series");
            int serieIndex = int.Parse(Console.ReadLine());
            foreach (var i in Enum.GetValues(typeof(Genre)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genre), i));
            }
            Console.Write("Enter the genre from the options above: ");
            int genreInput = int.Parse(Console.ReadLine());

            Console.Write("Enter the title of the series: ");
            string titleInput = Console.ReadLine();

            Console.Write("Enter the Year of the Series Start: ");
            int yearInput = int.Parse(Console.ReadLine());

            Console.Write("Enter the Description of the Series: ");
            string descriptionInput = Console.ReadLine();

            Serie serieUpdate = new Serie(serieIndex,
                                        (Genre)genreInput,
                                        titleInput,
                                        descriptionInput,
                                        yearInput);

            repository.Update(serieIndex, serieUpdate);
        }

        private static void DeleteSerie()
        {
            Console.WriteLine("Enter the id of the series");
            int serieId = int.Parse(Console.ReadLine());
            repository.Delete(serieId);
        }

        private static void ViewByID()
        {
            Console.Write("Enter the id of the series: ");
            int serieIndex = int.Parse(Console.ReadLine());

            var serie = repository.ReturnById(serieIndex);

            Console.WriteLine(serie.ToString());
        }
    }
}