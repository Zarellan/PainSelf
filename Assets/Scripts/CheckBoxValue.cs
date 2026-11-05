using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckBoxValue : MonoBehaviour
{
    [SerializeField] string valueName;
    // Start is called before the first frame update
    void Start()
    {
        bool cond = PlayerPrefs.GetString(valueName) == "true"?true:false;

        GetComponent<Toggle>().isOn = cond;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
