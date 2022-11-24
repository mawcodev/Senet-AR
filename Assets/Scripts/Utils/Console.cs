using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Console
{

    public Text texto;
    
    public void Log(string t)
    {
        texto.text = t;
    }
}
