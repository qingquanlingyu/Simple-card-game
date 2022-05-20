using System.Collections;
using System.Collections.Generic;
using System;
using CSharpMysql;
using UnityEngine;

namespace StaticData
{
    public class Monster
    {
        public static int ghp;
        public static int gatk;
        public static int gdef;
        public static int garm;
        public static int geff;
        public static int gappr;
        public static string gname;
        public static string gdes;
        public static void LoadId(int id)
        {
            MysqlAccess mq = new MysqlAccess();
            string cmd = $"select * from monster where gid = {id}";
            List<string> res = mq.SelectWithSqlCommand(cmd, "gname");
            if (res.Count == 0)
                return;
            else if (res.Count > 1)
                Debug.LogWarning("在怪物数据库中搜索到错误的id数量，请数据库管理员检查数据库");
            else
            {
                gname = res[0];
                Debug.Log("gname: " + gname);
                try
                {
                    ghp = Int32.Parse(mq.SelectWithSqlCommand(cmd, "ghp")[0]);
                    Debug.Log("ghp: " + ghp.ToString());
                }
                catch (ArgumentNullException)
                {
                    Debug.LogWarning("在怪物数据库中未搜索到规定为非空的值，请数据库管理员检查数据库");
                }
                catch (FormatException)
                {
                    Debug.LogWarning("怪物数据库中Int型数据转化异常，请数据库管理员检查数据库");
                }

                try
                {
                    gatk = Int32.Parse(mq.SelectWithSqlCommand(cmd, "gatk")[0]);
                    Debug.Log("gatk: " + gatk.ToString());
                }
                catch (ArgumentNullException)
                {
                    Debug.LogWarning("在怪物数据库中未搜索到规定为非空的值，请数据库管理员检查数据库");
                }
                catch (FormatException)
                {
                    Debug.LogWarning("怪物数据库中Int型数据转化异常，请数据库管理员检查数据库");
                }

                try
                {
                    gdef = Int32.Parse(mq.SelectWithSqlCommand(cmd, "gdef")[0]);
                    Debug.Log("gdef: " + gdef.ToString());
                }
                catch (ArgumentNullException)
                {
                    Debug.LogWarning("在怪物数据库中未搜索到规定为非空的值，请数据库管理员检查数据库");
                }
                catch (FormatException)
                {
                    Debug.LogWarning("怪物数据库中Int型数据转化异常，请数据库管理员检查数据库");
                }

                try
                {
                    geff = Int32.Parse(mq.SelectWithSqlCommand(cmd, "geff")[0]);
                    Debug.Log("geff: " + geff.ToString());
                }
                catch (ArgumentNullException)
                {
                    Debug.LogWarning("在怪物数据库中未搜索到规定为非空的值，请数据库管理员检查数据库");
                }
                catch (FormatException)
                {
                    Debug.LogWarning("怪物数据库中Int型数据转化异常，请数据库管理员检查数据库");
                }

                try
                {
                    gappr = Int32.Parse(mq.SelectWithSqlCommand(cmd, "gappr")[0]);
                    Debug.Log("gappr: " + gappr.ToString());
                }
                catch (ArgumentNullException)
                {
                    Debug.LogWarning("在怪物数据库中未搜索到规定为非空的值，请数据库管理员检查数据库");
                }
                catch (FormatException)
                {
                    Debug.LogWarning("怪物数据库中Int型数据转化异常，请数据库管理员检查数据库");
                }

                try
                {
                    gdes = mq.SelectWithSqlCommand(cmd, "gdes")[0];
                    Debug.Log("gdes: " + gdes);
                }
                catch (ArgumentNullException)
                {
                    Debug.LogWarning("在怪物数据库中未搜索到规定为非空的值，请数据库管理员检查数据库");
                }
                garm = 0;
            }
        }
    }

    
}
