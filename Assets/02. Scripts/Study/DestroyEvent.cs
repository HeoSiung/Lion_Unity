using System;
using UnityEngine;

public class DestroyEvent : MonoBehaviour
{
    public float destroyTime = 3f;
    
    void Start()
    {
        Destroy(this.gameObject, destroyTime); // 자기 자신을 3초 뒤에 파괴하는 기능
    }

    void OnDestroy()
    {
        Debug.Log($"{this.gameObject.name}이 파괴되었습니다.");
    }
}