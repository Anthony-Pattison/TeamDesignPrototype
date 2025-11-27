using UnityEngine;

public class TextMeshLayerOrderer : MonoBehaviour
{
    public int orderInLayer;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GetComponent<Renderer>().sortingOrder = orderInLayer;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
