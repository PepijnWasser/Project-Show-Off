using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using TMPro;

public class TextManager : MonoBehaviour
{
    [SerializeField] private TMP_Text bubbleText;
    [SerializeField] private LanguageIconManager languageIconManagerScript;
    private string[] dutchLines;
    private string[] englishLines;
    private int counter;

    private void Start()
    {
        counter = 0;

        string readFromFilePathEN = Application.streamingAssetsPath + "/TutorialTexts/" + "TutorialEnglishNumbers" + ".txt";
        string readFromFilePathNL = Application.streamingAssetsPath + "/TutorialTexts/" + "TutorialNederlandsCijfers" + ".txt";

        englishLines = File.ReadAllLines(readFromFilePathEN);
        dutchLines = File.ReadAllLines(readFromFilePathNL);

        WriteCurrentLine();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            counter++;

            if (counter >= englishLines.Length || counter >= dutchLines.Length)
            {
                counter = 0;
            }
        }
        WriteCurrentLine();
    }

    private void WriteCurrentLine()
    {
        if (languageIconManagerScript.currentLanguage == "EN")
        {
            bubbleText.text = englishLines[counter];
        }
        else if (languageIconManagerScript.currentLanguage == "NL")
        {
            bubbleText.text = dutchLines[counter];
        }
    }
}
