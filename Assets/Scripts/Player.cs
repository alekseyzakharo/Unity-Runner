using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

    public float thrust = 5.0f;
    const float THRESHOLD = 5.0f;
    const float PLAYERBOUNDARY = 8.0f;
    
    public float firstPressPos;
    public float delta;

    public Rigidbody rb;

    // Use this for initialization
    void Start ()
    {
        rb = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if(Input.GetMouseButtonDown(0))
        {
            firstPressPos = Input.mousePosition.x;
        }
        
        if(Input.GetMouseButtonUp(0))
        {
            delta = firstPressPos - Input.mousePosition.x;

            if(System.Math.Abs(delta) > THRESHOLD)
            {
                if (transform.position.x < PLAYERBOUNDARY && transform.position.x > -PLAYERBOUNDARY)
                {
                    //if (delta > 0)
                    //    transform.Translate(transform.position.x + 1, 0, 0);
                    //else
                    //    transform.Translate(transform.position.x - 1, 0, 0);
                    if (delta > 0)
                    {
                        rb.AddForce(transform.right * thrust);
                        Debug.Log("force right");
                    }
                    else
                    {
                        rb.AddForce(-transform.right * thrust);
                        Debug.Log("force left");
                    }
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
