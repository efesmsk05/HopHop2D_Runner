using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuAudioSource : MonoBehaviour
{
    // Start is called before the first frame update

    private AudioSource m_AudioSource;

    public AudioClip main;
    void Start()
    {
        m_AudioSource = GetComponent<AudioSource>();    

        m_AudioSource.clip = main;

        m_AudioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
