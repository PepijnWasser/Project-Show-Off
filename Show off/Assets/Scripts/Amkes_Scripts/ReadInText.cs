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
    private int counter;

    private void Start()
    {
        counter = 0;

        dutchLines = File.ReadAllLines("Assets/Amkes_Files/A_Txt/TutorialNederlands.txt");
        englishLines = File.ReadAllLines("Assets/Amkes_Files/A_Txt/TutorialEnglish.txt");

        WriteCurrentLine();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            counter++;

            if (counter >= englishLines.Length || counter >= dutchLines.Length)
            {
                counter = 0;
            }
            Debug.Log("Counter: " + counter);

            WriteCurrentLine();
        }
    }

    private void WriteCurrentLine()
    {
        if (languageIconManagerScript.startLanguage == "EN")
        {
            bubbleText.text = englishLines[counter];
        }
        else if (languageIconManagerScript.startLanguage == "NL")
        {
            bubbleText.text = dutchLines[counter];
        }
    }
}
