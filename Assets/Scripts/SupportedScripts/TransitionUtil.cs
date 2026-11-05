using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TransitionUtil
{

    public static void TransIn()
    {
        GameObject.FindWithTag("Transition").GetComponent<Transition>().TransIn();
        
    }

    
    public static void TransOut()
    {
        GameObject.FindWithTag("Transition").GetComponent<Transition>().TransOut();
    }


    public static void MainMenuTransition1()
    {
        GameObject.FindWithTag("Transition").GetComponent<Transition>().MainMenuTransition1();
    }


    public static void SceneChange(string sceneName)
    {
        GameObject.FindWithTag("Transition").GetComponent<Transition>().SceneChange(sceneName);
        
    }

}
