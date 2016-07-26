using UnityEngine;
using System.Collections;

public class Sniper : MonoBehaviour {

    public Transform BulletSpawnPoint;
    public GameObject BulletPrefab;

    public SteamVR_TrackedObject rightController;

    public Camera scopeCamera;

    public const float minFOV = 10f;
    public const float maxFOV = 90f;
	
	// Update is called once per frame
	void Update () {
        var device = SteamVR_Controller.Input((int)rightController.index);
        if (device.GetTouchDown(SteamVR_Controller.ButtonMask.Trigger))
        {
            GameObject go = Instantiate(BulletPrefab, BulletSpawnPoint.position, BulletSpawnPoint.transform.rotation) as GameObject;
            go.transform.Rotate(90f, 0f, 0f);
            go.GetComponent<Rigidbody>().velocity = 700f * BulletSpawnPoint.transform.forward;
        }

        if (device.GetPress(SteamVR_Controller.ButtonMask.Touchpad))
        {
            float touchY = device.GetAxis(Valve.VR.EVRButtonId.k_EButton_Axis0).y;
            float fov = scopeCamera.fieldOfView - 1f * touchY;
            if (fov < minFOV)
            {
                scopeCamera.fieldOfView = minFOV;
            } else if (fov > maxFOV)
            {
                scopeCamera.fieldOfView = maxFOV;
            } else
            {
                scopeCamera.fieldOfView = fov;
            }
        }
    }
}
