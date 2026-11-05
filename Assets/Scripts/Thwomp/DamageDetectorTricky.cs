using System.Collections;
using System.Collections.Generic;
using PrimeTween;
using UnityEngine;

public class DamageDetectorTricky : MonoBehaviour
{
    [SerializeField]
    TrickyThwomp thwomp;

    bool killed = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }



        void OnTriggerEnter2D(Collider2D other)
        {
            if (GameObject.FindWithTag("Floor").name == other.name)
                {
                    thwomp.thwomped = true;
                    thwomp.detected = false;
                    //GetComponent<AudioSource>().Play();
                    AudioUtil.Play("vineBoom");

                    Tween.ShakeCamera(GameObject.FindWithTag("MainCamera").GetComponent<Camera>(),9,0.5f,30);

                    StartCoroutine(Timer.timer(1.5f,()=>{thwomp.backToPos = true;}));

                }

            if (GameObject.FindWithTag("Player").name == other.name && !thwomp.thwomped && !killed)
                {

                    GameObject.FindWithTag("Player").transform.localScale = new Vector2(3.6f,1.2f);
                    GameObject.FindWithTag("Player").GetComponent<PlayerMovement>().Unmoveable();
                    GameObject.FindWithTag("Player").GetComponent<PlayerMovement>().canChange = false;
                    GameObject.FindWithTag("Player").GetComponent<PlayerMovement>().ChangeAnimation("None",true);

                    GameObject.FindWithTag("GameOver").GetComponent<GameOver>().GameOverAdvanced(thwomp.deathMessage.Replace("--","\n"),"",4);

                    killed = true;
                }
        }
}
