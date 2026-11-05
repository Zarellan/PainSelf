using System;
using System.Collections;
using System.Collections.Generic;
using PrimeTween;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerMovement : MonoBehaviour
{

    Vector2 pos;

    Rigidbody2D rigid;

    [SerializeField]
    float speed;

    [SerializeField]
    float jump;


    bool canJump = true;

    bool canMove = true;

    Animator anim;

    string currentAnimation;


    public bool canChange = true;

    bool falled = false;


    public bool ignoreFallDetecing = false;


    public static float defaultPosX,defaultPosY;

    public static float checkPointID;

    [SerializeField]
    GameObject spark;

    [SerializeField]
    Animator sparko;

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();

        anim = GetComponent<Animator>();

        GameObject.FindWithTag("SoundTrack").GetComponent<SoundTrackScript>().PlayMusic("painherself world 1");
        GameObject.FindWithTag("SoundTrack").GetComponent<SoundTrackScript>().SetVolume(PlayerPrefs.GetFloat("Volume",1));


        if (defaultPosX != 0)
        {
            transform.position = new Vector2(defaultPosX,defaultPosY);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
        if (Input.GetKey(KeyCode.RightArrow) && canJump)
        {
            GetComponent<SpriteRenderer>().flipX = false;
            ChangeAnimation("walk");
        }
        else if (Input.GetKey(KeyCode.LeftArrow) && canJump)
        {
            GetComponent<SpriteRenderer>().flipX = true;
            ChangeAnimation("walk");

        }
        else if (canJump && canMove)
        {
            ChangeAnimation("Idle");
        }
        }


        GameObject.FindWithTag("MainCamera").transform.position = new Vector3(transform.position.x,Mathf.Clamp(transform.position.y + 1,-5,30),-10);

        if (canMove)
        PlayerJump();

        FallVoidDetect();


        

        if (rigid.linearVelocity.y == 0 && !canJump)
        {
            canJump = true;

            
            ChangeAnimation("Idle");
        }
    }

    void FixedUpdate()
    {
        PlayerMove();

    }


    void PlayerMove()
    {
        if (canMove)
        {
        pos = transform.position;

        pos.x += Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime;

        transform.position = pos;
        }
        

    }


    void OnTriggerEnter2D(Collider2D other)
    {
        /*if (GameObject.FindWithTag("Floor").name == other.name || GameObject.FindWithTag("Platform").name == other.name)
            {
                canJump = true;

                
                ChangeAnimation("Idle");
            }*/
    }





    void PlayerJump()
    {
            if (Input.GetKeyDown(KeyCode.UpArrow) && canJump)
            {
                rigid.linearVelocity = new Vector2(rigid.linearVelocity.x,jump);
                ChangeAnimation("Jump");
                canJump = false;
            }
            else if (Input.GetKeyUp(KeyCode.UpArrow) && rigid.linearVelocity.y > 0)
            {
                rigid.linearVelocity = new Vector2(rigid.linearVelocity.x,-0.000001f);
            }

            if (rigid.linearVelocity.y < 0 && !canJump)
                ChangeAnimation("JumpDown");


        
        
    }

    public void Unmoveable()
    {
        canMove = false;
        canJump = false;

    }

    public void Moveable()
    {
        canMove = true;
        canJump = true;
    }


    public void ChangeAnimation(string newAnimation)
    {
        if (currentAnimation == newAnimation || !canChange)
            return;

        currentAnimation = newAnimation;

        anim.Play(newAnimation);
    }

    public void ChangeAnimation(string newAnimation,bool forceChange)
    {
        if (currentAnimation == newAnimation && !forceChange)
            return;

        currentAnimation = newAnimation;

        anim.Play(newAnimation);
    }


    void FallVoidDetect()
    {
        if (transform.position.y < -4 && !falled && !ignoreFallDetecing)
            {
                
                GameObject.FindWithTag("GameOver").GetComponent<GameOver>().GameOverAdvanced("Hey ron\nhey billy (that hurt)","",2);
                falled = true;
            }
    }



    public void Victory(string sceneToChange)
    {
        GetComponent<SpriteRenderer>().enabled = false;
        spark.GetComponent<SpriteRenderer>().enabled = true;
        Unmoveable();
        sparko.Play("Spark1");

        AudioUtil.Play("bigRingSound");

        rigid.linearVelocity = new Vector2(0,0);
        rigid.gravityScale = 0;
        
        StartCoroutine(Timer.timer(2,()=>{

            TransitionUtil.TransIn();
            Tween.AudioVolume(SoundtrackUtil.GetAudio(),0,1,Ease.Linear);
            
        }));

        StartCoroutine(Timer.timer(3,()=>{
            
        SceneManager.LoadScene(sceneToChange);
        TransitionUtil.TransOut();
        

        }));

    }

}
