using System.Collections;
using System.Collections.Generic;
using PrimeTween;
using UnityEngine;

public class MxAppears : MonoBehaviour
{
    Vector2 pos;


    string currentAnimation;

    [SerializeField]
    float jumpForce;

    [SerializeField]
    float runSpeed;

    bool landed = false;

    Animator anim;


    Rigidbody2D rigid;


    bool running = false;


    bool start = false;


    [SerializeField]
    AudioClip jump;

    
    [SerializeField]
    AudioClip soundTrack;

    bool touched = false;



    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();

        rigid = GetComponent<Rigidbody2D>();

        player = GameObject.FindWithTag("Player");

        //Physics2D.IgnoreCollision(GetComponent<BoxCollider2D>(), GameObject.FindWithTag("Platform").GetComponent<BoxCollider2D>());
    }

    // Update is called once per frame
    void Update()
    {
        Run();


    }

    public void Appear()
    {
        if (player.GetComponent<PlayerMovement>().canChange)
        {
        rigid.linearVelocity = new Vector2(rigid.linearVelocity.x,jumpForce);
        start = true;
        GetComponent<AudioSource>().Play();
        GetComponent<AudioSource>().PlayOneShot(jump,0.5f);

        rigid.gravityScale = 9.1f;
        }

    }

    void Run()
    {
        if (start)
        {
        pos = transform.position;

        pos.x += -runSpeed * Time.deltaTime;

        transform.position = pos;
        }

    }


    void ChangeAnimation(string newAnimation)
    {
        if (currentAnimation == newAnimation)
            return;

        currentAnimation = newAnimation;

        anim.Play(newAnimation);
    }

        void OnCollisionEnter2D(Collision2D other)
        {
            if (GameObject.FindWithTag("Floor").name == other.gameObject.name && !landed)
                {
                    ChangeAnimation("Run");

                    Tween.ShakeCamera(GameObject.FindWithTag("MainCamera").GetComponent<Camera>(),9,0.5f,30);

                    GetComponent<AudioSource>().clip = soundTrack;
                    GetComponent<AudioSource>().Play();

                    Tween.AudioVolume(GetComponent<AudioSource>(),0,5);

                    running = true;
                    landed = true;
                }

            if (player.name == other.gameObject.name)
                {
                    //rigid.velocity = new Vector2(rigid.velocity.x,rigid.velocity.y);
                    if (!touched)
                    {
                    player.transform.localScale = new Vector2(3.6f,1.2f);
                    player.GetComponent<PlayerMovement>().Unmoveable();
                    player.GetComponent<PlayerMovement>().canChange = false;
                    player.GetComponent<PlayerMovement>().ChangeAnimation("None",true);
                    AudioUtil.Play("Stomp");
                    GameObject.FindWithTag("GameOver").GetComponent<GameOver>().GameOverAdvanced("Innocence doesn't get you so far","mario death",4);
                    touched = true;
                    }

                }



        }

}
