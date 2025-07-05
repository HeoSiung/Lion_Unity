using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PortalController : MonoBehaviour
{
    public enum ScenType { TOWN, ADVENTURE }    // ScenType 열거형 배열, TOWN과 ADVENTURE가 들어있음
    public ScenType scenType;                   // 어느 ScenType으로 이동할지 선택하는 값

    public DarkerRoutine fade;      // DarkerRoutine 스크립트에 연결해서 페이드 실행

    public GameObject portalEffect; // portalEffect에 포탈 효과를 드롭다운해 담음
    public GameObject loadingImage; // loadingImage에 로딩 이미지를 드롭다운해 담음

    public Image progressBar;       // 로딩 바를 드롭다운해 지정

    void OnTriggerEnter2D(Collider2D other)     // 다른 오브젝트가 트리거에 닿을면
    {
        if (other.CompareTag("Player"))         // 해당 오브젝트의 태그가 "Player"일 때
        {
            StartCoroutine(PortalRoutine());    // PortalRoutine 코루틴을 실행함
        }
    }

    IEnumerator PortalRoutine()         // IEnumerator은 코루틴을 생성할때 사용하는 함수의 리턴 타입, WaitForSeconds등의 지연을 주기 위해 쓰임
    {
        portalEffect.SetActive(true);   // 드롭다운해 담은 포탈 효과를 활성
        yield return StartCoroutine(fade.Fade(3f, Color.white, true)); // 3초동안 페이드 온

        loadingImage.SetActive(true);   // 드롭다운해 담은 로딩 이미지를 활성
        yield return StartCoroutine(fade.Fade(3f, Color.white, false)); // 3초동안 페이드 오프

        while (progressBar.fillAmount < 1f) // 드롭다운해 담은 로딩바가 가득 찰때까지 반복
        {
            progressBar.fillAmount += Time.deltaTime * 0.3f;
            // 로딩바.채워진 정도 += 프레임 간 시간 * 0.3 -> 로딩바를 천천히 채움

            yield return null;  // 잠깐 기다림
        }

        if (scenType == ScenType.TOWN)  // 현재 scenType에 따라 씬 로드
            SceneManager.LoadScene(1);  // TOWN일 경우
        else
            SceneManager.LoadScene(0);  // ADVENTURE일 경우
    }
}