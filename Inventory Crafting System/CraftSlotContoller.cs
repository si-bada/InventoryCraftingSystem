using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftSlotContoller : MonoBehaviour {
	public Vector2 coords;

	//select a slot , NOTE : THIS ACTION MUST BE DONE IN THE TWO PANELS - CRAFT & ITEM
	void OnMouseEnter(){ 
		if(!Input.GetMouseButtonDown(0)&&Camera.main.ScreenToWorldPoint(Input.mousePosition).x < transform.GetComponent<RectTransform> ().rect.width
			&& Camera.main.ScreenToWorldPoint(Input.mousePosition).y < transform.GetComponent<RectTransform> ().rect.height){
			transform.parent.GetComponent<CraftController> ().selectedSlot = this.transform;
			transform.parent.GetComponent<CraftController> ().otherPanel.GetComponent<CraftController> ().selectedSlot=this.transform;

		}
	}

}

