using UnityEngine;
using System.Collections;

public class Cam : MonoBehaviour {
    private float time;

    //rotation
    public float angle;
    private float rotationZz;
    private float smooth;
	// Use this for initialization
	void Start () {
        time = Time.deltaTime;
        smooth = 2.0f;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("right") || Input.GetKey("d"))
        {
            rotationZz = Input.GetAxis("Horizontal") * angle;
            Quaternion target = Quaternion.Euler(0, rotationZz, 0);
            transform.rotation = Quaternion.Slerp(transform.rotation, target, time * smooth);
        }
        if (Input.GetKeyDown("left") || Input.GetKey("a"))
        {
            rotationZz = Input.GetAxis("Horizontal") * -angle;
            Quaternion target = Quaternion.Euler(0, -rotationZz, 0);
            transform.rotation = Quaternion.Slerp(transform.rotation, target, time * smooth);
        }
	}
}
