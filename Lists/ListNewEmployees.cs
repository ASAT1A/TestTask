using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask
{
    // Список сотрудников на момент создания профиля
    public class ListNewEmployees
    {
        public static List<BaseEmployee> NewEmployeesInOgranisation = new List<BaseEmployee> { };

        public static void AddNewEmployeesInOgranisation(BaseEmployee employee)
        {
            ListNewEmployees.NewEmployeesInOgranisation.Add(employee);
        }
        public static void DeleteNewEmployeesInOgranisation(BaseEmployee employee)
        {
            ListNewEmployees.NewEmployeesInOgranisation.Remove(employee);
        }
        public static void ClearNewEmployeesInOgranisation()
        {
            ListNewEmployees.NewEmployeesInOgranisation.Clear();
        }
    }
}
