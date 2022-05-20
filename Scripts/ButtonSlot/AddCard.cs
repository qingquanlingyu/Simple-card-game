using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using StaticData;
using UnityEngine.SceneManagement;

public class AddCard : MonoBehaviour
{
    public Button b;
    public int cardid;
    // Start is called before the first frame update
    void Start()
    {
        b.onClick.AddListener(OnClick);
    }

    private void OnClick()
    {
        Deck.deck.Add(new Card(cardid));
        RoleData.nowlayer++;
        SceneManager.LoadScene("Map");
    }
}
