using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using CSharpMysql;
using StaticData;

public class Load : MonoBehaviour
{
    public Button load;
    private MysqlAccess mq;

    void Start()
    {
        mq = new MysqlAccess();
        load.onClick.AddListener(OnClick);
    }

    private void OnClick()
    {
        if (load.name.Substring(0, 4) != "save")
            return;
        int index = load.name[4] - '0';
        string cmd = $"select * from role where id = {index}";
        RoleData.LoadId(index);
        Deck.LoadDeck();
        Ornament.LoadOrnaments();

        if (SceneManager.GetActiveScene().name == "Map")
            return;
        SceneManager.LoadScene("Map");
        
    }
}
