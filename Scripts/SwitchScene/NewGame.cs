using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NewGame : MonoBehaviour
{
    public Button b;

    void Start()
    {
        b.onClick.AddListener(OnClick_Load);
    }

    private void OnClick_Load()
    {
        if (SceneManager.GetActiveScene().name == "NewRole")
        {
            return;
        }
        Debug.Log("NewRole");
        SceneManager.LoadScene("NewRole");
    }
}
