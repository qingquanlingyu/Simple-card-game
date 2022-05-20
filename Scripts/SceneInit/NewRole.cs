using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using StaticData;
using CSharpMysql;

public class NewRole : MonoBehaviour
{
    public Button b;
    public InputField t;
    public Text err;
    // Start is called before the first frame update
    void Start()
    {
        err.enabled = false;
        b.onClick.AddListener(OnClick);
    }

    private void OnClick()
    {
        Debug.Log(t.text.Length);
        if (t.text.Length == 0 || t.text.Length > 20)
        {
            err.enabled = true;
            return;
        }
        RoleData.id = 0;
        RoleData.name = t.text;
        RoleData.hp = 20;
        RoleData.maxhp = 20;
        RoleData.nowlayer = 1;
        RoleData.arm = 0;
        RoleData.atk = 6;
        RoleData.def = 0;
        //添加基础手牌
        MysqlAccess mq = new MysqlAccess();
        string cmd = $"select * from card where kid > 0";
        List<string> res = mq.SelectWithSqlCommand(cmd, "kid");
        Deck.CARDNUM = res.Count;
        Debug.Log($"卡牌总数：{Deck.CARDNUM}");

        Deck.nowdeck = new Hashtable();
        Deck.deck = new List<Card>();
        Deck.deck.Add(new Card(1));
        Deck.deck.Add(new Card(1));//攻击X2
        Deck.deck.Add(new Card(2));
        Deck.deck.Add(new Card(2));//防御X2
        Deck.deck.Add(new Card(3));//盾击X1
        //初始化饰品
        cmd = $"select * from ornament where sid > 0";
       res = mq.SelectWithSqlCommand(cmd, "sid");
        Ornament.ORNANUM = res.Count;
        Debug.Log($"饰品总数：{Ornament.ORNANUM}");

        Ornament.effects = new bool[9];
        Ornament.ornas = new List<Orna>();
        if (SceneManager.GetActiveScene().name == "Map")
        {
            return;
        }
        SceneManager.LoadScene("Map");
    }
}
