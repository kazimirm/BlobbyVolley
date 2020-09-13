using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zem : MonoBehaviour {

	public static Logger LOGGER;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerEnter2D(Collider2D col)
    {
      Debug.Log(gameObject.name + "collided with a ground");
    }


    }

