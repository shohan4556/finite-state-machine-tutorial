﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieAI : MonoBehaviour {

	public bool isSeenPlayer = false;
	public bool isInRange = false;
	public Transform target; // player
	public float SightRange = 10f;
	public float SightAngle = 45f; // eye sight angle 
	public GameObject[] waypoints;

	private float agentSpeed;	
	private Animator animator;
	private NavMeshAgent agent;


	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
		agent = GetComponent<NavMeshAgent>();

		//agent.updateRotation = false;
		agentSpeed = agent.speed;
		agent.updateRotation = false;

	}
	
	// Update is called once per frame
	void Update () {
		isSeenPlayer = eyeSight();
		
		if(agent.desiredVelocity.magnitude > Mathf.Epsilon){
			//Vector3 localRot = transform.InverseTransformDirection(agent.desiredVelocity);
			Quaternion lookRot = Quaternion.LookRotation(agent.desiredVelocity, Vector3.up);
			transform.rotation = Quaternion.Slerp(transform.rotation, lookRot, Time.deltaTime * 5f);
		}
	}

	public bool eyeSight(){
		Vector3 direction = target.position - this.transform.position;
		float angle = Vector3.Angle(direction, this.transform.forward);

		if(direction.magnitude < SightRange && angle < SightAngle){
			
			Quaternion lookRotation = Quaternion.LookRotation(direction, Vector3.up);
			transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, 2f*Time.deltaTime);
			return true;
		}

		return false;
	}

	/// <summary>
	/// Callback for processing animation movements for modifying root motion.
	/// </summary>
	void OnAnimatorMove()
	{
		agent.velocity = animator.deltaPosition/Time.deltaTime;
		//Debug.Log(agent.velocity);
	}

	public bool inRange(){
		return false;	
	}

	

}
