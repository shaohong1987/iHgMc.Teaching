using MySqlSugar;
using System.Linq;
using Web.Core;
using Web.Models.ViewModel;

namespace Web.Models
{
    public class UserModel
    {
        public void Login(User u)
        {
            using (var db = TeachingDao.GetInstance())
            {
                var user = db.Queryable<User>().Single(); 
            }
        }
    }
}