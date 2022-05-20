using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using StaticData;

public class OrnaAwardInit : MonoBehaviour
{
    public GameObject content;

    void Start()
    {
        System.Random rm = new System.Random();
        for (int i = 0; i < 3 ; i++)
        {
            int sid = rm.Next(1, Ornament.ORNANUM + 1);
            GameObject k;
            Debug.Log($"¼ÓÔØ½±Àø¿¨ÅÆ£¬idÎª{sid}");
            Orna tmp = new Orna(sid, false);
            switch (sid)
            {
                case 1:
                    k = Instantiate(Resources.Load<GameObject>("Awardornas/1"), new Vector3(0, 0, 0), Quaternion.identity, content.transform);
                    break;
                case 2:
                    k = Instantiate(Resources.Load<GameObject>("Awardornas/2"), new Vector3(0, 0, 0), Quaternion.identity, content.transform);
                    break;
                case 3:
                    k = Instantiate(Resources.Load<GameObject>("Awardornas/3"), new Vector3(0, 0, 0), Quaternion.identity, content.transform);
                    break;
                case 4:
                    k = Instantiate(Resources.Load<GameObject>("Awardornas/4"), new Vector3(0, 0, 0), Quaternion.identity, content.transform);
                    break;
                case 5:
                    k = Instantiate(Resources.Load<GameObject>("Awardornas/5"), new Vector3(0, 0, 0), Quaternion.identity, content.transform);
                    break;
                case 6:
                    k = Instantiate(Resources.Load<GameObject>("Awardornas/6"), new Vector3(0, 0, 0), Quaternion.identity, content.transform);
                    break;
                case 7:
                    k = Instantiate(Resources.Load<GameObject>("Awardornas/7"), new Vector3(0, 0, 0), Quaternion.identity, content.transform);
                    break;
                case 8:
                    k = Instantiate(Resources.Load<GameObject>("Awardornas/8"), new Vector3(0, 0, 0), Quaternion.identity, content.transform);
                    break;
                case 9:
                    k = Instantiate(Resources.Load<GameObject>("Awardornas/9"), new Vector3(0, 0, 0), Quaternion.identity, content.transform);
                    break;
                default:
                    k = Instantiate(Resources.Load<GameObject>("Awardornas/1"), new Vector3(0, 0, 0), Quaternion.identity, content.transform);
                    break;
            }
            k.GetComponent<AddOrna>().ornaid = sid;
            foreach (Transform child in k.transform)
                if (child.name == "Text")
                    child.GetComponent<Text>().text = tmp.sname;
            k.GetComponent<MoveOn>().text = tmp.sdes;
        }
    }
}
