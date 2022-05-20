using System.Collections;
using System.Collections.Generic;
using CSharpMysql;
using UnityEngine;
using System;

namespace StaticData
{
    public class Deck 
    {
        public static int CARDNUM;
        public static List<Card> deck;
        public static Hashtable nowdeck;
        public static void LoadDeck()
        {
            deck = new List<Card>();
            nowdeck = new Hashtable();
            MysqlAccess mq = new MysqlAccess();

            string cmd = $"select * from card where kid > 0";
            List<string> res = mq.SelectWithSqlCommand(cmd, "kid");
            CARDNUM = res.Count;
            Debug.Log($"����������{CARDNUM}");

            cmd = $"select * from deck where id = {RoleData.id}";
            res = mq.SelectWithSqlCommand(cmd, "kid");
            if (res.Count == 0)
                Debug.LogWarning("�޷��ҵ��ô浵��ɫ��Ӧ���飬�������ݿ�");
            foreach (string kid in res)
            {
                int k = 0;
                try
                {
                    k = Int32.Parse(kid);
                }
                catch (FormatException)
                {
                    Debug.LogWarning("�������ݿ���Int������ת���쳣�������ݿ����Ա������ݿ�");
                }
                Card card = new Card(k);
                deck.Add(card);
            }
        }

        public static void SaveDeck()
        {
            MysqlAccess mq = new MysqlAccess();
            mq.Delete("deck", new MysqlData("id", RoleData.id));
            foreach (Card c in deck)
            {
                mq.InsertInto("deck", new MysqlData("id", RoleData.id), new MysqlData("kid", c.kid));
            }
        }
    }

    public class Card
    {
        public int kid;
        public int khp;
        public int karm;
        public int keff;
        public int kappr;
        public int katk;
        public int kdef;
        public string kname;
        public string kdes;

        public Card(int id)
        {
            MysqlAccess mq = new MysqlAccess();
            string cmd = $"select * from card where kid = {id}";
            List<string> res = mq.SelectWithSqlCommand(cmd, "kname");
            if (res.Count == 0)
                return;
            else if (res.Count > 1)
                Debug.LogWarning("�ڿ������ݿ��������������id�����������ݿ����Ա������ݿ�");
            else
            {
                kid = id;
                kname = res[0];
                Debug.Log("kname: " + kname);
                try
                {
                    kdes = mq.SelectWithSqlCommand(cmd, "kdes")[0];
                    Debug.Log("kdes: " + kdes);
                }
                catch (ArgumentNullException)
                {
                    Debug.LogWarning("�ڿ������ݿ���δ�������涨Ϊ�ǿյ�ֵ�������ݿ����Ա������ݿ�");
                }

                try
                {
                    khp = Int32.Parse(mq.SelectWithSqlCommand(cmd, "khp")[0]);
                    Debug.Log("khp: " + khp.ToString());
                }
                catch (ArgumentNullException)
                {
                    Debug.LogWarning("�ڿ������ݿ���δ�������涨Ϊ�ǿյ�ֵ�������ݿ����Ա������ݿ�");
                }
                catch (FormatException)
                {
                    Debug.LogWarning("�������ݿ���Int������ת���쳣�������ݿ����Ա������ݿ�");
                }

                try
                {
                    karm = Int32.Parse(mq.SelectWithSqlCommand(cmd, "karm")[0]);
                    Debug.Log("karm: " + khp.ToString());
                }
                catch (ArgumentNullException)
                {
                    Debug.LogWarning("�ڿ������ݿ���δ�������涨Ϊ�ǿյ�ֵ�������ݿ����Ա������ݿ�");
                }
                catch (FormatException)
                {
                    Debug.LogWarning("�������ݿ���Int������ת���쳣�������ݿ����Ա������ݿ�");
                }

                try
                {
                    keff = Int32.Parse(mq.SelectWithSqlCommand(cmd, "keff")[0]);
                    Debug.Log("keff: " + keff.ToString());
                }
                catch (ArgumentNullException)
                {
                    Debug.LogWarning("�ڿ������ݿ���δ�������涨Ϊ�ǿյ�ֵ�������ݿ����Ա������ݿ�");
                }
                catch (FormatException)
                {
                    Debug.LogWarning("�������ݿ���Int������ת���쳣�������ݿ����Ա������ݿ�");
                }

                try
                {
                    kappr = Int32.Parse(mq.SelectWithSqlCommand(cmd, "kappr")[0]);
                    Debug.Log("kappr: " + kappr.ToString());
                }
                catch (ArgumentNullException)
                {
                    Debug.LogWarning("�ڿ������ݿ���δ�������涨Ϊ�ǿյ�ֵ�������ݿ����Ա������ݿ�");
                }
                catch (FormatException)
                {
                    Debug.LogWarning("�������ݿ���Int������ת���쳣�������ݿ����Ա������ݿ�");
                }

                try
                {
                    kdef = Int32.Parse(mq.SelectWithSqlCommand(cmd, "kdef")[0]);
                    Debug.Log("kdef: " + kdef.ToString());
                }
                catch (ArgumentNullException)
                {
                    Debug.LogWarning("�ڿ������ݿ���δ�������涨Ϊ�ǿյ�ֵ�������ݿ����Ա������ݿ�");
                }
                catch (FormatException)
                {
                    Debug.LogWarning("�������ݿ���Int������ת���쳣�������ݿ����Ա������ݿ�");
                }

                try
                {
                    katk = Int32.Parse(mq.SelectWithSqlCommand(cmd, "katk")[0]);
                    Debug.Log("katk: " + katk.ToString());
                }
                catch (ArgumentNullException)
                {
                    Debug.LogWarning("�ڿ������ݿ���δ�������涨Ϊ�ǿյ�ֵ�������ݿ����Ա������ݿ�");
                }
                catch (FormatException)
                {
                    Debug.LogWarning("�������ݿ���Int������ת���쳣�������ݿ����Ա������ݿ�");
                }
            }
        }
    }
}
