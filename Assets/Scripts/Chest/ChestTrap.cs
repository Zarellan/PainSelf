using System.Collections;
using System.Collections.Generic;
using PrimeTween;
using UnityEngine;

public class ChestTrap : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Open()
    {
        
        AudioUtil.Play("Ochest");
        GameObject.FindWithTag("McChest").GetComponent<Canvas>().enabled = true;

        Tween.AudioVolume(GameObject.FindWithTag("SoundTrack").GetComponent<AudioSource>(),0,3);
        Tween.AudioPitch(GameObject.FindWithTag("SoundTrack").GetComponent<AudioSource>(),0.5f,3);
        StartCoroutine(Timer.timer(3,Dying));
    }

    void Dying()
    {
        GameObject.FindWithTag("Player").GetComponent<PlayerMovement>().canChange = false;
        GameObject.FindWithTag("Player").GetComponent<PlayerMovement>().ChangeAnimation("Fish",true);

        AudioUtil.Play("Cchest");
        GameObject.FindWithTag("McChest").GetComponent<Canvas>().enabled = false;
        AudioUtil.Play("FishDeath");

        GameOverUtil.Over("get it ?\nbecause she like's pain while totem of undying removes the pain...\nI need help","",1.5f);
    }

    public void Closed()
    {

    }
}
