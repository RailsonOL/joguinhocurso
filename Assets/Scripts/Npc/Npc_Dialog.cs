using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Npc_Dialog : MonoBehaviour
{
    public float dialogueRange;
    public LayerMask playerLayer;
    public DialogSettings dialogue;
    bool playerHit;
    private List<string> sentences = new List<string>();

    private void Start() {
        GetNpcTexts();
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && playerHit)
        {
            DialogueController.instance.Speech(sentences.ToArray());
        }
    }

    void GetNpcTexts()
    {
        for(int i = 0; i < dialogue.dialogues.Count; i++)
        {
            switch(DialogueController.instance.language){
                case DialogueController.idiom.english:
                    sentences.Add(dialogue.dialogues[i].sentence.english);
                    break;
                case DialogueController.idiom.portuguese:
                    sentences.Add(dialogue.dialogues[i].sentence.portuguese);
                    break;
                case DialogueController.idiom.spanish:
                    sentences.Add(dialogue.dialogues[i].sentence.spanish);
                    break;
            };
        }
    }
    void FixedUpdate()
    {
        ShowDialogue();
    }

    void ShowDialogue(){
        Collider2D hit = Physics2D.OverlapCircle(transform.position, dialogueRange, playerLayer);

        if(hit != null){
            playerHit = true;
        }else{
            playerHit = false;
        }
    }

    void OnDrawGizmosSelected(){
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, dialogueRange);
    }
}
