using UnityEngine;
using System.Collections;


public class Ball : MonoBehaviour {
	private Vector3 direction;
	private Vector3 vect;

	
	// Use this for initialization
	void Start () {
		Init ();
			
	}

	void Init(){
		float Dirx = Random.Range(10.0f , 15.0f);
		float Dirz = Random.Range(0,2);
		if (Dirz == 0){
			vect = new Vector3( Dirx, 0, 10.0f);
		}
		else {
			vect = new Vector3( Dirx, 0, -10.0f);
		}
		rigidbody.velocity = vect * 20;


	}
	 void OnCollisionEnter(Collision collision) {
		if (collision.gameObject.CompareTag("TopWall")){
			GameLogic.Instance.player1score +=1;
			GameLogic.Instance.instantiateBall();
			Destroy(gameObject);
		}
		else if (collision.gameObject.CompareTag("BottomWall")){
			GameLogic.Instance.player2score +=1;
			GameLogic.Instance.instantiateBall();
			Destroy(gameObject);

		}
		else if (Mathf.Abs(rigidbody.velocity.magnitude) < 1500){
			if (collision.gameObject.CompareTag("RedPad") || collision.gameObject.CompareTag("GreenPad")){
				if (collision.gameObject.CompareTag("RedPad")){
					rigidbody.AddForce(new Vector3 (0.0f,0.0f,-1.0f) , ForceMode.Impulse) ;
				}
				else 
					rigidbody.AddForce(new Vector3 (0.0f,0.0f,1.0f) , ForceMode.Impulse) ;
			}
			else {
					rigidbody.velocity = rigidbody.velocity * 1.10f;
			}
		}
    }
	
	// Update is called once per frame
	void Update () {

	}
}

