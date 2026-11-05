using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignTrap : MonoBehaviour
{

    bool startCountDown = false;
    float countDown = 0;

    [SerializeField]
    GameObject explosion;

    bool inside = false;

    bool gone = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (startCountDown)
            countDown += Time.deltaTime;

        if (countDown >= 5 && !gone)
        {
            explosion.GetComponent<Animator>().Play("DoIt");
            GameObject.FindWithTag("GlobalAudio").GetComponent<GlobalAudio>().PlayAudio("deltarune explosion");
            gameObject.GetComponent<SpriteRenderer>().color = new Color(0,0,0,0);
            gone = true;
            countDown = 0;
            GameObject.FindWithTag("GlobalMessage").GetComponent<GlobalMessage>().MessageDisappear();

            if (inside)
            {
                GameObject.FindWithTag("GameOver").GetComponent<GameOver>().GameOverAdvanced("if you read the sign fast\nyou could've survived it","",2);
                GameObject.FindWithTag("Player").GetComponent<SpriteRenderer>().color = new Color(0,0,0,0);
            }
        }
    }


    void OnTriggerEnter2D(Collider2D other)
        {
            
                if (GameObject.FindWithTag("Player").name == other.name && !startCountDown)
                {
                    startCountDown = true;

                    GameObject.FindWithTag("GlobalMessage").GetComponent<GlobalMessage>().MessageAppear("Congratulations you are SUCH a true gamer\nwhile you are reading this message\nthe sign will explode in 5 seconds");
                    inside = true;
                }

        }

    void OnTriggerExit2D(Collider2D other)
        {
            
                if (GameObject.FindWithTag("Player").name == other.name)
                {
                    GameObject.FindWithTag("GlobalMessage").GetComponent<GlobalMessage>().MessageDisappear();
                    inside = false;
                }

        }
}
