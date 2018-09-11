using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour {

    const float SPEEDINCRESE = 0.005f;
    const float POINTINCREASE = 10f;

    public static float speed;

    private float gameScore;

    public Text scoreText;
    public Text speedText;
    public Text splashtext;

    public GameObject path;
    public GameObject obstacles;

    // Use this for initialization
    void Start () {

        speed = 0;
        gameScore = 0;

        scoreText = GameObject.Find("Score").GetComponents<Text>()[0]; 
        speedText = GameObject.Find("Speed").GetComponents<Text>()[0];
        splashtext = GameObject.Find("SplashText").GetComponent<Text>();

        path = GameObject.Find("Path");
        obstacles = GameObject.Find("Obstacles");

        createPath();

        StartCoroutine(countdown());
    }
	
	// Update is called once per frame
	void Update () {
    }

    private void createPath()
    {
        for (int i = 0; i < 5; i++)
        {
            GameObject currentFloor = Instantiate((GameObject)Resources.Load("GroundPiece"));
            currentFloor.transform.Translate(0, 0, i * 20);
            currentFloor.transform.parent = path.transform;

            if (i == 0)
                continue;
            GameObject obstacle = Instantiate((GameObject)Resources.Load("Obstacle"));
            int randZ = Random.Range(-8, 8);
            int randX = Random.Range(-6, 6);
            obstacle.transform.Translate(randX, 3, (i * 20) + randZ);

            obstacle.transform.parent = obstacles.transform;
        }      
    }

    private IEnumerator countdown()
    {
        splashtext.enabled = true;
        for(int i = 3;i > 0;i--)
        {
            splashtext.text = i.ToString(); ;
            yield return new WaitForSeconds(1);
        }
        splashtext.enabled = false;

        //start the speed
        speed = 0.2f;

        //transition to running animation
        GameObject.Find("malcolm").GetComponent<Animator>().SetBool("IsRunning", true);
    }


    public void createNextFloor()
    {
        Transform last = path.transform.GetChild(path.transform.childCount-1);

        GameObject currentFloor = Instantiate((GameObject)Resources.Load("GroundPiece"));
        currentFloor.transform.Translate(0, 0, last.position.z + 20);

        GameObject obstacle = Instantiate((GameObject)Resources.Load("Obstacle"));

        //randomize obstacle position
        int randZ = Random.Range(-8, 8);
        int randX = Random.Range(-6, 6);
        obstacle.transform.Translate(randX, 3, last.position.z + randZ);

        //place new gameobject into proper hierachical position
        currentFloor.transform.parent = path.transform;
        obstacle.transform.parent = obstacles.transform;

        //update point/speed/texts
        speed += SPEEDINCRESE;
        gameScore += POINTINCREASE;
        scoreText.text = "Score: " + gameScore.ToString();
        speedText.text = "Speed: " + speed.ToString("0.##");
        
    }

    //allow other objects to set the speed of the game
    public void setSpeed(float newSpeed)
    {
        speed = newSpeed;
    }
}
