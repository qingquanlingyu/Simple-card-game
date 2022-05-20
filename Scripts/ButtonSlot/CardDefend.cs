using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using StaticData;
using ClearSky;

public class CardDefend : MonoBehaviour
{
    // Start is called before the first frame update
    public Button b;
    public int cardno;
    void Start()
    {
        b.onClick.AddListener(OnClick);
    }
    private void OnClick()
    {
        int cardid = (int)Deck.nowdeck[cardno];
        Deck.nowdeck.Remove(cardno);
        var SceneCon = GameObject.Find("Canvas").GetComponent<WarInit>();
        SceneCon.UpdateData();
        GameObject.Find("Wizard").GetComponent<WizDemo1>().LookUp();
        int addarm = Deck.deck[cardid].karm * (RoleData.atk) / 100;
        if (Ornament.effects[4])
            addarm = (int)(addarm * 1.5);
        Debug.Log($"��һ�û���{addarm}");
        RoleData.arm += addarm;
        int adddef = Deck.deck[cardid].kdef * (RoleData.atk) / 100;
        Debug.Log($"��һ�÷���{adddef}");
        RoleData.def += adddef;
        SceneCon.UpdateData();
        SceneCon.Roundend();

    }
}
