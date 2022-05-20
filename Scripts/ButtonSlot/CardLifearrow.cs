using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using StaticData;
using ClearSky;

public class CardLifearrow : MonoBehaviour
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
        GameObject.Find("Wizard").GetComponent<WizDemo1>().Attack();
        int damage = Deck.deck[cardid].katk * (RoleData.atk) / 100 - Monster.gdef;
        Debug.Log($"Íæ¼Ò»ù´¡ÉËº¦{damage}");
        if (Ornament.effects[4])
        {
            if (Monster.garm >= 2 * damage)
            {
                Monster.garm -= 2 * damage;
                damage = 0;
            }
            else
            {
                damage -= (Monster.garm + 1) / 2;
                Monster.garm = 0;
            }
        }
        else
        {
            if (Monster.garm >= damage)
            {
                Monster.garm -= damage;
                damage = 0;
            }
            else
            {
                damage -= Monster.garm;
                Monster.garm = 0;
            }
        }
        Monster.ghp -= damage;
        if (Ornament.effects[1])
            RoleData.hp = Math.Min(RoleData.hp + (int)(RoleData.atk * 0.2), RoleData.maxhp);
        if (Ornament.effects[2])
            Monster.ghp -= (int)(RoleData.atk * 0.2);
        if (Ornament.effects[5])
            RoleData.arm += 1;
        if (Ornament.effects[7])
            Monster.ghp -= (int)(Monster.gdef * 0.5);
        RoleData.hp = Math.Min(RoleData.hp + (int)(Deck.deck[cardid].khp * RoleData.maxhp / 100), RoleData.maxhp);
        SceneCon.UpdateData();
        if (Monster.ghp <= 0)
            SceneCon.MonsterDead();
        else
            SceneCon.Roundend();
    }
}
