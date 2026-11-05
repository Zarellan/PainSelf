using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlideValue : MonoBehaviour
{
    [SerializeField]
    string valueName;
    [SerializeField]
    float defaultValue;
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetFloat(valueName,PlayerPrefs.GetFloat(valueName,defaultValue));

        GetComponent<Slider>().value = PlayerPrefs.GetFloat(valueName,defaultValue);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangedValue()
    {
        PlayerPrefs.SetFloat(valueName,GetComponent<Slider>().value);
    }
}
