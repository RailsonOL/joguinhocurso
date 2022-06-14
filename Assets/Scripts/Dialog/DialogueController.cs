using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueController : MonoBehaviour
{
    [System.Serializable]
    public enum idiom {
        portuguese,
        english,
        spanish
    }

    public idiom language;

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

    public static DialogueController instance;

    private void Awake() {
        instance = this;
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
        if(speechText.text == sentences[index])
        {
            if(index < sentences.Length - 1)
            {
                index++;
                speechText.text = "";
                StartCoroutine(TypeSentence());
            }
            else
            {
                EndDialogue();
            }
        }
    }

    public void EndDialogue()
    {
        dialogueBox.SetActive(false);
        isShowing = false;
        index = 0;
        speechText.text = "";
        sentences = null;
    }

    public void Speech(string[] txt)
    {
        if(!isShowing)
        {
            dialogueBox.SetActive(true);
            sentences = txt;
            StartCoroutine(TypeSentence());
            isShowing = true;
        }
    }
}
