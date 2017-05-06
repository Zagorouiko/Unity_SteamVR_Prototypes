using UnityEngine;
using System.Collections;

public class LineMovement : MonoBehaviour {

    public float speed;
    public Vector3 dir;

    private float rand1;
    private float rand2;
    private float rand3;

    private Renderer rend;

	// Use this for initialization
	void Start () {
        rend = GetComponent<Renderer>();
    }
	
	// Update is called once per frame
	void Update () {

    }

    void FixedUpdate()
    {
        rand1 = Random.Range(0f, 5f) * Time.deltaTime;
        rand2 = Random.Range(0f, 15f) * Time.deltaTime;
        rand3 = Random.Range(0f, 10f) * Time.deltaTime;

        Color newColor = new Color(Random.value, Random.value, Random.value, 1.0f);
        rend.material.color = newColor;

        transform.position += dir.normalized * speed;
        transform.localScale += new Vector3(rand1, 0, 0);
        transform.Rotate(rand1, rand2, rand2);
        CubeShorten();
    }

    private void CubeShorten()
    {
        if (transform.localScale.x > 15f)
        {
            transform.localScale -= new Vector3(rand2, 0, 0);
        } 
    }
}
