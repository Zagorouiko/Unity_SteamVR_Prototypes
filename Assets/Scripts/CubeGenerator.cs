using UnityEngine;
using System.Collections;

public class CubeGenerator : MonoBehaviour {

    public SteamVR_TrackedObject trackedObj;
    private GameObject generatedCube;
    public GameObject cubePrefab;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        SteamVR_Controller.Device device = SteamVR_Controller.Input((int)trackedObj.index);
        if (device.GetTouchDown(SteamVR_Controller.ButtonMask.Trigger))
        {
            generatedCube = Instantiate(cubePrefab);
            generatedCube.transform.position = new Vector3(trackedObj.transform.position.x, trackedObj.transform.position.y, trackedObj.transform.position.z);
        } 
	}
}
