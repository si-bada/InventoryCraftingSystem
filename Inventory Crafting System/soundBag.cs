using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundBag : MonoBehaviour {

	AudioSource audio;

	// Use this for initialization
	void Start () {
		audio = GetComponent<AudioSource> ();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator OnTriggerEnter2D(Collider2D other){
		if (other.CompareTag ("item")) {
			if (other.gameObject.GetComponent<FollowPath> ().enabled) {
				audio.Play ();
				Destroy (other.gameObject);
				this.GetComponent<Animator> ().enabled = true;
				yield return new WaitForSeconds (2.65f);
				this.GetComponent<Animator> ().enabled = false;

			}


		}


	}
}
