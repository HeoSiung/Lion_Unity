using UnityEngine;

public class StudyMaterial : MonoBehaviour
{
    public Material mat;
    public string hexCode;
    
    void Start()
    {
        this.GetComponent<MeshRenderer>().material = mat; // MeshRenderer에 접근해서 바꾸는 방식
        
        this.GetComponent<MeshRenderer>().sharedMaterial = mat; // MeshRenderer에 접근해서 바꾸는 방식

        this.GetComponent<MeshRenderer>().material.color = Color.green; 
        
        this.GetComponent<MeshRenderer>().sharedMaterial.color = Color.green;
        
        
        this.GetComponent<MeshRenderer>().material.color = new Color(130f/255f, 20f/255f, 70f/255f, 1);

        mat = this.GetComponent<MeshRenderer>().material;
        Color outputColor;

        if (ColorUtility.TryParseHtmlString(hexCode, out outputColor))
        {
            mat.color = outputColor;
        }
    }
}