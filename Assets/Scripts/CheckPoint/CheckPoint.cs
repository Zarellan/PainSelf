using System.Collections;
using System.Collections.Generic;
using PrimeTween;
using UnityEngine;
using UnityEngine.Jobs;

public class CheckPoint : MonoBehaviour
{
    [SerializeField]
    float defPosX,defPosY;

    [SerializeField]
    int id;
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
        if (GameObject.FindWithTag("Player").name == other.name && PlayerMovement.checkPointID != id && PlayerPrefs.GetString("AllowCheckpoints") == "true")
            {
                PlayerMovement.defaultPosX = defPosX;
                PlayerMovement.defaultPosY = defPosY;
                PlayerMovement.checkPointID = id;

                Color col = GetComponent<SpriteRenderer>().color;
                GetComponent<SpriteRenderer>().color = new Color(col.r,col.g,col.b,0.7f);
                Tween.Alpha(GetComponent<SpriteRenderer>(),0,0.5f);

                AudioUtil.Play("cut2");

            }
    }

}
