using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MapDropCard: MonoBehaviour
{
    public Button b;

    void Start()
    {
        b.onClick.AddListener(OnClick);
    }
    private void OnClick()
    {
        if (SceneManager.GetActiveScene().name == "DropCard")
        {
            return;
        }
        Debug.Log("DropCard");
        SceneManager.LoadScene("DropCard");
    }
}
