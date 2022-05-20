using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using StaticData;

public class CardAwardInit : MonoBehaviour
{
    public GameObject content;

    void Start()
    {
        System.Random rm = new System.Random();
        for (int i = 0; i < 3 ; i++)
        {
            int kid = rm.Next(1, Deck.CARDNUM + 1);
            GameObject k;
            Debug.Log($"¼ÓÔØ½±Àø¿¨ÅÆ£¬idÎª{kid}");
            Card tmp = new Card(kid);
            switch (tmp.kappr)
            {
                case 1:
                    k = Instantiate(Resources.Load<GameObject>("Awardcards/1Attack"), new Vector3(0, 0, 0), Quaternion.identity, content.transform);
                    break;
                case 2:
                    k = Instantiate(Resources.Load<GameObject>("Awardcards/2Defend"), new Vector3(0, 0, 0), Quaternion.identity, content.transform);
                    break;
                case 3:
                    k = Instantiate(Resources.Load<GameObject>("Awardcards/3Shieldhit"), new Vector3(0, 0, 0), Quaternion.identity, content.transform);
                    break;
                case 4:
                    k = Instantiate(Resources.Load<GameObject>("Awardcards/4Shielddef"), new Vector3(0, 0, 0), Quaternion.identity, content.transform);
                    break;
                case 5:
                    k = Instantiate(Resources.Load<GameObject>("Awardcards/5Lifearrow"), new Vector3(0, 0, 0), Quaternion.identity, content.transform);
                    break;
                default:
                    k = Instantiate(Resources.Load<GameObject>("Awardcards/1Attack"), new Vector3(0, 0, 0), Quaternion.identity, content.transform);
                    break;
            }
            k.GetComponent<AddCard>().cardid = kid;
            foreach (Transform child in k.transform)
            {
                if (child.name == "Name")
                    child.GetComponent<Text>().text = tmp.kname;
                else if (child.name == "Des")
                    child.GetComponent<Text>().text = tmp.kdes;
            }
        }
    }
}
