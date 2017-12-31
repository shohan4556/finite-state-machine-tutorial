using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour {

	private NavMeshAgent agent; // player 
	private Animator animator;

	// Use this for initialization
	void Start () {
		agent = GetComponent<NavMeshAgent>();
		animator = GetComponent<Animator>();
		
	}
	
	// Update is called once per frame
	void Update () {
	
		if(Input.GetMouseButtonDown(0)){
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hitinfo;

			if(Physics.Raycast(ray.origin, ray.direction, out hitinfo)){
				//Debug.Log("hit");
				
			}	
		}

	
	} //end 




}
