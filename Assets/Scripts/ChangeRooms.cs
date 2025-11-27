using UnityEngine;

public class ChangeRooms : MonoBehaviour
{
    public Vector3 NewPlayerPos;
    public Vector3 NewCameraPos;
    public Vector3 CameraPosRotation;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnTriggerEnter(Collider other)
    {
        GameObject Camera = GameObject.Find("Main Camera");
        if (other.GetComponent<PlayerMovement>() != null)
        {
            other.GetComponent<PlayerMovement>().EndCorutines();
        }
        Camera.transform.position = NewCameraPos;
        Camera.transform.eulerAngles = CameraPosRotation;

        other.transform.position = NewPlayerPos;
        other.transform.eulerAngles = CameraPosRotation;

        if (other.GetComponent<NewPlayerMovement>() != null)
        {
            other.GetComponent<NewPlayerMovement>().agent.Warp(NewPlayerPos);
        }
    }

}
