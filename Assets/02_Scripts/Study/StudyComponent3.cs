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
        obj.name = "포치타";

        Transform objTf = obj.transform;
        int count = objTf.childCount;

        Debug.Log($"캐릭터의 자식 오브젝트의 수는 {count}개 입니다.");

        Debug.Log($"캐릭터의 첫 번째 자식 오브젝트는 {objTf.GetChild(0).name}입니다.");

        Debug.Log($"캐릭터의 마지막 자식 오브젝트는 {objTf.GetChild(count - 1).name}입니다.");
    }
}
