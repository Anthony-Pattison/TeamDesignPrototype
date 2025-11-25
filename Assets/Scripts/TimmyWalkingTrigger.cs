using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Splines;
using UnityEngine.UIElements;

public class TimmyWalkingTrigger : MonoBehaviour
{
    // timmy
    [SerializeField] GameObject Timmy;
    [SerializeField] Axis newAxis;
    Axis StartingAxis;
    
    SplineAnimate SpAnimate;
    GameObject TimmyImage;
    // for timer
    [SerializeField] float HowLongTillTimmyLeaves;
    float timer;
    VictimScripts vm;
    bool dead = false;
    private void Start()
    {
        TimmyImage = Timmy.transform.GetChild(0).gameObject;
        vm = GetComponent<VictimScripts>();
        SpAnimate = Timmy.GetComponent<SplineAnimate>();
        SpAnimate.enabled = false;
    }
    void Update()
    {
        if (!dead)
        {
            followSpline();
        }
    }
    void followSpline()
    {
        if (HowLongTillTimmyLeaves < timer)
        {
            SpAnimate.enabled = true;
        }
        else
        {
            timer += Time.deltaTime;
        }
        if(SpAnimate.Duration >= 13.86f)
        {
            TimmyImage.transform.eulerAngles = new Vector3(90, 90, -90);
        }
        else
        {
            TimmyImage.transform.eulerAngles = new Vector3(90, 90, 0);
        }
        if (vm.followPlayer)
        {
            SpAnimate.enabled = false;
            dead = true;
        }
        if (SpAnimate.Duration <= 0.9f)
        {
            SpAnimate.enabled = false;
            timer = 0;
        }
        
    }
}
