using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StaticData;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    [RuntimeInitializeOnLoadMethod]
    static void Initialize()
    {
        RoleData.music = true;
        if (SceneManager.GetActiveScene().name == "TitleUI")
        {
            return;
        }
        SceneManager.LoadScene("TitleUI");
    }

}
