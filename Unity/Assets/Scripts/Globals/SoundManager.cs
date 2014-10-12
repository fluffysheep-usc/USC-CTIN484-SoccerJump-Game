﻿using UnityEngine;
using System.Collections.Generic;

/* adapted from https://dl.dropboxusercontent.com/u/96068012/Tutorials/AudioManager/AudioManagerTutorial.pdf */

public class SoundManager : Singleton {

	private List<GameObject> loopSounds = new List<GameObject>();
	GameObject mCamera;

	void Start() {
		// Find the main camera
		mCamera = GameObject.Find ("Main Camera");

	}
	
	public void play(AudioClip clip)
	{
		play(clip, false);
	}
	public void play(AudioClip clip, bool loop, float vol = 1)
	{
		GameObject sound = new GameObject();
		sound.transform.position = mCamera.transform.position;
		sound.AddComponent<AudioSource>();
		AudioSource audioSource = sound.GetComponent<AudioSource>();
		audioSource.playOnAwake = false;
		audioSource.rolloffMode = AudioRolloffMode.Linear; // not sure what this does
		audioSource.clip = clip;
		audioSource.loop = loop;
		audioSource.volume = vol;
		audioSource.Play();
		if (! loop) Destroy(sound, clip.length);
		else loopSounds.Add(sound);
	}
	
	public void stop(AudioClip clip) {
		foreach(GameObject sound in loopSounds) {
			if (sound.GetComponent<AudioSource>().clip.Equals(clip))
			{
				loopSounds.Remove(sound);
				Destroy (sound);
				break; // if we only have one looping clip of a kind at any given point
			}
		}
	}
	
	#region Inherited functions
	protected override void DestroyIfMoreThanOneOnObject(){
		if (transform.GetComponents<InputManager>().Length > 1){
			Debug.Log ("Destroying Extra " + this.GetType() + " Attachment");
			DestroyImmediate(this);
		}
	}
	#endregion
	
}