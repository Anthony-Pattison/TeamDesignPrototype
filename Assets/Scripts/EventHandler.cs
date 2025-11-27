using UnityEngine;
using UnityEngine.Events;

public class EventHandler : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public UnityEvent ResetGame;
    public UnityEvent<GameObject, bool> processDisplay;

}
