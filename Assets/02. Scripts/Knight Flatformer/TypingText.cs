using System.Collections;
using TMPro;
using UnityEngine;

public class TypingText : MonoBehaviour // 글자가 하나씩 쓰여지게 하는 스크립트
{
    [SerializeField] private TextMeshProUGUI textUI; // textUI라는 변수에 [SerializeField]를 써서 유니티상 텍스트맵을 끌어다가 넣음
    private string currText; // currText에 기존 문장을 저장함
    [SerializeField] private float typingSpeed = 0.1f; // 글자가 쓰여지는 속도, 유니티 상에서 [SerializeField]를 써서 속도 조절 가능

    private void Awake() // 스크립트가 실행될떄 실행됨
    {
        currText = textUI.text; // currText에 textUI로 지정된 텍스트를 저장함
    }

    private void OnEnable() // 오브젝트가 켜질때 실행됨
    {
        textUI.text = string.Empty; // currText에 텍스트 저장해뒀으니 처음에 화면에 표시되는 텍스트를 삭제함

        StartCoroutine(TypingRoutine()); // TypingRoutine() 코루틴 실행
    }

    IEnumerator TypingRoutine() // 코루틴이라 시간 간격을 두고 계속 실행
    {
        int textCount = currText.Length; // currText에 저장된 텍스트의 길이만큼 textCount라는 변수에 int(정수)값 지정
        for (int i = 0; i < textCount; i++) // 위에서 나온 텍스트 길이만큼 밑의 기능 수행
        {
            textUI.text += currText[i]; // textUI에 currText의 i번째 텍스트를 더함
            yield return new WaitForSeconds(typingSpeed); // typingSpeed만큼 각 글자 사이에 시간을 둠
        }
    }
}
