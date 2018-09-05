using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Obstacle : MonoBehaviour
{
    GameObject player;
    // Use this for initialization
    void Start()
    {
        player = GameObject.Find("malcolm");
    }

    // Update is called once per frame
    void Update()
    {
        if ((transform.position.z < -20))
            Destroy(gameObject);
        transform.Translate(0, 0, -Game.speed);
    }
}
