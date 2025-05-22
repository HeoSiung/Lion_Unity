using UnityEngine;

public class StudyComponent : MonoBehaviour
{
    public GameObject obj;
    public GameObject objTf;

    void Start()
    {
        obj = GameObject.FindGameObjectWithTag("Player");

        Debug.Log($"이름 : {obj.name}");
        Debug.Log($"태그 : {obj.tag}");
        Debug.Log($"위치 : {obj.transform.position}");
        Debug.Log($"회전 : {obj.transform.rotation}");
        Debug.Log($"크기 : {obj.transform.localScale}");

        // obj의 MeshFilter 컴포넌트에 접근해서 mesh를 Log 메세지로 출력하는 기능
        Debug.Log($"Mesh 데이터 : {obj.GetComponent<MeshFilter>().mesh}");

        // obj의 MeshRenderer 컴포넌트에 접근해서 material을 Log 메세지로 출력하는 기능
        Debug.Log($"Material 데이터 : {obj.GetComponent<MeshRenderer>().material}");

        // obj의 MeshRenderer 컴포넌트에 접근해서 활성상태를 false로 변경하는(끄는) 기능
        obj.GetComponent<MeshRenderer>().enabled = false;

        // obj의 GameObject 활성상태를 false로 변경하는(끄는) 기능
        obj.SetActive(false);
    }

}
