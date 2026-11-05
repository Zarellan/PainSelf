using System.Collections;
using System.Collections.Generic;
using PrimeTween;
using UnityEngine;
using UnityEngine.UIElements;


public class TrickyThwomp : MonoBehaviour
{

    GameObject damageDetector;

    [SerializeField]
    GameObject playerDetector;


    float originalPosY;


    public bool detected = false;

    public bool thwomped = false;

    public bool backToPos = false;

    public bool rightPosition = false;

    public float whenStop;

    bool reachedTrick = false;

    bool createdTrick = false;

    bool pumpumpum = false;

    [SerializeField]
    float floorTouched;

    int timesCrushed = 0;

    
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
        

        if (pumpumpum)
            Pumpum();



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
        if (transform.position.y > PlayerExistCond("y") && whenStop < transform.position.y)
            transform.position = new Vector2(transform.position.x,transform.position.y - thwompSpeed * Time.deltaTime);
        else
        {
            reachedTrick = true;
            if (!createdTrick)
            StartTrick();

            createdTrick = true;
        }
        

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


    void StartTrick()
    {
        StartCoroutine(Timer.timer(1,()=>Tween.ScaleX(transform,1.38f,0.25f,Ease.OutCirc)));
        StartCoroutine(Timer.timer(1.8f,()=>{GetComponent<Animator>().Play("Amogus");pumpumpum = true;AudioUtil.Play("when the impostor is sus");}));
        
    }

    void Pumpum()
    {
        
        GetComponent<Rigidbody2D>().gravityScale = 10;
        if (floorTouched > transform.position.y && timesCrushed < 3)
        {
            if (GetComponent<Rigidbody2D>().linearVelocity.y < 0)
            timesCrushed++;

            GetComponent<Rigidbody2D>().linearVelocity = new Vector2(GetComponent<Rigidbody2D>().linearVelocity.x,30);
        }

    }

}
