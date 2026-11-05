using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundTrackScript : MonoBehaviour
{
    public static SoundTrackScript instance;
    new AudioSource audio;

    [SerializeField]
    AudioClip[] clips;

    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();


        if (instance != null)
        {
            Destroy(this.gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void PlayMusic(string name)
    {
        audio.volume = 1;
        for (int i = 0;i < clips.Length;i++)
            {
                if (clips[i].name == name)
                {
                    audio.clip = clips[i];
                    audio.Play();
                }
            }
    }

    public void SetVolume(float volume)
    {
        audio.volume = volume;
    }

    public void StopMusic()
    {
        audio.Stop();
    }

    public void PauseMusic()
    {
        audio.Pause();
    }

    public void UnPauseMusic()
    {
        audio.UnPause();
    }

    public AudioSource GetAudio()
    {
        return GetComponent<AudioSource>();
    }

}
