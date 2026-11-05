using System.Collections;
using System.Collections.Generic;
using PrimeTween;
using UnityEngine;

public class Sticker : MonoBehaviour
{

    [SerializeField]
    float whenAppear;

    float scaleX,scaleY;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Timer.timer(whenAppear,BringSticker));


        scaleX = transform.localScale.x;
        scaleY = transform.localScale.y;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void BringSticker()
    {
        GetComponent<SpriteRenderer>().enabled = true;
        transform.localScale = new Vector2(scaleX+0.5f,scaleY+0.5f);
        Tween.Scale(transform,new Vector2(scaleX,scaleY),0.1f,Ease.Linear);

        AudioUtil.Play("titlecard"+Random.Range(1,3));
    }
}
