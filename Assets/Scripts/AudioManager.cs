using NUnit.Framework;
using System.Collections.Generic;
using UnityEditor.Search;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.VFX;
public class AudioManager : MonoBehaviour
{
    [System.Serializable]
    public struct MyData
    {
        public string Name; // This will appear as the element's name in the Inspector
        public int Value;
        public AudioClip Reference;
    }
    
    public MyData[] SoundSet;
    AudioSource AS;
    void Start()
    {
        AS = GetComponent<AudioSource>();
    }

    public void PlaySound(AudioClip sound)
    {
        if (AS.isPlaying) {
            AS.PlayOneShot(sound);
        }
    }
}
