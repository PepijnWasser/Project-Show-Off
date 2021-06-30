using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LanguageManager : MonoBehaviour
{
    [SerializeField] private Button dutchButton;
    [SerializeField] private Button englishButton;
    private Color tempColor;
    private float transparentFloat = 0.5f;
    private float solidFloat = 1.0f;

    private void Start()
    {
        Button dbtn = dutchButton.GetComponent<Button>();
        dbtn.onClick.AddListener(ChangeToDutch);

        Button ebtn = englishButton.GetComponent<Button>();
        ebtn.onClick.AddListener(ChangeToEnglish);
    }

    private void ChangeToDutch()
    {
        Debug.Log("Verandert naar Nederlands");
        SetButtonTransparency(dutchButton, solidFloat);
        SetButtonTransparency(englishButton, transparentFloat);
    }

    private void ChangeToEnglish()
    {
        Debug.Log("Changed to English");
        SetButtonTransparency(englishButton, solidFloat);
        SetButtonTransparency(dutchButton, transparentFloat);
    }

    private void SetButtonTransparency(Button button, float alpha)
    {
        tempColor = button.image.color;
        tempColor.a = alpha;
        button.image.color = tempColor;
    }
}
