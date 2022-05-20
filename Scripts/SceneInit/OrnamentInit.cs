using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using StaticData;
using System.Data;
using CSharpMysql;

public class OrnamentInit : MonoBehaviour
{
    public GameObject content;
    void Start()
    {
        RectTransform transform = content.transform.GetComponent<RectTransform>();
        transform.sizeDelta = new Vector2(0,  Ornament.ornas.Count/6*180+200); // 宽，高
        foreach (Orna o in Ornament.ornas)
        {
            GameObject k;
            Debug.Log($"加载饰品，id为{o.sid}");
            switch (o.sid)
            {
                case 1:
                    k = Instantiate(Resources.Load<GameObject>("ornaments/1"), new Vector3(0, 0, 0), Quaternion.identity, content.transform);
                    break;
                case 2:
                    k = Instantiate(Resources.Load<GameObject>("ornaments/2"), new Vector3(0, 0, 0), Quaternion.identity, content.transform);
                    break;
                case 3:
                    k = Instantiate(Resources.Load<GameObject>("ornaments/3"), new Vector3(0, 0, 0), Quaternion.identity, content.transform);
                    break;
                case 4:
                    k = Instantiate(Resources.Load<GameObject>("ornaments/4"), new Vector3(0, 0, 0), Quaternion.identity, content.transform);
                    break;
                case 5:
                    k = Instantiate(Resources.Load<GameObject>("ornaments/5"), new Vector3(0, 0, 0), Quaternion.identity, content.transform);
                    break;
                case 6:
                    k = Instantiate(Resources.Load<GameObject>("ornaments/6"), new Vector3(0, 0, 0), Quaternion.identity, content.transform);
                    break;
                case 7:
                    k = Instantiate(Resources.Load<GameObject>("ornaments/7"), new Vector3(0, 0, 0), Quaternion.identity, content.transform);
                    break;
                case 8:
                    k = Instantiate(Resources.Load<GameObject>("ornaments/8"), new Vector3(0, 0, 0), Quaternion.identity, content.transform);
                    break;
                case 9:
                    k = Instantiate(Resources.Load<GameObject>("ornaments/9"), new Vector3(0, 0, 0), Quaternion.identity, content.transform);
                    break;
                default:
                    k = Instantiate(Resources.Load<GameObject>("ornaments/1"), new Vector3(0, 0, 0), Quaternion.identity, content.transform);
                    break;
            }
            foreach (Transform child in k.transform)
                if (child.name == "Text")
                    child.GetComponent<Text>().text = o.sname;
            k.GetComponent<MoveOn>().text = o.sdes;
        }
    }
}
