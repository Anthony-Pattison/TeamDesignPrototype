using UnityEngine;

public class InstantFail : MonoBehaviour
{
    [SerializeField] GameObject steven;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnTriggerEnter(Collider other)
    {
        steven.GetComponent<VictimScripts>().playCorutine();
    }
    private void Update()
    {
        if (steven.GetComponent<VictimScripts>().followPlayer)
        {
            Destroy(this.gameObject);
        }
    }
}
