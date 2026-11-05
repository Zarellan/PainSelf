using System.Collections;
using System.Collections.Generic;
using PrimeTween;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class ButtonScript : MonoBehaviour , IPointerEnterHandler, IPointerExitHandler
{

    Image spriteRend;
    public TMP_Text text;

    // Start is called before the first frame update
    void Start()
    {
        spriteRend = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = new Vector2(transform.position.x,(Mathf.Cos(Time.time + differenceY) / 4f) + posY);

    }
    


    public void OnPointerEnter(PointerEventData eventData)
    {
        if (GetComponentInParent<Button>().enabled)
        {
        Tween.Scale(transform,endValue:1.3f,duration:0.3f,Ease.OutSine);
        Tween.Color(text,endValue:Color.yellow,duration:0.3f,Ease.OutSine);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (GetComponentInParent<Button>().enabled)
        {
        Tween.Scale(transform,endValue:1f,duration:0.3f,Ease.OutSine);
        Tween.Color(text,endValue:Color.white,duration:0.3f,Ease.OutSine);
        }
    }

}
