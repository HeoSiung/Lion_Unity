using UnityEngine;

public class StudyGameObject : MonoBehaviour
{
    public GameObject prefab;

    public GameObject destroyObj;

    public Vector3 pos;
    public Quaternion rot;


    void Start()
    {
        Debug.Log("�����Ǿ����ϴ�!");

        CreateAmongus();
        Destroier();
    }

    public void CreateAmongus()
    {
        GameObject obj = Instantiate(prefab, pos, rot);
        obj.name = "��ġŸ";
    }

    public void Destroier()
    {
        Destroy(destroyObj, 3f);
        Debug.Log("�ı��Ǿ����ϴ�...");
    }

}