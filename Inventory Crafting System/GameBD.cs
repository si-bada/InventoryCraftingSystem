using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class GameBD : MonoBehaviour {

	public Sprite[] sprites;
	public static GameBD _insctance;
	public static List<item> itemList1 = new List<item> ();//LIST THAT CONTAINS ALL ITEMS 
	public static List<item> itemList = new List<item> (); //INVENTORY LIST 
	public static List<CraftItemController> itemPanelList = new List<CraftItemController> (); //LIST FOR ITEM PANEL
	public static List<CraftItemController> CraftitemList = new List<CraftItemController> (); // LIST FOR CRAFT PANEL
	public static List<myComponents> CompoundList = new List<myComponents>(); //LIST FOR COMPOUNDS

	// Use this for initialization
	void Start () {
		_insctance = this;
		//ITEM CREATION

		item i0 = new item ();
		i0.name = "item_bulb";
		i0.sprite = sprites [0];
		i0.count = 1;
		i0.coords = Vector2.zero;
		i0.mytype = "composant";
		itemList1.Add (i0);


		item i1 = new item ();
		i1.name = "item_radio";
		i1.sprite = sprites [1];
		i1.count = 1;
		i1.mytype = "compound";
		i1.coords = Vector2.zero;

		itemList1.Add (i1);

		item i2 = new item ();
		i2.name = "item_card";
		i2.sprite = sprites [2];
		i2.count = 1;
		i2.mytype = "composant";
		i2.coords = Vector2.zero;
		itemList1.Add (i2);

		item i3 = new item ();
		i3.name = "item_fuel";
		i3.sprite = sprites [3];
		i3.count = 1;
		i3.coords = Vector2.zero;
		i3.mytype = "composant";

		itemList1.Add (i3);

		item i4 = new item ();
		i4.name = "item_lamp";
		i4.sprite = sprites [4];
		i4.count = 1;
		i4.coords =Vector2.zero;
		i4.mytype = "compound";

		itemList1.Add (i4);

		item i5 = new item ();
		i5.name = "item_meca";
		i5.sprite = sprites [5];
		i5.count = 1;
		i5.coords = Vector2.zero;
		i5.mytype = "composant";

		itemList1.Add (i5);

		item i6 = new item ();
		i6.name = "item_cable";
		i6.sprite = sprites [6];
		i6.count = 1;
		i6.coords = Vector2.zero;
		i6.mytype = "composant";

		itemList1.Add (i6);

		item i7 = new item ();
		i7.name = "item_parap";
		i7.sprite = sprites [7];
		i7.coords = Vector2.zero;
		i7.mytype = "compound";
		i7.count = 1;
		itemList1.Add (i7);

		item i8 = new item ();
		i8.name = "item_battrie";
		i8.sprite = sprites [8];
		i8.count = 1;
		i8.mytype = "composant";
		i8.coords =Vector2.zero;
		itemList1.Add (i8);

		/*item i9 = new item (); //THIS ITEM IS ONLY USED FOR INITIALISATION
		i9.name = "item_bada";
		i9.sprite = sprites [8];
		i9.count = 1;
		i9.mytype = "composant";
		i4.coords = Vector2.zero;
		itemList1.Add (i9);*/

		item i9 = new item ();
		i9.name = "item_mini_potion";
		i9.sprite = sprites [9];
		i9.count = 1;
		i9.mytype = "powerup";
		i9.coords =Vector2.zero;
		itemList1.Add (i9);

		item i10 = new item ();
		i10.name = "item_full_potion";
		i10.sprite = sprites [10];
		i10.count = 1;
		i10.mytype = "powerup";
		i10.coords =Vector2.zero;
		itemList1.Add (i10);

		item i11 = new item ();
		i11.name = "item_life_more";
		i11.sprite = sprites [11];
		i11.count = 1;
		i11.mytype = "powerup";
		i11.coords =Vector2.zero;
		itemList1.Add (i11);

		item i12 = new item ();
		i12.name = "item_laser_shield";
		i12.sprite = sprites [12];
		i12.count = 1;
		i12.mytype = "powerup";
		i12.coords =Vector2.zero;
		itemList1.Add (i12);

		item i13 = new item ();
		i13.name = "item_coin_doubler";
		i13.sprite = sprites [13];
		i13.count = 1;
		i13.mytype = "powerup";
		i13.coords =Vector2.zero;
		itemList1.Add (i13);

		item i14 = new item ();
		i14.name = "item_super_magnet";
		i14.sprite = sprites [14];
		i14.count = 1;
		i14.mytype = "powerup";
		i14.coords =Vector2.zero;
		itemList1.Add (i14);

		myComponents compound1 = new myComponents ();
		compound1.name = "item_radio";
		compound1.mycomponents.Add (convertToCraft (i6));
		compound1.mycomponents.Add (convertToCraft (i8));
		compound1.mycomponents.Add (convertToCraft (i2));

		CompoundList.Add (compound1);

		myComponents compound2 = new myComponents ();
		compound2.name = "item_lamp";
		compound2.mycomponents.Add (convertToCraft (i6));
		compound2.mycomponents.Add (convertToCraft (i8));
		compound2.mycomponents.Add (convertToCraft (i0));

		CompoundList.Add (compound2);




		
	}
	/// //////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	//FUNCTIONS WORKING WITH THE INVENTORY PANEL///
	//FUNCTIONS WORKING WITH THE INVENTORY PANEL///
	//FUNCTIONS WORKING WITH THE INVENTORY PANEL///
	/// //////////////////////////////////////////////////////////////////////////////////////////////////////////////////

	//FINDS ITEM BY NAME .. 
	public item FindItem( string itemname){ 
		item newitem = new item ();
		for (int i = 0; i < itemList1.Count; i++) {
			if (itemname == itemList1 [i].name) {
				return itemList1[i];
			}
				
		}
		return newitem;
	}



	//CHECK IF AN ITEM EXISTS IN THE LIST .. THE LIST SHOULD CONTAINS ITEMS
	public int ItemExist( string itemname , List<item> list){
		for (int i = 0; i < list.Count; i++) {
			if (itemname == list[i].name) {
				return i;
			}
		}
		return -1;
	}


	//TAKES THE COORDINATES OF AN ITEM AND RETURN THE INDEX OF THAT ITEM IN A GIVEN LIST 
	public int CoordToIndex(Vector2 coord , List<item> mylist ) {
		for (int n = 0; n < mylist.Count; n++) {
			if (mylist [n].coords == coord) {
				return n;
			}
		}
		return -1;
	}



	//SWAP THE COORDINATES OF TWO ITEMS
	public void swapCoord(Vector2 vect1, Vector2 vect2){
		int i = CoordToIndex (vect1,itemList);
		int j = CoordToIndex (vect2,itemList);
		//CHECK IF ONE THE COORDINATES IS ZERO
		if (i == -1) {
			itemList [j].coords = vect1;
		} else if (j == -1) {
			itemList [i].coords = vect2;

		} else {
			Vector2 vect3 = itemList [i].coords;
			itemList [i].coords = itemList [j].coords;
			itemList [j].coords=vect3;
		}
	}



//RETURNS THE COORDINATES FROM THE ITEM NAME
	public Vector2 MyVector(string name){
		for (int i = 0; i < itemList.Count; i++) {
			if (itemList [i].name == name) {
				return itemList [i].coords;
			}
		}
		return Vector2.zero;
	}



//REPLACE THE ITEM IF IT IS ALREADY THERE AND INCREASE IT'S COUNT BY 1
	public void replaceitem (Vector2 index){
		int i = CoordToIndex (index,itemList);
		//Debug.Log (i);
		item newitem = new item();
		newitem.name = itemList [i].name;
		newitem.sprite = itemList [i].sprite;
		newitem.count = itemList [i].count +1;
		newitem.coords = itemList [i].coords;
		newitem.mytype = itemList [i].mytype;
		itemList.RemoveAt(i);
		//itemPanelList.RemoveAt(i);
		itemList.Add(newitem);
		//itemPanelList.Add (convertToCraft(newitem));

	}


	//REMOVE ITEM IF THE COUNT IS 1 .. DECREASE COUNT IF NOT 
	public void removeItem(Vector2 vect , List<item> list){
		
		int i = CoordToIndex (vect,list);
		//Debug.Log (i);
		if (list[i].count == 1) {
			//Debug.Log ("removed");
			list.RemoveAt(i);
		} else {
			list[i].count--;		
		}
	}


	//FIND THE COORDINATES OF THE FIRST EMPTY SLOT IN A LIST
	public Vector2 FirstEmptySlot(List<item> list){
		for (int i = 1; i <= 3; i++) {
			for (int j = 1; j <= 3; j++) {
				int k = CoordToIndex (new Vector2(j,i),list);
				if (k == -1) {
					return new Vector2(j,i);
				}
			}
		}
		return new Vector2 (0, 0);
	}



	////CRAFT FUNCTIONS//////////////////////CRAFT FUNCTIONS////////////////////////////////CRAFT FUNCTIONS
	/// ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	/////////////////////CRAFT FUNCTIONS//////////////////CRAFT FUNCTIONS///////////////////CRAFT FUNCTIONS//////////////////////////////////
	/// /////////////////////////////////CRAFT FUNCTIONS//////////////////////CRAFT FUNCTIONS/////////////////CRAFT FUNCTIONS




	//THIS IS EXECUTED WHEN THE EVENT IS A DOUBLE CLICK
	//SWITCH ITEM BETWEEN PANELS
	public void switchPanel(CraftItemController item,GameObject otherPanel){
		if (otherPanel.name == "Craft Panel") { //SWITCH FROM ITEM PANEL TO CRAFT PANEL
				int i = ItemExistCraft (item, CraftitemList);
				Debug.Log ("switch index" + i);
				if (i == -1) {
					Debug.Log ("NEW ITEM");
					item.count = 1;
					item.countTEXT = CraftController._instance.selectedItem.Find ("count").GetComponent<Text> ();
					CraftController._instance.selectedItem.Find ("count").GetComponent<Text> ().text= item.count.ToString ();
					item.countTEXT.text = item.count.ToString ();
					CraftitemList.Add (item);
				} else {
					Debug.Log ("REPLACE");
					item.countTEXT = CraftController._instance.selectedItem.Find ("count").GetComponent<Text> ();
					CraftController._instance.selectedItem.Find ("count").GetComponent<Text> ().text= item.count.ToString ();
					item.countTEXT.text = item.count.ToString ();
					replaceitemCraft (i,item, CraftitemList);
				}
				Debug.Log("before remove itemCount is "+itemPanelList.Count);
				removeItemCraft (item, itemPanelList);

		} else { //SWITCH FROM CRAFT PANEL TO ITEM PANEL
				int i = ItemExistCraft (item, itemPanelList);
				Debug.Log ("switch index" + i);
				if (i == -1) {
					Debug.Log ("NEW ITEM");
					item.count = 1;
					item.countTEXT = CraftController._instance.selectedItem.Find ("count").GetComponent<Text> ();
					CraftController._instance.selectedItem.Find ("count").GetComponent<Text> ().text= item.count.ToString ();
					item.countTEXT.text = item.count.ToString ();
					itemPanelList.Add (item);
				} else {
					Debug.Log ("REPLACE");
					item.countTEXT = CraftController._instance.selectedItem.Find ("count").GetComponent<Text> ();
					CraftController._instance.selectedItem.Find ("count").GetComponent<Text> ().text= item.count.ToString ();
					item.countTEXT.text = item.count.ToString ();
					replaceitemCraft (i, item, itemPanelList);
				}
				removeItemCraft (item, CraftitemList);
		}
		//PANEL MAJ 
		CraftController._instance.selectedItem.transform.parent.parent.gameObject.GetComponent<CraftController> ().createInventory ();
		CraftController._instance.selectedItem.transform.parent.parent.gameObject.
		GetComponent<CraftController> ().otherPanel.GetComponent<CraftController> ().createInventory ();
	}


	//INCREASE THE COUNT OF AN ITEM BY 1
	//CREATE A NEW ITEM AND REPLACE IT WITH THE OLD ONE 
	public void replaceitemCraft (int i,CraftItemController item, List<CraftItemController> list){

		CraftItemController newitem = new CraftItemController();
		newitem.name = list [i].name;
		newitem.sprite = list [i].sprite;
		newitem.count = list [i].count +1;
		newitem.countTEXT = CraftController._instance.selectedItem.transform.GetComponent<CraftItemController> ().countTEXT;
		newitem.countTEXT.text = newitem.count.ToString ();
		newitem.coords = list [i].coords;
		newitem.mytype = list [i].mytype;
		list.RemoveAt(i);
		list.Add (newitem);
	}


	//CHECK IF THERE IS A MATCH BETWEEN THE CRAFT PANEL ITEMS AND THE COMPONENTS COMPOSING A COMPOUND
	//THIS FUNCTION RETURNS THE INDEX OF THE COMPOUND IN THE COMPOUND LIST IF THERE IS ONE .. ELSE -1
	public int IsAMatch(){
		
		int i =0;

		while(i<CompoundList.Count){
			if (CraftitemList.Count != CompoundList [i].mycomponents.Count) {
				Debug.Log ("not the same length");
				return -1;
			}
			int j = 0;
			do{
				int k = ItemExistCraft (CraftitemList [j], CompoundList [i].mycomponents);
				if(k == -1 ){
					i++;
					break;
				}else{
					j++;
				}
			}while(j<CompoundList [i].mycomponents.Count);
			if (j==CompoundList [i].mycomponents.Count)
				return i;
		}
		return -1;
	}

	//CONVERT A CRAFTITEM TO ITEM 
	public CraftItemController convertToCraft(item myitem){
		CraftItemController newitem1 = new CraftItemController();
		newitem1.name = myitem.name;
		newitem1.sprite = myitem.sprite;
		newitem1.countTEXT = myitem.countTEXT;
		newitem1.count = myitem.count;
		newitem1.coords = myitem.coords;
		newitem1.mytype = myitem.mytype;
		return newitem1;
	}

	//CONVERT ITEM TO CRAFTITEM
	public item convertToItem(CraftItemController myitem){
		item newitem1 = new item();
		newitem1.name = myitem.name;
		newitem1.sprite = myitem.sprite;
		newitem1.countTEXT = myitem.countTEXT;
		newitem1.count = myitem.count;
		newitem1.mytype = myitem.mytype;
		newitem1.coords = myitem.coords;
		return newitem1;
	}

	//RETURNS THE INDEX OF THE ITEM IN THE SPECIFIED LIST FROM ITS COORDINATES 
	public int CoordToIndexCraft(Vector2 coord , List<CraftItemController> mylist ) {
		for (int n = 0; n < mylist.Count; n++) {
			if (mylist [n].coords == coord) {
				return n;
			}
		}
		return -1;
	}

	//RETURNS THE INDEX OF THE ITEM IN THE LIST IF IT EXISTS ELSE -1
	public int ItemExistCraft( CraftItemController item, List<CraftItemController> list){
		for (int i = 0; i < list.Count; i++) {
			if (item.name == list[i].name) {
				return i;
			}
		}
		return -1;
	}


	//REMOVE THE ITEM FROM THE LIST IF THERE IS ONLY ONE OF IT .. ELSE THE COUNT VARIABLE DECREASES BY ONE
	public void removeItemCraft(CraftItemController item , List<CraftItemController> list){
		int j = ItemExistCraft (item, list);
		if (list[j].count == 1) {
			list.RemoveAt(j);
			CraftController._instance.createInventory ();
		} else {
			list[j].count--;	
			CraftController._instance.createInventory ();
		}
	}


	//THIS FUNCTION IS CALLED WHEN THE CANCEL BUTTON IS CLICKED
	// IT CLEARS THE CRAFT PANEL AND RETURN ITS ITEMS TO THE ITEM PANEL
	public void ClearCraftPanel(){
		CraftitemList.Clear ();
		itemPanelList.Clear ();
		if (transform.Find("Compound_Slot") != null) {
			transform.Find("Compound_Slot").transform.Find ("compound").
			GetComponent<SpriteRenderer> ().sprite = null;
		}
		for (int i = 0;i<itemList.Count;i++) {
			itemPanelList.Add (convertToCraft(itemList [i]));
		}
		if (CraftController._instance) {
			CraftController._instance.createInventory ();
			CraftController._instance.otherPanel.GetComponent<CraftController> ().createInventory ();
		}
	}
		


	//THIS FUNCTION  DISPLAYS THE COMPONENTS OF THE CLICKED COMPOUND
	public void displayComponents(CraftItemController compound){

		for (int i = 0; i<CompoundList.Count; i++) {

			if (compound.name == CompoundList [i].name) {
				CraftitemList.Clear (); 
				for (int j = 0; j < CompoundList [i].mycomponents.Count; j++) {
					CraftitemList.Add (CompoundList [i].mycomponents [j]);
				}
				break;
			}
		}
		CraftController._instance.createInventory ();
		CraftController._instance.otherPanel.GetComponent<CraftController> ().createInventory ();
	}



	//THIS FUNCTION IS CALLED THE VALIDATE BUTTON IS CLICKED 
	//IT SAVE THE CHANGES ACCORDING TO WHAT THE PLAYER WANT
	public void SaveChanges(){
		string name = CraftController._instance.compoundSlot.transform.Find ("compound").GetComponent<CraftItemController> ().name;
		if (name == null) {
			for (int i = 0; i < CraftitemList.Count; i++) {
				int index = ItemExist (CraftitemList [i].name, itemList);
				if (index == -1) {
					CraftitemList [i].coords = FirstEmptySlot (itemList);
					//displayitem );
					itemList.Add((convertToItem (CraftitemList [i])));
				} else {
					CraftitemList [i].coords = itemList [index].coords;
					replaceitem (CraftitemList [i].coords);
				}
			}
			string myname = CraftController._instance.compoundSlot.transform.Find ("compound").GetComponent<SpriteRenderer> ().sprite.name;
			removeItem (FindItem (myname).coords, itemList);
		} else {
			for (int i = 0; i < CraftitemList.Count; i++) {
				removeItem (MyVector(CraftitemList[i].name), itemList);
			}
			item newitem = FindItem (name);
			int index = ItemExist (name, itemList);
			if (index == -1) {
				newitem.coords = FirstEmptySlot (itemList);
				itemList.Add(newitem);
			} else {
				replaceitem (itemList [index].coords);
			}
		}
		ClearCraftPanel ();
		inventoryControllr._instance.createInventory ();
	}
}
