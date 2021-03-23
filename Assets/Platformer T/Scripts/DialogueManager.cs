using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {

	public static DialogueManager instance;

	[SerializeField] private Image iconImage;
	[SerializeField] private Text nameText;
	[SerializeField] private Text dialogueText;
	[SerializeField] private Text continueText;

	[SerializeField] private Animator dialogueSystemAnim;
	[SerializeField] private Animator dialogueIconAnim;

    private bool isActualSentenceFinished = false;

	//private bool isAGhost = false;
	//private bool isNothing = false;
	private bool isPlayerWord = true;

	private bool isDialoguin = false;
	//private bool isTextboxOn = false;

	/*public bool IsTextboxOn {
		get {
			return isTextboxOn;
		}
		set {
			isTextboxOn = value;
		}
	}*/

	private Queue<string> sentences;

	public bool IsDialoguin {
		get {
			return isDialoguin;
		}
	}

	public bool IsPlayerWord {
		get {
			return isPlayerWord;
		}
		set {
			isPlayerWord = value;
		}
	}

    public bool IsActualSentenceFinished { get => isActualSentenceFinished; set => isActualSentenceFinished = value; }

    // Use this for initialization
    void Awake () {
		instance = this;
	}

	// Use this for initialization
	void Start () {
		sentences = new Queue<string> ();
	}

	//
	public void PlayerIcon () {
		dialogueIconAnim.SetTrigger ("Player");
	}

	//
	public void GhostIcon () {
		dialogueIconAnim.SetTrigger ("Ghost");
	}

	//
	private void IconOff () {
		dialogueIconAnim.ResetTrigger ("Player");
		dialogueIconAnim.ResetTrigger ("Ghost");
		dialogueIconAnim.SetBool ("Speaking", false);
	}

	//
	public void StartDialogue (Dialogue dialogue) {

		//Debug.Log ("Start Conversation with: " + dialogue.Name);

		GameObject.FindObjectOfType<PT_PlayerPlatformerController> ().StopMovement ();

		isDialoguin = true;

        dialogueSystemAnim.SetBool ("isShowing", true);

		dialogueIconAnim.SetBool ("Speaking", true);

		iconImage.sprite = dialogue.Icon;

		nameText.text = dialogue.Name;

		continueText.text = "Continue...";

		sentences.Clear ();

        dialogueText.text = string.Empty;


        foreach (string sentence in dialogue.Sentences) {

			sentences.Enqueue (sentence);
			
		}

        //DisplayNextSentence ();

    }

	public void DisplayNextSentence () {

		if(sentences.Count > 0)
			dialogueIconAnim.SetTrigger ("Speak");

		if(sentences.Count == 1)
			continueText.text = "Finish";

		if(sentences.Count == 0){

			Invoke ("IconOff", 0.5f);
			EndDialogue ();
			return;
			
		}

		string sentence = sentences.Dequeue ();
		//Debug.Log (sentence);
		//dialogueText.text = sentence;
		StopAllCoroutines ();
		StartCoroutine (TypeSentence (sentence));
		
	}

	IEnumerator TypeSentence (string sentence) {

		dialogueText.text = "";
		foreach (char letter in sentence.ToCharArray ()) {
			dialogueText.text += letter;
			yield return null;
		}

        if (dialogueText.text.ToCharArray().Length == sentence.ToCharArray().Length) {
            IsActualSentenceFinished = true;
        }
	
	}

	private void EndDialogue () {

		isDialoguin = false;
		
		//Debug.Log ("End of conversation");
		dialogueSystemAnim.SetBool ("isShowing", false);

		Invoke ("IconOff", 0.5f);

        GameObject.FindObjectOfType<PT_PlayerPlatformerController> ().ContinueMovement ();
	}

	void Update () {
		//Debug.Log (isPlayerWord);
	}

}
