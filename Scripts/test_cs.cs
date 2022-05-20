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
            Debug.Log(Time.deltaTime);//ʵʱ֡ˢ������
            Debug.Log(Time.frameCount);//��֡��
            Debug.Log($"time:{Time.timeSinceLevelLoad}  realtime:{Time.realtimeSinceStartup}");//��Ϸʱ�䡢ʵ��ʱ��(������ͣ)
        }
    }

    IEnumerator PrintWithCoroutine()
    {
        yield return new WaitForSeconds(1);
        print("Time: second " + (++TimeCount).ToString());
    }

    [Button()]
    // �Ƴ����� �����õ�Object
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
