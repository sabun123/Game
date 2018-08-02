using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ChangeText : MonoBehaviour {

    Text messageUI;

	// Use this for initialization
	void Start () {
        messageUI = gameObject.GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void updateText(string message)
    {
        Debug.Log("Message passed in was " + message);
        messageUI.text = message;
    }
}
