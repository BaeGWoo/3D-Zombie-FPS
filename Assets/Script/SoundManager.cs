using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SoundManager : MonoBehaviour
{
    private AudioSource audioSource;
    [SerializeField] AudioClip[] audioClip;

    public static SoundManager instance;


    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if(instance==null)
        {
            instance = this;
        }
    }


    public void Sound(int element)
    {
        audioSource.PlayOneShot(audioClip[element]);
    }
  
}
