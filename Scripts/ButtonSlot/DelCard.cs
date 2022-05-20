using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using StaticData;
using UnityEngine.SceneManagement;

public class DelCard : MonoBehaviour
{
    public Button b;
    public int cardno;
    // Start is called before the first frame update
    void Start()
    {
        b.onClick.AddListener(OnClick);
    }

    private void OnClick()
    {
        Deck.deck.RemoveAt(cardno);
        SceneManager.LoadScene("Map");
    }
}
