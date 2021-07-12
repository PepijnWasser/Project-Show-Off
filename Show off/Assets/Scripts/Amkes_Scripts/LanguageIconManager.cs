using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LanguageIconManager : MonoBehaviour
{
    public string currentLanguage { get; private set; }

    [SerializeField] private Button dutchButton;
    [SerializeField] private Button englishButton;
    private Color tempColor;
    private float transparentFloat = 0.5f;
    private float solidFloat = 1.0f;

    private void Start()
    {
        SetButtonTransparency(dutchButton, transparentFloat);
        SetButtonTransparency(englishButton, transparentFloat);
    }

    public void ChangeToDutch()
    {
        SetButtonTransparency(dutchButton, solidFloat);
        SetButtonTransparency(englishButton, transparentFloat);
        currentLanguage = "NL";
    }

    public void ChangeToEnglish()
    {
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
