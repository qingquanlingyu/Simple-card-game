using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MapOrna : MonoBehaviour
{
    public Button b;

    void Start()
    {
        b.onClick.AddListener(OnClick);
    }
    private void OnClick()
    {
        if (SceneManager.GetActiveScene().name == "Ornament")
        {
            return;
        }
        Debug.Log("Ornament");
        SceneManager.LoadScene("Ornament");
    }
}
