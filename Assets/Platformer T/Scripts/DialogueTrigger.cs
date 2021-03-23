//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{

    [SerializeField] private Dialogue dialogue;
    [SerializeField] private Collider2D playerCol;

    private bool isGhostCol = false;

    //
    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }

    //
    void OnTriggerStay2D(Collider2D other)
    {
        isGhostCol = true;
        DialogueManager.instance.IsPlayerWord = false;
    }

    //
    void OnTriggerExit2D(Collider2D other)
    {
        isGhostCol = false;
        DialogueManager.instance.IsPlayerWord = true;
    }

    private void Update()
    {

        if (playerCol.CompareTag("Player") && gameObject.GetComponent<GhostController>().IsVisible && isGhostCol)
        {

            if (!DialogueManager.instance.IsPlayerWord)
            {
                //DialogueManager.instance.IsPlayerWord = false;
                if (Input.GetKeyDown(KeyCode.C))
                {


                    DialogueManager.instance.GhostIcon();
                    if (!DialogueManager.instance.IsDialoguin)
                        TriggerDialogue();
                    else
                    {
                        if (DialogueManager.instance.IsActualSentenceFinished)
                        {
                            DialogueManager.instance.DisplayNextSentence();
                            DialogueManager.instance.IsActualSentenceFinished = false;
                        }
                    }

                    if (playerCol.transform.position.x > transform.position.x)
                        GetComponent<SpriteRenderer>().flipX = true;
                    else
                        GetComponent<SpriteRenderer>().flipX = false;

                }
            }
        }

    }

}
