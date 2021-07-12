using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using TMPro;

public class TextManagerGame : MonoBehaviour
{
    [SerializeField] private LanguageIconManager languageIconManagerScript;
    private string[] dutchLines;
    private string[] englishLines;
    private string[] positiveCoralNL;
    private string[] positiveCoralEN;
    private string[] neutralCoralNL;
    private string[] neutralCoralEN;
    private string[] negativeCoralNL;
    private string[] negativeCoralEN;
    private string prevLanguage;

    public List<string> currentLines { get; private set; }
    public List<string> posCorLines { get; private set; }
    public List<string> neuCorLines { get; private set; }
    public List<string> negCorLines { get; private set; }

    private void Start()
    {
        currentLines = new List<string>();
        posCorLines = new List<string>();
        neuCorLines = new List<string>();
        negCorLines = new List<string>();

        string readFromFilePathEN = Application.streamingAssetsPath + "/TutorialDialogueGame/" + "TutorialDialogueEnglish" + ".txt";
        string readFromFilePathNL = Application.streamingAssetsPath + "/TutorialDialogueGame/" + "TutorialDialogueNederlands" + ".txt";
        string readPosCorNL = Application.streamingAssetsPath + "/TutorialDialogueGame/" + "CoralOutcomePositiveNL" + ".txt";
        string readPosCorEN = Application.streamingAssetsPath + "/TutorialDialogueGame/" + "CoralOutcomePositiveEN" + ".txt";
        string readNeuCorNL = Application.streamingAssetsPath + "/TutorialDialogueGame/" + "CoralOutcomeNeutralNL" + ".txt";
        string readNeuCorEN = Application.streamingAssetsPath + "/TutorialDialogueGame/" + "CoralOutcomeNeutralEN" + ".txt";
        string readNegCorNL = Application.streamingAssetsPath + "/TutorialDialogueGame/" + "CoralOutcomeNegativeNL" + ".txt";
        string readNegCorEN = Application.streamingAssetsPath + "/TutorialDialogueGame/" + "CoralOutcomeNegativeEN" + ".txt";

        englishLines = File.ReadAllLines(readFromFilePathEN);
        dutchLines = File.ReadAllLines(readFromFilePathNL);
        positiveCoralNL = File.ReadAllLines(readPosCorNL);
        positiveCoralEN = File.ReadAllLines(readPosCorEN);
        neutralCoralNL = File.ReadAllLines(readNeuCorNL);
        neutralCoralEN = File.ReadAllLines(readNeuCorEN);
        negativeCoralNL = File.ReadAllLines(readNegCorNL);
        negativeCoralEN = File.ReadAllLines(readNegCorEN);

        prevLanguage = languageIconManagerScript.currentLanguage;
    }

    private void Update()
    {
        if (languageIconManagerScript.currentLanguage != prevLanguage)
        {
            if (languageIconManagerScript.currentLanguage == "EN")
            {
                WriteArrayIntoList(englishLines, currentLines);
                WriteArrayIntoList(positiveCoralEN, posCorLines);
                WriteArrayIntoList(neutralCoralEN, neuCorLines);
                WriteArrayIntoList(negativeCoralEN, negCorLines);
            }
            else if (languageIconManagerScript.currentLanguage == "NL")
            {
                WriteArrayIntoList(dutchLines, currentLines);
                WriteArrayIntoList(positiveCoralNL, posCorLines);
                WriteArrayIntoList(neutralCoralNL, neuCorLines);
                WriteArrayIntoList(negativeCoralNL, negCorLines);
            }
            prevLanguage = languageIconManagerScript.currentLanguage;
        }
    }

    private void WriteArrayIntoList(string[] lines, List<string> list)
    {
        list.Clear();

        for (int i = 0; i < lines.Length; i++)
        {
            list.Add(lines[i]);
        }
    }
}
