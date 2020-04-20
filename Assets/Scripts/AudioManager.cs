using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    #region Singleton
    
    public static AudioManager instance;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            
        }
        else
        {
            Destroy(gameObject);
        }
    }
    

    #endregion

    public AudioSource oneShotSource;
    public AudioSource musicSource;


    public void PlayOneShot(AudioClip clip)
    {
        oneShotSource.PlayOneShot(clip);
    }
    

}
