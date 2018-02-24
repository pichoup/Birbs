using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARControl : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Input.gyro.enabled = true;
	}

    protected void Update()
    {
        GyroModifyCamera();
    }

    // The Gyroscope is right-handed.  Unity is left handed.
    // Make the necessary change to the camera.
    void GyroModifyCamera()
    {
        transform.rotation = GyroToUnity(Input.gyro.attitude);
    }

    private static Quaternion GyroToUnity(Quaternion q)
    {
        return new Quaternion(q.x, q.y, -q.z, -q.w);
    }
}
