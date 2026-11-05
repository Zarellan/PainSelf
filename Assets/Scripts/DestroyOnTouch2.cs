using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.Callbacks;
using UnityEditor.U2D;
#endif
using UnityEngine;
using UnityEngine.PlayerLoop;

public class DestroyOnTouch2 : MonoBehaviour
{
    float num = 0;

    bool timeStart = false;

    public bool thouchedThis = false;

    [SerializeField]
    Sprite catLol;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timeStart)
        num += Time.unscaledDeltaTime;

        if (num > 3 && Time.timeScale != 1)
        {
            GameObject.FindWithTag("MainCamera").GetComponent<Camera>().orthographicSize = 5;
            Time.timeScale = 1;
            GameObject.FindWithTag("GameOver").GetComponent<GameOver>().GameOverAdvanced("THINK FAST CHUCKLE NUT","mario death",2);
        }
        else if (num > 2.14f  && Time.timeScale != 1)
        {
            GameObject.FindWithTag("MainCamera").GetComponent<Camera>().orthographicSize = 2;
        }

        if (GameObject.FindWithTag("Player").transform.position.y < -4 && !timeStart && thouchedThis)
        {
            Time.timeScale = 0f;
            GameObject.FindWithTag("GlobalAudio").GetComponent<GlobalAudio>().PlayAudio("fed up");
            timeStart = true;
            GameObject.FindWithTag("MX").GetComponent<AudioSource>().Stop();
            GameObject.FindWithTag("SoundTrack").GetComponent<SoundTrackScript>().PauseMusic();

            GameObject.FindWithTag("Player").GetComponent<PlayerMovement>().Unmoveable();
            GameObject.FindWithTag("Player").GetComponent<PlayerMovement>().ChangeAnimation("JumpDown");
            GameObject.FindWithTag("Player").GetComponent<PlayerMovement>().canChange = false;

            //
        }

        if (thouchedThis)
        {
            GameObject.FindWithTag("Player").GetComponent<PlayerMovement>().ignoreFallDetecing = true;
            transform.position = new Vector2(transform.position.x,transform.position.y - 15 * Time.deltaTime);
        }

    }


        void OnCollisionEnter2D(Collision2D other)
        {
            if (GameObject.FindWithTag("Player").name == other.gameObject.name)
                {
                    thouchedThis = true;

                    GetComponent<SpriteRenderer>().sprite = catLol;
                }

        }


}
