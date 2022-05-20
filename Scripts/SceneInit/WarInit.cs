using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using StaticData;
using System;
using ClearSky;

public class WarInit : MonoBehaviour
{
    public GameObject content;
    private GameObject mons;
    public GameObject dead;
    void Start()
    {
        dead.SetActive(false);
        //���ع���
        Debug.Log($"���ع�����{Monster.gappr}");
        Quaternion RotationFZ = Quaternion.Euler(0f, 180f, 0f);
        Vector3 gpos = new Vector3(940, 460, 0);
        switch (Monster.gappr)
        {
            case 1:
               mons = Instantiate(Resources.Load<GameObject>("monsters/1base"), gpos, RotationFZ, GameObject.Find("Canvas").transform);
                break;
            case 2:
                mons = Instantiate(Resources.Load<GameObject>("monsters/2shield"), gpos, RotationFZ, GameObject.Find("Canvas").transform); 
                break;
            case 3:
                mons = Instantiate(Resources.Load<GameObject>("monsters/3archer"), gpos, RotationFZ, GameObject.Find("Canvas").transform);
                break;
            case 4:
                mons = Instantiate(Resources.Load<GameObject>("monsters/4warrier"), gpos, RotationFZ, GameObject.Find("Canvas").transform);
                break;
            default:
                mons = Instantiate(Resources.Load<GameObject>("monsters/1base"), gpos, RotationFZ, GameObject.Find("Canvas").transform);
                break;
        }
        mons.GetComponent<MoveOn>().text = Monster.gdes;
        foreach (Transform child in mons.GetComponentsInChildren<Transform>())
        {
            if (child.name == "Name")
                child.GetComponent<Text>().text = Monster.gname;
            else if (child.name == "Def")
                child.GetComponent<Text>().text = Monster.gdef.ToString();
            else if (child.name == "Arm")
                child.GetComponent<Text>().text = Monster.garm.ToString();
            else if (child.name == "HP")
                child.GetComponent<Text>().text = Monster.ghp.ToString();
        }
        //�����������
        Debug.Log($"�����������");
        GameObject hptext = GameObject.Find("pHP");
        hptext.GetComponent<Text>().text = RoleData.hp.ToString() + "/" + RoleData.maxhp.ToString();
        GameObject armtext = GameObject.Find("pArm");
        armtext.GetComponent<Text>().text = RoleData.arm.ToString();
        GameObject deftext = GameObject.Find("pDef");
        deftext.GetComponent<Text>().text = RoleData.def.ToString();

        //���ؿ���
        Debug.Log($"���ؿ���");
        int RmNum = 3;
        System.Random rm = new System.Random();
        //���ѡ3�Ų�ͬ���Ƽ����ʼ����
        for (int i = 0; Deck.nowdeck.Count < RmNum; i++)
        {
            int nValue = rm.Next(Deck.deck.Count - 1);
            if (!Deck.nowdeck.ContainsValue(nValue))
                Deck.nowdeck.Add(nValue, nValue); 
        }
        for(int i = 0; i < Deck.deck.Count; i++)
        {
            if (Deck.nowdeck.ContainsValue(i))
            {
                Card c = Deck.deck[i];
                GameObject k;
                Debug.Log($"���ؿ��ƣ�idΪ{c.kid}");
                switch (c.kappr)
                {
                    case 1:
                        k = Instantiate(Resources.Load<GameObject>("Warcards/1Attack"), new Vector3(0, 0, 0), Quaternion.identity, content.transform);
                        k.GetComponent<CardAttack>().cardno = i;
                        break;
                    case 2:
                        k = Instantiate(Resources.Load<GameObject>("Warcards/2Defend"), new Vector3(0, 0, 0), Quaternion.identity, content.transform);
                        k.GetComponent<CardDefend>().cardno = i;
                        break;
                    case 3:
                        k = Instantiate(Resources.Load<GameObject>("Warcards/3Shieldhit"), new Vector3(0, 0, 0), Quaternion.identity, content.transform);
                        k.GetComponent<CardShieldhit>().cardno = i;
                        break;
                    case 4:
                        k = Instantiate(Resources.Load<GameObject>("Warcards/4Shielddef"), new Vector3(0, 0, 0), Quaternion.identity, content.transform);
                        k.GetComponent<CardShielddef>().cardno = i;
                        break;
                    case 5:
                        k = Instantiate(Resources.Load<GameObject>("Warcards/5Lifearrow"), new Vector3(0, 0, 0), Quaternion.identity, content.transform);
                        k.GetComponent<CardLifearrow>().cardno = i;
                        break;
                    default:
                        k = Instantiate(Resources.Load<GameObject>("Warcards/1Attack"), new Vector3(0, 0, 0), Quaternion.identity, content.transform);
                        k.GetComponent<CardAttack>().cardno = i;
                        break;
                }
                
                foreach (Transform child in k.transform)
                {
                    if (child.name == "Name")
                        child.GetComponent<Text>().text = c.kname;
                    else if (child.name == "Des")
                        child.GetComponent<Text>().text = c.kdes;
                }
            }
        }
    }

    public void UpdateData()
    {
        //���¹�������
        Debug.Log($"���¹�������");
        foreach (Transform child in mons.GetComponentsInChildren<Transform>())
        {
            if (child.name == "Def")
                child.GetComponent<Text>().text = Monster.gdef.ToString();
            else if (child.name == "Arm")
                child.GetComponent<Text>().text = Monster.garm.ToString();
            else if (child.name == "HP")
                child.GetComponent<Text>().text = Monster.ghp.ToString();
        }
        //�����������
        Debug.Log($"�����������");
        GameObject hptext = GameObject.Find("pHP");
        hptext.GetComponent<Text>().text = RoleData.hp.ToString() + "/" + RoleData.maxhp.ToString();
        GameObject armtext = GameObject.Find("pArm");
        armtext.GetComponent<Text>().text = RoleData.arm.ToString();
        GameObject deftext = GameObject.Find("pDef");
        deftext.GetComponent<Text>().text = RoleData.def.ToString();

        //���ؿ���
        foreach (Transform child in content.transform)
        {
            Destroy(child.gameObject);
        }
        Debug.Log($"���¿���");
        for (int i = 0; i < Deck.deck.Count; i++)
        {
            if (Deck.nowdeck.ContainsValue(i))
            {
                Card c = Deck.deck[i];
                GameObject k;
                Debug.Log($"���ؿ��ƣ�idΪ{c.kid}");
                switch (c.kappr)
                {
                    case 1:
                        k = Instantiate(Resources.Load<GameObject>("Warcards/1Attack"), new Vector3(0, 0, 0), Quaternion.identity, content.transform);
                        k.GetComponent<CardAttack>().cardno = i;
                        break;
                    case 2:
                        k = Instantiate(Resources.Load<GameObject>("Warcards/2Defend"), new Vector3(0, 0, 0), Quaternion.identity, content.transform);
                        k.GetComponent<CardDefend>().cardno = i;
                        break;
                    case 3:
                        k = Instantiate(Resources.Load<GameObject>("Warcards/3Shieldhit"), new Vector3(0, 0, 0), Quaternion.identity, content.transform);
                        k.GetComponent<CardShieldhit>().cardno = i;
                        break;
                    case 4:
                        k = Instantiate(Resources.Load<GameObject>("Warcards/4Shielddef"), new Vector3(0, 0, 0), Quaternion.identity, content.transform);
                        k.GetComponent<CardShielddef>().cardno = i;
                        break;
                    case 5:
                        k = Instantiate(Resources.Load<GameObject>("Warcards/5Lifearrow"), new Vector3(0, 0, 0), Quaternion.identity, content.transform);
                        k.GetComponent<CardLifearrow>().cardno = i;
                        break;
                    default:
                        k = Instantiate(Resources.Load<GameObject>("Warcards/1Attack"), new Vector3(0, 0, 0), Quaternion.identity, content.transform);
                        k.GetComponent<CardAttack>().cardno = i;
                        break;
                }
                foreach (Transform child in k.transform)
                {
                    if (child.name == "Name")
                        child.GetComponent<Text>().text = c.kname;
                    else if (child.name == "Des")
                        child.GetComponent<Text>().text = c.kdes;
                }
            }
        }
    }

    public void Roundend()
    {
        //�����ж�
        bool ishurt = false;
        int realmatk = (int)(Monster.gatk * (Math.Log10(RoleData.nowlayer)  + 1));
        int tmp = UnityEngine.Random.Range(0, 10);
        if (tmp < 6)//����
        {
            Debug.Log("����ʹ���� ����");
            int damage = realmatk - RoleData.def;
            if (Monster.geff == 1)
                damage += RoleData.def / 2;
            else if (Monster.geff == 2)
                Monster.ghp += (int)(damage * 0.2);
            if (RoleData.arm >= damage)
                RoleData.arm -= damage;
            else
            {
                RoleData.hp -= (damage - RoleData.arm);
                RoleData.arm = 0;
            }
            ishurt = true;
        }//����
        else
        {
            Debug.Log("����ʹ���� ����");
            Monster.garm += (int)(realmatk * 0.7);
        }

        //��ƷЧ��
        if (Ornament.effects[3])
            RoleData.hp = Math.Min(RoleData.hp + 1, RoleData.maxhp);
        //���³鿨
        int RmNum = 3;
        for (int i = 0; Deck.nowdeck.Count < RmNum; i++)
        {
            int nValue = UnityEngine.Random.Range(0, Deck.deck.Count);
            if (!Deck.nowdeck.ContainsValue(nValue))
                Deck.nowdeck.Add(nValue, nValue);
        }

        StartCoroutine(WaitForSecondsRealtime(1.0f, () =>
        {
            if (ishurt)
                GameObject.Find("Wizard").GetComponent<WizDemo1>().Hurt();
            else
                GameObject.Find("Wizard").GetComponent<WizDemo1>().Idle();
            UpdateData();
            if (RoleData.hp < 0)
                PlayerDead();
        }));
    }
    public void PlayerDead()
    {
        GameObject.Find("Wizard").GetComponent<WizDemo1>().Die();
        StartCoroutine(WaitForSecondsRealtime(1.0f, () =>
        {
            dead.SetActive(true);
        }));
    }

    public void MonsterDead()
    {
        RoleData.def = 0;
        RoleData.arm = 0;
        RoleData.nowlayer++;
        int tmp = UnityEngine.Random.Range(0, 10);
        if (tmp < 6)
        {
            Debug.Log("��������");
            SceneManager.LoadScene("CardAward");
        }
        else
        {
            Debug.Log("������Ʒ");
            SceneManager.LoadScene("OrnaAward");
        }
    }

    public static IEnumerator WaitForSecondsRealtime(float duration, Action action = null)
    {
        yield return new WaitForSecondsRealtime(duration);
        action?.Invoke();
    }
}
