using UnityEngine;

public class StudyComponent : MonoBehaviour
{
    public GameObject obj;
    public GameObject objTf;

    void Start()
    {
        obj = GameObject.FindGameObjectWithTag("Player");

        Debug.Log($"�̸� : {obj.name}");
        Debug.Log($"�±� : {obj.tag}");
        Debug.Log($"��ġ : {obj.transform.position}");
        Debug.Log($"ȸ�� : {obj.transform.rotation}");
        Debug.Log($"ũ�� : {obj.transform.localScale}");

        // obj�� MeshFilter ������Ʈ�� �����ؼ� mesh�� Log �޼����� ����ϴ� ���
        Debug.Log($"Mesh ������ : {obj.GetComponent<MeshFilter>().mesh}");

        // obj�� MeshRenderer ������Ʈ�� �����ؼ� material�� Log �޼����� ����ϴ� ���
        Debug.Log($"Material ������ : {obj.GetComponent<MeshRenderer>().material}");

        // obj�� MeshRenderer ������Ʈ�� �����ؼ� Ȱ�����¸� false�� �����ϴ�(����) ���
        obj.GetComponent<MeshRenderer>().enabled = false;

        // obj�� GameObject Ȱ�����¸� false�� �����ϴ�(����) ���
        obj.SetActive(false);
    }

}
