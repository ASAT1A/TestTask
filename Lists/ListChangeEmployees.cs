using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask
{

    // Список, куда заносится работник во время изменения
    public class ListChangeEmployees
    {
        public static List<BaseEmployee> ChangeEmployeesInOgranisation = new List<BaseEmployee> { };

        public static void AddChangeEmployeesInOgranisation(BaseEmployee employee)
        {
            ListChangeEmployees.ChangeEmployeesInOgranisation.Add(employee);
        }
        public static void DeleteChangeEmployeesInOgranisation(BaseEmployee employee)
        {
            ListChangeEmployees.ChangeEmployeesInOgranisation.Remove(employee);
        }
        public static void ClearChangeEmployeesInOgranisation()
        {
            ListChangeEmployees.ChangeEmployeesInOgranisation.Clear();
        }
    }
}
