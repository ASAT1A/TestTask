using System;

namespace TestTask
{
    // Наследуюмый класс руководителя со специальной информацией: Дата приема на работу
    public class LeaderSubvision : BaseEmployee
    {
        public LeaderSubvision() : base()
        {

        }
        public LeaderSubvision(string Name, int IdGender, int IdSubdivision, string SpecialInfo, DateTime Birthday) : base(Name, IdGender, IdSubdivision, SpecialInfo, Birthday)
        {
            this.Position = GetPosition(3);
        }
        public override void PrintInfo(int positionX, int positionY)
        {
            Print.PrintDoubleText("ФИО: ", Name, positionX, positionY, ConsoleColor.Gray, ConsoleColor.White);
            Print.PrintDoubleText("Дата рождения: ", Birthday.ToLongDateString(), positionX, positionY + 1, ConsoleColor.Gray, ConsoleColor.White);
            Print.PrintDoubleText("Пол: ", Gender, positionX, positionY + 2, ConsoleColor.Gray, ConsoleColor.White);
            Print.PrintDoubleText("Подразделение: ", Subdivision, positionX, positionY + 3, ConsoleColor.Gray, ConsoleColor.White);
            Print.PrintDoubleText("Должность: ", Position, positionX, positionY + 4, ConsoleColor.Gray, ConsoleColor.White);
            Print.PrintDoubleText("Дата приема на работу: ", SpecialInfo, positionX, positionY + 5, ConsoleColor.Gray, ConsoleColor.White);
        }

        public override void SetSpecialInfo(int positionX, int positionY, int countLines)
        {
            bool endBirthday = true;
            while (endBirthday)
            {
                Print.ClearSpace(' ', countLines, Console.BufferWidth / 2, positionX - 2, positionY + 2);
                Print.PrintText("Введите дату приема сотрудника на работу в виде \"DD.MM.YYYY\": ", positionX, positionY + 3, ConsoleColor.White);

                string dValue = Console.ReadLine();
                if (DateTime.TryParseExact(dValue, "dd.MM.yyyy", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out DateTime date)) //&& (date > new DateTime(01, 01, 1930)) && (date < new DateTime(01, 01, 2010))
                {
                    Print.ClearSpace(' ', countLines, Console.BufferWidth / 2, positionX, positionY + 2);
                    ListNewEmployees.NewEmployeesInOgranisation[0].SpecialInfo = date.ToLongDateString();
                    endBirthday = false;
                }
                else
                {
                    Console.WriteLine("Введите корректное значение в виде дд.мм.гггг");
                }
            }
        }

        public override void SetAllInfo(int positionX, int positionY, int countLines)
        {
            SetName(positionX, positionY, countLines);
            SetGender(positionX, positionY, countLines);
            SetBirthday(positionX, positionY, countLines);
            SetSubdivision(positionX, positionY, countLines);
            SetSpecialInfo(positionX, positionY, countLines);
        }
    }
}
