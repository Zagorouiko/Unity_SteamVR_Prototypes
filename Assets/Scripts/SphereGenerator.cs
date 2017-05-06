using UnityEngine;
using System.Collections;

public class SphereGenerator : MonoBehaviour {

    public SteamVR_TrackedObject trackedObj;
    private GameObject generatedSphere;
    public GameObject spherePrefab;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        SteamVR_Controller.Device device = SteamVR_Controller.Input((int)trackedObj.index);
        if (device.GetTouchDown(SteamVR_Controller.ButtonMask.Grip))
        {
            generatedSphere = Instantiate(spherePrefab);
            generatedSphere.transform.position = new Vector3(trackedObj.transform.position.x, trackedObj.transform.position.y, trackedObj.transform.position.z);
        }
    }
}
