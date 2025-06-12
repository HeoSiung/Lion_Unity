using UnityEngine;

public class Calculator : MonoBehaviour
{
    public int number1, number2; // 멤버 변수 (필드)
    
    void Start()
    {
        int addResult = AddMethod(); // 함수 호출

        int minusResult = MinusMethod(); // 함수 호출

        Debug.Log($"더한 값 : {addResult} / 뺀 값 : {minusResult}");
    }

    int AddMethod()
    {
        // 지역 변수 result
        int result = number1 + number2;
        
        return result;
    }

    int MinusMethod()
    {
        // 지역 변수 result
        int result = number1 - number2;

        return result;
    }
}