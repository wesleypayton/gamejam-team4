using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPosition : MonoBehaviour
{
	public GameObject player;
	public GameObject camera;
	public float initialX;
	public float initialY;
	public float initialZ;

    void Start()
    {
        initialX = player.transform.position.x;
		initialY = player.transform.position.y;
		initialZ = player.transform.position.z;
    }

    void Update()
    {
        
    }
	
	private void OnTriggerEnter(Collider other){
		camera.transform.position = new Vector3(initialX,initialY,initialZ);
		player.transform.position = new Vector3(initialX,initialY,initialZ);
	}
}
