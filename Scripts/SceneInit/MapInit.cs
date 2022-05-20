using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using StaticData;
using System.Data;
using System;
using CSharpMysql;

public class MapInit : MonoBehaviour
{
    // Start is called before the first frame update
    private int dhp1 = 0;
    private int dhp2 = 0;
    void Start()
    {
        GameObject hptext = GameObject.Find("HP");
        hptext.GetComponent<Text>().text = RoleData.hp.ToString() + "/" + RoleData.maxhp.ToString();

        GameObject rolenametext = GameObject.Find("RoleName");
        rolenametext.GetComponent<Text>().text = RoleData.name;

        GameObject layertext = GameObject.Find("Layer");
        layertext.GetComponent<Text>().text = "当前层数："+RoleData.nowlayer.ToString();

        MysqlAccess mq = new MysqlAccess();
        int en1 = UnityEngine.Random.Range(1, 15), en2 = UnityEngine.Random.Range(1, 15);
        while (en2 == en1)
            en2 = UnityEngine.Random.Range(1, 15); 

        DataTable encounters = mq.SelectFrom("encounter");
        if (encounters != null)
        {
            DataRow[] drs1 = encounters.Select($"zid = {en1}");
            int appr1 = (int)drs1[0]["zappr"];
            string name1 = (string)drs1[0]["zname"];
            string des1 = (string)drs1[0]["zdes"];
            GameObject e1 = null;
            switch (appr1)
            {
                case 1:
                    e1 = Instantiate(Resources.Load<GameObject>("encounters/1Treasure"), new Vector3(400, 360, 0), Quaternion.identity, GameObject.Find("canvas").transform);
                    break;
                case 2:
                    e1 = Instantiate(Resources.Load<GameObject>("encounters/2Heal"), new Vector3(400, 360, 0), Quaternion.identity, GameObject.Find("canvas").transform);
                    break;
                case 3:
                    e1 = Instantiate(Resources.Load<GameObject>("encounters/3Drop"), new Vector3(400, 360, 0), Quaternion.identity, GameObject.Find("canvas").transform);
                    break;
                case 4:
                    e1 = Instantiate(Resources.Load<GameObject>("encounters/4Switch"), new Vector3(400, 360, 0), Quaternion.identity, GameObject.Find("canvas").transform);
                    break;
                case 5:
                    e1 = Instantiate(Resources.Load<GameObject>("encounters/5Sacrifice"), new Vector3(400, 360, 0), Quaternion.identity, GameObject.Find("canvas").transform);
                    break;
                case 6:
                    e1 = Instantiate(Resources.Load<GameObject>("encounters/6Attack"), new Vector3(400, 360, 0), Quaternion.identity, GameObject.Find("canvas").transform);
                    break;
                default:
                    e1 = Instantiate(Resources.Load<GameObject>("encounters/6Attack"), new Vector3(400, 36, 0), Quaternion.identity, GameObject.Find("canvas").transform);
                    break;
            }
            foreach (Transform child in e1.transform)
                child.GetComponent<Text>().text = name1;
            e1.GetComponent<MoveOn>().text = des1;
            if (e1.name[0] == '6')
            {
                e1.GetComponent<MapWar>().gid = (int)drs1[0]["zgid"];
                Debug.Log($"填入战斗事件对应怪物id：{(int)drs1[0]["zgid"]}");
            }
            else if (e1.name[0] == '1')
            {
                e1.GetComponent<MapTreasure>().zeff = (int)drs1[0]["zeff"];
                Debug.Log($"填入宝藏事件对应区分eff：{(int)drs1[0]["zeff"]}");
            }
            else if (e1.name[0] == '2')
            {
                dhp1 = (int)drs1[0]["zhp"];
                e1.GetComponent<Button>().onClick.AddListener(AddHP1);
            }
            else if (e1.name[0] == '5')
            {
                e1.GetComponent<MapSacrifice>().zeff = (int)drs1[0]["zeff"];
                e1.GetComponent<MapSacrifice>().dhp = (int)drs1[0]["zhp"];
                Debug.Log($"填入献祭事件对应区分eff：{(int)drs1[0]["zeff"]}");
            }


            DataRow[] drs2 = encounters.Select($"zid = {en2}");
            int appr2 = (int)drs2[0]["zappr"];
            string name2 = (string)drs2[0]["zname"];
            string des2 = (string)drs2[0]["zdes"];
            GameObject e2 = null;
            switch (appr2)
            {
                case 1:
                    e2 = Instantiate(Resources.Load<GameObject>("encounters/1Treasure"), new Vector3(880, 360, 0), Quaternion.identity, GameObject.Find("canvas").transform);
                    break;
                case 2:
                    e2 = Instantiate(Resources.Load<GameObject>("encounters/2Heal"), new Vector3(880, 360, 0), Quaternion.identity, GameObject.Find("canvas").transform);
                    break;
                case 3:
                    e2 = Instantiate(Resources.Load<GameObject>("encounters/3Drop"), new Vector3(880, 360, 0), Quaternion.identity, GameObject.Find("canvas").transform);
                    break;
                case 4:
                    e2 = Instantiate(Resources.Load<GameObject>("encounters/4Switch"), new Vector3(880, 360, 0), Quaternion.identity, GameObject.Find("canvas").transform);
                    break;
                case 5:
                    e2 = Instantiate(Resources.Load<GameObject>("encounters/5Sacrifice"), new Vector3(880, 360, 0), Quaternion.identity, GameObject.Find("canvas").transform);
                    break;
                case 6:
                    e2 = Instantiate(Resources.Load<GameObject>("encounters/6Attack"), new Vector3(880, 360, 0), Quaternion.identity, GameObject.Find("canvas").transform);
                    break;
                default:
                    e1 = Instantiate(Resources.Load<GameObject>("encounters/6Attack"), new Vector3(880, 360, 0), Quaternion.identity, GameObject.Find("canvas").transform);
                    break;
            }
            foreach (Transform child in e2.transform)
                child.GetComponent<Text>().text = name2;
            e2.GetComponent<MoveOn>().text = des2;
            if (e2.name[0] == '6')
            {
                e2.GetComponent<MapWar>().gid = (int)drs2[0]["zgid"];
                Debug.Log($"填入战斗事件对应怪物id：{(int)drs2[0]["zgid"]}");
            }
            else if (e2.name[0] == '1')
            {
                e2.GetComponent<MapTreasure>().zeff = (int)drs2[0]["zeff"];
                Debug.Log($"填入宝藏事件对应区分eff：{(int)drs2[0]["zeff"]}");
            }
            else if (e2.name[0] == '2')
            {
                dhp2 = (int)drs2[0]["zhp"];
                e2.GetComponent<Button>().onClick.AddListener(AddHP2);
            }
            else if (e2.name[0] == '5')
            {
                e2.GetComponent<MapSacrifice>().zeff = (int)drs2[0]["zeff"];
                e2.GetComponent<MapSacrifice>().dhp = (int)drs2[0]["zhp"];
                Debug.Log($"填入献祭事件对应区分eff：{(int)drs2[0]["zeff"]}");
            }
        }
    }

    private void AddHP1()
    {
        RoleData.hp = Math.Min(RoleData.maxhp, (int)(RoleData.hp * (1.0 + dhp1 / 100.0)));
        RoleData.nowlayer++;
        SceneManager.LoadScene("Map");
    }

    private void AddHP2()
    {
        RoleData.hp = Math.Min(RoleData.maxhp, (int)(RoleData.hp * (1.0 + dhp2 / 100.0)));
        RoleData.nowlayer++;
        SceneManager.LoadScene("Map");
    }
}
