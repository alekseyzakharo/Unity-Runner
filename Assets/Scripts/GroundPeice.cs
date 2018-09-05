using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundPeice : MonoBehaviour {
    public Material material;


	// Use this for initialization
	void Start () {
        //change color of all prefab parts (children) of this prefab

        

        for (int i = 0;i < transform.childCount; i++)
            transform.GetChild(i).GetComponent<Renderer>().material.color = Color.HSVToRGB(5f * Game.speed, 5f * Game.speed, 5f * Game.speed);
    }
	
	// Update is called once per frame
	void Update () {
        if (transform.position.z < -19)
        {
            GameObject.Find("Main Camera").SendMessage("createNextFloor");
            Destroy(gameObject);
        }
        transform.Translate(0, 0, -Game.speed);
	}
}
