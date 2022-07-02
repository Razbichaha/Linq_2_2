using System;
using System.Collections.Generic;
using System.Linq;

namespace Linqu_2
{
    class Program
    {
        static void Main(string[] args)
        {
            ProgramCore programCore = new();
            programCore.StartWorkingWithPrisoners();
        }
    }

    class ProgramCore
    {
        private int _quantityPerpetratos = 30;
        private List<Perpetrator> _perpetrators = new List<Perpetrator>();

        public ProgramCore()
        {
            GenerateBase();
        }

        internal void StartWorkingWithPrisoners()
        {
            Console.Clear();
            Console.WriteLine("База данных перед амнистией");
            Console.WriteLine("Для продолжения нажмите Enter");
            Console.ReadLine();

            ShowAll();

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Для амнистии за антиправительственные выступления нажмите Enter");
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadLine();

            AmnestyPolitical();
            ShowAll();

            Console.ReadLine();
        }

        private void AmnestyPolitical()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Прошла амнистия");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;

            var amnesty = from Perpetrator in _perpetrators where Perpetrator.Status == "Антиправительственное" select Perpetrator;
            var amnestyDelete =_perpetrators .Except(amnesty);

            List<Perpetrator> temp = new List<Perpetrator>();

            foreach (Perpetrator perpetrator in amnestyDelete)
            {
                temp.Add(perpetrator);
            }
            _perpetrators = temp;
        }

        private void ShowAll()
        {
            foreach (Perpetrator perpetrator in _perpetrators)
            {
                ShowPerpetrator(perpetrator);
            }
        }

        private void ShowPerpetrator(Perpetrator perpetrator)
        {
            Console.WriteLine($" {perpetrator.FullName }  | Преступление - {perpetrator.Status}");
        }

        private void GenerateBase()
        {
            bool continueGeneration = true;

            while (continueGeneration)
            {
                Perpetrator perpetrator = new Perpetrator();

                if (CheckFullNameMatching(perpetrator) == false)
                {
                    _perpetrators.Add(perpetrator);
                }
                if (_perpetrators.Count == _quantityPerpetratos)
                {
                    continueGeneration = false;
                }
            }
        }

        private bool CheckFullNameMatching(Perpetrator perpetrator)
        {
            bool isMatching = false;

            foreach (Perpetrator perpetratorTemp in _perpetrators)
            {
                if (perpetrator.FullName == perpetratorTemp.FullName)
                {
                    isMatching = true;
                }
            }
            return isMatching;
        }
    }

    class Perpetrator
    {
        internal string FullName { get; private set; }
        internal string Status { get; private set; }

        public Perpetrator()
        {
            GenerateFullName();
            GenerateStatus();
        }

        internal void SetStatusAmnesty()
        {
            Status = "Амнистирован";
        }

        private void GenerateFullName()
        {
            string[] fullNameBase = { "Нестер Евгения Ильинична", "Самиров Леонид Егорович"
                , "Рязанцев Андрей Александрович", "Фунтов Юрий Геннадьевич", "Ивойлова Ксения Марселевна"
                , "Шестунов Алексей Романович", "Ефанов Николай Алексеевич", "Петухина Алена Никитовна", "Качковский Вадим Васильевич"
                , "Тунеева Маргарита Вадимовна", "Точилкина Анжелика Григорьевна", "Батраков Никита Павлович", "Вязмитинова Галина Яновна"
                , "Индейкина Оксана Романовна", "Колосюк Руслан Янович", "Четков Михаил Ильич", "Хорошилова Надежда Кирилловна"
                , "Кадулин Павел Тимурович", "Якименко Вероника Рамилевна", "Валиулин Дмитрий Данилович", "Тельпугова Евгения Артемовна"
                , "Биушкина Татьяна Олеговна", "Славутинский Николай Игоревич", "Давыдов Александр Петрович", "Туаева Вероника Максимовна"
                , "Мутовкина Ирина Васильевна", "Тактаров Эдуард Ринатович", "Златовратский Борис Павлович", "Недодаева Полина Аркадьевна"
                , "Спиридонов Роман Борисович", "Лоринова Людмила Тимуровна", "Ряхин Марат Русланович", "Юльева Екатерина Ивановна"
                , "Шуйгин Олег Максимович", "Проклов Глеб Валентинович", "Майданов Тимофей Алексеевич", "Славянинов Артур Маратович"
                , "Таюпова Оксана Робертовна", "Коноплич Маргарита Андреевна", "Дратцева Римма Денисовна", "Гречановская Тамара Федоровна"
                , "Петрищева Ирина Никитовна", "Шейхаметова Раиса Артуровна", "Сумцова Анжелика Геннадьевна", "Есиповская Татьяна Робертовна"
                , "Свиногузова Кристина Ильдаровна", "Галанина Лидия Альбертовна", "Ледяева Жанна Константиновна", "Дудник Егор Радикович"
                , "Гаянов Григорий Алексеевич" };
            Random random = new Random();

            FullName = fullNameBase[random.Next(fullNameBase.Length)];
        }

        private void GenerateStatus()
        {
            string[] status = { "Уголовное", "Антиправительственное" };
            Random random = new Random();

            Status = status[random.Next(status.Length)];
        }
    }
}
