//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class PlayerDialogueTrigger : MonoBehaviour
{

    [SerializeField] private Dialogue dialogue;

    //
    public void TriggerDialogue()
    {

        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);

    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (DialogueManager.instance.IsPlayerWord)
        {
            if (Input.GetKeyDown(KeyCode.C) && !GameManager.instance.IsNearArcade)
            {
                DialogueManager.instance.PlayerIcon();
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
            }
        }

    }
}
