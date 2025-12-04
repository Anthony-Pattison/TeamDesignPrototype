using UnityEngine;

public class DetectHoverObject : MonoBehaviour
{
    EventHandler eventHandler;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        eventHandler = GameObject.Find("EventHandler").GetComponent<EventHandler>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseEnter()
    {
        eventHandler.processDisplay.Invoke(gameObject, true);
    }

    private void OnMouseExit()
    {
        eventHandler.processDisplay.Invoke(gameObject, false);
    }
}
