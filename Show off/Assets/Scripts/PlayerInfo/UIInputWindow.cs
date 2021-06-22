using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Linq;

public class UIInputWindow : MonoBehaviour
{
    public InputField nameField;
    public InputField ageField;
    public Text resolutionText;

    public GameObject sceneObjects;

    public int MaxLengthName;

    bool validName = false;
    bool validAge = false;

    PlayerInfo playerInfo;

    public CameraController camControlScript;

    private void Awake()
    {
        PlayerInfo _playerInfo = GameObject.FindObjectOfType<PlayerInfo>();
        if (_playerInfo != null)
        {
            playerInfo = _playerInfo;
        }
        else
        {
            Debug.LogError("noPlayerInfoFound", this);
        }
        camControlScript.enabled = false;
    }

    //test if the name and age are valid and puts it in the playerInfo
    public void FinishCompletion()
    {
        if(validName && validAge)
        {
            gameObject.SetActive(false);
            sceneObjects.SetActive(true);
            if(playerInfo != null)
            {
                playerInfo.playerName = nameField.text;
                playerInfo.age = Int32.Parse(ageField.text);
            }
            camControlScript.enabled = true;
        }
        else
        {
            resolutionText.text = "Vul je naam en leeftijd in";
        }
    }

    void Start()
    {
        nameField.onEndEdit.AddListener(delegate { ValidateNameInput(nameField); });
        nameField.onValueChanged.AddListener(delegate { ValidateNameInput(nameField); });

        ageField.onEndEdit.AddListener(delegate { ValidateAgeInput(ageField); });
        ageField.onValueChanged.AddListener(delegate { ValidateAgeInput(ageField); });
    }

    private void OnDestroy()
    {
        nameField.onEndEdit.RemoveListener(delegate { ValidateNameInput(nameField); });
        nameField.onValueChanged.RemoveListener(delegate { ValidateNameInput(nameField); });

        ageField.onEndEdit.RemoveListener(delegate { ValidateAgeInput(ageField); });
        ageField.onValueChanged.RemoveListener(delegate { ValidateAgeInput(ageField); });
    }

    //check if the name is valid
    void ValidateNameInput(InputField inputField)
    {
        string inputValue = inputField.text;
        if(inputValue.Length < MaxLengthName)
        {
            bool containsInt = inputValue.Any(char.IsDigit);
            if(containsInt == false)
            {
                validName = true;
                resolutionText.text = "";
            }
            else
            {
                validName = false;
                resolutionText.text = "Naam kan geen nummers bevatten";
            }
        }
        else
        {
            validName = false;
            resolutionText.text = "Naam is te lang";
        }
    }

    //check if age is valid
    void ValidateAgeInput(InputField inputField)
    {
        string inputValue = inputField.text;
        if (inputValue.Length <= 3)
        {
            bool isInt = inputValue.All(char.IsDigit);
            if (isInt == true)
            {
                validAge = true;
                resolutionText.text = "";
            }
            else
            {
                validAge = false;
                resolutionText.text = "Leeftijd kan max 3 tekens bevatten";
            }
        }
        else
        {
            validAge = false;
            resolutionText.text = "Leeftijd kan max 3 tekens bevatten";
        }
    }
}
