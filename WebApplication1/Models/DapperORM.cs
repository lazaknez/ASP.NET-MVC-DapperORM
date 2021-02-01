using Dapper;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public static class DapperORM
    {
        private static string konekcioniString = @"Data Source=.\SQLEXPRESS;Initial Catalog=BazaCRUD;Integrated Security=True";

        public static void IzvrsiBezVracanja(string procedureName, DynamicParameters parametar)
        {
            using (SqlConnection sqlConn = new SqlConnection(konekcioniString) )
            {
                sqlConn.Open();
                sqlConn.Execute(procedureName,parametar,commandType:System.Data.CommandType.StoredProcedure);
            }
        }
        
        
        //DapperORM.IzvrsiVratiScalar<int>(_,_);
        public static T IzvrsiVratiScalar<T>(string procedureName, DynamicParameters parametar)
        {
            using (SqlConnection sqlConn = new SqlConnection(konekcioniString))
            {
                sqlConn.Open();
                return (T)Convert.ChangeType(sqlConn.Execute(procedureName, parametar, commandType: System.Data.CommandType.StoredProcedure),typeof(T));

            }
        }

        //DrapperORM.VratiListu<ZaposleniModel> --- IEnumerable<ZaposleniModel>
        public static IEnumerable<T> VratiListu<T>(string procedureName, DynamicParameters parametar)
        {
            using (SqlConnection sqlConn = new SqlConnection(konekcioniString))
            {
                sqlConn.Open();
                return sqlConn.Query<T>(procedureName, parametar, commandType: System.Data.CommandType.StoredProcedure);
            }
        }
    }
}
