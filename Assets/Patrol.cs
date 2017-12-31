using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Patrol : StateMachineBehaviour {

	//public GameObject[] waypoints;
	NavMeshAgent agent;
	public float accuray = 2;
	public int currentWP = 0;
	public ZombieAI zombieAI;


	void Awake(){
		//waypoints = GameObject.FindGameObjectsWithTag("waypoint");
		
	}

	//OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {

		zombieAI = animator.gameObject.GetComponent<ZombieAI>();
		agent = animator.gameObject.GetComponent<NavMeshAgent>();
		currentWP = 0;
	}

	// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		if(zombieAI.waypoints.Length == 0){
			return;
		}

		if(Vector3.Distance(agent.transform.position, zombieAI.waypoints[currentWP].transform.position)<accuray){
			currentWP ++;
			if(currentWP >= zombieAI.waypoints.Length){
				currentWP = 0;
			}
			Debug.Log("current WP : "+currentWP);
		}

		if(!agent.pathPending && agent.remainingDistance < 1f){
			agent.ResetPath();
			agent.destination = (zombieAI.waypoints[currentWP].transform.position);
			Debug.Log("current WP : "+currentWP);
		}
	}

	// OnStateExit is called when a transition ends and the state machine finishes evaluating this state
	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	
	}

	// OnStateMove is called right after Animator.OnAnimatorMove(). Code that processes and affects root motion should be implemented here
	//override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}

	// OnStateIK is called right after Animator.OnAnimatorIK(). Code that sets up animation IK (inverse kinematics) should be implemented here.
	//override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}
}
