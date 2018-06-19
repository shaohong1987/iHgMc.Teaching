using MySqlSugar;

namespace Web.Core
{
    public class TeachingDao
    {
        private TeachingDao() 
        {
        }
        public static string ConnectionString
        {
            get
            {
                return "server=localhost;;Database=ihgmc_hospital_teaching;Uid=root;Pwd=65866447";
            }
        }
        public static SqlSugarClient GetInstance()
        {
            var db = new SqlSugarClient(ConnectionString)
            {
                IsEnableLogEvent = false
            };
            //var logger = log4net.LogManager.GetLogger("SQL");
            //db.LogEventStarting = (sql, par) => { logger.Info(sql + " " + par + "\r\n");};
            return db;
        }
    }
}