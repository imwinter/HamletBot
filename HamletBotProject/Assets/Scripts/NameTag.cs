using UnityEngine;
using System.Collections;

public class NameTag : MonoBehaviour {

	public Transform target;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.LookAt(target);
		transform.Rotate(Vector3.up*180);
	}
}
