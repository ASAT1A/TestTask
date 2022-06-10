using System;

namespace TestTask
{
    // Основной класс, где описываются ключевые методы при работе с пользователем
    public class Menu
    {
        public static void Execution()
        {
            //  Добавление начальных сотрудников в базу данных
            int X = 2, Y = 6;
            ListEmployees.AddEmployeesInOgranisation(new Worker("Ермаков Владимир Игнатьевич", 1 , 4, "Давыдов Родион Игнатьевич", DateTime.Parse("1985.11.23")));
            ListEmployees.AddEmployeesInOgranisation(new Director("Капустин Тимур Лукьянович", 1, 2, "РАМФУД", DateTime.Parse("1991.05.10")));
            ListEmployees.AddEmployeesInOgranisation(new Worker("Рыбаков Михаил Леонидович", 1, 4, "Давыдов Родион Игнатьевич", DateTime.Parse("1967.09.13")));
            ListEmployees.AddEmployeesInOgranisation(new Controller("Мамонтов Владимир Михайлович", 1, 3, "Капустин Тимур Лукьянович", DateTime.Parse("1993.03.20")));
            ListEmployees.AddEmployeesInOgranisation(new LeaderSubvision("Давыдов Родион Игнатьевич", 1, 4, "17.02.2012", DateTime.Parse("1981.04.22")));
            ListEmployees.AddEmployeesInOgranisation(new Controller("Кабанов Артур Антонович", 1, 1, "Капустин Тимур Лукьянович", DateTime.Parse("1987.07.02")));
            ListEmployees.AddEmployeesInOgranisation(new Worker("Капустина Елена Арсеньевна", 2, 1, "Цветкова Елизавета Алексеевна", DateTime.Parse("1993.02.06")));
            ListEmployees.AddEmployeesInOgranisation(new LeaderSubvision("Цветкова Елизавета Алексеевна", 2, 1, "17.02.2016", DateTime.Parse("1987.12.11")));
            ListEmployees.AddEmployeesInOgranisation(new LeaderSubvision("Медведев Дмитрий Денисович", 1, 2, "11.02.1999", DateTime.Parse("1972.07.08")));
            ListEmployees.AddEmployeesInOgranisation(new Worker("Князев Филипп Игоревич", 1, 2, "Медведев Дмитрий Денисович", DateTime.Parse("1995.10.15")));
            ListEmployees.AddEmployeesInOgranisation(new Worker("Кулаков Ян Васильевич", 1, 2, "Медведев Дмитрий Денисович", DateTime.Parse("1987.03.21")));

            //  Описывается основной процесс работы программы
            while (true)
            {
                //  Отрисовывается главное меню программы
                Print.ClearAllSpace();
                PrintMainMenu(X, Y);
                Console.SetCursorPosition(0, 0);

                //  Считывается нажатая кнопка в главном меню программы
                ConsoleKeyInfo key = Console.ReadKey(true);

                switch (key.Key)
                {
                    case ConsoleKey.A:
                        ClickA(X, Y, 9);
                        break;
                    case ConsoleKey.D:
                        ClickD(X, Y, 9);
                        break;
                    case ConsoleKey.O:
                        ClickO(X, Y, 9);
                        break;
                    case ConsoleKey.C:
                        ClickC(X, Y, 9);
                        break;
                    case ConsoleKey.P:
                        ClickP(X, Y, 9);
                        break;
                }
                ListNewEmployees.ClearNewEmployeesInOgranisation();
                ListChangeEmployees.ClearChangeEmployeesInOgranisation();
            }
        }

        //  Описываетя отрисовка заголовка программы
        public static void PrintHeader(int positionX, int positionY, ConsoleColor colorText, ConsoleColor colorWall)
        {
            Print.PrintText(Print.PrintWall('=', 85), positionX, positionY, colorWall);
            Print.PrintText("Список сотрудников предприятия по производству пищевой промышленности - \"РАМФУД\"", positionX + 3, positionY + 1, colorText);
            Print.PrintText(Print.PrintWall('=', 85), positionX, positionY + 2, colorWall);
        }

        //  Описывается отрисовка пользовательского управления
        public static void PrintUsersMenu(int positionX, int positionY)
        {
            Print.PrintText("Управление списком: ", positionX, positionY, ConsoleColor.White);
            Print.PrintText(Print.PrintWall('=', 95), positionX, positionY + 1, ConsoleColor.Gray);
            Print.PrintInitializerChar('A', ConsoleColor.Cyan, positionX, positionY + 2);
            Print.PrintText("- Добавить новый профиль сотрудника", positionX + 6, positionY + 2, ConsoleColor.White);
            Print.PrintInitializerChar('D', ConsoleColor.Cyan, positionX, positionY + 4);
            Print.PrintText("- Удалить профиль сотрудника", positionX + 6, positionY + 4, ConsoleColor.White);
            Print.PrintInitializerChar('O', ConsoleColor.Cyan, positionX, positionY + 6);
            Print.PrintText("- Открыть профиль сотрудника", positionX + 6, positionY + 6, ConsoleColor.White);
            Print.PrintInitializerChar('C', ConsoleColor.Cyan, positionX, positionY + 8);
            Print.PrintText("- Установить критерии поиска сотрудников", positionX + 6, positionY + 8, ConsoleColor.White);
            Print.PrintInitializerChar('P', ConsoleColor.Cyan, positionX, positionY + 10);
            Print.PrintText("- Полностью очистить список сотрудников", positionX + 6, positionY + 10, ConsoleColor.White);

            Print.PrintText(Print.PrintWall('=', 95), positionX, positionY + 11, ConsoleColor.Gray);

        }

        //  Описывается отрисовка главного меню программы
        public static void PrintMainMenu(int positionX, int positionY)
        {
            PrintHeader(0, 1, ConsoleColor.Yellow, ConsoleColor.Gray);
            PrintUsersMenu(positionX, positionY);
            ListEmployees.PrintEmployeesInOgranisation(positionX, positionY + 14);
        }

        //  Описываются действия при нажатии кнопки "A" + Закончено
        public static void ClickA(int positionX, int positionY, int countLines)
        {
            bool endA = true;
            while (endA)
            {
                //  Описываются выбор должности сотрудника и создание его профиля
                A_ChoicePosition(positionX, positionY, countLines);

                // Описываются действия, если пользователь выбрал должность
                if (ListNewEmployees.NewEmployeesInOgranisation.Count != 0)
                {
                    // Описывается заполнение профился сотрудника
                    ListNewEmployees.NewEmployeesInOgranisation[0].SetAllInfo(positionX, positionY, countLines);
                    Print.ClearSpace(' ', countLines, Console.BufferWidth / 2, positionX, positionY + 2);

                    // Отрисовывается профиль сотрудника
                    ListNewEmployees.NewEmployeesInOgranisation[0].PrintInfo(positionX, positionY + 3);

                    bool endAdd = true;
                    while (endAdd)
                    {
                        Print.PrintInitializerChar('C', ConsoleColor.Cyan, positionX + 45, positionY + 7);
                        Print.PrintText("- Изменить профиль сотрудника", positionX + 51, positionY + 7, ConsoleColor.White);
                        Print.PrintInitializerChar('B', ConsoleColor.Cyan, positionX + 45, positionY + 9);
                        Print.PrintText("- Вернуться в главное меню", positionX + 51, positionY + 9, ConsoleColor.White);


                        // Определяется параметр для изменения
                        ConsoleKeyInfo key = Console.ReadKey(true);

                        switch (key.Key)
                        {
                            case ConsoleKey.C:
                                bool endChange = true;
                                while (endChange)
                                {
                                    Print.ClearSpace(' ', countLines, Console.BufferWidth, positionX, positionY + 2);
                                    Print.PrintText("Выберите свойство, которое хотите изменить: ", positionX, positionY + 2, ConsoleColor.White);
                                    Print.PrintInitializerChar('1', ConsoleColor.Cyan, positionX, positionY + 4);
                                    Print.PrintInitializerChar('2', ConsoleColor.Cyan, positionX, positionY + 5);
                                    Print.PrintInitializerChar('3', ConsoleColor.Cyan, positionX, positionY + 6);
                                    Print.PrintInitializerChar('4', ConsoleColor.Cyan, positionX, positionY + 7);
                                    Print.PrintInitializerChar('5', ConsoleColor.Cyan, positionX, positionY + 8);
                                    Print.PrintInitializerChar('6', ConsoleColor.Cyan, positionX, positionY + 9);
                                    ListNewEmployees.NewEmployeesInOgranisation[0].PrintInfo(positionX + 8, positionY + 4);
                                    Print.PrintInitializerChar('B', ConsoleColor.Cyan, positionX + 51, positionY + 7);
                                    Print.PrintText("- Вернуться в главное меню", positionX + 56, positionY + 7, ConsoleColor.White);

                                    ConsoleKeyInfo key2 = Console.ReadKey(true);

                                    switch (key2.Key)
                                    {
                                        case ConsoleKey.D1:
                                            Print.ClearSpace(' ', countLines, Console.BufferWidth, positionX, positionY + 2);
                                            ListNewEmployees.NewEmployeesInOgranisation[0].SetName(positionX, positionY, countLines);
                                            break;
                                        case ConsoleKey.D2:
                                            Print.ClearSpace(' ', countLines, Console.BufferWidth, positionX, positionY + 2);
                                            ListNewEmployees.NewEmployeesInOgranisation[0].SetBirthday(positionX, positionY, countLines);
                                            break;
                                        case ConsoleKey.D3:
                                            Print.ClearSpace(' ', countLines, Console.BufferWidth, positionX, positionY + 2);
                                            ListNewEmployees.NewEmployeesInOgranisation[0].SetGender(positionX, positionY, countLines);
                                            break;
                                        case ConsoleKey.D4:
                                            Print.ClearSpace(' ', countLines, Console.BufferWidth, positionX, positionY + 2);
                                            ListNewEmployees.NewEmployeesInOgranisation[0].SetSubdivision(positionX, positionY, countLines);
                                            break;
                                        case ConsoleKey.D5:
                                            ListChangeEmployees.ClearChangeEmployeesInOgranisation();
                                            A_ChangePosition(positionX, positionY, countLines);
                                            ListNewEmployees.ClearNewEmployeesInOgranisation();
                                            ListNewEmployees.AddNewEmployeesInOgranisation(ListChangeEmployees.ChangeEmployeesInOgranisation[0]);
                                            Print.ClearSpace(' ', countLines, Console.BufferWidth, positionX, positionY + 2);
                                            ListNewEmployees.NewEmployeesInOgranisation[0].SetSpecialInfo(positionX, positionY, countLines);
                                            break;
                                        case ConsoleKey.D6:
                                            Print.ClearSpace(' ', countLines, Console.BufferWidth, positionX, positionY + 2);
                                            ListNewEmployees.NewEmployeesInOgranisation[0].SetSpecialInfo(positionX, positionY, countLines);
                                            break;
                                        case ConsoleKey.B:
                                            endChange = false;
                                            endAdd = false;
                                            endA = false;
                                            break;
                                    }
                                }
                                break;
                            case ConsoleKey.B:
                                ListEmployees.AddEmployeesInOgranisation(ListNewEmployees.NewEmployeesInOgranisation[0]);
                                ListNewEmployees.NewEmployeesInOgranisation.Clear();
                                endAdd = false;
                                endA = false;
                                break;
                        }
                    }

                    // В конце готовый профиль добавляется в общий список сотрудников
                    if (ListNewEmployees.NewEmployeesInOgranisation.Count != 0)
                    {
                        ListEmployees.AddEmployeesInOgranisation(ListNewEmployees.NewEmployeesInOgranisation[0]);
                        ListNewEmployees.ClearNewEmployeesInOgranisation();
                        ListChangeEmployees.ClearChangeEmployeesInOgranisation();
                    }
                }
                else
                {
                    endA = false;
                }
            }
        }


        //  Описываются действия при нажатии кнопки "D" + Закончено
        public static void ClickD(int positionX, int positionY, int countLines)
        {
            bool endD = true;
            while (endD)
            {
                Print.ClearSpace(' ', countLines, Console.BufferWidth / 2, positionX, positionY + 2);
                Print.PrintInitializerChar('0', ConsoleColor.Cyan, positionX, positionY + 10);
                Print.PrintText("- Введите, чтобы вернуться назад", positionX + 6, positionY + 10, ConsoleColor.White);
                Print.PrintText("Введите номер профиля для удаления: ", positionX, positionY + 3, ConsoleColor.White);

                string input = Console.ReadLine();
                bool result = int.TryParse(input, out int number);
                if (result == true)
                {
                    if (number == 0)
                    {
                        endD = false;
                    }
                    else if (number > 0 && number <= ListEmployees.EmployeesInOgranisation.Count)
                    {
                        ListEmployees.DeleteEmployeesInOgranisation(ListEmployees.EmployeesInOgranisation[number - 1]);
                        endD = false;
                    }
                    else
                    {
                        Print.PrintLongText("В списке нет сотрудника с таким номером\nНажмите любую кнопку для продолжения", positionX, positionY + 4);
                        Console.ReadKey();
                    }
                }
                else
                {

                }
            }
        }


        //  Описываются действия при нажатии кнопки "O" + Закончено
        public static void ClickO(int positionX, int positionY, int countLines)
        {
            if (ListEmployees.EmployeesInOgranisation.Count != 0)
            {
                bool endO = true;
                while (endO)
                {
                    Print.ClearSpace(' ', countLines, Console.BufferWidth / 2, positionX, positionY + 2);
                    Print.PrintInitializerChar('0', ConsoleColor.Cyan, positionX, positionY + 10);
                    Print.PrintText("- Введите, чтобы вернуться назад", positionX + 6, positionY + 10, ConsoleColor.White);
                    Print.PrintText("Введите номер профиля для открытия: ", positionX, positionY + 3, ConsoleColor.White);

                    string input = Console.ReadLine();
                    bool result = int.TryParse(input, out int number);
                    if (result == true)
                    {
                        if (number == 0)
                        {
                            endO = false;
                        }
                        else if (number > 0 && number <= ListEmployees.EmployeesInOgranisation.Count)
                        {
                            Print.ClearSpace(' ', countLines, Console.BufferWidth / 2, positionX, positionY + 2);
                            ListNewEmployees.AddNewEmployeesInOgranisation(ListEmployees.EmployeesInOgranisation[number - 1]);

                            // Отрисовывается профиль сотрудника
                            ListNewEmployees.NewEmployeesInOgranisation[0].PrintInfo(positionX, positionY + 3);

                            bool endAdd = true;
                            while (endAdd)
                            {
                                Print.PrintInitializerChar('C', ConsoleColor.Cyan, positionX + 45, positionY + 7);
                                Print.PrintText("- Изменить профиль сотрудника", positionX + 51, positionY + 7, ConsoleColor.White);
                                Print.PrintInitializerChar('B', ConsoleColor.Cyan, positionX + 45, positionY + 9);
                                Print.PrintText("- Вернуться в главное меню", positionX + 51, positionY + 9, ConsoleColor.White);


                                // Определяется параметр для изменения
                                ConsoleKeyInfo key = Console.ReadKey(true);

                                switch (key.Key)
                                {
                                    case ConsoleKey.C:
                                        bool endChange = true;
                                        while (endChange)
                                        {
                                            Print.ClearSpace(' ', countLines, Console.BufferWidth, positionX, positionY + 2);
                                            Print.PrintText("Выберите свойство, которое хотите изменить: ", positionX, positionY + 2, ConsoleColor.White);
                                            Print.PrintInitializerChar('1', ConsoleColor.Cyan, positionX, positionY + 4);
                                            Print.PrintInitializerChar('2', ConsoleColor.Cyan, positionX, positionY + 5);
                                            Print.PrintInitializerChar('3', ConsoleColor.Cyan, positionX, positionY + 6);
                                            Print.PrintInitializerChar('4', ConsoleColor.Cyan, positionX, positionY + 7);
                                            Print.PrintInitializerChar('5', ConsoleColor.Cyan, positionX, positionY + 8);
                                            Print.PrintInitializerChar('6', ConsoleColor.Cyan, positionX, positionY + 9);
                                            ListNewEmployees.NewEmployeesInOgranisation[0].PrintInfo(positionX + 8, positionY + 4);
                                            Print.PrintInitializerChar('B', ConsoleColor.Cyan, positionX + 51, positionY + 7);
                                            Print.PrintText("- Вернуться в главное меню", positionX + 56, positionY + 7, ConsoleColor.White);

                                            ConsoleKeyInfo key2 = Console.ReadKey(true);

                                            switch (key2.Key)
                                            {
                                                case ConsoleKey.D1:
                                                    Print.ClearSpace(' ', countLines, Console.BufferWidth, positionX, positionY + 2);
                                                    ListNewEmployees.NewEmployeesInOgranisation[0].SetName(positionX, positionY, countLines);
                                                    break;
                                                case ConsoleKey.D2:
                                                    Print.ClearSpace(' ', countLines, Console.BufferWidth, positionX, positionY + 2);
                                                    ListNewEmployees.NewEmployeesInOgranisation[0].SetBirthday(positionX, positionY, countLines);
                                                    break;
                                                case ConsoleKey.D3:
                                                    Print.ClearSpace(' ', countLines, Console.BufferWidth, positionX, positionY + 2);
                                                    ListNewEmployees.NewEmployeesInOgranisation[0].SetGender(positionX, positionY, countLines);
                                                    break;
                                                case ConsoleKey.D4:
                                                    Print.ClearSpace(' ', countLines, Console.BufferWidth, positionX, positionY + 2);
                                                    ListNewEmployees.NewEmployeesInOgranisation[0].SetSubdivision(positionX, positionY, countLines);
                                                    break;
                                                case ConsoleKey.D5:
                                                    ListChangeEmployees.ClearChangeEmployeesInOgranisation();
                                                    A_ChangePosition(positionX, positionY, countLines);
                                                    ListNewEmployees.ClearNewEmployeesInOgranisation();
                                                    ListNewEmployees.AddNewEmployeesInOgranisation(ListChangeEmployees.ChangeEmployeesInOgranisation[0]);
                                                    Print.ClearSpace(' ', countLines, Console.BufferWidth, positionX, positionY + 2);
                                                    ListNewEmployees.NewEmployeesInOgranisation[0].SetSpecialInfo(positionX, positionY, countLines);
                                                    break;
                                                case ConsoleKey.D6:
                                                    Print.ClearSpace(' ', countLines, Console.BufferWidth, positionX, positionY + 2);
                                                    ListNewEmployees.NewEmployeesInOgranisation[0].SetSpecialInfo(positionX, positionY, countLines);
                                                    break;
                                                case ConsoleKey.B:
                                                    endChange = false;
                                                    break;
                                            }
                                        }
                                        if (ListNewEmployees.NewEmployeesInOgranisation.Count != 0)
                                        {
                                            ListEmployees.DeleteEmployeesInOgranisation(ListEmployees.EmployeesInOgranisation[number - 1]);
                                            ListEmployees.EmployeesInOgranisation.Insert(number - 1, ListNewEmployees.NewEmployeesInOgranisation[0]);
                                        }
                                        endAdd = false;
                                        endO = false;
                                        break;
                                    case ConsoleKey.B:
                                        ListNewEmployees.NewEmployeesInOgranisation.Clear();
                                        endAdd = false;
                                        endO = false;
                                        break;
                                }
                            }
                        }
                        else
                        {
                            Print.ClearSpace(' ', countLines, Console.BufferWidth, positionX, positionY + 2);
                            Print.PrintLongText("В списке нет сотрудника с таким номером\nНажмите любую кнопку для продолжения", positionX, positionY + 4);
                            Console.ReadKey();
                        }
                    }
                    else
                    {
                        Print.ClearSpace(' ', countLines, Console.BufferWidth / 2, positionX, positionY + 2);
                        Print.PrintInitializerChar('0', ConsoleColor.Cyan, positionX, positionY + 10);
                        Print.PrintText("- Введите, чтобы вернуться назад", positionX + 6, positionY + 10, ConsoleColor.White);
                        Print.PrintText("Введите номер профиля для открытия: ", positionX, positionY + 3, ConsoleColor.White);
                    }
                }
            }
            else
            {
                Print.ClearSpace(' ', countLines, Console.BufferWidth, positionX, positionY + 2);
                Console.ForegroundColor = ConsoleColor.White;
                Print.PrintLongText("Список сотрудников пуст\nНажмите любую кнопку для продолжения", positionX, positionY + 4);
                Console.ReadKey();
            }
        }


        //  Описываются действия при нажатии кнопки "C"
        public static void ClickC(int positionX, int positionY, int countLines)
        {
            string choiceSubdivision = null, choicePosition = null;
            bool endC = true;
            while (endC)
            {
                Print.ClearSpace(' ', countLines, Console.BufferWidth / 2, positionX, positionY + 2);
                Print.PrintText("Введите подразделение и тип занимаемой должности для выборки сотрудников: ", positionX, positionY + 3, ConsoleColor.White);

                Print.PrintInitializerChar('1', ConsoleColor.Cyan, positionX, positionY + 5);
                Print.PrintText("- Ввести подразделение", positionX + 6, positionY + 5, ConsoleColor.White);
                Print.PrintInitializerChar('2', ConsoleColor.Cyan, positionX, positionY + 6);
                Print.PrintText("- Ввести должность", positionX + 6, positionY + 6, ConsoleColor.White);

                Print.PrintDoubleText("Выбранное подразделение: ", choiceSubdivision, positionX + 40, positionY + 5, ConsoleColor.Gray, ConsoleColor.White);
                Print.PrintDoubleText("Выбранная должность: ", choicePosition, positionX + 40, positionY + 6, ConsoleColor.Gray, ConsoleColor.White);

                Print.PrintInitializerChar('3', ConsoleColor.Cyan, positionX, positionY + 9);
                Print.PrintText("- Вывести список сотрудников", positionX + 6, positionY + 9, ConsoleColor.White);
                Print.PrintInitializerChar('0', ConsoleColor.Cyan, positionX, positionY + 10);
                Print.PrintText("- Вернуться в главное меню", positionX + 6, positionY + 10, ConsoleColor.White);

                ConsoleKeyInfo key = Console.ReadKey(true);

                switch (key.Key)
                {
                    case ConsoleKey.D1:
                        choiceSubdivision = GetChoiceSubdivision(positionX, positionY, countLines);
                        break;
                    case ConsoleKey.D2:
                        choicePosition = GetChoicePosition(positionX, positionY, countLines);
                        break;
                    case ConsoleKey.D3:
                        Print.ClearAllSpace();
                        PrintHeader(0, 1, ConsoleColor.Yellow, ConsoleColor.Gray);
                        PrintUsersMenu(positionX, positionY);
                        GetSelectedList(positionX, positionY + 14, countLines, choiceSubdivision, choicePosition);
                        break;
                    case ConsoleKey.D0:
                        endC = false;
                        break;
                }
            }
        }


        //  Описываются действия при нажатии кнопки "P" + Закончено
        public static void ClickP(int positionX, int positionY, int countLines)
        {
            bool endPure = true;
            while (endPure)
            {
                Print.ClearSpace(' ', countLines, Console.BufferWidth / 2, positionX, positionY + 2);
                Print.PrintText("Вы уверены, что хотите полностью удалить список сотрудников?", positionX, positionY + 3, ConsoleColor.White);

                Print.PrintInitializerChar('Y', ConsoleColor.Cyan, positionX, positionY + 6);
                Print.PrintText("- Да, удалить", positionX + 6, positionY + 6, ConsoleColor.White);
                Print.PrintInitializerChar('N', ConsoleColor.Cyan, positionX, positionY + 8);
                Print.PrintText("- Нет, вернуться в главное меню", positionX + 6, positionY + 8, ConsoleColor.White);

                ConsoleKeyInfo key = Console.ReadKey(true);

                switch (key.Key)
                {
                    case ConsoleKey.Y:
                        ListEmployees.ClearEmployeesInOgranisation();
                        Print.ClearAllSpace();
                        endPure = false;
                        break;
                    case ConsoleKey.N:
                        Print.ClearAllSpace();
                        endPure = false;
                        break;
                }
            }
        }


        //  Описывается выбор должности
        public static void A_ChoicePosition(int positionX, int positionY, int countLines)
        {
            bool endPosition = true;
            while (endPosition)
            {
                Print.ClearSpace(' ', countLines, Console.BufferWidth / 2, positionX, positionY + 2);
                Print.PrintInitializerChar('0', ConsoleColor.Cyan, positionX, positionY + 10);
                Print.PrintText("- Введите, чтобы вернуться назад", positionX + 6, positionY + 10, ConsoleColor.White);
                Print.PrintText("Выберите должность сотрудника: ", positionX, positionY + 3, ConsoleColor.White);

                //  Отрисовывается список возможным должностей
                int counter = 1;
                int Y = positionY;
                for (int i = 0; i < BaseEmployee.arrayPosition.Length; i++)
                {
                    Print.PrintInitializerInt(counter, ConsoleColor.Cyan, positionX, Y + 5);
                    Print.PrintText(BaseEmployee.arrayPosition[i], positionX + 6, Y + 5, ConsoleColor.White);
                    counter++;
                    Y += 1;
                }

                //  Считывается нажатая кнопка при выборе должности
                ConsoleKeyInfo key = Console.ReadKey(true);

                switch (key.Key)
                {
                    case ConsoleKey.D1:
                        ListNewEmployees.AddNewEmployeesInOgranisation(new Worker());
                        ListNewEmployees.NewEmployeesInOgranisation[0].Position = BaseEmployee.arrayPosition[0];
                        Print.ClearSpace(' ', countLines, Console.BufferWidth / 2, positionX, positionY + 2);
                        endPosition = false;
                        break;
                    case ConsoleKey.D2:
                        ListNewEmployees.AddNewEmployeesInOgranisation(new Controller());
                        ListNewEmployees.NewEmployeesInOgranisation[0].Position = BaseEmployee.arrayPosition[1];
                        Print.ClearSpace(' ', countLines, Console.BufferWidth / 2, positionX, positionY + 2);
                        endPosition = false;
                        break;
                    case ConsoleKey.D3:
                        ListNewEmployees.AddNewEmployeesInOgranisation(new LeaderSubvision());
                        ListNewEmployees.NewEmployeesInOgranisation[0].Position = BaseEmployee.arrayPosition[2];
                        Print.ClearSpace(' ', countLines, Console.BufferWidth / 2, positionX, positionY + 2);
                        endPosition = false;
                        break;
                    case ConsoleKey.D4:
                        if(CheckDirectorInList() == true)
                        {
                            Print.ClearSpace(' ', countLines, Console.BufferWidth, positionX, positionY + 2);
                            Print.PrintLongText("Должность директора организации уже занята, выберите другую должность\nНажмите любую кнопку для продолжения", positionX, positionY + 4);
                            Console.ReadKey();
                        }
                        else
                        {
                            ListNewEmployees.AddNewEmployeesInOgranisation(new Director());
                            ListNewEmployees.NewEmployeesInOgranisation[0].Position = BaseEmployee.arrayPosition[3];
                            Print.ClearSpace(' ', countLines, Console.BufferWidth / 2, positionX, positionY + 2);
                            endPosition = false;
                        }
                        break;
                    case ConsoleKey.D0:
                        Print.ClearSpace(' ', countLines, Console.BufferWidth / 2, positionX, positionY + 2);
                        endPosition = false;
                        break;
                }
            }
        }

        //  Описывается смена должности
        public static void A_ChangePosition(int positionX, int positionY, int countLines)
        {
            Print.ClearSpace(' ', countLines, Console.BufferWidth, positionX, positionY + 2);

            bool endPositionChange = true;
            while (endPositionChange)
            {
                Print.ClearSpace(' ', countLines, Console.BufferWidth / 2, positionX, positionY + 2);
                Print.PrintText("Выберите должность сотрудника: ", positionX, positionY + 3, ConsoleColor.White);

                //  Отрисовывается список возможным должностей
                int counter = 1;
                int Y = positionY;
                for (int i = 0; i < BaseEmployee.arrayPosition.Length; i++)
                {
                    Print.PrintInitializerInt(counter, ConsoleColor.Cyan, positionX, Y + 5);
                    Print.PrintText(BaseEmployee.arrayPosition[i], positionX + 6, Y + 5, ConsoleColor.White);
                    counter++;
                    Y += 1;
                }

                //  Считывается нажатая кнопка при выборе должности
                ConsoleKeyInfo key = Console.ReadKey(true);

                switch (key.Key)
                {
                    case ConsoleKey.D1:
                        ListChangeEmployees.AddChangeEmployeesInOgranisation(new Worker());
                        ListChangeEmployees.ChangeEmployeesInOgranisation[0].Position = BaseEmployee.arrayPosition[0];
                        A_AssignmentСharacteristics(positionX, positionY, countLines);
                        Print.ClearSpace(' ', countLines, Console.BufferWidth / 2, positionX, positionY + 2);
                        endPositionChange = false;
                        break;
                    case ConsoleKey.D2:
                        ListChangeEmployees.AddChangeEmployeesInOgranisation(new Controller());
                        ListChangeEmployees.ChangeEmployeesInOgranisation[0].Position = BaseEmployee.arrayPosition[1];
                        A_AssignmentСharacteristics(positionX, positionY, countLines);
                        Print.ClearSpace(' ', countLines, Console.BufferWidth / 2, positionX, positionY + 2);
                        endPositionChange = false;
                        break;
                    case ConsoleKey.D3:
                        ListChangeEmployees.AddChangeEmployeesInOgranisation(new LeaderSubvision());
                        ListChangeEmployees.ChangeEmployeesInOgranisation[0].Position = BaseEmployee.arrayPosition[2];
                        A_AssignmentСharacteristics(positionX, positionY, countLines);
                        Print.ClearSpace(' ', countLines, Console.BufferWidth / 2, positionX, positionY + 2);
                        endPositionChange = false;
                        break;
                    case ConsoleKey.D4:
                        if (CheckDirectorInList() == true)
                        {
                            Print.ClearSpace(' ', countLines, Console.BufferWidth, positionX, positionY + 2);
                            Print.PrintLongText("Должность директора организации уже занята, выберите другую должность\nНажмите любую кнопку для продолжения", positionX, positionY + 4);
                            Console.ReadKey();
                        }
                        else
                        {
                            ListChangeEmployees.AddChangeEmployeesInOgranisation(new Director());
                            ListChangeEmployees.ChangeEmployeesInOgranisation[0].Position = BaseEmployee.arrayPosition[3];
                            A_AssignmentСharacteristics(positionX, positionY, countLines);
                            Print.ClearSpace(' ', countLines, Console.BufferWidth / 2, positionX, positionY + 2);
                            endPositionChange = false;
                        }
                        break;
                        
                }
            }
        }

        //  Описывается передача характеристик 
        public static void A_AssignmentСharacteristics(int positionX, int positionY, int countLines)
        {
            ListChangeEmployees.ChangeEmployeesInOgranisation[0].Name = ListNewEmployees.NewEmployeesInOgranisation[0].Name;
            ListChangeEmployees.ChangeEmployeesInOgranisation[0].Gender = ListNewEmployees.NewEmployeesInOgranisation[0].Gender;
            ListChangeEmployees.ChangeEmployeesInOgranisation[0].Birthday = ListNewEmployees.NewEmployeesInOgranisation[0].Birthday;
            ListChangeEmployees.ChangeEmployeesInOgranisation[0].Subdivision = ListNewEmployees.NewEmployeesInOgranisation[0].Subdivision;
        }

        // Описывается выбор подразделения при выборке
        public static string GetChoiceSubdivision(int positionX, int positionY, int countLines)
        {
            while (true)
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

                Print.PrintInitializerChar('6', ConsoleColor.Cyan, positionX, positionY + 10);
                Print.PrintText("Пустое поле", positionX + 6, positionY + 10, ConsoleColor.White);

                ConsoleKeyInfo key = Console.ReadKey(true);

                switch (key.Key)
                {
                    case ConsoleKey.D1: return BaseEmployee.arraySubdivision[0];
                    case ConsoleKey.D2: return BaseEmployee.arraySubdivision[1];
                    case ConsoleKey.D3: return BaseEmployee.arraySubdivision[2];
                    case ConsoleKey.D4: return BaseEmployee.arraySubdivision[3];
                    case ConsoleKey.D5: return BaseEmployee.arraySubdivision[4];
                    case ConsoleKey.D6: return null;
                }
            }
        }

        // Описывается выбор должности при выборке
        public static string GetChoicePosition(int positionX, int positionY, int countLines)
        {
            while (true)
            {
                Print.ClearSpace(' ', countLines, Console.BufferWidth / 2, positionX - 2, positionY + 2);
                Print.PrintText("Выберите должность сотрудника: ", positionX, positionY + 3, ConsoleColor.White);

                int counter = 1;
                int Y = positionY;
                for (int i = 0; i < BaseEmployee.arrayPosition.Length; i++)
                {
                    Print.PrintInitializerInt(counter, ConsoleColor.Cyan, positionX, Y + 5);
                    Print.PrintText(BaseEmployee.arrayPosition[i], positionX + 6, Y + 5, ConsoleColor.White);
                    counter++;
                    Y += 1;
                }

                Print.PrintInitializerChar('5', ConsoleColor.Cyan, positionX, positionY + 10);
                Print.PrintText("Пустое поле", positionX + 6, positionY + 10, ConsoleColor.White);

                ConsoleKeyInfo key = Console.ReadKey(true);

                switch (key.Key)
                {
                    case ConsoleKey.D1: return BaseEmployee.arrayPosition[0];
                    case ConsoleKey.D2: return BaseEmployee.arrayPosition[1];
                    case ConsoleKey.D3: return BaseEmployee.arrayPosition[2];
                    case ConsoleKey.D4: return BaseEmployee.arrayPosition[3];
                    case ConsoleKey.D5: return null;
                }
            }
        }

        // Описывается вывод всех подходящий сотрудников при выборке
        public static void GetSelectedList(int positionX, int positionY, int countLines, string choiceSubdivision, string choicePosition)
        {
            int counter = 1;
            Print.PrintText("Список сотрудников: ", positionX, positionY, ConsoleColor.White);
            for (int i = 0; i < ListEmployees.EmployeesInOgranisation.Count; i++)
            {
                if ((choiceSubdivision == ListEmployees.EmployeesInOgranisation[i].Subdivision && choicePosition == null) || (choicePosition == ListEmployees.EmployeesInOgranisation[i].Position && choiceSubdivision == null) || (choiceSubdivision == ListEmployees.EmployeesInOgranisation[i].Subdivision && choicePosition == ListEmployees.EmployeesInOgranisation[i].Position))
                {
                    Print.PrintText(Print.PrintWall('~', 50), positionX, positionY + 1, ConsoleColor.DarkGray);
                    Print.PrintInitializerInt(counter, ConsoleColor.Cyan, positionX, positionY + 2);
                    ListEmployees.EmployeesInOgranisation[i].PrintInfo(positionX + 10, positionY + 2);
                    Print.PrintText(Print.PrintWall('~', 50), positionX, positionY + 8, ConsoleColor.DarkGray);
                    counter++;
                    positionY += 10;
                }
            }
        }

        // Проверка нахождения директора в организации
        public static bool CheckDirectorInList()
        {
            for (int i = 0; i < ListEmployees.EmployeesInOgranisation.Count; i++)
            {
                string text = ListEmployees.EmployeesInOgranisation[i].Position;
                if (text == BaseEmployee.arrayPosition[3])
                    return true;
            }
            return false;
        }
    }
}
