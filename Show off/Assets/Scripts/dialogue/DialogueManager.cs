using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public Sprite blankSprite;
    public Sprite hoverSprite;

    public GameObject tMProObject;

    public GameObject textBox;

    public List<string> messages = new List<string>();
    List<string> usedMessages = new List<string>();

    TextMeshProUGUI tMPro;

    private void Awake()
    {
        TaskManager.onTaskCompleted += AddMessage;
    }

    void Start()
    {
        tMPro = tMProObject.GetComponent<TextMeshProUGUI>(); 
    }

    private void OnDestroy()
    {
        TaskManager.onTaskCompleted -= AddMessage;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if(messages.Count > 0)
        {
            string randomMessage = messages[Random.Range(0, messages.Count)];
            textBox.SetActive(true);
            UseMessage(randomMessage);
            TestAvailibleMessages();
        }
    }

    void UseMessage(string message)
    {
        tMPro.text = message;
        usedMessages.Add(message);
        messages.Remove(message);
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
        if(messages.Count > 0)
        {
            GetComponent<Image>().sprite = hoverSprite;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        GetComponent<Image>().sprite = blankSprite;
        textBox.SetActive(false);
    }

    private void AddMessage(Task task)
    {
        messages.Add(task.outcomeMessage);
    }
}