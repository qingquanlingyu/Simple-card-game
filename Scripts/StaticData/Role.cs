using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using CSharpMysql;

namespace StaticData
{
    public class RoleData
    {
        public static bool music;//�Ƿ���������

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
                Debug.LogWarning("�ڴ浵���ݿ��������������id�����������ݿ����Ա������ݿ�");
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
                    Debug.LogWarning("�ڴ浵���ݿ���δ�������涨Ϊ�ǿյ�ֵ�������ݿ����Ա������ݿ�");
                }
                catch (FormatException)
                {
                    Debug.LogWarning("�浵���ݿ���Int������ת���쳣�������ݿ����Ա������ݿ�");
                }

                try
                {
                    nowlayer = Int32.Parse(mq.SelectWithSqlCommand(cmd, "nowlayer")[0]);
                    Debug.Log("Layer: " + nowlayer.ToString());
                }
                catch (ArgumentNullException)
                {
                    Debug.LogWarning("�ڴ浵���ݿ���δ�������涨Ϊ�ǿյ�ֵ�������ݿ����Ա������ݿ�");
                }
                catch (FormatException)
                {
                    Debug.LogWarning("�浵���ݿ���Int������ת���쳣�������ݿ����Ա������ݿ�");
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
            md[3] = new MysqlData("none", new System.Random().Next());//���÷��ţ���֤timestamp�Զ�����
            return mq.Update("role", md, mdid);
        }
    }
}
