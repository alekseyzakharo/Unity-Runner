using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class Player : MonoBehaviour {

    public float moveDist = 5.0f;

    private const float THRESHOLD = 0.10f; //percentage representation of screen swipe distance
    private const float PLAYERBOUNDARY = 8.0f;
    
    private float firstPressPos;
    private float delta;

    private Vector3 destination;
    private float lerpSpeed = 10.0f;

    private float screenWidth;
    private float swipeStrength;

    float x, y, z;

    // Use this for initialization
    void Start ()
    {
        Screen.orientation = ScreenOrientation.Portrait;
        screenWidth = Screen.width;
    }
	
	// Update is called once per frame
	void Update ()
    {
        transform.position = Vector3.Lerp(transform.position, destination, lerpSpeed * Time.deltaTime);

        if (Input.GetMouseButtonDown(0))
        {
            firstPressPos = Input.mousePosition.x;
        }
        
        if(Input.GetMouseButtonUp(0))
        {
            delta = firstPressPos - Input.mousePosition.x;

            swipeStrength = delta / screenWidth;

            if (Math.Abs(swipeStrength) > THRESHOLD)
            {
                if (transform.position.x < PLAYERBOUNDARY && transform.position.x > -PLAYERBOUNDARY)
                {
                    y = transform.position.y;
                    z = transform.position.z;
                    if (delta > 0)
                    {
                        x = destination.x + (moveDist * swipeStrength);
                        if (x > PLAYERBOUNDARY)
                            x = PLAYERBOUNDARY;
                        //destination = new Vector3(x, y, z);
                        //Debug.Log("right" + destination.ToString() + " " + transform.position.ToString());
                    }
                    else
                    {
                        x = destination.x - moveDist;
                        if (x < -PLAYERBOUNDARY)
                            x = -PLAYERBOUNDARY;
                        //destination = new Vector3(destination.x - moveDist, y, z);
                        //Debug.Log("left" + destination.ToString() + " " + transform.position.ToString());
                    }
                    destination = new Vector3(x, y, z);
                    Debug.Log("moved" + destination.ToString() + " " + transform.position.ToString());
                }
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Obstacle")
        {
            Text gameover = GameObject.Find("GameOver").GetComponent<Text>();
            gameover.enabled = true;
            ModeSelect();
        }
    }
 
    public void ModeSelect()
    {
        StartCoroutine(LoadAfterDelay("Start"));
    }

    IEnumerator LoadAfterDelay(string levelName)
    {
        yield return new WaitForSeconds(03); // wait 1 seconds
        SceneManager.LoadScene(levelName);
    }

    

}
