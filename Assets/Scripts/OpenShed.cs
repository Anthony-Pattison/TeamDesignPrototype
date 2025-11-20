using UnityEngine;

public class OpenShed : MonoBehaviour
{
    [SerializeField] GameObject AudioHandler;
    [SerializeField] GameObject CrowBar;
    [SerializeField] GameObject Rope;
    [SerializeField] GameObject prompt;
    [SerializeField] GameObject  input;
    EventHandler Eventhandler;
    AudioManager Audiomanager;
    void Start()
    {
        Audiomanager = AudioHandler.GetComponent<AudioManager>();
        Eventhandler = GameObject.Find("EventHandler").GetComponent<EventHandler>();
        Eventhandler.ResetGame.AddListener(ResetPlaystate);
    }
    private void ResetPlaystate()
    {
        Rope.SetActive(false);
        CrowBar.SetActive(false);
        if (input != null) {
            input.SetActive(false);
        }
        this.gameObject.SetActive(true);
    }
    private void OnTriggerEnter(Collider other)
    {
        prompt.SetActive(true);
      
            if (this.gameObject.name == "Window Trigger" && input != null && CrowBar.activeInHierarchy)
            {
                Audiomanager.PlaySound(Audiomanager.SoundSet[1].Reference);
                input.SetActive(true);
                CrowBar.SetActive(false);
                return;
            }
            if (this.gameObject.name == "Shed (1)") {
                Rope.SetActive(true);
                CrowBar.SetActive(true);
                print("Obtain rope");
                prompt.SetActive(false);
                this.gameObject.SetActive(false);
            }
        
    }
    private void OnTriggerExit(Collider other)
    {
        prompt.SetActive(false);
    }
}
