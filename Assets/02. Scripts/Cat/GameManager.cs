using TMPro;
using UnityEngine;

namespace Cat
{
    public class GameManager : MonoBehaviour
    {
        public SoundManager soundManager;

        public TextMeshProUGUI playTimeUI;
        public TextMeshProUGUI scoreUI;

        private float timer;
        public static int score;
        public static bool isPlay;

        void Start()
        {
            soundManager.SetBGMSound("Intro");
        }

        void Update()
        {
            if (!isPlay) 
                return;

            timer += Time.deltaTime;

            playTimeUI.text = $"플레이 시간 : {timer:F1}초";
            scoreUI.text = $"<color=red>X</color> {score}";
        }
    }
}
