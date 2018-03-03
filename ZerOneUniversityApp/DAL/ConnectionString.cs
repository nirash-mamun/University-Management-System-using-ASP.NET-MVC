using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZerOneUniversityApp.DAL
{
    public class ConnectionString
    {
        //public string connectionString = @"Data Source=DESKTOP-R94DMM4;Initial Catalog=ZerOneUniversity_DB;Integrated Security=True";
        public string connectionString = @"Data Source=np:\\.\pipe\LOCALDB#F809AE90\tsql\query;Initial Catalog=ZerOneUniversity_DB;Integrated Security=True";
    }
}
