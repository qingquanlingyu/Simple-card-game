using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StaticData;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MapSacrifice: MonoBehaviour
{
    public Button b;
    public int zeff;
    public int dhp;
    void Start()
    {
        b.onClick.AddListener(OnClick);
    }
    private void OnClick()
    {
        RoleData.hp = (int)(RoleData.hp * (1.0 + dhp / 100.0));
        if (zeff == 2)
        {
            Debug.Log("CardAward");
            SceneManager.LoadScene("CardAward");
        }
        else if (zeff == 1)
        {
            Debug.Log("OrnaAward");
            SceneManager.LoadScene("OrnaAward");
        }
    }
}
