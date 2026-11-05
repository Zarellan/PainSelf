using System.Collections;
using System.Collections.Generic;
using PrimeTween;
using TMPro;
using UnityEngine;

public class GlobalMessage : MonoBehaviour
{
    [SerializeField]
    TMP_Text message;
    [SerializeField]
    GameObject messageBox;
    Tween messageBoxTween;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MessageAppear(string text)
    {
        message.text = text;

        messageBoxTween = Tween.UIAnchoredPositionY(messageBox.GetComponent<RectTransform>(),422.5f,0.5f,Ease.OutSine);
    }

    public void MessageDisappear()
    {
        messageBoxTween = Tween.UIAnchoredPositionY(messageBox.GetComponent<RectTransform>(),664.1f,0.5f,Ease.OutSine);
    }
}
