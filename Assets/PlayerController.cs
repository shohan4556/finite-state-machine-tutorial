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
				Debug.Log("hit");
				SetAgentDest(hitinfo.point);
			}	
		}

		// mechanim with navmesh agent 
		if(agent.desiredVelocity.sqrMagnitude > Mathf.Epsilon){
			Quaternion lookRotation = Quaternion.LookRotation(agent.desiredVelocity, Vector3.up);
			transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, 2f*Time.deltaTime);
		}

		// play current animation state
		// Debug.Log(agent.velocity.magnitude);
		float syncVel = Mathf.Round(agent.velocity.sqrMagnitude * 100f)/100f;
		animator.SetFloat("speed", syncVel);

	
	} //end 

	public void SetAgentDest(Vector3 posToMove){
		//if(agent.remainingDistance < 0.25f){
			agent.ResetPath();
			agent.destination = posToMove;
	//	}
		//Debug.Log(posToMove);
	}


}
