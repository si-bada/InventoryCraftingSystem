using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class inventoryControllr : MonoBehaviour {
	public Transform selectedItem, selectedSlot,originalSlot; 
	public GameObject slotprefab,itemprefab;
	public Vector2 inventorySize= new Vector2(3,4);
	public float slotSize;
	public Vector2 windowSize;
	public static inventoryControllr _instance;
	public bool canDragItem;
	public Sprite moteur2Active;
	public bool canChangePosition ; 
	private GameObject deactivateUI;
	public Sprite bgItem;

	GameObject player;
	GameObject Gui;
	// Use this for initialization
	void Start () {



		createInventory ();
		_instance = this;

		deactivateUI = GameObject.Find("Player");

		player = GameObject.Find("Player");

		Gui = GameObject.Find("GUI");

	}
	void OnMouseEnter(){
		canChangePosition = true;
	}

	void OnMouseExit(){
		canChangePosition = false;
		selectedSlot = null;
	}

	public void createInventory(){



		foreach (Transform t in this.transform) {
			Destroy (t.gameObject);
		}

		for (int i = 1; i <= inventorySize.x; i++) {
			for (int j = 1; j <= inventorySize.y; j++) {
				GameObject slot = Instantiate (slotprefab) as GameObject;
				slot.transform.SetParent (this.transform, false);
				slot.name = "slot_" + i + "_" + j;
				slot.GetComponent<RectTransform> ().anchoredPosition = new Vector3 ((windowSize.x) / (inventorySize.x) * i, (windowSize.y) / (inventorySize.y) * -j, 1);
				slot.GetComponent<SlotController> ().coords = new Vector2 (i,j);
		
				//CREATE ITEMS && KEEP ITEM POSITIONS 
		
				Vector2 vect = new Vector2 (i, j);
				int n = GameBD._insctance.CoordToIndex (vect,GameBD.itemList);
				if (n != -1 ){
					slot.GetComponent<Image> ().sprite = bgItem;
					GameObject item = Instantiate (itemprefab) as GameObject;
					item.transform.SetParent (slot.transform, false);
					item.GetComponent<RectTransform> ().anchoredPosition = Vector3.zero;


					item newitem = item.GetComponent<item> ();
					newitem.name = GameBD.itemList [n].name;
					newitem.sprite = GameBD.itemList [n].sprite;
					newitem.count = GameBD.itemList [n].count;
					newitem.countTEXT=item.transform.Find ("count").GetComponent<Text> ();
					newitem.countTEXT.text ="x"+ newitem.count.ToString ();
					item.name = newitem.name;
					item.GetComponent<SpriteRenderer> ().sprite = newitem.sprite;
					//CHANGE THE ITEM POSITION WITH THE RIGHT SLOT POSITION
					if (item.GetComponent<item> ().coords == Vector2.zero) {
						item.GetComponent<item> ().coords = slot.GetComponent<SlotController> ().coords;
					}
				
				}
			}
		}
	}

	

	// Update is called once per frame
	void Update () {
		
		//*************//
		// Click Down  //
		//*************//
		if(Input.GetMouseButtonDown(0) && selectedItem != null){
			GameObject engine2 = player.GetComponent<PlayerInteract> ().engine2;

			///// ACTIVATE ENGINE 2 
			if (engine2 != null) {
				if (engine2.transform.Find ("engine_item").GetComponent<SpriteRenderer>().sprite.name == selectedItem.name 
					&& engine2.GetComponent<SystemActivation> ().active ==false) {
					UnFreeze ();
					SpriteRenderer spriteRenderer = engine2.GetComponent<SpriteRenderer> ();
					spriteRenderer.sprite = moteur2Active;

					engine2.GetComponent<SystemActivation> ().active = true;
					engine2.GetComponent<SystemActivation> ().setActive();
					engine2.transform.Find ("engine_item").GetComponent<SpriteRenderer> ().enabled = false;
					GameBD._insctance.removeItem (selectedItem.GetComponent<item>().coords,GameBD.itemList);
					transform.parent.gameObject.SetActive(false);  //inventory
					transform.parent.parent.Find ("Bag").gameObject.SetActive (true); //bag
					player.GetComponent<Player>().stopPlayer = false;
					GameBD._insctance.ClearCraftPanel ();
					createInventory ();

				}
			}
				

			if (GameBD._insctance.FindItem (selectedItem.name).mytype == "powerup") {
				UnFreeze ();
				GameBD._insctance.removeItem (selectedItem.GetComponent<item>().coords,GameBD.itemList);


				transform.parent.gameObject.SetActive(false);  //inventory
				transform.parent.parent.Find ("Bag").gameObject.SetActive (true); //bag
				player.GetComponent<Player>().stopPlayer = false;

				GameBD._insctance.ClearCraftPanel ();
				createInventory ();

				Gui.GetComponent<LevelManager> ().PowerupsUse (selectedItem.name);

			}


			canDragItem = true;
			originalSlot = selectedItem.parent;
			selectedItem.GetComponent<BoxCollider>().enabled = false;
}

		//****************//
		//  Click Pressed //
		//****************//
		if (Input.GetMouseButton (0) && selectedItem != null && canDragItem) {
			selectedItem.position =  new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x ,Camera.main.ScreenToWorldPoint(Input.mousePosition).y ,-5);
		}

		//****************//
		// Click Released //
		//****************//
		else if(Input.GetMouseButtonUp(0) && selectedItem != null ){
			canDragItem = false;
		

			if (selectedSlot == null || selectedSlot.name == originalSlot.name) {
				selectedItem.SetParent (originalSlot);

			}
			else{
				if (selectedSlot.childCount > 0 && canChangePosition) {

					//STACK ITEMS
					if (selectedItem.name == selectedSlot.GetChild (0).name && selectedSlot.name != originalSlot.name) {
						Debug.Log ("WE STACKED 2 ITEMS");
						selectedItem.GetComponent<item> ().IncreaseAmount (selectedSlot.GetChild (0).GetComponent<item> ().count);
						Destroy (selectedSlot.GetChild (0).gameObject);
					}
					//SWAP ITEMS
					else {

						int i = GameBD._insctance.CoordToIndex (selectedItem.GetComponent<item> ().coords,GameBD.itemList);

						if (i == -1) {
							selectedItem.SetParent (originalSlot);
						} else {

							item newitem = GameBD.itemList [i];

							int myitem = GameBD._insctance.ItemExist (selectedSlot.GetChild (0).name,GameBD.itemList);

							GameBD._insctance.swapCoord (newitem.coords, GameBD.itemList[myitem].coords);

							selectedItem.GetComponent<item> ().coords = newitem.coords;
							selectedSlot.GetChild (0).gameObject.GetComponent<item> ().coords = GameBD.itemList [myitem].coords;

							selectedSlot.GetChild (0).SetParent (originalSlot);
							selectedItem.SetParent (selectedSlot);


							foreach (Transform t in originalSlot) {
								t.localPosition = Vector3.zero;
							}

						}

					}
				} else {
					
					int i = GameBD._insctance.CoordToIndex (selectedItem.GetComponent<item> ().coords,GameBD.itemList);
					Debug.Log (i + "is my index  and my coords are "+selectedItem.GetComponent<item> ().coords);
					if (i == -1) {
						selectedItem.SetParent (originalSlot);
					} else {
						item newitem = GameBD.itemList [i];

						GameBD._insctance.swapCoord (newitem.coords, selectedSlot.GetComponent<SlotController> ().coords);


						selectedItem.GetComponent<item> ().coords = newitem.coords;

					

						selectedItem.SetParent (selectedSlot);


						foreach (Transform t in originalSlot) {
							t.localPosition = Vector3.zero;
						}

					}
				}
			
			}
			selectedItem.GetComponent<Collider>().enabled = true;
			selectedItem.localPosition = Vector3.zero;
			selectedItem = null;
			createInventory ();
		}
	}

	public void Freeze(){
		GameObject P = GameObject.FindGameObjectWithTag ("Player");
		deactivateUI = GameObject.Find ("GUI").transform.Find("Ui").gameObject;

		P.GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.FreezeAll;
		deactivateUI.gameObject.SetActive (false);
	}
	public void UnFreeze(){
		GameObject P = GameObject.FindGameObjectWithTag ("Player");
		deactivateUI = GameObject.Find ("GUI").transform.Find("Ui").gameObject;

		P.GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.None | RigidbodyConstraints2D.FreezeRotation;
		deactivateUI.gameObject.SetActive (true);
		P.GetComponent<PlayerInteract> ().interfaceActived = false;
	}
}
