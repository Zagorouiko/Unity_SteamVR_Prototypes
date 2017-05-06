using UnityEngine;
using System.Collections;

public class airplane : MonoBehaviour {

    public GameObject Explosion;

	void OnTriggerEnter()
    {
        Vector3 temp = transform.position;
        temp.y += 10f;
        Instantiate(Explosion, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
}
