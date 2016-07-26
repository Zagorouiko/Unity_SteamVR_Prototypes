using UnityEngine;
using System.Collections;

public class Slingshot : MonoBehaviour
{

    public GameObject ballPrefab;
    public GameObject slingGO;

    private Vector3 slingShotStart;


    private GameObject currBall;
    private bool ready = true;

    private SteamVR_TrackedObject trackedController;
    private bool inSlingShot = false;

    private LaserArc arc;

    public float STRENGTH = 20f;

    // Use this for initialization
    void Start()
    {
        slingShotStart = slingGO.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (ready)
        {
            currBall = Instantiate(ballPrefab);
            currBall.transform.parent = slingGO.transform;
            currBall.transform.localPosition = Vector3.zero;
            arc = GetComponent<LaserArc>();
            currBall.GetComponent<LineRenderer>().enabled = false;
            ready = false;
        }

        currBall.transform.LookAt(slingShotStart);

        if (trackedController != null)
        {
            var device = SteamVR_Controller.Input((int)trackedController.index);
            if (inSlingShot)
            {
                if (device.GetTouchUp(SteamVR_Controller.ButtonMask.Trigger))
                {

                    currBall.GetComponent<LineRenderer>().enabled = false;
                    inSlingShot = false;

                    Vector3 ballPos = currBall.transform.position;

                    slingGO.transform.position = slingShotStart;
                    currBall.transform.parent = null;

                    Rigidbody r = currBall.GetComponent<Rigidbody>();
                    r.velocity = (slingShotStart - ballPos) * STRENGTH;
                    arc.myVelocity = r.velocity.magnitude;
                    r.useGravity = true;
                    ready = true;

                } else if (device.GetTouch(SteamVR_Controller.ButtonMask.Trigger))
                {
                    currBall.GetComponent<LineRenderer>().enabled = true;
                    slingGO.transform.position = trackedController.transform.position;
                }
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        trackedController = other.GetComponent<SteamVR_TrackedObject>();
        if (trackedController != null)
        {
            inSlingShot = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        trackedController = other.GetComponent<SteamVR_TrackedObject>();
        if (trackedController != null)
        {
            inSlingShot = false;
        }
    }
}
