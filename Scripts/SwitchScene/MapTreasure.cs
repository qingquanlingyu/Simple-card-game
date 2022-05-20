using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MapTreasure : MonoBehaviour
{
    public Button b;
    public int zeff;
    void Start()
    {
        b.onClick.AddListener(OnClick);
    }
    private void OnClick()
    {
        if (zeff == 2)
        {
            Debug.Log("CardAward");
            SceneManager.LoadScene("CardAward");
        }
        else if (zeff == 1)
        {
            Debug.Log("OrnaAward");
            SceneManager.LoadScene("OrnaAward");
        }
    }
}
