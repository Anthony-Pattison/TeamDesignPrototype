using UnityEngine;

public class ReadNewspaper : MonoBehaviour
{
    EventHandler eventhandler;
    public GameObject newspaper;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        eventhandler = GameObject.Find("EventHandler").GetComponent<EventHandler>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        newspaper.SetActive(true);
        print("read newspaper");
    }

    private void OnTriggerExit(Collider other)
    {
        newspaper.SetActive(false);
        print("stopped reading newspaper");
    }
}
