using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundPeice : MonoBehaviour {
    public Material material;
    public GameObject gameScript;

	// Use this for initialization
	void Start () {
        //change color of all prefab parts (children) of this prefab
        for (int i = 0;i < transform.childCount; i++)
            transform.GetChild(i).GetComponent<Renderer>().material.color = Color.HSVToRGB(5f * Game.speed, 5f * Game.speed, 5f * Game.speed);

        gameScript = GameObject.Find("malcolm").transform.Find("Main Camera").gameObject;
    }
	
	// Update is called once per frame
	void Update () {
        if (transform.position.z < -19)
        {
            gameScript.SendMessage("createNextFloor");
            Destroy(gameObject);
        }
        transform.Translate(0, 0, -Game.speed);
	}
}
