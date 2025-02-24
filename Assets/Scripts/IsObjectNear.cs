using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Conditions {

	public class IsObjectNear : ConditionTask {
        public float detectionRadius;
        public LayerMask targetMask;
        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit(){
			return null;
		}

		//Called whenever the condition gets enabled.
		protected override void OnEnable() {
			
		}

		//Called whenever the condition gets disabled.
		protected override void OnDisable() {
			
		}

		//Called once per frame while the condition is active.
		//Return whether the condition is success or failure.
		protected override bool OnCheck() {
            // Searches for either a player or cheese depending on the context, within a certain detection radius
            // Returns true if the object is within the radius
            Collider[] colliders;
            colliders = Physics.OverlapSphere(agent.transform.position, detectionRadius, targetMask);
            if (colliders.Length > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
	}
}