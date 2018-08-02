using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ExitGame : MonoBehaviour {

    Button exit;

	// Use this for initialization
	void Start () {
        // Grab the button component of this game object
        exit = gameObject.GetComponent<Button>();
        // Add a listener function for the onclick event
        exit.onClick.AddListener(OnClick);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnClick()
    {
        Application.Quit();
    }
}
