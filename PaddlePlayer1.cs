using UnityEngine;
using System.Collections;

public class PaddlePlayer1 : MonoBehaviour {
	public int speed = 50;
	private Vector3 movement;
	private RaycastHit hit;
	private bool selected = false;
	
	
	// Use this for initialization
	void Start () {
	  hit = new RaycastHit();
	}
	

	void FixedUpdate () {
	
		if (Input.GetKey("right")){		
			 if (this.transform.localPosition.x < 0.326f){
				 movement = Vector3.right;
				 this.transform.Translate(movement * 500 * Time.deltaTime);
			}			
		}
		if (Input.GetKey("left")){		
			  if (this.transform.localPosition.x > -0.326f){
				 movement = Vector3.left; 
				 this.transform.Translate(movement * 500 * Time.deltaTime);
			 }
		}
		if(Input.GetMouseButton(0)){
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			if (Physics.Raycast (ray, out hit)) {					
				if(hit.collider.gameObject.CompareTag("RedPad")){
					selected = true;
				} 
			}
			if (selected){
				Vector3 mousepos = Input.mousePosition;
				Transform camTransform = Camera.main.transform;
				Vector3 move = Camera.main.ScreenToWorldPoint(new Vector3 (mousepos.x, mousepos.y,
					camTransform.position.y - this.transform.position.y)) - this.transform.position;
				move.y = 0.0f;
				move.z = 0.0f;
				Vector3 newPosition = this.rigidbody.position + move;
				if ((newPosition.x > -525f) && (newPosition.x < 525f) ){
					this.rigidbody.transform.Translate(move);

				}

			}
			
		}
		foreach (Touch touch in Input.touches) {
			if (touch.phase == TouchPhase.Began) {
				// Construct a ray from the current touch coordinates
				Ray ray = Camera.main.ScreenPointToRay (touch.position);
				if (Physics.Raycast (ray, out hit)) {					
					if(hit.collider.gameObject.CompareTag("RedPad")){
						selected = true;
					}
				}
			}
			else if( touch.phase == TouchPhase.Moved){
				if (selected){
					Vector3 touchpos = touch.position;
					Transform camTransform = Camera.main.transform;
					Vector3 move = Camera.main.ScreenToWorldPoint(new Vector3 (touchpos.x, touchpos.y, 
						camTransform.position.y - this.transform.position.y)) - this.transform.position;
					move.y = 0.0f;
					move.z = 0.0f;
					Vector3 newPosition = this.rigidbody.position + move;
					if ((newPosition.x > -525f) && (newPosition.x < 525f) ){
						this.rigidbody.transform.Translate(move);
						
					}
				}
			}			
			else if( touch.phase == TouchPhase.Ended){
				selected = false;
			}
		}
		
	}
}
