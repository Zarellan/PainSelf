using System.Collections;
using System.Collections.Generic;
using PrimeTween;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Transition : MonoBehaviour
{

    [SerializeField]
    GameObject black1,black2;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
        //TransOut();
        //MainMenuTransition();
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void TransIn()
    {
        Tween.UIAnchoredPositionY(black1.GetComponent<RectTransform>(),270,0.5f,Ease.OutCirc);
        Tween.UIAnchoredPositionY(black2.GetComponent<RectTransform>(),-270,0.5f,Ease.OutCirc);
    }

    public void TransOut()
    {
        Tween.UIAnchoredPositionY(black1.GetComponent<RectTransform>(),810,0.5f,Ease.InSine);
        Tween.UIAnchoredPositionY(black2.GetComponent<RectTransform>(),-810,0.5f,Ease.InSine);
    }

    public void MainMenuTransition1()
    {
        black1.GetComponent<RectTransform>().anchoredPosition = new Vector2(0,270);
        black2.GetComponent<RectTransform>().anchoredPosition = new Vector2(0,-270);

        Tween.UIAnchoredPositionY(black1.GetComponent<RectTransform>(),400,0.5f,Ease.OutCirc);
        Tween.UIAnchoredPositionY(black2.GetComponent<RectTransform>(),-400,0.5f,Ease.OutCirc);

        StartCoroutine(Timer.timer(1.3f,()=>{
            TransOut();
        }));

    }

    public void SceneChange(string sceneName)
    {
        TransIn();
        Tween.AudioVolume(SoundtrackUtil.GetAudio(),0,1f);
        StartCoroutine(Timer.timer(1.3f,()=>{
            SceneManager.LoadScene(sceneName);
            TransOut();
        }));

        
    }

}
