using System;
using UnityEngine;

public class PushPlatform : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D targetRb;
    [SerializeField] private float pushPower = 50f;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            targetRb = other.GetComponent<Rigidbody2D>();
            Invoke("PushCharacter", 0.1f);
        }

        if (other.CompareTag("Monster"))
        {
            targetRb = other.GetComponent<Rigidbody2D>();
            Invoke("PushCharacter", 0.1f);
        }
    }

    private void PushCharacter()
    {
        targetRb.AddForceY(pushPower, ForceMode2D.Impulse);
        animator.SetTrigger("Push");
    }
}