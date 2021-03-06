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
        dialogueManager.UseTutorialMessage(tutorialMessages[messageIndex]);
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
            if (firstTaskCompleted)
            {
                string newMessage = "";
                if(coralOutcome > 0)
                {
                    if(popularityOutcome > 0)
                    {
                        newMessage = "Een zeer goede keuze! De populariteit is niet alleen gestegen, maar het koraalrif is ook gezonder. Goed gedaan!";
                    }
                    else if (popularityOutcome == 0)
                    {
                        newMessage = "Het koraalrif is gezonder geworden. Goed gedaan!";
                    }
                    else
                    {
                        newMessage = "Het koraalrif is gezonder geworden, maar ten koste van de populariteit. Hier moeten we voor oppassen.";
                    }
                }
                else if(coralOutcome == 0)
                {
                    if (popularityOutcome > 0)
                    {
                        newMessage = "The popularity of our island went up without sacrificing coral health!";
                    }
                    else if (popularityOutcome == 0)
                    {
                        newMessage = "your changes resulted in a neutral outcome for the coral and popularity.";
                    }
                    else
                    {
                        newMessage = "Aah, you lost some popularity. At least the coral is healthy";
                    }
                }
                else if(coralOutcome < 0)
                {
                    if (popularityOutcome > 0)
                    {
                        newMessage = "De populariteit is gestegen, maar ten koste van de gezondheid van het koraalrif. Hier moeten we voor oppassen.";
                    }
                    else if (popularityOutcome == 0)
                    {
                        newMessage = "Ooh, we lost some coral health. no problem, it is only your first day";
                    }
                    else
                    {
                        newMessage = "That was a bad choice. Both the coral and popularity went down.";
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
                dialogueManager.UseTutorialMessage(tutorialMessages[messageIndex]);
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
