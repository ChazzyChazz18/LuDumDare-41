using UnityEngine;
using System.Collections;

public class Warp : MonoBehaviour
{

    // Variables

    public Transform warpTarget; //target warp variable

    [SerializeField] private AudioSource audioS;
    [SerializeField] private Collider2D playerCol;

    private bool isReadyToWarp = false;

    // Methods

    // Use this even before Start for initialization
    void Awake()
    {
        //textArea = GameObject.Find ("HUD");
    }

    // Use this for initialization
    void Start()
    {

    }

    // This method let the player collide with the warp object so he can warp (yeah i know ~.~) alongisde with all the process that needs to happen
    IEnumerator OnTriggerEnter2D(Collider2D other)
    {

        if (gameObject.CompareTag("Warp_LR"))
        {
            WarpFader2 wf = GameObject.FindObjectOfType<WarpFader2>();

            audioS.Play();

            other.GetComponent<Animator>().enabled = false; //make the player animation stop

            other.GetComponent<PT_PlayerPlatformerController>().StopMovement();

            yield return StartCoroutine(wf.Fadein()); //starting fading process with a coroutine

            other.gameObject.transform.position = warpTarget.position; //make player position the same as the warp destination position
            Camera.main.transform.position = new Vector3(warpTarget.position.x, warpTarget.position.y, Camera.main.transform.position.z); //make the camera position the same as the warp destination position

            //StartCoroutine (textArea.GetComponent<AreaText>().ShowAreaText(targetMap.name)); //let the are text appear and do it magic :D

            yield return StartCoroutine(wf.Fadeout()); //ending the fading process with a coroutine

            other.GetComponent<PT_PlayerPlatformerController>().ContinueMovement();

            other.GetComponent<Animator>().enabled = true; //make the player animation continue

            yield return null;
        }

    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (gameObject.CompareTag("Warp_UD"))
        {
            isReadyToWarp = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (gameObject.CompareTag("Warp_UD"))
        {
            isReadyToWarp = false;
        }
    }

    private IEnumerator warpUpDown()
    {
        WarpFader wf = GameObject.FindObjectOfType<WarpFader>();

        audioS.Play();

        playerCol.GetComponent<Animator>().enabled = false; //make the player animation stop

        playerCol.GetComponent<PT_PlayerPlatformerController>().StopMovement();

        yield return StartCoroutine(wf.Fadein()); //starting fading process with a coroutine

        playerCol.gameObject.transform.position = warpTarget.position; //make player position the same as the warp destination position
        Camera.main.transform.position = new Vector3(warpTarget.position.x, warpTarget.position.y, Camera.main.transform.position.z); //make the camera position the same as the warp destination position

        //StartCoroutine (textArea.GetComponent<AreaText>().ShowAreaText(targetMap.name)); //let the are text appear and do it magic :D

        yield return StartCoroutine(wf.Fadeout()); //ending the fading process with a coroutine

        playerCol.GetComponent<PT_PlayerPlatformerController>().ContinueMovement();

        playerCol.GetComponent<Animator>().enabled = true; //make the player animation continue

        yield return null;
    }

    // Update is called once per frame
    void Update()
    {
        if (isReadyToWarp && Input.GetKeyDown(KeyCode.UpArrow))
        {
            StartCoroutine(warpUpDown());
        }
    }

}// End of class Warp

