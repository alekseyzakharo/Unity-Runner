using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class StartGame : MonoBehaviour {

    Button start;
    Button exit;

    // Use this for initialization
    void Start () {
        start = GameObject.Find("Start").GetComponent<Button>();
        exit = GameObject.Find("Exit").GetComponent<Button>();
        start.onClick.AddListener(startGame);
        exit.onClick.AddListener(exitGame);
    }
	
	// Update is called once per frame
	void Update () {
		
	}


    void startGame()
    {
        SceneManager.LoadScene("Scene1");
    }

    void exitGame()
    {
        Application.Quit();
    }
}
