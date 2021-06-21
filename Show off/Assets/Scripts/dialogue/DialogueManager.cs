using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public Sprite blankSprite;
    public Sprite hoverSprite;

    public GameObject textBox;
    public GameObject textBoxTutorial;

    bool tutorialFinished = false; 

    public List<string> messages = new List<string>();
    List<string> usedMessages = new List<string>();

    TextMeshProUGUI text;
    TextMeshProUGUI textTutorial;

    private void Awake()
    {
        TaskManager.onTaskCompleted += AddMessage;
        text = textBox.GetComponentInChildren<TextMeshProUGUI>();
        textTutorial = textBoxTutorial.GetComponentInChildren<TextMeshProUGUI>();
    }


    private void OnDestroy()
    {
        TaskManager.onTaskCompleted -= AddMessage;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if(messages.Count > 0 && tutorialFinished)
        {
            string randomMessage = messages[Random.Range(0, messages.Count)];
            textBox.SetActive(true);
            UseMessage(randomMessage);
            TestAvailibleMessages();
        }
    }

    void UseMessage(string message)
    {
        text.text = message;
        usedMessages.Add(message);
        messages.Remove(message);
    }

    public void UseTutorialMessage(string message)
    {
        textBoxTutorial.SetActive(true);
        textTutorial.text = message;
        usedMessages.Add(message);
    }

    void TestAvailibleMessages()
    {
        if(messages.Count <= 0)
        {
            GetComponent<Image>().sprite = blankSprite;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if(messages.Count > 0 && tutorialFinished)
        {
            GetComponent<Image>().sprite = hoverSprite;
        }
    }

    //when we exit change the sprite 
    public void OnPointerExit(PointerEventData eventData)
    {
        GetComponent<Image>().sprite = blankSprite;
        textBox.SetActive(false);

    }

    //add a message to our message pool
    private void AddMessage(Task task)
    {
        messages.Add(task.outcomeMessage);
    }

    public void FinishTutorial()
    {
        textBoxTutorial.SetActive(false);
        tutorialFinished = true;
    }
}
