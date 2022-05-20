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
            Debug.Log($"卡牌总数：{CARDNUM}");

            cmd = $"select * from deck where id = {RoleData.id}";
            res = mq.SelectWithSqlCommand(cmd, "kid");
            if (res.Count == 0)
                Debug.LogWarning("无法找到该存档角色对应卡组，请检查数据库");
            foreach (string kid in res)
            {
                int k = 0;
                try
                {
                    k = Int32.Parse(kid);
                }
                catch (FormatException)
                {
                    Debug.LogWarning("卡牌数据库中Int型数据转化异常，请数据库管理员检查数据库");
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
                Debug.LogWarning("在卡牌数据库中搜索到错误的id数量，请数据库管理员检查数据库");
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
                    Debug.LogWarning("在卡牌数据库中未搜索到规定为非空的值，请数据库管理员检查数据库");
                }

                try
                {
                    khp = Int32.Parse(mq.SelectWithSqlCommand(cmd, "khp")[0]);
                    Debug.Log("khp: " + khp.ToString());
                }
                catch (ArgumentNullException)
                {
                    Debug.LogWarning("在卡牌数据库中未搜索到规定为非空的值，请数据库管理员检查数据库");
                }
                catch (FormatException)
                {
                    Debug.LogWarning("卡牌数据库中Int型数据转化异常，请数据库管理员检查数据库");
                }

                try
                {
                    karm = Int32.Parse(mq.SelectWithSqlCommand(cmd, "karm")[0]);
                    Debug.Log("karm: " + khp.ToString());
                }
                catch (ArgumentNullException)
                {
                    Debug.LogWarning("在卡牌数据库中未搜索到规定为非空的值，请数据库管理员检查数据库");
                }
                catch (FormatException)
                {
                    Debug.LogWarning("卡牌数据库中Int型数据转化异常，请数据库管理员检查数据库");
                }

                try
                {
                    keff = Int32.Parse(mq.SelectWithSqlCommand(cmd, "keff")[0]);
                    Debug.Log("keff: " + keff.ToString());
                }
                catch (ArgumentNullException)
                {
                    Debug.LogWarning("在卡牌数据库中未搜索到规定为非空的值，请数据库管理员检查数据库");
                }
                catch (FormatException)
                {
                    Debug.LogWarning("卡牌数据库中Int型数据转化异常，请数据库管理员检查数据库");
                }

                try
                {
                    kappr = Int32.Parse(mq.SelectWithSqlCommand(cmd, "kappr")[0]);
                    Debug.Log("kappr: " + kappr.ToString());
                }
                catch (ArgumentNullException)
                {
                    Debug.LogWarning("在卡牌数据库中未搜索到规定为非空的值，请数据库管理员检查数据库");
                }
                catch (FormatException)
                {
                    Debug.LogWarning("卡牌数据库中Int型数据转化异常，请数据库管理员检查数据库");
                }

                try
                {
                    kdef = Int32.Parse(mq.SelectWithSqlCommand(cmd, "kdef")[0]);
                    Debug.Log("kdef: " + kdef.ToString());
                }
                catch (ArgumentNullException)
                {
                    Debug.LogWarning("在卡牌数据库中未搜索到规定为非空的值，请数据库管理员检查数据库");
                }
                catch (FormatException)
                {
                    Debug.LogWarning("卡牌数据库中Int型数据转化异常，请数据库管理员检查数据库");
                }

                try
                {
                    katk = Int32.Parse(mq.SelectWithSqlCommand(cmd, "katk")[0]);
                    Debug.Log("katk: " + katk.ToString());
                }
                catch (ArgumentNullException)
                {
                    Debug.LogWarning("在卡牌数据库中未搜索到规定为非空的值，请数据库管理员检查数据库");
                }
                catch (FormatException)
                {
                    Debug.LogWarning("卡牌数据库中Int型数据转化异常，请数据库管理员检查数据库");
                }
            }
        }
    }
}
