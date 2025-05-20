using UnityEngine;

public class Study_Class
{
    public int number;

    public Study_Class(int number)
    {
        this.number = number;
    }
}

public struct Study_Struct
{
    public int number;

    public Study_Struct(int number)
    {
        this.number = number;
    }
}

public class Study_ClassStruct : MonoBehaviour
{
    void Start()
    {
        Debug.Log("클래스 ---------------------------");
        Study_Class c1 = new Study_Class(10);
        Study_Class c2 = c1;
        Debug.Log($"c1 : {c1} / c2 : {c2}");

        c1.number = 100;
        Debug.Log($"c1 : {c1.number} / c2 : {c2.number}");


        Debug.Log("구조체 ---------------------------");
        Study_Struct s1 = new Study_Struct(10);
        Study_Struct s2 = s1;
        Debug.Log($"s1 : {s1} / s2 : {s2}");

        s1.number = 100;
        Debug.Log($"s1 : {s1.number} / s2 : {s2.number}");
    }
}