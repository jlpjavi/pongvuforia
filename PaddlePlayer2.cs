using UnityEngine;
using System.Collections;

public class PaddlePlayer2 : MonoBehaviour {
	public int speed = 50;
	private Vector3 movement;
	private bool limitleft = false, limitright = false;
	private GameObject wall_left, wall_right;
	// Use this for initialization
	void Start () {
		
	}
	
//	 void OnCollisionEnter(Collision collision) {
//		Debug.LogError("Entra en la derecha");
//        if (collision.gameObject.CompareTag("RWall")){
//			Debug.LogError("Entra en la derecha");
//		}
//		else if (collision.gameObject.CompareTag("LWall")){
//			Debug.LogError("Entra en la izquierda");
//		}
//			
//    }
//	void OnCollisionEnter(Collision  collision) {
//		 if (collision.gameObject.CompareTag("Wall1")){
//		 	limitright = true;
//		 }	
//		 else if (collision.gameObject.CompareTag("Wall2" )) {
//			limitleft = true;
//		 }	
//    }
//	
//	void OnCollisionExit(Collision collision) {
//        if (collision.gameObject.CompareTag("Wall1")){
//		 	limitright = false;
//		 }	
//		 else if (collision.gameObject.CompareTag("Wall2" )) {
//			limitleft = false;
//		 }		
//			
//    }
		
//	 void OnCollisionExit(Collision collision) {
//		Debug.LogError("Sale de la derecha");
//        if (collision.gameObject.CompareTag("RWall")){
//				Debug.LogError("Sale de la derecha");
//		}
//		else if (collision.gameObject.CompareTag("LWall")){
//				Debug.LogError("Sale de la izquierda");
//		}
//			
//	}
	
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey("right")){		
			 if (this.transform.localPosition.x > -0.386f){
				 movement = Vector3.left;
				 this.transform.Translate(movement * 500 * Time.deltaTime);

			 }
			
		}
		if (Input.GetKey("left")){		
			 if (this.transform.localPosition.x < 0.386f){ 
				 movement = Vector3.right; 
				 this.transform.Translate(movement * 500 * Time.deltaTime);
			 }
		}
	}
}
