using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource auidioSource;
    [Header ("Sounds") ]
    public AudioClip MainMenu;
    public AudioClip GameMusic;

    [Header("Fx")]

    public AudioSource FxAudioSource;

    public AudioClip jump;
    public AudioClip dead;
    public AudioClip hit;
    public AudioClip eat;

    
    private bool mute = false;


    void Start()
    {



        auidioSource.clip = GameMusic;

        auidioSource.Play();

        

    }

    private void fxPlay(AudioClip clip)
    {
        FxAudioSource.clip = clip;
        FxAudioSource.PlayOneShot(clip);


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            fxPlay(jump);
        }


    }

    private void FixedUpdate()
    {
        if (PlayerManager.instance.gameOver == true)
        {
            fxPlay(dead);


        }

        if(PlayerManager.instance.isTriggered == true)
        {
            fxPlay(hit);
            PlayerManager.instance.isTriggered = false; 
        }

        if(PlayerManager.instance.coinSound == true)
        {
            fxPlay(eat);

            PlayerManager.instance.coinSound = false;  
        }
    }

    public void OnButtonPress()
    {
        if(mute == false)
        {
            mute = true;
            auidioSource.Pause();
        }
        else
        {
            mute = false;
            auidioSource.Play();
        }
        
    }

}
