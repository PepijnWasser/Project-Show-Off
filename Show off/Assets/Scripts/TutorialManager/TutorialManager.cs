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
        Debug.Log("this is it"+ messageIndex);
        /*if(messageIndex == 0 || messageIndex == 1 || messageIndex == 2 || messageIndex == 3)
        {
            if (Input.GetMouseButtonDown(0))
            {
                dialogueManager.UseTutorialMessage(tutorialMessages[messageIndex]);
                messageIndex += 1;
            }
        }*/
        if(messageIndex == 1)
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
        else if(messageIndex == 2)
        {
            if (Input.GetMouseButtonDown(0))
            {
                dialogueManager.UseTutorialMessage(tutorialMessages[messageIndex]);
                messageIndex += 1;
            }
        }
        else if(messageIndex == 3)
        {
            if (Input.GetMouseButtonDown(0))
            {
                dialogueManager.UseTutorialMessage(tutorialMessages[messageIndex]);
                messageIndex += 1; //replace this with following pseudo code
                /*
                 if(first task is crops farm){
                 messageIndex=4;
                 }
                 else if(first task is cow farm || increase tourism){
                 messageIndex=5;
                 }
                 else if(first task is clean trash){
                 messageIndex=6;
                 }
                 else if(first task is decrease tourism)
                 {
                 messageIndex=7;
                 }
                 */
            }
        }
        else if (messageIndex == 4 || messageIndex == 5 || messageIndex == 6 || messageIndex == 7)
        {
            dialogueManager.UseTutorialMessage(tutorialMessages[messageIndex]);
            if (dayCompleted/*energy runs out day 1?*/)
            {
                messageIndex = 8; //display last message when energy runs out day 1
            }
        }
        else if(messageIndex == 8)
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
        if(messageIndex == 1)
        {
            buttonClicked = true;
        }
    }
}
