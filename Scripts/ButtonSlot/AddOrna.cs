using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using StaticData;
using UnityEngine.SceneManagement;

public class AddOrna : MonoBehaviour
{
    public Button b;
    public int ornaid;
    // Start is called before the first frame update
    void Start()
    {
        b.onClick.AddListener(OnClick);
    }

    private void OnClick()
    {
        Ornament.ornas.Add(new Orna(ornaid));
        RoleData.nowlayer++;
        SceneManager.LoadScene("Map");
    }
}
