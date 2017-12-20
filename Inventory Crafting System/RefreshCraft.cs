using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RefreshCraft : MonoBehaviour {
	public static RefreshCraft  _instance;
	void start(){
		_instance = this;
	}

	public void Refresh(){
		if (CraftController._instance.selectedPanel) {
			CraftController._instance.selectedPanel.gameObject.GetComponent<CraftController> ().createInventory ();
			CraftController._instance.selectedPanel.gameObject.GetComponent<CraftController> ().
			otherPanel.GetComponent<CraftController> ().createInventory ();
		}
		if (CraftController._instance.selectedItem) {
			CraftController._instance.selectedItem.transform.parent.parent.gameObject.
			GetComponent<CraftController> ().createInventory ();
			CraftController._instance.selectedItem.transform.parent.parent.gameObject.
			GetComponent<CraftController> ().otherPanel.GetComponent<CraftController> ().createInventory ();
		}
	}
}
