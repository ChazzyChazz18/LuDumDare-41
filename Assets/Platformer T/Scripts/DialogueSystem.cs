using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueSystem : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    public void StartDialogue()
    {

        DialogueManager.instance.DisplayNextSentence();

    }

    // Update is called once per frame
    void Update()
    {

    }
}
