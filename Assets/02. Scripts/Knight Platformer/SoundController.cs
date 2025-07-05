using UnityEngine;
using UnityEngine.UI;

public class SoundController : MonoBehaviour
{
    [SerializeField] private AudioSource bgmAudio;      // 인스펙터 창에 bgmAudio으로 표시
    [SerializeField] private AudioSource eventAudio;    // 인스펙터 창에 eventAudio으로 표시

    [SerializeField] private AudioClip[] clips;         // 인스펙터 창에 clips으로 표시

    [SerializeField] private Slider bgmVolume;          // 인스펙터 창에 bgmVolume으로 표시
    [SerializeField] private Toggle bgmMute;            // 인스펙터 창에 bgmMute으로 표시

    [SerializeField] private Slider eventVolume;        // 인스펙터 창에 eventVolume으로 표시
    [SerializeField] private Toggle eventMute;          // 인스펙터 창에 eventMute으로 표시

    private void Awake()                        // 스크립트가 활성화 될 때 실행
    {
        DontDestroyOnLoad(gameObject);          // 씬을 전환해도 이 게임 오브젝트는 사라지지 않음

        bgmVolume.value = bgmAudio.volume;      // 
        eventVolume.value = eventAudio.volume;  // 볼륨 슬라이더에 현재 볼륨 표시

        bgmMute.isOn = bgmAudio.mute;           // 
        eventMute.isOn = eventAudio.mute;       // 토글에 현재 음소거 상태 표시
    }

    private void Start()                                                // 게임이 시작될 때 실행
    {
        BgmSoundPlay("Red Leaf Town BGM");                              // BgmSoundPlay의 Red Leaf Town BGM 실행

        bgmVolume.onValueChanged.AddListener(OnBgmVolumeChanged);       // 
        eventVolume.onValueChanged.AddListener(OnEventVolumeChanged);   // 슬라이더 값이 바뀌면 함수 실행해서 볼륨도 변경

        bgmMute.onValueChanged.AddListener(OnBgmMute);                  // 
        eventMute.onValueChanged.AddListener(OnEventMute);              // 토글 상태가 바뀌면 함수 실행해서 음소거 On/Off
    }

    public void BgmSoundPlay(string clipName)   // clipName 문자열 값을 대입하고 실행
    {
        foreach (var clip in clips)             // 
        {
            if (clip.name == clipName)          // clipName의 이름을 가진 클립 찾기
            {
                bgmAudio.clip = clip;           // 있으면 bgmAudio.clip에 대입
                bgmAudio.Play();                // 실행
                return;                         // 종료
            }
        }

        Debug.Log($"{clipName}을 찾지 못했습니다.");
    }

    public void EventSoundPlay(string clipName) // clipName 문자열 값을 대입하고 실행
    {
        foreach (var clip in clips)             // 
        {
            if (clip.name == clipName)          // clipName의 이름을 가진 클립 찾기
            {
                eventAudio.PlayOneShot(clip);   // 있으면 bgmAudio.clip에 대입하고 한 번 실행
                return;                         // 종료
            }
        }

        Debug.Log($"{clipName}을 찾지 못했습니다.");
    }

    private void OnBgmVolumeChanged(float volume)   // 
    {
        bgmAudio.volume = volume;                   // 오디오 볼륨을 변경
    }

    private void OnEventVolumeChanged(float volume) // 
    {
        eventAudio.volume = volume;                 // 오디오 볼륨을 변경
    }

    private void OnBgmMute(bool isMute)             // 
    {
        bgmAudio.mute = isMute;                     // 토글 상태에 따라 음소거 On/Off
    }

    private void OnEventMute(bool isMute)           // 
    {
        eventAudio.mute = isMute;                   // 토글 상태에 따라 음소거 On/Off
    }
}