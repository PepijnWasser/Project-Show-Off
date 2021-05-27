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
            if (dayCompleted)
            {
                string newMessage = "";
                if(coralOutcome > 0)
                {
                    if(popularityOutcome > 0)
                    {
                        newMessage = "Great job. The health of the coral went up, and you gained some popularity.";
                    }
                    else if (popularityOutcome == 0)
                    {
                        newMessage = "You did well. The coral gained health without sacrificing our popularity.";
                    }
                    else
                    {
                        newMessage = "You managed to increase the health of the coral, but at the cost of our popularity. Keep ths in mind!";
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
                        newMessage = "Our popularity went up at the cost of some coral health.";
                    }
                    else if (popularityOutcome == 0)
                    {
                        newMessage = "Ooh, we lost some coral health. no problem, it is only your first day";
                    }
                    else
                    {
                        newMessage = "That was a bad choise. Both the coral and popularity went down.";
                    }
                }

                dialogueManager.UseTutorialMessage(newMessage);
                messageIndex += 1;
            }
        }
        else if (messageIndex == 4)
        {

            if (Input.GetMouseButtonDown(0))
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

    void GetCompletedTaskOutcome(Task task)
    {
        coralOutcome += task.coralOutcome;
        popularityOutcome += task.popularityOutcome;
    }
}
