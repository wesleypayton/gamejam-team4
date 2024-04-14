using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerBees : MonoBehaviour
{
	public GameObject swarm;
    public Bee beeSeverity;

	private AudioSource audioSource;
	private float count;
	private float increment;

    void Start()
    {
		audioSource = GetComponent<AudioSource>();
		count = 0;
		increment = -1;
		swarm.SetActive(false);
    }
	
	void Update(){
		if(swarm.activeSelf && count == 50){
			swarm.transform.Translate(Vector3.up * Time.deltaTime);
			swarm.transform.Translate(Vector3.up * Time.deltaTime);
			swarm.transform.Translate(Vector3.up * Time.deltaTime);
			increment = increment * -1;
		}
		
		if(swarm.activeSelf && count == 0){
			swarm.transform.Translate(Vector3.down * Time.deltaTime);
			swarm.transform.Translate(Vector3.down * Time.deltaTime);
			swarm.transform.Translate(Vector3.down * Time.deltaTime);
			increment = increment * -1;
		}
		
		if(swarm.activeSelf){
			count = count + increment;
		}
		
	}
	
	// make sure the bee particle effects activate on the flower when in range
	private void OnTriggerEnter(Collider collider){
		audioSource.Play();
		swarm.SetActive(true);
        beeSeverity.DecreaseSeverity();
    }
}
