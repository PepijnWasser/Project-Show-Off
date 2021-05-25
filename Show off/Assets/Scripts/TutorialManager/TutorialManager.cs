using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour
{
    public DialogueManager dialogueManager;
    public TaskManager taskManager;
    public Button taskListButton;
    public GameObject arrow;

    public List<string> tutorialMessages;

    public int messageIndex = 0;

    bool dayCompleted = false;
    bool buttonClicked = false;

    private void Awake()
    {
        Energy.onDayCompleted += EnergyDayCompleted;
        taskListButton.onClick.AddListener(ButtonClicked);
    }


    private void Start()
    {
        dialogueManager.UseTutorialMessage(tutorialMessages[messageIndex]);
        messageIndex += 1;
    }

    private void OnDestroy()
    {
        Energy.onDayCompleted -= EnergyDayCompleted;
        taskListButton.onClick.RemoveListener(ButtonClicked);
    }

    private void Update()
    {
        if(messageIndex == 0 || messageIndex == 1 || messageIndex == 2 || messageIndex == 3)
        {
            if (Input.GetMouseButtonDown(0))
            {
                dialogueManager.UseTutorialMessage(tutorialMessages[messageIndex]);
                messageIndex += 1;
            }
        }
        else if(messageIndex == 4)
        {
            arrow.SetActive(true);
            if (buttonClicked)
            {
                taskManager.gameObject.SetActive(true);
                arrow.SetActive(false);
                dialogueManager.UseTutorialMessage(tutorialMessages[messageIndex]);
                messageIndex += 1;
            }
        }
        else if(messageIndex == 5)
        {
            if (dayCompleted)
            {
                dialogueManager.UseTutorialMessage(tutorialMessages[messageIndex]);
                messageIndex += 1;
            }
        }
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                dialogueManager.FinishTutorial();
                Destroy(this.gameObject);
            }
        }   
    }

    void EnergyDayCompleted()
    {
        dayCompleted = true;
    }

    void ButtonClicked()
    {
        if(messageIndex == 4)
        {
            buttonClicked = true;
        }
    }
}
