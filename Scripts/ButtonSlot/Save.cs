using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CSharpMysql;
using StaticData;

public class Save : MonoBehaviour
{
    public Button save;
    public GameObject warn;
    private MysqlAccess mq;

    void Start()
    {
        mq = new MysqlAccess();
        save.onClick.AddListener(OnClick);
    }

    private void OnClick()
    {
        if (save.name.Substring(0, 4) != "save")
            return;
        char index = save.name[4];  
        string cmd = $"select * from role where id = {index}";
        List<string> res = mq.SelectWithSqlCommand(cmd, "name");
        if (res.Count == 0)
        {
            RoleData.id = index - '0';
            int ires = RoleData.InsertRole();
            Deck.SaveDeck();
            if (ires > 0)
            {
                foreach (Transform child in save.transform)
                {
                    if (child.gameObject.name == "Name")
                        child.gameObject.GetComponent<Text>().text = RoleData.name;
                    else if (child.gameObject.name == "Time")
                    {
                        string tcmd = $"select * from role where id = {RoleData.id}";
                        List<string> rolename = mq.SelectWithSqlCommand(tcmd, "time");
                        child.gameObject.GetComponent<Text>().text = rolename[0];
                    }
                }
            }
        }
        else if (res.Count > 1)
            Debug.LogWarning("在存档数据库中搜索到错误的id数量，请数据库管理员检查数据库");
        else
        {
            RoleData.id = index - '0';
            warn.SetActive(true);
        }
    }
}
