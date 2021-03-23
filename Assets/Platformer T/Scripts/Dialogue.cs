using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue {

	[SerializeField] private Sprite icon;
	[SerializeField] private string name;
	[SerializeField, TextArea(3, 10)] private string[] sentences;

	public Sprite Icon {
		get {
			return icon;
		}
	}
	
	public string Name {
		get {
			return name;
		}
	}

	public string[] Sentences {
		get {
			return sentences;
		}
	}
}
