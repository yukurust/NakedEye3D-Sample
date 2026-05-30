using UnityEngine;

public class OutlineController : MonoBehaviour
{
    private bool isOutlineActive = false;
    private Material material;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        material = GetComponent<Renderer>().materials[1];
        //material.SetFloat("_OutlineWidth", 0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        Debug.Log("Clicked");
        isOutlineActive = !isOutlineActive;
        if (isOutlineActive)
        {
            material.SetFloat("_Outline_Size",1.05f);
        }
        else
        {
            material.SetFloat("_Outline_Size", 0f);
        }
    }
}
