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
    public TextManagerGame textManagerGameScript;

    private List<string> curLines = new List<string>();

    public int messageIndex = 0;

    bool firstTaskCompleted = false;
    bool firstDayCompleted = false;
    bool buttonClicked = false;

    float popularityOutcome;
    float coralOutcome;

    private void Awake()
    {
        Energy.onDayCompleted += EnergyDayCompleted;
        taskListButton.onClick.AddListener(ButtonClicked);
        TaskManager.onTaskCompleted += GetCompletedTaskOutcome;
    }


    private void Start()
    {
        curLines = textManagerGameScript.currentLines;
        dialogueManager.UseTutorialMessage(curLines[messageIndex]);
        messageIndex += 1;
    }

    private void OnDestroy()
    {
        Energy.onDayCompleted -= EnergyDayCompleted;
        taskListButton.onClick.RemoveListener(ButtonClicked);
        TaskManager.onTaskCompleted -= GetCompletedTaskOutcome;
    }

    private void Update()
    {
        if(messageIndex == 1)
        {
            arrow.SetActive(true);
            if (buttonClicked)
            {
                taskManager.gameObject.SetActive(true);
                arrow.SetActive(false);
                dialogueManager.UseTutorialMessage(curLines[messageIndex]);
                messageIndex += 1; 
            }
        }
        else if(messageIndex == 2)
        {
            if (Input.GetMouseButtonDown(0))
            {
                dialogueManager.UseTutorialMessage(curLines[messageIndex]);
                messageIndex += 1;
            }
        }
        else if(messageIndex == 3)
        {
            if (firstTaskCompleted)
            {
                string newMessage = "";
                if(coralOutcome > 0)
                {
                    if(popularityOutcome > 0)
                    {
                        newMessage = textManagerGameScript.posCorLines[0];
                    }
                    else if (popularityOutcome == 0)
                    {
                        newMessage = textManagerGameScript.posCorLines[1];
                    }
                    else
                    {
                        newMessage = textManagerGameScript.posCorLines[2];
                    }
                }
                else if(coralOutcome == 0)
                {
                    if (popularityOutcome > 0)
                    {
                        newMessage = textManagerGameScript.neuCorLines[0];
                    }
                    else if (popularityOutcome == 0)
                    {
                        newMessage = textManagerGameScript.neuCorLines[1];
                    }
                    else
                    {
                        newMessage = textManagerGameScript.neuCorLines[2];
                    }
                }
                else if(coralOutcome < 0)
                {
                    if (popularityOutcome > 0)
                    {
                        newMessage = textManagerGameScript.negCorLines[0];
                    }
                    else if (popularityOutcome == 0)
                    {
                        newMessage = textManagerGameScript.negCorLines[1];
                    }
                    else
                    {
                        newMessage = textManagerGameScript.negCorLines[2];
                    }
                }

                dialogueManager.UseTutorialMessage(newMessage);
                messageIndex += 1;
            }
        }
        else if (messageIndex == 4)
        {

            if (firstDayCompleted)
            {
                dialogueManager.UseTutorialMessage(curLines[messageIndex]);
                messageIndex += 1; //display last message when energy runs out day 1
            }
        }
        else if(messageIndex == 5)
        {
            if (Input.GetMouseButtonDown(0))
            {
                dialogueManager.FinishTutorial();
                Destroy(this.gameObject);
            }

        } 
    }

    void ButtonClicked()
    {
        if(messageIndex == 1)
        {
            buttonClicked = true;
        }
    }

    void EnergyDayCompleted()
    {
        firstDayCompleted = true;
    }

    void GetCompletedTaskOutcome(Task task)
    {
        coralOutcome += task.coralOutcome;
        popularityOutcome += task.popularityOutcome;
        firstTaskCompleted = true;
    }
}
