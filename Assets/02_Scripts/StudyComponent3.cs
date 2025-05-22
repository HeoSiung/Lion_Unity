using System;
using System.Net;
using UnityEngine;

public class StudyComponent3 : MonoBehaviour
{
    public GameObject prefab;

    void Start()
    {
        CreateAmongus();
    }

    public void CreateAmongus()
    {
        GameObject obj = Instantiate(prefab);
        obj.name = "��ġŸ";

        Transform objTf = obj.transform;
        int count = objTf.childCount;

        Debug.Log($"ĳ������ �ڽ� ������Ʈ�� ���� {count}�� �Դϴ�.");

        Debug.Log($"ĳ������ ù ��° �ڽ� ������Ʈ�� {objTf.GetChild(0).name}�Դϴ�.");

        Debug.Log($"ĳ������ ������ �ڽ� ������Ʈ�� {objTf.GetChild(count - 1).name}�Դϴ�.");
    }
}
