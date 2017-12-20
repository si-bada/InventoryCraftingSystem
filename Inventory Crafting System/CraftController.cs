using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;


public class CraftController : MonoBehaviour {
	public Transform selectedItem, selectedSlot,selectedPanel; 
	public GameObject craft_slot,craft_item;
	public Vector2 inventorySize= new Vector2(3,4);
	public float slotSize;
	public Vector2 windowSize;
	public static CraftController _instance;
	public bool canDragItem;
	public Sprite moteur2Active;
	public bool canChangePosition ; 
	public GameObject otherPanel;
	public GameObject compoundSlot = null;


	GameObject player;
	// Use this for initialization
	void Start () {
		createInventory ();
		_instance = this;
		player = GameObject.Find("Player");
		selectedPanel = null;


	}

	void OnMouseEnter(){  // ENTER ACTION ON SELECTED PANEL
		canChangePosition = true;
//		Debug.Log ("we entred" + this.gameObject.name);
		selectedPanel = this.transform;
	}

	void OnMouseExit(){  //EXIT ACTION ON SELECTED PANEL
		canChangePosition = false;
		selectedSlot = null;
		selectedPanel = null;
	}
//	public Transform getSelectedItem(){
//		return selectedItem;
//	}

	public void createInventory(){  // CREATE ITEMPANEL AND CRAFTPANEL

		foreach (Transform t in this.transform) {  //DESTROY THE OLD PANELS
			Destroy (t.gameObject);

		}
				
		for (int i = 1; i <= inventorySize.x; i++) {   //CREATE SLOTS FOR THE ITEMPANEL AND CRAFTPANEL
			for (int j = 1; j <= inventorySize.y; j++) {
				GameObject slot = Instantiate (craft_slot) as GameObject;
				slot.transform.SetParent (this.transform, false);
				slot.name = "slot_" + j + "_" + i;
				slot.GetComponent<RectTransform> ().anchoredPosition = new Vector3 ((windowSize.x) / (inventorySize.x) * i, (windowSize.y) / (inventorySize.y) * -j, 1);
				slot.GetComponent<CraftSlotContoller> ().coords = new Vector2 (i,j);


				if (otherPanel.name == "Craft Panel") { //CREATE ITEMS FOR THE ITEMPANEL
					if (i + (j - 1) * 3 <= GameBD.itemPanelList.Count) {
						GameObject item = Instantiate (craft_item) as GameObject;
						item.transform.SetParent (slot.transform);

						CraftItemController newitem = item.GetComponent<CraftItemController> ();
						newitem.name = GameBD.itemPanelList [(i + (j - 1) * 3) - 1].name;
						newitem.count = GameBD.itemPanelList [(i + (j - 1) * 3) - 1].count;
						newitem.mytype = GameBD.itemPanelList [(i + (j - 1) * 3) - 1].mytype;
						newitem.countTEXT=item.transform.Find ("count").GetComponent<Text> ();
						newitem.countTEXT.text = newitem.count.ToString ();
						newitem.sprite = GameBD.itemPanelList [(i + (j - 1) * 3) - 1].sprite;

						item.name = newitem.name;
						item.GetComponent<RectTransform> ().anchoredPosition = Vector3.zero;
						item.GetComponent<RectTransform> ().localScale = new Vector3 (23, 23, 1);
						item.GetComponent<SpriteRenderer> ().sprite = newitem.sprite;
						if (item.GetComponent<CraftItemController> ().coords == Vector2.zero) {
							item.GetComponent<CraftItemController> ().coords = slot.GetComponent<CraftSlotContoller> ().coords;
						}
					}
						
				} else { //CREATE ITEMS FOR THE CRAFTPANEL
					if (i + (j - 1) * 3 <= GameBD.CraftitemList.Count) {
						GameObject item = Instantiate (craft_item) as GameObject;
						item.transform.SetParent (slot.transform);

						CraftItemController newitem = item.GetComponent<CraftItemController> ();
						newitem.name = GameBD.CraftitemList [(i + (j - 1) * 3) - 1].name;
						newitem.count = GameBD.CraftitemList [(i + (j - 1) * 3) - 1].count;
						newitem.mytype = GameBD.CraftitemList [(i + (j - 1) * 3) - 1].mytype;
						newitem.countTEXT=item.transform.Find ("count").GetComponent<Text> ();
						newitem.countTEXT.text = newitem.count.ToString ();
						newitem.sprite = GameBD.CraftitemList [(i + (j - 1) * 3) - 1].sprite;
						
						item.name = newitem.name;
						item.GetComponent<RectTransform> ().anchoredPosition = Vector3.zero;
						item.GetComponent<RectTransform> ().localScale = new Vector3 (23, 23, 1);
						item.GetComponent<SpriteRenderer> ().sprite = newitem.sprite;
						if (item.GetComponent<CraftItemController> ().coords == Vector2.zero) {
						item.GetComponent<CraftItemController> ().coords = slot.GetComponent<CraftSlotContoller> ().coords;
						}
					}
				}
					
			}
		}
	}
}

