using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    private float timeElapsed = 0.0f;
    private float air = 100.0f;
    private float bat = 100.0f;
    private float timeLeft = 0.0f;
    public bool moving = false;

    private Animator anim;
		private CharacterController controller;

		public float speed = 600.0f;
		public float turnSpeed = 400.0f;
		private Vector3 moveDirection = Vector3.zero;
		public float gravity = 20.0f;

		void Start () {
			controller = GetComponent <CharacterController>();
			anim = gameObject.GetComponentInChildren<Animator>();
		}

		void Update (){
			if (Input.GetKey ("w")) {
				anim.SetInteger ("AnimationPar", 1);
                moving = true;
			}  else {
				anim.SetInteger ("AnimationPar", 0);
                moving = false;
			}

			if(controller.isGrounded){
				moveDirection = transform.forward * Input.GetAxis("Vertical") * speed;
                moving = true;
			}

            if (Input.GetAxis("Vertical")< 1)
                { moving = false; }

            float turn = Input.GetAxis("Horizontal");
			transform.Rotate(0, turn * turnSpeed * Time.deltaTime, 0);
			controller.Move(moveDirection * Time.deltaTime);
			moveDirection.y -= gravity * Time.deltaTime;

            timeElapsed += Time.deltaTime;
            air -= Time.deltaTime / 2;
            if (moving)
            {
                bat -= Time.deltaTime;
            }
            timeLeft = Mathf.Min(bat, air);
        }

        void OnGUI()
        {
            GUI.Label(new Rect(10, 10, 250, 100), "Time on mission: " + Mathf.RoundToInt(timeElapsed));
            GUI.Label(new Rect(10, 25, 250, 100), "Air: " + Mathf.RoundToInt(air));
            GUI.Label(new Rect(10, 40, 250, 100), "Battery: " + Mathf.RoundToInt(bat));
            GUI.Label(new Rect(10, 55, 250, 100), "Time to return to station: " + Mathf.RoundToInt(timeLeft));


        }
}
