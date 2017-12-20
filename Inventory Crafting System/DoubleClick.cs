using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoubleClick : MonoBehaviour {
	public Transform selectedItem;
	GameObject otherPanel;


	void OnGUI(){
		Event e = Event.current;
		//THE EVENT IS A MOUSE EVENT AND WE HAVE A DOUBLE CLICK
		if (e.isMouse && e.type == EventType.MouseDown && e.clickCount == 2 && CraftController._instance.selectedItem.gameObject == gameObject) {


			CraftItemController item1 = new CraftItemController();
			item1.name = CraftController._instance.selectedItem.GetComponent<CraftItemController>().name;
			item1.sprite = CraftController._instance.selectedItem.GetComponent<CraftItemController> ().sprite;
			item1.coords = CraftController._instance.selectedItem.GetComponent<CraftItemController> ().coords;
			item1.count = CraftController._instance.selectedItem.GetComponent<CraftItemController> ().count;
			item1.countTEXT = CraftController._instance.selectedItem.GetComponent<CraftItemController> ().countTEXT;
			item1.mytype = CraftController._instance.selectedItem.GetComponent<CraftItemController> ().mytype;

			if (item1.mytype.Equals("composant")) { //WHEN I CLICK ON A COMPONENT
				
				//OTHERPANEL IS THE PANEL THAT ITEM WILL GO TO 
				otherPanel = CraftController._instance.selectedItem.transform.parent.parent.gameObject.GetComponent<CraftController> ().otherPanel;
				//SWITCH THE ITEM 
				GameBD._insctance.switchPanel (item1, otherPanel); 
				//CHECK IS THERE A MATCH BETWEEN MY COMPOUNDS AND MY COMPONENTS
				int i = GameBD._insctance.IsAMatch (); 

				//IF THERE IS ONE "i" IS THE INDEX OF THE COMPOUND THAT WE MATCHED ELSE IT'S -1
				//IF THERE IS A MATCH !! 
				if (i != -1) { 

					string myname = GameBD.CompoundList [i].name;
					//GET THE COMPOUND FROM THE DATABASE
					CraftItemController item = GameBD._insctance.convertToCraft (GameBD._insctance.FindItem (myname));
					//ASSIGN THE COMPOUND ( sprite , type , name ) TO THE COMPOUND SLOT
					CraftController._instance.compoundSlot.transform.Find ("compound").
					GetComponent<SpriteRenderer> ().sprite = item.sprite;

					CraftController._instance.compoundSlot.transform.Find ("compound").
					GetComponent<CraftItemController> ().mytype = item.mytype;

					CraftController._instance.compoundSlot.transform.Find ("compound").
					GetComponent<CraftItemController> ().name = item.name;

				} else {
					// THERE IS NO MATCH "i" == -1 
					//DELETE THE COMPOUND IF IT'S THERE 
					
					Debug.Log ("delete craft item");
					CraftController._instance.compoundSlot.transform.Find ("compound").
					GetComponent<SpriteRenderer> ().sprite = null;

					CraftController._instance.compoundSlot.transform.Find ("compound").
					GetComponent<CraftItemController> ().mytype = null;
					
				}
			} else {//WHEN I CLICK ON A COMPOUND
				if (CraftController._instance.selectedItem.transform.parent.parent.gameObject.GetComponent<CraftController> ().
					selectedPanel.name == "item_panel") {

					CraftController._instance.compoundSlot.transform.Find ("compound").
					GetComponent<SpriteRenderer> ().sprite = CraftController._instance.selectedItem.GetComponent<CraftItemController> ().sprite;

					CraftController._instance.compoundSlot.transform.Find ("compound").
					GetComponent<CraftItemController> ().mytype = CraftController._instance.selectedItem.GetComponent<CraftItemController> ().mytype;
					// NAME HERE WILL BE NULL TO TEST EITHER WE WANT TO HAVE THE COMPONENTS OR THE COMPOUND WHEN WE VALIDATE THE CRAFT ACTION
					CraftController._instance.compoundSlot.transform.Find ("compound").
					GetComponent<CraftItemController> ().name = null;

					GameBD._insctance.displayComponents (item1);
					GameBD._insctance.removeItemCraft (item1, GameBD.itemPanelList);
				}
			}
		}


	}
}
