using UnityEngine;
using System.Collections;

public class ChangeRooms : MonoBehaviour
{
    public Vector3 NewPlayerPos;
    public Vector3 NewCameraPos;
    public Vector3 CameraPosRotation;

    [Header("Dissolving Transition")]
    public Renderer dissolvingObject;
    public float dissolveSpeed = 1;
    public float dissolveFinishDelay = 0.5f;

    private float materialTransparency;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnTriggerEnter(Collider other)
    {
        GameObject Camera = GameObject.Find("Main Camera");
        if (other.GetComponent<PlayerMovement>() != null)
        {
            other.GetComponent<PlayerMovement>().EndCorutines();
        }

        if (dissolvingObject != null)
        {
            StartCoroutine(WaitForDissolve(Camera, other));
        }
        else
        {
            ChangePositions(Camera, other);
        }
    }

    IEnumerator WaitForDissolve(GameObject camera, Collider other)
    {
        print("started dissolving");
        materialTransparency = 0;
        yield return DissolveTransition();
        yield return new WaitForSeconds(dissolveFinishDelay);
        ChangePositions(camera, other);
        dissolvingObject.material.SetFloat("_DissolveStrength", -1);
    }

    IEnumerator DissolveTransition()
    {
        while (materialTransparency < 1.1)
        {
            print("dissolving: " + materialTransparency);
            materialTransparency += 1 * dissolveSpeed * Time.deltaTime;
            dissolvingObject.material.SetFloat("_DissolveStrength", materialTransparency);
            yield return new WaitForSeconds(Time.deltaTime);
        }
    }

    void ChangePositions(GameObject camera, Collider other)
    {
        camera.transform.position = NewCameraPos;
        camera.transform.eulerAngles = CameraPosRotation;

        other.transform.position = NewPlayerPos;
        other.transform.eulerAngles = CameraPosRotation;

        if (other.GetComponent<NewPlayerMovement>() != null)
        {
            other.GetComponent<NewPlayerMovement>().agent.Warp(NewPlayerPos);
        }
    }

}
