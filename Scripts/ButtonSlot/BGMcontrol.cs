using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using StaticData;

public class BGMcontrol : MonoBehaviour
{
    public AudioSource au;
    public Button b;
    // Start is called before the first frame update
    void Start()
    {
        if (RoleData.music)
            au.Play();
        else
            au.Stop();
        b.onClick.AddListener(OnClick);
    }

    private void OnClick()
    {
        if (au.isPlaying)
        {
            RoleData.music = false;
            au.Stop();
        }

        else     
        {
            RoleData.music = true;
            au.Play(); 
        }
    }
}
