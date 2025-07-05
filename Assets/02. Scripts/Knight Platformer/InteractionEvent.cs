using System;
using System.Collections;
using UnityEngine;

public class InteractionEvent : MonoBehaviour
{
    public enum InteractionType { SIGN, DOOR, NPC } // 열거형 변수 InteractionType에 SIGN, DOOR, NPC 대입
    public InteractionType type;                    // 인스펙터 창에 type으로 표시

    public SoundController soundController; // 인스펙터 창에 soundController로 표시

    public GameObject popUp;                // 인스펙터 창에 popUp으로 표시

    public DarkerRoutine fade;              // 인스펙터 창에 fade로 표시

    public GameObject map;                  // 인스펙터 창에 map으로 표시
    public GameObject house;                // 인스펙터 창에 house로 표시

    public Vector3 inDoorPos;               // 안으로 들어갔을 때 위치 변슈
    public Vector3 outDoorPos;              // 밖으로 나왔을 때 위치 변수
    public bool isHouse;                    // 지금 집 안에 있는지 여부

    void OnTriggerEnter2D(Collider2D other) // 다른 오브젝트의 트리거에 닿았을 때
    {
        if (other.CompareTag("Player"))     // 만약 그 오브젝트의 대그가 Player라면
        {
            Interaction(other.transform);   // 그 오브젝트의 위치값을 대입해서 Interaction 함수 호출
        }
    }

    private void OnTriggerExit2D(Collider2D other)  // 다른 오브젝트의 트리거에서 떨어졌을 때
    {
        if (other.CompareTag("Player"))             // 만약 그 오브젝트의 대그가 Player라면
        {
            popUp.SetActive(false);                 // popUp에 드롭다운한 오브젝트를 비활성화 함
        }
    }

    void Interaction(Transform player)  // 입력받은 오브젝트 위치값을 대입한 채로 시작
    {
        switch (type)                   // InteractionType의 type 감지
        {
            case InteractionType.SIGN:                  // type이 SIGN이라면
                popUp.SetActive(true);                  // popUp에 드롭다운한 오브젝트를 활성화 함
                break;                                  // 스위치문 종료

            case InteractionType.DOOR:                  // type이 DOOR라면
                StartCoroutine(DoorRoutine(player));    // DoorRoutine 코루틴 호출
                break;                                  // 스위치문 종료

            case InteractionType.NPC:                   // type이 NPC라면
                popUp.SetActive(true);                  // popUp에 드롭다운한 오브젝트를 활성화 함
                break;                                  // 스위치문 종료
        }
    }

    IEnumerator DoorRoutine(Transform player)           // 입력받은 오브젝트 위치값을 대입한 채로 시작
    {
        soundController.EventSoundPlay("Door Open");    // soundController 스크립트의 EventSoundPlay 함수의 Door Open 실행

        yield return StartCoroutine(fade.Fade(2f, Color.black, true));  // Fade 코루틴을 2초동안 검은색으로 점점 활성화

        map.SetActive(isHouse);                     // isHouse bool값이 참이라면 map을 활성화
        house.SetActive(!isHouse);                  // isHouse bool값이 거짓이라면 house를 활성화

        var pos = isHouse ? outDoorPos : inDoorPos; // isHouse bool값이 참이라면 outDoorPos 위치로, 거짓이라면 inDoorPos 위치를 pos에 대입
        player.transform.position = pos;            // 플레이어의 위치를 pos로 변경

        isHouse = !isHouse;                         // isHouse bool값을 역전

        yield return new WaitForSeconds(1f);                            // 1초 동안 기다림
        soundController.EventSoundPlay("Door Close");                   // soundController 스크립트의 EventSoundPlay 함수의 Door Close 실행

        yield return StartCoroutine(fade.Fade(2f, Color.black, false)); // Fade 코루틴을 2초동안 검은색으로 점점 활성화
    }
}