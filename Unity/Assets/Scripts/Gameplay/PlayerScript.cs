﻿using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

	private int mPlayerNumber = 1;
	public int PlayerNumber { get { return mPlayerNumber; } set { mPlayerNumber = value; } }

	private event Action CollisionExit;

	// Player movement gameplay
	public bool mIsGrounded = true;
	public bool IsGrounded { get { return mIsGrounded; } set { mIsGrounded = value;}}

	void Start() {
		// HACK -- Make sure this doesn't break anything in the future.
		if (transform.name.Contains("1")) {
			mPlayerNumber = 1;
		} else if (transform.name.Contains("2")) {
			mPlayerNumber = 2;
		} else if (transform.name.Contains("3")) {
			mPlayerNumber = 3;
		} else if (transform.name.Contains("4")) {
			mPlayerNumber = 4;
		}
	}

	void OnCollisionStay(Collision c) {
		if (!c.gameObject.CompareTag("Ball"))
		mIsGrounded = true;
	}

	void OnCollisionExit(Collision c) {
		mIsGrounded = false;
		if (CollisionExit != null) {
			CollisionExit();
		}
	}

	public void RegisterCollisionExit(Action func) {
		CollisionExit += func;
	}

	public void DeRegisterCollisionExit(Action func) {
		CollisionExit -= func;
	}

}