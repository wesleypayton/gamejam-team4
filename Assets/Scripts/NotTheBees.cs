using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotTheBees : MonoBehaviour
{
	public ParticleSystem bees;
	
    void Start()
    {

    }
	
	// make sure the bee particle effects activate on the flower when in range
	private void OnCollisionEnter(Collision collision){
		bees.Play();
	}
}
