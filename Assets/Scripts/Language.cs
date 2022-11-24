using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Language : MonoBehaviour
{
    public int ChangeLanguage = 1;
    public string[] EnglishText;
    public string[] SpanishText;
    public Text[] Text;

    void Update()
    {
        ChangeLanguage = PlayerPrefs.GetInt("Idioma");
        if(ChangeLanguage == 0)
        {
            EnglishLanguage();

        }else if(ChangeLanguage == 1)
        {
            SpanishLanguage();
        }  
    }

    public void Change(){
        if(ChangeLanguage == 0)
        {
            ChangeLanguage = 1;
            PlayerPrefs.SetInt("Idioma", ChangeLanguage);
            PlayerPrefs.Save();
        }else if(ChangeLanguage == 1)
        {
            ChangeLanguage = 0;
            PlayerPrefs.SetInt("Idioma", ChangeLanguage);
            PlayerPrefs.Save();
        }  
    }

    public void EnglishLanguage(){
        if(Text[0] != null)
        {
            Text[0].text = EnglishText[0];
        }
        if(Text[1] != null)
        {
            Text[1].text = EnglishText[1];
        }
        if(Text[2] != null)
        {
            Text[2].text = EnglishText[2];
        }
        if(Text[3] != null)
        {
            Text[3].text = EnglishText[3];
        }
        if(Text[4] != null)
        {
            Text[4].text = EnglishText[4];
        }
        if (Text[5] != null)
        {
            Text[5].text = EnglishText[5];
        }
        if (Text[6] != null)
        {
            Text[6].text = EnglishText[6];
        }
    }
    public void SpanishLanguage(){
        if(Text[0] != null)
        {
            Text[0].text = SpanishText[0];
        }
        if(Text[1] != null)
        {
            Text[1].text = SpanishText[1];
        }
        if(Text[2] != null)
        {
            Text[2].text = SpanishText[2];
        }
        if(Text[3] != null)
        {
            Text[3].text = SpanishText[3];
        }
        if(Text[4] != null)
        {
            Text[4].text = SpanishText[4];
        }
        if (Text[5] != null)
        {
            Text[5].text = SpanishText[5];
        }
        if (Text[6] != null)
        {
            Text[6].text = SpanishText[6];
        }
    }
}
