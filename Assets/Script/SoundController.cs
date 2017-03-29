using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{

    public AudioClip InteractiveSound;
    
    public AudioClip MessageSound;

    public void Start()
    {
        
    }

    public void PlayInteractiveSound()
    {
        AudioSource.PlayClipAtPoint(InteractiveSound,new Vector3(0,0,0));
    }
    public void NewMessageSound()
    {
        GetComponent<AudioSource>().Play();

    }
    

}
