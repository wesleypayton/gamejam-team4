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
	private float activeBee = 1;
	private float interrupter = 0;
	private Bee script; // script attatched to GameManager
	
    // Start is called before the first frame update
    void Start()
    {
		script = GameObject.FindObjectOfType<Bee>();
        bee1.SetActive(true);
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
		if(script.severity.ToString() == "Low" && interrupter == 50){
			swarm();
		}
		
		if(script.severity.ToString() == "Medium" && (interrupter == 0 || interrupter == 50 || interrupter == 100)){
			swarm();
		}
		
		if(script.severity.ToString() == "High" && (interrupter == 0 || interrupter == 25 || interrupter == 50 || interrupter == 100)){
			swarm();
		}
		
		interrupter = interrupter + 5;
		
		if (interrupter == 100){
			interrupter = 0;
		}
    }
	
	private void swarm(){
		switch(activeBee){
			case 1:
				bee1.SetActive(false);
				bee2.SetActive(true);
				activeBee = activeBee + 1;
				break;
			case 2:
				bee2.SetActive(false);
				bee3.SetActive(true);
				activeBee = activeBee + 1;
				break;
			case 3:
				bee3.SetActive(false);
				bee4.SetActive(true);
				activeBee = activeBee + 1;
				break;
			case 4:
				bee4.SetActive(false);
				bee5.SetActive(true);
				activeBee = activeBee + 1;
				break;
			case 5:
				bee5.SetActive(false);
				bee6.SetActive(true);
				activeBee = activeBee + 1;
				break;
			case 6:
				bee6.SetActive(false);
				bee7.SetActive(true);
				activeBee = activeBee + 1;
				break;
			case 7:
				bee7.SetActive(false);
				bee8.SetActive(true);
				activeBee = activeBee + 1;
				break;
			case 8:
				bee8.SetActive(false);
				bee9.SetActive(true);
				activeBee = activeBee + 1;
				break;
			case 9:
				bee9.SetActive(false);
				bee1.SetActive(true);
				activeBee = 1;
				break;
			
		}
	}
}
