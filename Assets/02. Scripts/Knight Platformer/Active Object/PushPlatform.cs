using System;
using UnityEngine;

public class PushPlatform : MonoBehaviour
{
    private Animator animator;      // 발판 애니메이터
    private Rigidbody2D targetRb;   // 밀어낼 대상의 Rigidbody2D
    [SerializeField] private float pushPower = 50f; // 밀어내는 힘, 에디터에서 조정 가능

    void Start()
    {
        animator = GetComponent<Animator>();    // 이 오브젝트의 애니메이터를 가져옴
    }

    void OnTriggerEnter2D(Collider2D other)     // 다른 오브젝트가 트리거에 닿으면
    {
        if (other.CompareTag("Player"))         // 만약 그것의 태그가 Player면
        {
            targetRb = other.GetComponent<Rigidbody2D>();   //  targetRb에 해당 오브젝트의 Rigidbody2D를 대입
            Invoke("PushCharacter", 0.1f);      // 0.1초 후에 PushCharacter 함수 호출
        }

        if (other.CompareTag("Monster"))
        {
            targetRb = other.GetComponent<Rigidbody2D>();
            Invoke("PushCharacter", 0.1f);
        }
    }

    private void PushCharacter()
    {
        targetRb.AddForceY(pushPower, ForceMode2D.Impulse); // 닿은 오브젝트의 Rigidbody2D에 밀어내는 힘 만큼의 순간적인 힘을 y방향으로 가함 
        animator.SetTrigger("Push");    // 발판 애니메이터에 Push 트리거를 보냄
    }
}