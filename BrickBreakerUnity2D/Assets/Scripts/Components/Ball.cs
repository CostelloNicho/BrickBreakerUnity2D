using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {



	void OnCollisionEnter2D(Collision2D collision)
	{
		Destroy(collision.gameObject);
	}

}
