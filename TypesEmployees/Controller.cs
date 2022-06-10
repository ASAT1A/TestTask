using System;

namespace TestTask
{
    // Наследуюмый класс контролера со специальной информацией: ФИО директора
    public class Controller : BaseEmployee
    {
        public Controller() : base()
        {

        }
        public Controller(string Name, int IdGender, int IdSubdivision, string SpecialInfo, DateTime Birthday) : base(Name, IdGender, IdSubdivision, SpecialInfo, Birthday)
        {
            this.Position = GetPosition(2);
        }

        public override void PrintInfo(int positionX, int positionY)
        {
            Print.PrintDoubleText("ФИО: ", Name, positionX, positionY, ConsoleColor.Gray, ConsoleColor.White);
            Print.PrintDoubleText("Дата рождения: ", Birthday.ToLongDateString(), positionX, positionY + 1, ConsoleColor.Gray, ConsoleColor.White);
            Print.PrintDoubleText("Пол: ", Gender, positionX, positionY + 2, ConsoleColor.Gray, ConsoleColor.White);
            Print.PrintDoubleText("Подразделение: ", Subdivision, positionX, positionY + 3, ConsoleColor.Gray, ConsoleColor.White);
            Print.PrintDoubleText("Должность: ", Position, positionX, positionY + 4, ConsoleColor.Gray, ConsoleColor.White);
            Print.PrintDoubleText("ФИО директора: ", SpecialInfo, positionX, positionY + 5, ConsoleColor.Gray, ConsoleColor.White);
        }

        public override void SetSpecialInfo(int positionX, int positionY, int countLines)
        {
            bool endSpecialInfo = true;
            while (endSpecialInfo)
            {
                Print.ClearSpace(' ', countLines, Console.BufferWidth / 2, positionX - 2, positionY + 2);
                Print.PrintText("Введите ФИО директора: ", positionX, positionY + 3, ConsoleColor.White);

                string input = Console.ReadLine();

                if (input.Length <= 5)
                {
                    Print.PrintLongText("Введите корректное ФИО, разделяя слова пробелом\nНажмите любую кнопку для продолжения", positionX, positionY + 4);
                    Console.ReadKey();
                }
                else
                {
                    Print.ClearSpace(' ', countLines, Console.BufferWidth / 2, positionX, positionY + 2);
                    ListNewEmployees.NewEmployeesInOgranisation[0].SpecialInfo = input;
                    endSpecialInfo = false;
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
