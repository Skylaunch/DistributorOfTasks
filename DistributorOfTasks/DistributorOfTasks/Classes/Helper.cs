using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistributorOfTasks.Classes
{
    public class Helper
    {
        public static DistributorOfTasksEntities Connection = new DistributorOfTasksEntities();
        public static User CurrentUser = new User();
    }
}
