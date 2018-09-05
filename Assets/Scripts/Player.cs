using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

    static Animator anim;

    public float speed = 5.0f;
    public float rotSpeed = 75.0f;

    public Vector2 firstPressPos;
    public Vector2 secondPressPos;
    public Vector2 currentSwipe;

    // Use this for initialization
    void Start ()
    {
        anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update ()
    {
       

        float translation = Input.GetAxis("Horizontal") * speed;

        translation *= Time.deltaTime;

        transform.Translate(translation,0 , 0);
   
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

    public void swipe()
    {
        if (Input.touches.Length > 0)
        {
            Touch t = Input.GetTouch(0);
            if (t.phase == TouchPhase.Began)
            {
                //save began touch 2d point
                firstPressPos = new Vector2(t.position.x, t.position.y);
            }
            if (t.phase == TouchPhase.Ended)
            {
                //save ended touch 2d point
                secondPressPos = new Vector2(t.position.x, t.position.y);

                //create vector from the two points
                currentSwipe = new Vector3(secondPressPos.x - firstPressPos.x, secondPressPos.y - firstPressPos.y);

                //normalize the 2d vector
                currentSwipe.Normalize();

                //swipe left
                if (currentSwipe.x < 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f)
                {
                    transform.Translate(transform.position.x + 5.0f, 0, 0);
                }
                //swipe right
                if (currentSwipe.x > 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f)
                {
                    transform.Translate(transform.position.x - 5.0f, 0, 0);
                }
            }
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
