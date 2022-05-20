using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using StaticData;
using CSharpMysql;

public class SaveWarningYes : MonoBehaviour
{
    public Button yes;
    public GameObject warn;
    private MysqlAccess mq;
    void Start()
    {
        mq = new MysqlAccess();
        yes.onClick.AddListener(OnClick);
    }
    private void OnClick()
    {
        warn.SetActive(false);
        int ires = RoleData.UpdateRole();
        Deck.SaveDeck();
        if (ires > 0)
        {
            string name = "save" + RoleData.id.ToString();
            Transform save = GameObject.Find(name).transform;
            foreach (Transform child in save)
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
}
