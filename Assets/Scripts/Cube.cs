using UnityEngine;
using System.Collections;

public class Cube : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerStay()
    {
        touchCube();
    }

    void OnTriggerEnter()
    {
        touchCube();
    }

    void touchCube()
    {
        Destroy(this.gameObject);
    }
}
