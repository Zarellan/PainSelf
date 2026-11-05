using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lazer1 : MonoBehaviour
{
    
    bool whoopeded = false;
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
        if (GameObject.FindWithTag("Player").name == other.name && !whoopeded)
            {
                    GameObject.FindWithTag("Player").GetComponent<PlayerMovement>().Unmoveable();
                    GameObject.FindWithTag("Player").GetComponent<PlayerMovement>().canChange = false;
                    GameObject.FindWithTag("Player").GetComponent<PlayerMovement>().ChangeAnimation("Dust",true);
                    GameOverUtil.Over("You got shoop da whooped","",2);
                    whoopeded = true;

            }
    }

}
