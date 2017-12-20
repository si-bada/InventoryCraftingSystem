using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotController : MonoBehaviour {
	public Vector2 coords;
	// Use this for initialization
	void Start () {
		
	}

	void OnMouseEnter(){
		if(!Input.GetMouseButtonDown(0)&&Camera.main.ScreenToWorldPoint(Input.mousePosition).x < transform.GetComponent<RectTransform> ().rect.width
			&& Camera.main.ScreenToWorldPoint(Input.mousePosition).y < transform.GetComponent<RectTransform> ().rect.height){
			transform.parent.GetComponent<inventoryControllr> ().selectedSlot = this.transform;

		}
	}

}
