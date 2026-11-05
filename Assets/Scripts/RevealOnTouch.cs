using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RevealOnTouch : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


            void OnCollisionEnter2D(Collision2D other)
        {
            if (GameObject.FindWithTag("Player").name == other.gameObject.name)
                {
                    Color color1 = new Color(255,255,255,1);

                    GetComponent<SpriteRenderer>().color = color1;

                }

        }


}
