using System.Collections;
using UnityEngine;
using UnityEngine.Video;

public class PlayerMovement : MonoBehaviour
{
    public LayerMask Clickable;
    GameObject PlayerAnimation;
    EventHandler Eventhandler;
    GameObject MainCamera;
    Vector3 playerstartpos;
    Vector3 CameraStartpos;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        MainCamera = GameObject.Find("Main Camera");
        Eventhandler = GameObject.Find("EventHandler").GetComponent<EventHandler>();
        Eventhandler.ResetGame.AddListener(ResetPlaystate);
        PlayerAnimation = GameObject.Find("PlayerAnimation");
        PlayerAnimation.GetComponent<VideoPlayer>().playbackSpeed = 0;
        playerstartpos = transform.position;
        CameraStartpos = MainCamera.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 MousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(MousePos, transform.TransformDirection(Vector3.forward), out hit, 50, Clickable) && Input.GetMouseButtonDown(0))
        {
            EndCorutines();
            StartCoroutine(movePlayer(transform.position, hit.point));
        }
    }
    public void EndCorutines()
    {
        PlayerAnimation.GetComponent<VideoPlayer>().playbackSpeed = 0;
        StopAllCoroutines();
    }
    IEnumerator movePlayer(Vector3 PlayerPos, Vector3 EndPos)
    {
        if (PlayerPos.x > EndPos.x)
        {
            PlayerAnimation.transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            PlayerAnimation.transform.localScale = new Vector3(1, 1, 1);
        }
        while (PlayerPos != EndPos)
        {
            PlayerAnimation.GetComponent<VideoPlayer>().playbackSpeed = 0.5f;
            transform.position = Vector3.Lerp(transform.position, EndPos, .005f);
            yield return null;
        }
        PlayerAnimation.GetComponent<VideoPlayer>().playbackSpeed = 0;
    }
    private void ResetPlaystate()
    {
        EndCorutines();
        transform.position = playerstartpos;
        MainCamera.transform.position = CameraStartpos;

        transform.eulerAngles = Vector3.zero;
        MainCamera.transform.eulerAngles = Vector3.zero;
    }
}
