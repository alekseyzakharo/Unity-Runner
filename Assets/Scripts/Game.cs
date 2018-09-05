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

    public GameObject path;
    public GameObject obstacles;

    // Use this for initialization
    void Start () {

        speed = 0.2f;
        gameScore = 0;

        scoreText = GameObject.Find("Score").GetComponents<Text>()[0]; 
        speedText = GameObject.Find("Speed").GetComponents<Text>()[0];

        path = GameObject.Find("Path");
        obstacles = GameObject.Find("Obstacles");


        createPath();
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

    public void createNextFloor()
    {
        Transform last = path.transform.GetChild(path.transform.childCount-1);

        GameObject currentFloor = Instantiate((GameObject)Resources.Load("GroundPiece"));
        currentFloor.transform.Translate(0, 0, last.position.z + 20);
        GameObject obstacle = Instantiate((GameObject)Resources.Load("Obstacle"));
        int randZ = Random.Range(-8, 8);
        int randX = Random.Range(-6, 6);
        obstacle.transform.Translate(randX, 3, last.position.z + randZ);

        currentFloor.transform.parent = path.transform;
        obstacle.transform.parent = obstacles.transform;

        speed += SPEEDINCRESE;
        gameScore += POINTINCREASE;

        scoreText.text = "Score: " + gameScore.ToString();
        speedText.text = "Speed: " + speed.ToString("0.##");
    }

}
