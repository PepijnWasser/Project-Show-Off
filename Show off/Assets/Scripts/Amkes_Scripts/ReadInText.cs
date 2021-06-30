using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using TMPro;

public class ReadInText : MonoBehaviour
{
    [SerializeField] private TMP_Text bubbleText;
    [SerializeField] private LanguageIconManager languageIconManagerScript;
    private string[] dutchLines;
    private string[] englishLines;

    private void Start()
    {
        dutchLines = File.ReadAllLines("Assets/Amkes_Files/A_Txt/TutorialNederlands.txt");
        englishLines = File.ReadAllLines("Assets/Amkes_Files/A_Txt/TutorialEnglish.txt");

        if (languageIconManagerScript.startLanguage == "EN")
        {
            bubbleText.text = englishLines[0];
        }
        else if (languageIconManagerScript.startLanguage == "NL")
        {
            bubbleText.text = dutchLines[0];
        }
    }
}
