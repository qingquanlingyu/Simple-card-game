using System.Collections;
using NaughtyAttributes;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Quit : MonoBehaviour
{


    public Button ButtonQuit;

    void Start()
    {
        ButtonQuit.onClick.AddListener(OnClick_Quit);

        
    }

    private void OnClick_Quit()
    {
        Application.Quit();
    }


}
