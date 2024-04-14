using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSwarm : MonoBehaviour
{
	
	public GameObject bee1;
	public GameObject bee2;
	public GameObject bee3;
	public GameObject bee4;
	public GameObject bee5;
	public GameObject bee6;
	public GameObject bee7;
	public GameObject bee8;
	public GameObject bee9;
	public GameObject GameManager;
	
    // Start is called before the first frame update
    void Start()
    {
        bee1.SetActive(false);
		bee2.SetActive(false);
		bee3.SetActive(false);
		bee4.SetActive(false);
		bee5.SetActive(false);
		bee6.SetActive(false);
		bee7.SetActive(false);
		bee8.SetActive(false);
		bee9.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }
	
	private void swarm(){
		
	}
}
