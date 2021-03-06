﻿using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Rigidbody))]
public class SwordCutter : MonoBehaviour {

	public Material capMaterial;

    public SteamVR_TrackedObject trackedObj;

    void OnCollisionEnter(Collision collision)
    {
        GameObject victim = collision.collider.gameObject;

        GameObject[] pieces = BLINDED_AM_ME.MeshCut.Cut(victim, transform.position, transform.right, capMaterial);

        if (!pieces[1].GetComponent<Rigidbody>())
        {
            pieces[1].AddComponent<Rigidbody>();
            MeshCollider temp = pieces[1].AddComponent<MeshCollider>();
            temp.convex = true;
        }

        StartCoroutine(LongVibration(.2f, .2f));

        Destroy(pieces[1], 1);
    }

    IEnumerator LongVibration(float length, float strength)
    {
        for (float i = 0; i < length; i += Time.deltaTime)
        {
            SteamVR_Controller.Input((int) trackedObj.index).TriggerHapticPulse((ushort)Mathf.Lerp(0, 3999, strength));
            yield return null;
        }
    }
}
