using UnityEngine;
using System.Collections;

public class Fruit : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
	    if (transform.position.y < -10f)
            Destroy(this.gameObject);
	}
}
