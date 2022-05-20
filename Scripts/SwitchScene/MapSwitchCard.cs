using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MapSwitchCard: MonoBehaviour
{
    public Button b;

    void Start()
    {
        b.onClick.AddListener(OnClick);
    }
    private void OnClick()
    {
        if (SceneManager.GetActiveScene().name == "SwitchCard")
        {
            return;
        }
        Debug.Log("SwitchCard");
        SceneManager.LoadScene("SwitchCard");
    }
}
