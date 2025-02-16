using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine.AI;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions {

	public class RoamAT : ActionTask {
		public float roamRadius;
		private NavMeshAgent navAgent;
		public Material mouseMat;
		//Use for initialization. This is called only once in the lifetime of the task.
		//Return null if init was successfull. Return an error string otherwise
		protected override string OnInit() {
			navAgent = agent.GetComponent<NavMeshAgent>();
			mouseMat = agent.GetComponent<Material>();
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
			// Mouse material changes to light brown color
			mouseMat.color = new Color(135, 106, 101);
			// Mouse picks a random point on the NavMesh and moves to it
			Vector3 randomPoint = Random.insideUnitSphere * roamRadius + agent.transform.position;
			NavMeshHit navHit;
			if(!NavMesh.SamplePosition(randomPoint, out navHit, roamRadius, NavMesh.AllAreas))
			{
				return;
			}
			navAgent.SetDestination(navHit.position);
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
			// If the remaining distance is within stopping distance, stop moving
			if(!navAgent.pathPending && navAgent.remainingDistance <= navAgent.stoppingDistance)
			{
                EndAction(true);
            }
		}

		//Called when the task is disabled.
		protected override void OnStop() {
			
		}

		//Called when the task is paused.
		protected override void OnPause() {
			
		}
	}
}