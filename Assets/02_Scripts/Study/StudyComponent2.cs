using UnityEngine;

public class StudyComponent2 : MonoBehaviour
{
    public GameObject obj;

    public Mesh msh;
    public Material mat;

    void Start()
    {
        obj = GameObject.CreatePrimitive(PrimitiveType.Cube);

        CreateCube();
        CreateCube("정육면체");
    }

    public void CreateCube(string name = "큐브")
    {
        obj = new GameObject(name);

        obj.AddComponent<MeshFilter>();
        obj.GetComponent<MeshFilter>().mesh = msh;

        obj.AddComponent<MeshRenderer>();
        obj.GetComponent<MeshRenderer>().material = mat;

        obj.AddComponent<BoxCollider>();
    }

}
