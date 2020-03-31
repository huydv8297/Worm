using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	[SerializeField] Transform itemContainer;

	public Transform[,] items;
	public Color[] colors;
	public int itemCount;

	// Use this for initialization
	void Start () {
		itemCount = itemContainer.childCount;

		int containerSize = (int) Mathf.Sqrt(itemCount);

		items = new Transform[containerSize, containerSize];
		var j = 0;
		for(int i = 0; i < itemCount; i++){
 
			items[j, i - j * containerSize] = itemContainer.GetChild(i);
			if( (i + 1) % containerSize == 0){
				j++;
			}
		}

		Init();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void Init(){
		Image image;
		foreach(Transform item in items){
			image = item.GetComponent<Image>();
			image.color = colors[Random.Range(0, 3)];
		}
	}
}
