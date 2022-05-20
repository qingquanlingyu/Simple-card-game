using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CSharpMysql;

public class SaveLoad : MonoBehaviour
{
    // Start is called before the first frame update
    public int i;
    public Text rname;
    public Text rtime;
    void Start()
    {
        MysqlAccess mq = new MysqlAccess();
        string cmd = $"select * from role where id = {i}";
        List<string> rolename = mq.SelectWithSqlCommand(cmd, "name");
        List<string> roletime = mq.SelectWithSqlCommand(cmd, "time");
        if (rolename.Count == 0)
        { 
            rname.text = "";
            rtime.text = "";
        }
        else if (rolename.Count == 1)
        {
            rname.text = rolename[0];
            rtime.text = roletime[0];
        }
        else
            Debug.LogWarning("在存档数据库中搜索到错误的id数量，请数据库管理员检查数据库");
    }
}
