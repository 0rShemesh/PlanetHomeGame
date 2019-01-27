using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowing : MonoBehaviour {

    public GameObject player;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void LateUpdate()
    {

        Vector3 xy = new Vector3(player.transform.position.x, player.transform.position.y,-10);
        this.transform.position = xy;




    }
}
