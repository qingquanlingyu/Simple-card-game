using System.Collections;
using NaughtyAttributes;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleLoad : MonoBehaviour
{

    public Button ButtonLoad;

    void Start()
    {
        ButtonLoad.onClick.AddListener(OnClick_Load);
    }

    private void OnClick_Load()
    {
        if (SceneManager.GetActiveScene().name == "LoadUI")
        {
            return;
        }
        Debug.Log("Load");
        SceneManager.LoadScene("LoadUI");
    }
}
