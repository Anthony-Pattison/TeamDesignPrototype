using System.Collections;
using UnityEngine;
using UnityEngine.Splines;

public class VictimScripts : MonoBehaviour
{
    EventHandler Eventhandler;
    [SerializeField] float SplineSpeed;
    [SerializeField] GameObject AudioHandler;
    [SerializeField] Material Idle;
    [SerializeField] Material Spotted;
    [SerializeField] Material Dead;
    [SerializeField] GameObject Rope;
    [SerializeField] GameObject Bat;
    GameObject VicimPlaneObject;
    GameObject Player;
    MeshRenderer VictimRenderer;
    public bool followPlayer = false;
    Vector3 Startpos;
    AudioManager Audiomanager;
    bool playing = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Audiomanager = AudioHandler.GetComponent<AudioManager>();
        Startpos = transform.position;
        Eventhandler = GameObject.Find("EventHandler").GetComponent<EventHandler>();
        Player = GameObject.Find("Player");
        VicimPlaneObject = transform.GetChild(0).gameObject;
        VictimRenderer = VicimPlaneObject.GetComponent<MeshRenderer>();
        VictimRenderer.material = Idle;
        Eventhandler.ResetGame.AddListener(ResetPlaystate);
    }

    // Update is called once per frame
    void Update()
    {
        SplineAnimate spline = GetComponent<SplineAnimate>();
        spline.MaxSpeed = SplineSpeed;
        if (followPlayer)
        {
            transform.position = Player.transform.position + new Vector3(0, 5, 0);
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
        }
    }
    private void ResetPlaystate()
    {
        GetComponent<VictimScripts>().enabled = true;
        GetComponent<BoxCollider>().enabled = true;
        followPlayer = false;
        VictimRenderer.material = Idle;
        transform.position = Startpos;
    }
    private void OnTriggerStay(Collider other)
    {
        if (VicimPlaneObject.name == "TimmyImage")
        {
            if (other.gameObject.name == "DeadTimmy")
            {
                Rope.SetActive(false);
                transform.position = other.transform.position;
                followPlayer = false;
                GetComponent<VictimScripts>().enabled = false;
                GetComponent<BoxCollider>().enabled = false;
                return;
            }
            if (!Rope.activeInHierarchy)
            {
                followPlayer = false;
                VictimRenderer.material = Spotted;
                StartCoroutine(Wait(2));
                return;
            }
            Audiomanager.PlaySound(Audiomanager.SoundSet[2].Reference);
            VictimRenderer.material = Dead;
            followPlayer = true;
        }

        if (VicimPlaneObject.name == "StevenImage")
        {
            if (other.gameObject.name == "DeadSteven")
            {
                Bat.SetActive(false);
                transform.position = other.transform.position;
                VictimRenderer.material = Dead;
                followPlayer = false;
                GetComponent<VictimScripts>().enabled = false;
                GetComponent<BoxCollider>().enabled = false;
                return;
            }
            if (!Bat.activeInHierarchy)
            {
                followPlayer = false;
                VictimRenderer.material = Spotted;
                StartCoroutine(Wait(2));
                return;
            }
            Audiomanager.PlaySound(Audiomanager.SoundSet[0].Reference);
            Audiomanager.PlaySound(Audiomanager.SoundSet[3].Reference);
            VictimRenderer.material = Dead;
            followPlayer = true;
        }
    }
    IEnumerator Wait(float time)
    {

        if (playing)
        {
            playing = false;
            VictimRenderer.material = Spotted;
            Audiomanager.PlaySound(Audiomanager.SoundSet[4].Reference);
            yield return new WaitForSeconds(time);
            Eventhandler.ResetGame.Invoke();
            playing = true;
        }
    }
    public void playCorutine()
    {
        StartCoroutine(Wait(2));
    }
}
