using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using StaticData;
using System.Data;
using CSharpMysql;

public class DeckInit : MonoBehaviour
{
    public GameObject content;
    void Start()
    {
        RectTransform transform = content.transform.GetComponent<RectTransform>();
        transform.sizeDelta = new Vector2(0,  Deck.deck.Count/4*360+400); // ¿í£¬¸ß
        foreach (Card c in Deck.deck)
        {
            GameObject k;
            Debug.Log($"¼ÓÔØ¿¨ÅÆ£¬idÎª{c.kid}");
            switch (c.kappr)
            {
                case 1:
                    k = Instantiate(Resources.Load<GameObject>("cards/1Attack"), new Vector3(0, 0, 0), Quaternion.identity, content.transform);
                    break;
                case 2:
                    k = Instantiate(Resources.Load<GameObject>("cards/2Defend"), new Vector3(0, 0, 0), Quaternion.identity, content.transform);
                    break;
                case 3:
                    k = Instantiate(Resources.Load<GameObject>("cards/3Shieldhit"), new Vector3(0, 0, 0), Quaternion.identity, content.transform);
                    break;
                case 4:
                    k = Instantiate(Resources.Load<GameObject>("cards/4Shielddef"), new Vector3(0, 0, 0), Quaternion.identity, content.transform);
                    break;
                case 5:
                    k = Instantiate(Resources.Load<GameObject>("cards/5Lifearrow"), new Vector3(0, 0, 0), Quaternion.identity, content.transform);
                    break;
                default:
                    k = Instantiate(Resources.Load<GameObject>("cards/1Attack"), new Vector3(0, 0, 0), Quaternion.identity, content.transform);
                    break;
            }
            foreach (Transform child in k.transform)
            {
                if (child.name == "Name")
                    child.GetComponent<Text>().text = c.kname;
                else if (child.name == "Des")
                    child.GetComponent<Text>().text = c.kdes;
            }
        }
    }
}
