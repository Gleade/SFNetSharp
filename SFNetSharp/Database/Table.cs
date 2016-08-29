using MySql.Data.MySqlClient;
using SFNetSharp.Database;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFNetSharp.Database
{
    class Table
    {
        DataTable SchemaTable { get; set; }
        MySqlDataReader Reader;

        public Table(MySqlDataReader reader)
        {
            Reader = reader;
            SchemaTable = Reader.GetSchemaTable();
        }


        /// <summary>
        /// Gets the data from a column.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ColumnName">The name of the column to retreive the data from.</param>
        /// <returns>The data type of T or default(T) if the column data doesn't exist.</returns>
        public T GetData<T>(string ColumnName)
        {
            while(Reader.Read())
            {
                var Column = Reader[ColumnName];
                return (T)Column;
            }

            return default(T);
        }
    }
}
