using System.Collections;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CraftItemController : MonoBehaviour {
	public string name;
	public Sprite sprite;
	public int count=0;
	public Text countTEXT;
	public Vector2 coords;
	public string mytype;



	void OnMouseDown(){  //select an item 
		//if i'm moving a compound
		if (mytype == "compound" && CraftController._instance.selectedPanel == null && CraftController._instance.otherPanel.GetComponent<CraftController> ().selectedPanel == null) {
			transform.parent.parent.Find("items").Find("item_panel").GetComponent<CraftController> ().selectedItem = this.transform;
			transform.parent.parent.Find("items").Find("item_panel").GetComponent<CraftController> ().otherPanel.GetComponent<CraftController> ().selectedItem=this.transform;
		} else {//if i'm moving a component
			transform.parent.parent.GetComponent<CraftController> ().selectedItem = this.transform;
			transform.parent.parent.GetComponent<CraftController> ().otherPanel.GetComponent<CraftController> ().selectedItem=this.transform;
		}

	}
}

