using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LanguageIconManager : MonoBehaviour
{
    [Header("Please write EN (English) or NL (Nederlands)")]
    public string startLanguage;
    public string currentLanguage { get; private set; }
    
    [SerializeField] private Button dutchButton;
    [SerializeField] private Button englishButton;
    private Color tempColor;
    private float transparentFloat = 0.5f;
    private float solidFloat = 1.0f;

    private void Start()
    {
        if (startLanguage == "EN")
        {
            //Debug.Log("Starting language is english");
            ChangeToEnglish();
        }    
        else if (startLanguage == "NL")
        {
            //Debug.Log("Starttaal is Nederlands");
            ChangeToDutch();
        }
        else
        {
            Debug.LogError("Please write a valid response");
        }
    }

    public void ChangeToDutch()
    {
        //Debug.Log("Verandert naar Nederlands");
        SetButtonTransparency(dutchButton, solidFloat);
        SetButtonTransparency(englishButton, transparentFloat);
        currentLanguage = "NL";
    }

    public void ChangeToEnglish()
    {
        //Debug.Log("Changed to English");
        SetButtonTransparency(englishButton, solidFloat);
        SetButtonTransparency(dutchButton, transparentFloat);
        currentLanguage = "EN";
    }

    private void SetButtonTransparency(Button button, float alpha)
    {
        tempColor = button.image.color;
        tempColor.a = alpha;
        button.image.color = tempColor;
    }
}
