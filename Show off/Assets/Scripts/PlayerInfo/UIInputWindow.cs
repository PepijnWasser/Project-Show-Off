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
    }

    public void FinishCompletion()
    {
        if(validName && validAge)
        {
            gameObject.SetActive(false);
            sceneObjects.SetActive(true);
            if(playerInfo != null)
            {
                playerInfo.playerName = nameField.text;
                Debug.Log(playerInfo.name);
                playerInfo.age = Int32.Parse(ageField.text);
            }
        }
        else
        {
            resolutionText.text = "please enter valid credentials";
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
                resolutionText.text = "Name Can't contain numbers";
            }
        }
        else
        {
            validName = false;
            resolutionText.text = "Name too long";
        }
    }

    void ValidateAgeInput(InputField inputField)
    {
        string inputValue = inputField.text;
        if (inputValue.Length <= 2)
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
                resolutionText.text = "please enter a valid age";
            }
        }
        else
        {
            validAge = false;
            resolutionText.text = "please enter a valid age";
        }
    }
}
