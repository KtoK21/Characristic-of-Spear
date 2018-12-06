using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour {
    public GameObject rightHand;
    public GameObject leftHand;
    public GameObject spear;
	
	// Update is called once per frame
	void Update () {
        Vector3 from = rightHand.transform.position;
        Vector3 to = leftHand.transform.position;
        Vector3 relative = to-from;
        Quaternion rotation = Quaternion.LookRotation(relative)* Quaternion.Euler(90f,0f,0f);
        spear.transform.rotation = rotation; 
	}
}
