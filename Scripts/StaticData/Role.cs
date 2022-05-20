using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using CSharpMysql;

namespace StaticData
{
    public class RoleData
    {
        public static bool music;//是否启用音乐

        public static int id;
        public static string name;
        public static int hp;
        public static int nowlayer;
        public static int maxhp;
        public static int arm;
        public static int atk;
        public static int def;
        public static void LoadId(int id)
        {
            MysqlAccess mq = new MysqlAccess();
            RoleData.id = id;
            string cmd = $"select * from role where id = {id}";
            List<string> res = mq.SelectWithSqlCommand(cmd, "name");
            if (res.Count == 0)
                return;
            else if (res.Count > 1)
                Debug.LogWarning("在存档数据库中搜索到错误的id数量，请数据库管理员检查数据库");
            else
            {
                name = res[0];
                Debug.Log("Name: " + name);
                try
                {
                    hp = Int32.Parse(mq.SelectWithSqlCommand(cmd, "hp")[0]);
                    Debug.Log("HP: " + hp.ToString());
                }
                catch (ArgumentNullException)
                {
                    Debug.LogWarning("在存档数据库中未搜索到规定为非空的值，请数据库管理员检查数据库");
                }
                catch (FormatException)
                {
                    Debug.LogWarning("存档数据库中Int型数据转化异常，请数据库管理员检查数据库");
                }

                try
                {
                    nowlayer = Int32.Parse(mq.SelectWithSqlCommand(cmd, "nowlayer")[0]);
                    Debug.Log("Layer: " + nowlayer.ToString());
                }
                catch (ArgumentNullException)
                {
                    Debug.LogWarning("在存档数据库中未搜索到规定为非空的值，请数据库管理员检查数据库");
                }
                catch (FormatException)
                {
                    Debug.LogWarning("存档数据库中Int型数据转化异常，请数据库管理员检查数据库");
                }
            }
            arm = 0;
            maxhp = 20;
            atk = 6;
            def = 0;
        }
        public static int InsertRole()
        {
            MysqlAccess mq = new MysqlAccess();
            MysqlData [] md = new MysqlData[4];
            md[0] = new MysqlData("id", id);
            md[1] = new MysqlData("name", "\'" + name + "\'");
            md[2] = new MysqlData("hp", hp);
            md[3] = new MysqlData("nowlayer", nowlayer);
            
            return mq.InsertInto("role", md);         
        }

        public static int UpdateRole()
        {
            MysqlAccess mq = new MysqlAccess();

            MysqlData[] md = new MysqlData[4];
            MysqlData mdid = new MysqlData("id", id);
            md[0] = new MysqlData("name", "\'" + name + "\'");
            md[1] = new MysqlData("hp", hp);
            md[2] = new MysqlData("nowlayer", nowlayer);
            md[3] = new MysqlData("none", new System.Random().Next());//无用符号，保证timestamp自动更新
            return mq.Update("role", md, mdid);
        }
    }
}
