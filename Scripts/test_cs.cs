using System.Collections;
using NaughtyAttributes;
using System.Collections.Generic;
using UnityEngine;

public class test_cs : MonoBehaviour
{
    public Color color;
    public Color32 color32;
    public Vector3Int v;
    public bool PrintOnUpdate = true;
    public float TimeScale = 1.0F;
    public float MoveSpeed = 1.0F;

    public GameObject Prefab;
    public GameObject obj;

    int TimeCount = 0;

    [Button()]
    void TestTimeCoroutine()
    {
                StartCoroutine(PrintWithCoroutine());
    }

    [Button()]
    private void CreateGO()
    {
        if (Prefab != null)
            obj = GameObject.Instantiate(Prefab);
        else
            obj = GameObject.CreatePrimitive(PrimitiveType.Cube);
        Debug.Log("Create GameObject " + obj.name);
    }
    private void Start()
    {
        Debug.Log(v);
    }
    private void Update()
    {
        Time.timeScale = TimeScale;
        UpdatePosition();

    }

    private void UpdatePosition()
    {
        if (MoveSpeed <= 0) return;
        float moveDist = MoveSpeed * Time.deltaTime;
        transform.position = transform.position + transform.right * moveDist;
    }

    private void TestTime()
    {
        if (PrintOnUpdate)
        {
            Debug.Log(Time.deltaTime);//实时帧刷新周期
            Debug.Log(Time.frameCount);//总帧数
            Debug.Log($"time:{Time.timeSinceLevelLoad}  realtime:{Time.realtimeSinceStartup}");//游戏时间、实际时间(不吃暂停)
        }
    }

    IEnumerator PrintWithCoroutine()
    {
        yield return new WaitForSeconds(1);
        print("Time: second " + (++TimeCount).ToString());
    }

    [Button()]
    // 移除所有 测试用的Object
    void DestroyAllChildren()
    {
        
        List<Transform> trans = new List<Transform>();
        var count = transform.childCount;
        for (int i = 0; i < count; i++)
        {
            var tran = transform.GetChild(i);
            Debug.Log(tran.name);
        }
        foreach (Transform tran in transform)
        {
            trans.Add(tran);
        }

        foreach (var item in trans)
        {
            UnityEngine.Object.Destroy(item.gameObject);
        }
        GameObject.Find("a");
    }

}
