using UnityEngine;

public class StudySomething : MonoBehaviour
{
    public int currentLevel = 10;

    public int maxLevel = 99;

    void Start()
    {
        int levelPoint = currentLevel >= maxLevel ? 0 : 1;

        currentLevel += levelPoint;
    }
}