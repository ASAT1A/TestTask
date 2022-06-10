using System;

namespace TestTask
{

    // Базовый класс сотрудника
    abstract public class BaseEmployee
    {
        public static string[] arrayGender = { "Мужской", "Женский" };
        public static string[] arrayPosition = { "Рабочий", "Контролер", "Руководитель подразделения", "Директор" };
        public static string[] arraySubdivision = { "Бухгалтерия", "Отдел технического контроля", "Отдел кадров", "Производственный цех", "Служба безопасности" };
        private string name;
        private string gender;
        private string position;
        private string subdivision;
        private string specialInfo;
        public int idGender = 1;
        public int idPosition = 1;
        public int idSubdivisition = 1;
        private DateTime birthday;
        public string Name
        {
            get { return name; }
            set
            {
                if (value == null)
                    name = "Неопределено";
                else
                    name = value;
            }
        }
        public string Gender
        {
            get { return gender; }
            set
            {
                if (value == null)
                    gender = "Неопределен";
                else
                    gender = value;
            }
        }
        public string Position
        {
            get { return position; }
            set
            {
                if (value == null)
                    position = "Неопределена";
                else
                    position = value;
            }
        }
        public string Subdivision
        {
            get { return subdivision; }
            set
            {
                if (value == null)
                    subdivision = "Неопределен";
                else
                    subdivision = value;
            }
        }
        public string SpecialInfo
        {
            get { return specialInfo; }
            set
            {
                if (value == null)
                    specialInfo = "Неопределено";
                else
                    specialInfo = value;
            }
        }
        public int IdGender
        {
            get { return idGender; }
            set
            {
                if (value < 1)
                    idGender = 1;
                else if (value > 2)
                    idGender = 2;
                else
                    idGender = value;
            }
        }
        public int IdPosition
        {
            get { return idPosition; }
            set
            {
                if (value < 1)
                    idPosition = 1;
                else if (value > 4)
                    idPosition = 4;
                else
                    idPosition = value;
            }
        }
        public int IdSubdivision
        {
            get { return idSubdivisition; }
            set
            {
                if (value < 1)
                    idSubdivisition = 1;
                else if (value > 5)
                    idSubdivisition = 5;
                else
                    idSubdivisition = value;
            }
        }
        public DateTime Birthday
        {
            get { return birthday; }
            set
            {
                if(value == null)
                    birthday = DateTime.MinValue;
                else
                    birthday = value;
            }
        }

        public static string GetGender(int IdGender)
        {
                 if (IdGender == 1)
                return arrayGender[0];
            else if (IdGender == 2)
                return arrayGender[1];
            else
                return "Неопределен";
        }
        public static string GetPosition(int IdPosition)
        {
                 if (IdPosition == 1)
                return arrayPosition[0];
            else if (IdPosition == 2)
                return arrayPosition[1];
            else if (IdPosition == 3)
                return arrayPosition[2];
            else if (IdPosition == 4)
                return arrayPosition[3];
            else
                return "Неопределена";
        }
        public static string GetSubdivision(int IdSubdivision)
        {
                 if (IdSubdivision == 1)
                return arraySubdivision[0];
            else if (IdSubdivision == 2)
                return arraySubdivision[1];
            else if (IdSubdivision == 3)
                return arraySubdivision[2];
            else if (IdSubdivision == 4)
                return arraySubdivision[3];
            else if (IdSubdivision == 5)
                return arraySubdivision[4];
            else
                return "Неопределено";
        }
        public BaseEmployee()
        {
            this.Name = "Имя";
            this.Gender = GetGender(IdGender);
            this.Position = GetPosition(IdPosition);
            this.Subdivision = GetSubdivision(IdSubdivision);
            this.SpecialInfo = "Имя";
            this.Birthday = DateTime.MinValue;
        }
        public BaseEmployee(string Name, int IdGender, int IdSubdivision, string SpecialInfo, DateTime Birthday)
        {
            this.Name = Name;
            this.Gender = GetGender(IdGender);
            this.Position = GetPosition(IdPosition);
            this.Subdivision = GetSubdivision(IdSubdivision);
            this.SpecialInfo = SpecialInfo;
            this.Birthday = Birthday;
        }

        //  Описывается отрисовка информации о сотруднике
        public abstract void PrintInfo(int positionX, int positionY);

        //  Описывается выбор ФИО сотрудника
        public void SetName(int positionX, int positionY, int countLines)
        {
            bool endName = true;
            while (endName)
            {
                Print.ClearSpace(' ', countLines, Console.BufferWidth / 2, positionX - 2, positionY + 2);
                Print.PrintText("Введите ФИО сотрудника: ", positionX, positionY + 3, ConsoleColor.White);
                string input = Console.ReadLine();
               
                if (input.Length <= 5)
                {
                    Print.PrintLongText("Введите корректное ФИО, разделяя слова пробелом\nНажмите любую кнопку для продолжения", positionX, positionY + 4);
                    Console.ReadKey();
                }
                else
                {
                    Print.ClearSpace(' ', countLines, Console.BufferWidth / 2, positionX, positionY + 2);
                    ListNewEmployees.NewEmployeesInOgranisation[0].Name = input;
                    endName = false;
                }
            }
        }

        //  Описывается выбор пола сотрудника
        public void SetGender(int positionX, int positionY, int countLines)
        {
            bool endGender = true;
            while (endGender)
            {
                Print.ClearSpace(' ', countLines, Console.BufferWidth / 2, positionX - 2, positionY + 2);
                Print.PrintText("Выберите пол сотрудника: ", positionX, positionY + 3, ConsoleColor.White);

                int counter = 1;
                int Y = positionY;
                for (int i = 0; i < BaseEmployee.arrayGender.Length; i++)
                {
                    Print.PrintInitializerInt(counter, ConsoleColor.Cyan, positionX, Y + 5);
                    Print.PrintText(BaseEmployee.arrayGender[i], positionX + 6, Y + 5, ConsoleColor.White);
                    counter++;
                    Y += 1;
                }

                ConsoleKeyInfo key = Console.ReadKey(true);

                switch (key.Key)
                {
                    case ConsoleKey.D1:
                        ListNewEmployees.NewEmployeesInOgranisation[0].Gender = BaseEmployee.arrayGender[0];
                        Print.ClearSpace(' ', countLines, Console.BufferWidth / 2, positionX, positionY + 2);
                        endGender = false;
                        break;
                    case ConsoleKey.D2:
                        ListNewEmployees.NewEmployeesInOgranisation[0].Gender = BaseEmployee.arrayGender[1];
                        Print.ClearSpace(' ', countLines, Console.BufferWidth / 2, positionX, positionY + 2);
                        endGender = false;
                        break;
                }
            }
        }

        //  Описывается выбор даты рождения сотрудника
        public void SetBirthday(int positionX, int positionY, int countLines)
        {
            bool endBirthday = true;
            while (endBirthday)
            {
                Print.ClearSpace(' ', countLines, Console.BufferWidth / 2, positionX - 2, positionY + 2);
                Print.PrintText("Введите дату рождения сотрудника в виде \"DD.MM.YYYY\": ", positionX, positionY + 3, ConsoleColor.White);
                
                string dValue = Console.ReadLine();
                if (DateTime.TryParseExact(dValue, "dd.MM.yyyy", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out DateTime date)) //&& (date > new DateTime(01, 01, 1930)) && (date < new DateTime(01, 01, 2010))
                {
                    Print.ClearSpace(' ', countLines, Console.BufferWidth / 2, positionX, positionY + 2);
                    ListNewEmployees.NewEmployeesInOgranisation[0].Birthday = date;
                    endBirthday = false;
                }
                else
                {
                    Console.WriteLine("Введите корректное значение в виде дд.mm.гггг");
                }
            }
        }

        //  Описывается выбор подразделения сотрудника
        public void SetSubdivision(int positionX, int positionY, int countLines)
        {
            bool endSubdivision = true;
            while (endSubdivision)
            {
                Print.ClearSpace(' ', countLines, Console.BufferWidth / 2, positionX - 2, positionY + 2);
                Print.PrintText("Выберите подразделение сотрудника: ", positionX, positionY + 3, ConsoleColor.White);

                int counter = 1;
                int Y = positionY;
                for (int i = 0; i < BaseEmployee.arraySubdivision.Length; i++)
                {
                    Print.PrintInitializerInt(counter, ConsoleColor.Cyan, positionX, Y + 5);
                    Print.PrintText(BaseEmployee.arraySubdivision[i], positionX + 6, Y + 5, ConsoleColor.White);
                    counter++;
                    Y += 1;
                }

                ConsoleKeyInfo key = Console.ReadKey(true);

                switch (key.Key)
                {
                    case ConsoleKey.D1:
                        ListNewEmployees.NewEmployeesInOgranisation[0].Subdivision = BaseEmployee.arraySubdivision[0];
                        Print.ClearSpace(' ', countLines, Console.BufferWidth / 2, positionX, positionY + 2);
                        endSubdivision = false;
                        break;
                    case ConsoleKey.D2:
                        ListNewEmployees.NewEmployeesInOgranisation[0].Subdivision = BaseEmployee.arraySubdivision[1];
                        Print.ClearSpace(' ', countLines, Console.BufferWidth / 2, positionX, positionY + 2);
                        endSubdivision = false;
                        break;
                    case ConsoleKey.D3:
                        ListNewEmployees.NewEmployeesInOgranisation[0].Subdivision = BaseEmployee.arraySubdivision[2];
                        Print.ClearSpace(' ', countLines, Console.BufferWidth / 2, positionX, positionY + 2);
                        endSubdivision = false;
                        break;
                    case ConsoleKey.D4:
                        ListNewEmployees.NewEmployeesInOgranisation[0].Subdivision = BaseEmployee.arraySubdivision[3];
                        Print.ClearSpace(' ', countLines, Console.BufferWidth / 2, positionX, positionY + 2);
                        endSubdivision = false;
                        break;
                    case ConsoleKey.D5:
                        ListNewEmployees.NewEmployeesInOgranisation[0].Subdivision = BaseEmployee.arraySubdivision[4];
                        Print.ClearSpace(' ', countLines, Console.BufferWidth / 2, positionX, positionY + 2);
                        endSubdivision = false;
                        break;
                }
            }
        }

        public abstract void SetSpecialInfo(int positionX, int positionY, int countLines);
        //Описывается выбор уникальной информации о сотруднике
        public abstract void SetAllInfo(int positionX, int positionY, int countLines);
    }
}
