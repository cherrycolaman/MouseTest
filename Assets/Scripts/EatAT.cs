using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class EatAT : ActionTask {
        public BBParameter<GameObject> cheese;
        private float timer;
        public float eatingTime;
        public BBParameter<Material> mouseMat;
        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit() {
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
            timer = 0f;
            // Mouse is supposed to change to an orange-brown color
            mouseMat.value.color = new Color(191, 134, 54);
        }

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
            // Mouse eats cheese for about 3 seconds before cheese respawns elsewhere
            timer += Time.deltaTime;
            if (timer >= eatingTime)
            {
                Cheese cheeseScript = cheese.value.GetComponent<Cheese>();
                cheeseScript.SpawnCheese();
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