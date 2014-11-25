using UnityEngine;

public class Brick : MonoBehaviour 
{

    public void OnCollisionEnter2D (Collision2D coll)
    {
        Debug.Log(coll.gameObject.tag);
    }
}
