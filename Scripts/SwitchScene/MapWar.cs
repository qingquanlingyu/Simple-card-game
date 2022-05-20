using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StaticData;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MapWar : MonoBehaviour
{
    public Button b;
    public int gid;

    void Start()
    {
        b.onClick.AddListener(OnClick);
    }
    private void OnClick()
    {
        Debug.Log($"º”‘ÿπ÷ŒÔ{gid}");
        Monster.LoadId(gid);
        if (SceneManager.GetActiveScene().name == "War")
        {
            return;
        }
        Debug.Log("War");
        SceneManager.LoadScene("War");
    }
}
