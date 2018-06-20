using System.Collections.Generic;
using Web.Models;

namespace Web.Helper
{
    public class HgMc
    {
        public const string ConnectionString = "server=121.43.191.40;uid=root;pwd=123qwe;database=teaching_ihgmc_com";
        public static Queue<LogModel> LogQueue = new Queue<LogModel>();
        public const int LogHandInterval = 1000;//1s
    }
}