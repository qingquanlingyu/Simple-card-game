using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MapSave : MonoBehaviour
{
    public Button b;

    void Start()
    {
        b.onClick.AddListener(OnClick);
    }
    private void OnClick()
    {
        if (SceneManager.GetActiveScene().name == "SaveUI")
        {
            return;
        }
        Debug.Log("SaveUI");
        SceneManager.LoadScene("SaveUI");
    }
}
