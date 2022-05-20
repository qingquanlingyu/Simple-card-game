using System.Collections;
using NaughtyAttributes;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BackMap : MonoBehaviour
{

    public Button b;

    void Start()
    {
        b.onClick.AddListener(OnClick);
    }

    private void OnClick()
    {
        if (SceneManager.GetActiveScene().name == "Map")
        {
            return;
        }
        SceneManager.LoadScene("Map");
    }
}
