using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;

namespace MaterialConstructionAPI.DAL
{
    public class AbstractManager
    {
        DBContext _dbContext;

        public AbstractManager()
        {
            _dbContext = new DBContext();
        }

        public IEnumerable ExecuteQuery(string query, [Optional] params Object[] args)
        {
            using (_dbContext.GetConnection())
            {
                using (var command = new SqlCommand(query, _dbContext.GetConnection()))
                {
                    //use index,values to convert parameters passed  to sqlparameters         
                    var Parameters = args.Select((value, index) => ToConvertSqlParams(command, index.ToString(), value));

                    command.Parameters.AddRange(Parameters.ToArray());
                    _dbContext.OpenConnection();
                    //Execute the query 
                    using (var reader = command.ExecuteReader())
                    {
                        foreach (IDataRecord record in reader)
                            yield return record;
                    }
                    _dbContext.CloseConnection();
                }
            }
        }

        static SqlParameter ToConvertSqlParams(SqlCommand command, string name, object value)
        {
            var p = command.CreateParameter();
            p.ParameterName = name;
            p.Value = value;
            return p;
        }
    }
}