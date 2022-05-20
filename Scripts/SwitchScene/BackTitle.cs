using System.Collections;
using NaughtyAttributes;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BackTitle : MonoBehaviour
{

    public Button ButtonTitle;

    void Start()
    {
        ButtonTitle.onClick.AddListener(OnClick_Title);
    }

    private void OnClick_Title()
    {
        if (SceneManager.GetActiveScene().name == "TitleUI")
        {
            return;
        }
        SceneManager.LoadScene("TitleUI");
    }
}
