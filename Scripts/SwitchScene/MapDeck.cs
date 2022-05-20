using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MapDeck : MonoBehaviour
{
    public Button b;

    void Start()
    {
        b.onClick.AddListener(OnClick);
    }
    private void OnClick()
    {
        if (SceneManager.GetActiveScene().name == "Deck")
        {
            return;
        }
        Debug.Log("Deck");
        SceneManager.LoadScene("Deck");
    }
}
