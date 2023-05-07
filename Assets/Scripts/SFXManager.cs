using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    public AudioSource soundSource;


    
    public void playSoundEffect()
    {
        soundSource.Play();
    }

}
