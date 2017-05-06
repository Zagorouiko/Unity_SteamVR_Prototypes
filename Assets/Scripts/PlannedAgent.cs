using UnityEngine;
using System.Collections;

public class PlannedAgent : MonoBehaviour {

    public Vector3[] points;

    int counter = 0;
    private NavMeshAgent agent;

    private GameObject followTarget;

    // Use this for initialization
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        // Check if we've reached the destination
        if (!agent.pathPending)
        {
            if (agent.remainingDistance <= agent.stoppingDistance)
            {

                if (!agent.hasPath || agent.velocity.sqrMagnitude == 0f)

                {
                    //Done
                    NewDestination();
                }
            }
        }
    }

    private void NewDestination()
    {
        counter = (counter + 1) % points.Length;
        Vector3 newDest;

        if (followTarget != null)
        {
            newDest = followTarget.transform.position;
        } else {
            counter = (counter + 1) % points.Length;
            newDest = points[counter];
        }

        NavMeshHit hit;
        bool hasDestination = NavMesh.SamplePosition(newDest, out hit, 100f, 1);
        if (hasDestination)
        {
            agent.SetDestination(hit.position);
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "player")
            followTarget = other.gameObject;
    }
}
