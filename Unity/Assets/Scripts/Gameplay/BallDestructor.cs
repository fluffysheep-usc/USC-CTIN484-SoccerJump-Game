﻿using UnityEngine;
using System.Collections;

public class BallDestructor : MonoBehaviour {

	// HACK -- Fixes double scoring on same round.
	public bool mBallCanScore = true;

	public bool canDrop = false;

	void Start()
	{
		transform.parent = GameObject.Find ("Players").transform;
		if (!canDrop)
		{
			rigidbody.isKinematic = false;
			rigidbody.velocity = Vector3.zero;
			rigidbody.isKinematic = true;
			SingletonObject.Get.getTimer().Add(gameObject.GetInstanceID() + "dropping",
			                                          Drop, 300.0f, false);
		}
	}

	void Drop()
	{
		rigidbody.isKinematic = false;
		rigidbody.AddForce (Vector3.down * 1.5f);
	}


	void OnCollisionEnter(Collision other) {
		if (other.gameObject.CompareTag("Deadzone")) {
			mBallCanScore = true;
			rigidbody.velocity = Vector3.zero;
			transform.position = Vector3.up * 20;
            float horiz = Random.Range(-333, 333) * 1f;
			rigidbody.AddForce(new Vector3(horiz, -1, 0));
		}
	}
}
