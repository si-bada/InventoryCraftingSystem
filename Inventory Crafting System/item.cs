using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class item : MonoBehaviour {

	public string name;
	public Sprite sprite;
	public int count=0;
	public Text countTEXT;
	public Vector2 coords;
	public string mytype ;


	void OnMouseDown(){
		transform.parent.parent.GetComponent<inventoryControllr> ().selectedItem = this.transform;

	}
	public void IncreaseAmount(int a){
		count += a;
		transform.Find ("count").GetComponent<Text>().text=count.ToString();
	}
}
