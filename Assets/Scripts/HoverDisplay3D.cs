using TMPro;
using UnityEngine;

public class HoverDisplay3D : MonoBehaviour
{
    [Header("References")]
    public GameObject display;
    public GameObject backdropBox;
    public GameObject backdropObj;
    public TextMeshPro textObj;

    [Header("Text")]
    public string text = "";

    [Header("Offsets")]
    public float xOffset = 0;
    public float yOffset = 0;
    public float zOffset = 0;

    [Header("Colors")]
    public Color backdropColor = Color.black;
    public Color textColor = Color.white;

    GameObject parentObj;

    EventHandler eventHandler;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        eventHandler = GameObject.Find("EventHandler").GetComponent<EventHandler>();
        parentObj = transform.parent.gameObject;

        eventHandler.processDisplay.AddListener(ShowHideDisplay);

        SetupDisplay();
    }

    void SetupDisplay()
    {
        display.SetActive(false); //start unseen

        transform.localPosition = new Vector3(xOffset, yOffset, zOffset); //update position of display based on offset
        UpdateSize();

        //update colors of backdrop and text based on variables
        backdropObj.GetComponent<SpriteRenderer>().color = backdropColor;
        textObj.color = textColor;

        print("collider game-object: " + parentObj.name);

        //if there is set text, change text to that
        if (text != "")
        {
            textObj.text = text;
        }
        else
        {
            //changes text name to be the same as interactable obj
            textObj.text = parentObj.name;
        }

        UpdateBoxSize();
    }

    //updates the size of the display based on the parent's size
    void UpdateSize()
    {
        Vector2 parentScale = parentObj.transform.localScale;

        float newScaleX = 1 / parentScale.x;
        float newScaleY = 1 / parentScale.y;

        transform.localScale = new Vector3(newScaleX, newScaleY);
    }

    //updates the box size based on text
    void UpdateBoxSize()
    {
        Vector3 backdropSize = backdropBox.transform.localScale;
        backdropSize.x = 0.03f + textObj.text.Length * 0.07f;

        backdropBox.transform.localScale = backdropSize;
    }

    void ShowHideDisplay(GameObject obj, bool showDisplay)
    {
        if (obj.name != parentObj.name)
            return;

        display.SetActive(showDisplay);
    }
}
