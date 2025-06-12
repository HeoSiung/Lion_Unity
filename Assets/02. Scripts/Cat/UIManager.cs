using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Cat
{
    public class UIManager : MonoBehaviour
    {
        public SoundManager soundManager;

        public GameObject playObj;
        public GameObject introUI;
        public GameObject playUI;

        public TMP_InputField inputField;
        public TextMeshProUGUI nameTextUI;

        public Button startButton;

        private void Awake()
        {
            playObj.SetActive(false);
            introUI.SetActive(true);
            playUI.SetActive(false);
        }

        void Start()
        {
            startButton.onClick.AddListener(OnStartButton);
        }

        public void OnStartButton()
        {
            bool isNoText = inputField.text == "";

            if (isNoText)            
                Debug.Log("입력한 텍스트 없음");            
            else
            {
                nameTextUI.text = inputField.text;
                soundManager.SetBGMSound("Play");

                GameManager.isPlay = true;

                playObj.SetActive(true);
                playUI.SetActive(true);
                introUI.SetActive(false);

            }
        }
    }
}