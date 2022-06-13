using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueController : MonoBehaviour
{
    [Header("Components")]
    public GameObject dialogueBox; // The dialogue box
    public Image profileSprite; // The profile sprite
    public Text speechText;   // The dialogue text
    public Text actorNameText; // The actor name text

    [Header("Settings")]
    public float typingSpeed;

    private bool isShowing;
    private int index;
    private string[] sentences;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator TypeSentence()
    {
        foreach(char letter in sentences[index].ToCharArray())
        {
            speechText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    public void NextSentence(){

    }

    public void Speech()
    {
        if(!isShowing)
        {
            dialogueBox.SetActive(true);
            isShowing = true;
            StartCoroutine(TypeSentence());
        }

    }
}
