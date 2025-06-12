using UnityEngine;

public class StudyGameObject : MonoBehaviour
{
    public GameObject prefab;
    
    void Awake()
    {
        CreateAmongus();
    }

    public void CreateAmongus()
    {
        GameObject obj = Instantiate(prefab);
        obj.name = "어몽어스 캐릭터";
    }
    
}