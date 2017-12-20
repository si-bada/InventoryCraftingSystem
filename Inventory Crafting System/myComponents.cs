using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class myComponents : MonoBehaviour {
	public static myComponents _instance;
	public string name;
	public List<CraftItemController> mycomponents = new List<CraftItemController>();

	void start(){
		_instance = this;
	}
}
