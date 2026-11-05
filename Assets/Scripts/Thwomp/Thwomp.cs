using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Thwomp : MonoBehaviour
{

    GameObject damageDetector;

    [SerializeField]
    GameObject playerDetector;


    float originalPosY;


    public bool detected = false;

    public bool thwomped = false;

    public bool backToPos = false;

    public bool rightPosition = false;

    
    public enum Directions{
        left,
        right,
        up,
        down
    }

    [SerializeField]
    Directions direction;


    public string deathMessage;



    [SerializeField]
    float thwompSpeed;

    // Start is called before the first frame update
    void Start()
    {
        originalPosY = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (detected)
        {
            switch (direction)
            {
                case Directions.down: GoDown();break;
                case Directions.up: GoUp();break;


            }
        }
        else if (backToPos)
        {

            switch (direction)
            {
                case Directions.down: GoDownReverse();break;
                case Directions.up: GoUp();break;


            }
        }




    }

        void OnTriggerEnter2D(Collider2D other)
        {
            if (GameObject.FindWithTag("Player").name == other.name)
                {
                    //detected = false;
                }
        }

    void GoDown()
    {
        if (transform.position.y > PlayerExistCond("y"))
            transform.position = new Vector2(transform.position.x,transform.position.y - thwompSpeed * Time.deltaTime);
            


    }

    void GoDownReverse()
    {
        transform.position = new Vector2(transform.position.x,transform.position.y + 5 * Time.deltaTime);

        if (originalPosY < transform.position.y)
        {
            backToPos = false;
            thwomped = false;
        }

    }

    void GoUp()
    {
        if (transform.position.y < PlayerExistCond("y"))
            transform.position = new Vector2(transform.position.x,transform.position.y + thwompSpeed * Time.deltaTime);

    }

    float PlayerExistCond(string pos)
    {
        if (GameObject.FindWithTag("Player") != null)
        {
        if (pos == "x")
            return GameObject.FindWithTag("Player").transform.position.x;
        else
            return GameObject.FindWithTag("Player").transform.position.y;
        }
        else
        return 0;
    }

}
