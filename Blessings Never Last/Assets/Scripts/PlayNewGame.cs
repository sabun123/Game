using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class PlayNewGame : MonoBehaviour {

    Button thisButton;
    public GameObject loadingPanel;
    public int sceneNumber;

	// Use this for initialization
	void Start () {
        // Grab the button component off this UI element
        // that this script is attached to
        thisButton = gameObject.GetComponent<Button>();
        // Attach a listener
        thisButton.onClick.AddListener(OnClick);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnClick()
    {
        // Show the loading screen panel
        loadingPanel.SetActive(true);
        // Fire off the scene loading behind the scenes
        StartCoroutine(LoadNewScene());
    }

    // Coroutine for loading
    IEnumerator LoadNewScene()
    {
        //AsyncOperation async = Application.LoadLevelAsync(sceneNumber);
        AsyncOperation async = SceneManager.LoadSceneAsync(sceneNumber);

        // While the scene is still loading, keep repeating this coroutine running.
        while (!async.isDone)
        {
            yield return null;
        }
    }
}
