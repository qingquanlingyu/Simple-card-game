using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveWarningNo : MonoBehaviour
{
    public Button no;
    public GameObject warn;
    void Start()
    {
        no.onClick.AddListener(OnClick);

    }
    private void OnClick()
    {
        warn.SetActive(false);
    }
}
