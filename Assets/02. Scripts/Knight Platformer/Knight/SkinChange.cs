using UnityEngine;

public class SkinChange : MonoBehaviour
{
    public SpriteRenderer[] skin;
    private bool isChoice = true;
    private float characterPos; // ¿€º∫¡ﬂ

    void Start()
    {
        skin = GetComponentsInChildren<SpriteRenderer>(true);

        skin[0].gameObject.SetActive(true);
        skin[1].gameObject.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            isChoice = !isChoice;

            if (isChoice == true)
            {
                skin[0].gameObject.SetActive(true);
                skin[1].gameObject.SetActive(false);
            }
            else if (isChoice == false)
            {
                skin[0].gameObject.SetActive(false);
                skin[1].gameObject.SetActive(true);
            }

        }
    }
}
