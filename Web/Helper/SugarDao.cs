using MySqlSugar;
using Web.Models;

namespace Web.Helper
{
    public class SugarDao
    {
        public static SqlSugarClient GetInstance()
        {
            var db = new SqlSugarClient(HgMc.ConnectionString)
            {
                IsEnableLogEvent = true,
                LogEventStarting = (sql, par) =>
                {
                    HgMc.LogQueue.Enqueue(new LogModel
                    {
                        Content = sql + " " + par,
                        TypeName = "SQL"
                    });
                }
            };
            return db;
        }
    }
}