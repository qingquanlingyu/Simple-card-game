using System.Collections;
using System.Data;
using System.Collections.Generic;
using UnityEngine;  
using MySql.Data.MySqlClient;

namespace CSharpMysql
{
    /*
        select * from item where guid = 1000;
        insert into item(guid) values(1231);
        insert into item guid=123,item_id=21312;
        UPDATE table_name SET field1=new-value1, field2=new-value2 [WHERE Clause]
        DELETE FROM table_name [WHERE Clause]
    */
    public class MysqlAccess
    {
        private MySqlConnection connection;
        public MysqlAccess()
        {
            connection = new MySqlConnection(MySqlConnectString.New().ToString());
        }


        public DataTable SelectFrom(string table)
        {
            MySqlCommand command = new MySqlCommand();
            command.CommandText = $"select * from {table};";
            return ExecuteReader(command);
        }
        
        public DataTable SelectFrom(string table, params MysqlData[] datas)
        {
            MySqlCommand command = new MySqlCommand();
            var builder = AppendJoin(" and ", datas);
            command.CommandText = $"select * from {table} where BINARY {builder};";
            Debug.Log(command.CommandText);
            foreach (var item in datas)
            {
                command.Parameters.AddWithValue($"{item.key}=", item.value);
            }
            return ExecuteReader(command);
        }
        public List<string> SelectWithSqlCommand(string cmd,  string column)
        {
            Debug.Log(cmd);
            List<string>  res = new List<string>();
            MySqlCommand command = new MySqlCommand(cmd);
            connection.Open();
            command.Connection = connection;
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                res.Add(reader.GetString(column));
            }
            connection.Close();
            return res;
        }
        public int InsertInto(string table, params MysqlData[] datas)
        {
            MySqlCommand command = new MySqlCommand();

            var builder = AppendJoin(",", datas);
            command.CommandText = $"insert into {table} set {builder};";
            Debug.Log(command.CommandText);
            foreach (var item in datas)
            {
                command.Parameters.AddWithValue($"{item.key}", item.value);
            }
            return ExecuteNonQuery(command);
        }
        public int Update(string table, MysqlData[] updateDatas, params MysqlData[] whereDatas)
        {
            List<string> updateStrList = new List<string>();
            foreach (var item in updateDatas)
            {
                updateStrList.Add($"{item.key}={item.value}");
            }
            var updateStr = AppendJoin(",", updateStrList);

            List<string> whereStrList = new List<string>();
            foreach (var item in whereDatas)
            {
                whereStrList.Add($"{item.key}={item.value}");
            }
            var whereStr = AppendJoin(" and ", whereStrList);


            MySqlCommand command = new MySqlCommand();
            command.CommandText = $"update {table} set {updateStr} where {whereStr};";
            Debug.Log(command.CommandText);
            foreach (var item in updateDatas)
            {
                command.Parameters.AddWithValue($"{item.key}", item.value);
            }
            foreach (var item in whereDatas)
            {
                command.Parameters.AddWithValue($"{item.key}", item.value);
            }
            return ExecuteNonQuery(command);
        }
        public int Delete(string table, params MysqlData[] datas)
        {
            MySqlCommand command = new MySqlCommand();
            var builder = AppendJoin(" and ", datas);
            command.CommandText = $"delete from {table} where {builder};";
            Debug.Log(command.CommandText);
            foreach (var item in datas)
            {
                command.Parameters.AddWithValue($"@{item.key}", item.value);
            }
            return ExecuteNonQuery(command);
        }


        private DataTable ExecuteReader(MySqlCommand command)
        {
            connection.Open();
            command.Connection = connection;
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter(command);
            DataTable table = new DataTable();
            dataAdapter.Fill(table);
            connection.Close();
            return table;
        }
        private int ExecuteNonQuery(MySqlCommand command)
        {
            connection.Open();
            command.Connection = connection;
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter(command);
            var rowNum = command.ExecuteNonQuery();
            connection.Close();
            return rowNum;
        }



        private string AppendJoin<T>(string separator, List<T> values)
        {
            string str = "";
            for (int i = 0; i < values.Count; i++)
            {
                if (i == values.Count - 1)
                {
                    str += values[i];
                }
                else
                {
                    str += values[i] + separator;
                }
            }
            return str;
        }
        private string AppendJoin(string separator, params object[] values)
        {
            string str = "";
            for (int i = 0; i < values.Length; i++)
            {
                if (i == values.Length - 1)
                {
                    str += values[i];
                }
                else
                {
                    str += values[i] + separator;
                }
            }
            return str;
        }
    }
}


namespace CSharpMysql
{
    public class MysqlData
    {
        public string key { get; private set; }
        public object value { get; private set; }
        public MysqlData(string key, object value)
        {
            this.key = key;
            this.value = value;
        }
        public override string ToString()
        {
            return $"{key}={value}";
        }
    }
}
namespace CSharpMysql
{
    public class MySqlConnectString
    {
        public string server = "127.0.0.1";
        public int port = 3306;
        public string user = "root";
        public string password = "asantuSB";
        public string database = "rogue";

        public override string ToString()
        {
            return $"server={server};user={user};database={database};port={port};password={password}";
        }

        public static MySqlConnectString New()
        {
            return new MySqlConnectString();
        }
    }
}
