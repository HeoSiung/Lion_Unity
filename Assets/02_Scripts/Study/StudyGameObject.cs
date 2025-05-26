using UnityEngine;

public class StudyGameObject : MonoBehaviour
{
    public GameObject prefab;

    public GameObject destroyObj;

    public Vector3 pos;
    public Quaternion rot;


    void Start()
    {
        Debug.Log("생성되었습니다!");

        CreateAmongus();
        Destroier();
    }

    public void CreateAmongus()
    {
        GameObject obj = Instantiate(prefab, pos, rot);
        obj.name = "포치타";
    }

    public void Destroier()
    {
        Destroy(destroyObj, 3f);
        Debug.Log("파괴되었습니다...");
    }

}