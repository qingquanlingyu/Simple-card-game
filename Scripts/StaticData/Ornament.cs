using System.Collections;
using System.Collections.Generic;
using CSharpMysql;
using UnityEngine;
using System;

namespace StaticData
{
    public class Ornament
    {
        public static int ORNANUM;
        public static bool[] effects;
        public static List<Orna> ornas;
        public static void LoadOrnaments()
        {
            effects = new bool[9];
            ornas = new List<Orna>();
            for (int i = 0; i < 9; i++)
                effects[i] = false;
            MysqlAccess mq = new MysqlAccess();

            string cmd = $"select * from ornament where sid > 0";
            List<string> res = mq.SelectWithSqlCommand(cmd, "sid");
            ORNANUM = res.Count;
            Debug.Log($"饰品总数：{ORNANUM}");

            cmd = $"select * from ornaments where id = {RoleData.id}";
            res = mq.SelectWithSqlCommand(cmd, "sid");
            if (res.Count == 0)
                Debug.LogWarning("无法找到该存档角色对应饰品，请检查数据库");
            foreach (string sid in res)
            {
                int k = 0;
                try
                {
                    k = Int32.Parse(sid);
                }
                catch (FormatException)
                {
                    Debug.LogWarning("卡牌数据库中Int型数据转化异常，请数据库管理员检查数据库");
                }
                Orna orna = new Orna(k);
                ornas.Add(orna);
            }
        }
        public static void SaveOrnaments()
        {
            MysqlAccess mq = new MysqlAccess();
            mq.Delete("ornaments", new MysqlData("id", RoleData.id));
            foreach (Orna o in ornas)
            {
                mq.InsertInto("ornaments", new MysqlData("id", RoleData.id), new MysqlData("kid", o.sid));
            }
        }
    }

    public class Orna
    {
        public int sid;
        public int shp;
        public int satk;
        public string sname;
        public string sdes;
        public Orna(int id)
        {
            MysqlAccess mq = new MysqlAccess();
            string cmd = $"select * from ornament where sid = {id}";
            List<string> res = mq.SelectWithSqlCommand(cmd, "sname");
            if (res.Count == 0)
                return;
            else if (res.Count > 1)
                Debug.LogWarning("在饰品数据库中搜索到错误的id数量，请数据库管理员检查数据库");
            else
            {
                sid = id;
                sname = res[0];
                Debug.Log("sname: " + sname);
                try
                {
                    sdes = mq.SelectWithSqlCommand(cmd, "sdes")[0];
                    Debug.Log("kdes: " + sdes);
                }
                catch (ArgumentNullException)
                {
                    Debug.LogWarning("在饰品数据库中未搜索到规定为非空的值，请数据库管理员检查数据库");
                }

                try
                {
                    shp = Int32.Parse(mq.SelectWithSqlCommand(cmd, "shp")[0]);
                    Debug.Log("shp: " + shp.ToString());
                    RoleData.maxhp += shp;
                    RoleData.hp += shp;
                }
                catch (ArgumentNullException)
                {
                    Debug.LogWarning("在饰品数据库中未搜索到规定为非空的值，请数据库管理员检查数据库");
                }
                catch (FormatException)
                {
                    Debug.LogWarning("饰品数据库中Int型数据转化异常，请数据库管理员检查数据库");
                }

                try
                {
                    satk = Int32.Parse(mq.SelectWithSqlCommand(cmd, "satk")[0]);
                    Debug.Log("satk: " + satk.ToString());
                    RoleData.atk += satk;
                }
                catch (ArgumentNullException)
                {
                    Debug.LogWarning("在饰品数据库中未搜索到规定为非空的值，请数据库管理员检查数据库");
                }
                catch (FormatException)
                {
                    Debug.LogWarning("饰品数据库中Int型数据转化异常，请数据库管理员检查数据库");
                }

                try
                {
                    int seff = Int32.Parse(mq.SelectWithSqlCommand(cmd, "seff")[0]);
                    Debug.Log("seff: " + shp.ToString());
                    Ornament.effects[seff] = true;
                }
                catch (ArgumentNullException)
                {
                    Debug.LogWarning("在饰品数据库中未搜索到规定为非空的值，请数据库管理员检查数据库");
                }
                catch (FormatException)
                {
                    Debug.LogWarning("饰品数据库中Int型数据转化异常，请数据库管理员检查数据库");
                }
            }
        }

        public Orna(int id, bool flag)//只要有第二个参数，不参与数值计算
        {
            MysqlAccess mq = new MysqlAccess();
            string cmd = $"select * from ornament where sid = {id}";
            List<string> res = mq.SelectWithSqlCommand(cmd, "sname");
            if (res.Count == 0)
                return;
            else if (res.Count > 1)
                Debug.LogWarning("在饰品数据库中搜索到错误的id数量，请数据库管理员检查数据库");
            else
            {
                sid = id;
                sname = res[0];
                Debug.Log("sname: " + sname);
                try
                {
                    sdes = mq.SelectWithSqlCommand(cmd, "sdes")[0];
                    Debug.Log("kdes: " + sdes);
                }
                catch (ArgumentNullException)
                {
                    Debug.LogWarning("在饰品数据库中未搜索到规定为非空的值，请数据库管理员检查数据库");
                }

                try
                {
                    shp = Int32.Parse(mq.SelectWithSqlCommand(cmd, "shp")[0]);
                    Debug.Log("shp: " + shp.ToString());
                }
                catch (ArgumentNullException)
                {
                    Debug.LogWarning("在饰品数据库中未搜索到规定为非空的值，请数据库管理员检查数据库");
                }
                catch (FormatException)
                {
                    Debug.LogWarning("饰品数据库中Int型数据转化异常，请数据库管理员检查数据库");
                }

                try
                {
                    satk = Int32.Parse(mq.SelectWithSqlCommand(cmd, "satk")[0]);
                    Debug.Log("satk: " + satk.ToString());
                }
                catch (ArgumentNullException)
                {
                    Debug.LogWarning("在饰品数据库中未搜索到规定为非空的值，请数据库管理员检查数据库");
                }
                catch (FormatException)
                {
                    Debug.LogWarning("饰品数据库中Int型数据转化异常，请数据库管理员检查数据库");
                }

                try
                {
                    int seff = Int32.Parse(mq.SelectWithSqlCommand(cmd, "seff")[0]);
                    Debug.Log("seff: " + shp.ToString());
                }
                catch (ArgumentNullException)
                {
                    Debug.LogWarning("在饰品数据库中未搜索到规定为非空的值，请数据库管理员检查数据库");
                }
                catch (FormatException)
                {
                    Debug.LogWarning("饰品数据库中Int型数据转化异常，请数据库管理员检查数据库");
                }
            }
        }
    }
}
