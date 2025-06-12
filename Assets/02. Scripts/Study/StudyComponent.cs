using UnityEngine;

public class StudyComponent : MonoBehaviour
{
    public GameObject obj;

    public Mesh msh;
    public Material mat;
    
    void Start()
    {
        obj = GameObject.CreatePrimitive(PrimitiveType.Cube);
        
        CreateCube();
        CreateCube("Hello World");
    }

    public void CreateCube(string name = "Cube")
    {
        obj = new GameObject(name);
        
        obj.AddComponent<MeshFilter>();
        obj.GetComponent<MeshFilter>().mesh = msh;
        
        obj.AddComponent<MeshRenderer>();
        obj.GetComponent<MeshRenderer>().material = mat;
        
        obj.AddComponent<BoxCollider>();
    }
    
}