using System;
using UnityEngine;

public class Pinball : MonoBehaviour
{
    public PinballManager pinballManager; // 유니티 상에서 할당 필요

    void OnCollisionEnter2D(Collision2D other)
    {
        int score = 0;
        switch (other.gameObject.tag)
        {
            case "Score10":
                score = 10;
                break;
            case "Score30":
                score = 30;
                break;
            case "Score50":
                score = 50;
                break;
        }

        if (score != 0)
        {
            pinballManager.totalScore += score;

            Debug.Log($"{score}점 획득");
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("GameOver"))
        {
            Debug.Log($"게임 종료 : 현재 점수 {pinballManager.totalScore}");
        }
    }
}