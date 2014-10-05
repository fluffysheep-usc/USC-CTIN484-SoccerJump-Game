﻿using UnityEngine;
using System.Collections;

public class PlayerConfig {
	private int mPlayerNumber;
	private KeyCode mJump;
	private KeyCode mLeft;
	private KeyCode mRight;

	public int PlayerNumber { get { return mPlayerNumber; } set { mPlayerNumber = value; } }
	public KeyCode Jump { get { return mJump; } set { mJump = value; }}
	public KeyCode Left { get { return mLeft; } set { mLeft = value; }}
	public KeyCode Right { get { return mRight; } set { mRight = value; }}

	public PlayerConfig (KeyCode left, KeyCode jump, KeyCode right) {
		Jump = jump;
		Left = left;
		Right = right;
	}
}
