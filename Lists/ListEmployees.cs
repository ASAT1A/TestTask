using System;
using System.Collections.Generic;

namespace TestTask
{
    // Список сотрудников на предприятии
    public class ListEmployees
    {
        public static List<BaseEmployee> EmployeesInOgranisation = new List<BaseEmployee> { };

        public static void AddEmployeesInOgranisation(BaseEmployee employee)
        {
            ListEmployees.EmployeesInOgranisation.Add(employee);
        }
        public static void DeleteEmployeesInOgranisation(BaseEmployee employee)
        {
            ListEmployees.EmployeesInOgranisation.Remove(employee);
        }
        public static void ClearEmployeesInOgranisation()
        {
            ListEmployees.EmployeesInOgranisation.Clear();
        }
        public static void PrintEmployeesInOgranisation(int positionX, int positionY)
        {
            int counter = 1;
            Print.PrintText("Список сотрудников: ", positionX, positionY, ConsoleColor.White);
            for (int i = 0; i < EmployeesInOgranisation.Count; i++)
            {
                Print.PrintText(Print.PrintWall('~', 50), positionX, positionY + 1, ConsoleColor.DarkGray);
                Print.PrintInitializerInt(counter,ConsoleColor.Cyan, positionX, positionY + 2);
                ListEmployees.EmployeesInOgranisation[i].PrintInfo(positionX + 10, positionY + 2);
                Print.PrintText(Print.PrintWall('~', 50), positionX, positionY + 8, ConsoleColor.DarkGray);
                counter++;
                positionY += 10;
            }
        }
    }
}
