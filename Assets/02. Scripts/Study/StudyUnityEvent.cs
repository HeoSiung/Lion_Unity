using System;
using UnityEngine;

public class StudyUnityEvent : MonoBehaviour
{
    void Awake()
    {
        Debug.Log("Awake");
    }
    
    void Start()
    {
        Debug.Log("Start");   
    }

    void OnEnable() // 켜질 때 마다 1번 실행
    {
        Debug.Log("OnEnable");
    }

    void OnDisable() // 꺼질 때 마다 1번 실행
    {
        Debug.Log("OnDisable");
    }

    void Update()
    {
        
    }
}
