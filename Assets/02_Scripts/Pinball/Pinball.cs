using System;
using UnityEngine;

public class Pinball : MonoBehaviour
{
    public PinballManager pinballManager; // ����Ƽ �󿡼� �Ҵ� �ʿ�

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Untagged") == false)
        {
            int score = 0;
            switch (other.gameObject.tag)
            {
                case "Score1":
                    score = 1;
                    break;
                case "Score10":
                    score = 10;
                    break;
                case "Score50":
                    score = 50;
                    break;
            }

            pinballManager.totalScore += score;
            Debug.Log($"{score}�� ȹ��");
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("GameOver"))
        {
            Debug.Log($"���� ���� : ���� ���� {pinballManager.totalScore}");
        }
    }
}