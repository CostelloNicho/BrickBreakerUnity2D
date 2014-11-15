using UnityEngine;
using System.Collections;
using Assets.Scripts.Managers;

public class Borders : MonoBehaviour {

	public GameObject borderPrefab;

	private GameObject[] borders;

	// Use this for initialization
	void Start () 
	{
		borders = new GameObject[4];
		for( int i = 0; i < 4; i++ )
		{
			var go = Instantiate(borderPrefab) as GameObject;
			go.transform.localScale = Vector3.one;
			go.transform.parent = this.transform;
			go.name = "Border";
			borders[i] = go;
		}

		//configure right border
		var position = borders[0].transform.position;
		var scale = borders[0].transform.localScale;

		position.x = ResolutionManager.HalfWidth + 
			borders[0].GetComponent<BoxCollider2D>().bounds.extents.x;
		position.y = 0f;
		borders[0].transform.position = position;

		scale.y = ResolutionManager.HalfHeight * 2;
		scale.x = 1f;
		borders[0].transform.localScale = scale;

		//configure left border
		position = borders[1].transform.position;
		position.x = -ResolutionManager.HalfWidth -
			borders[1].GetComponent<BoxCollider2D>().bounds.extents.x;
		position.y = 0f;
		borders[1].transform.position = position;
		borders[1].transform.localScale = scale;


		//configure Top border
		position = borders[2].transform.position;
		scale = borders[2].transform.localScale;

		position.y = ResolutionManager.HalfHeight + 
			borders[2].GetComponent<BoxCollider2D>().bounds.extents.y;
		position.x = 0f;
		borders[2].transform.position = position;

		scale.x = ResolutionManager.HalfWidth * 2;
		scale.y = 1f;
		borders[2].transform.localScale = scale;

		//configure Bottom border
		position = borders[3].transform.position;
		position.y = -ResolutionManager.HalfHeight - 
			borders[3].GetComponent<BoxCollider2D>().bounds.extents.x;
		position.x = 0f;
		borders[3].transform.position = position;
		borders[3].transform.localScale = scale;



	}

}
