using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour {

	[SerializeField] private string sceneName;

	// Use this for initialization
	void Start () {

		if(SceneManager.GetSceneByName ("Company_Logo").isLoaded){
			Invoke ("ChangeScene", 3.5f);
		}
		
	}

	public void ChangeScene () {
		SceneLoader.instance.LoadSpecificScene (sceneName);
	}
	
	// Update is called once per frame
	void Update () {

		if(SceneManager.GetSceneByName ("Game_Intro").isLoaded){
			if(Input.GetKeyDown (KeyCode.C)){
				ChangeScene ();
			}
		}
		
	}
}
