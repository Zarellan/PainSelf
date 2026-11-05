using System.Collections;
using System.Collections.Generic;
using PrimeTween;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameOver : MonoBehaviour
{
    [SerializeField]
    GameObject canva;

    [SerializeField]
    Button revive;

    public TMP_Text deathText;

    Scene scene;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IsGameOver(string textMessage,string playAudio)
    {
        GameObject.FindWithTag("GlobalAudio").GetComponent<GlobalAudio>().PlayAudio(playAudio);
        Tween.UIAnchoredPositionY(canva.GetComponent<RectTransform>(),-377.66f,0.5f,Ease.OutSine);
        deathText.text = textMessage;
    }

    public void GameOverAdvanced(string textMessage,string playAudio,float duration)
    {

        GameObject.FindWithTag("Player").GetComponent<PlayerMovement>().Unmoveable();
        GameObject.FindWithTag("Player").GetComponent<PlayerMovement>().canChange = false;
        GameObject.FindWithTag("SoundTrack").GetComponent<SoundTrackScript>().PauseMusic();


        StartCoroutine(Timer.timer(duration,()=>IsGameOver(textMessage,playAudio)));
    }


    public void Revive()
    {
        GameObject.FindWithTag("Player").GetComponent<PlayerMovement>().Moveable();
        GameObject.FindWithTag("Player").GetComponent<PlayerMovement>().canChange = true;
        GameObject.FindWithTag("Player").transform.localScale = new Vector2(3.6f,3.6f);
        GameObject.FindWithTag("SoundTrack").GetComponent<SoundTrackScript>().UnPauseMusic();

    }


    public void Restart()
    {
        ShoopDaWoop.wooped = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        GameObject.FindWithTag("SoundTrack").GetComponent<AudioSource>().pitch = 1;
    }
}
