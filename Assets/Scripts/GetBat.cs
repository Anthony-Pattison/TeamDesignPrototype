using UnityEngine;

public class GetBat : MonoBehaviour
{
    EventHandler Eventhandler;
    [SerializeField] GameObject bat;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        Eventhandler = GameObject.Find("EventHandler").GetComponent<EventHandler>();
        Eventhandler.ResetGame.AddListener(ResetPlaystate);
    }
    private void OnTriggerEnter(Collider other)
    {
        bat.SetActive(true);
        this.gameObject.SetActive(false);
    }
    void ResetPlaystate()
    {
        bat.SetActive(false);
        this.gameObject.SetActive(true);
    }

}
