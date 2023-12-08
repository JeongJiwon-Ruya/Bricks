using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSourceManager : MonoBehaviour {
  public static AudioSourceManager instance;

  public AudioSource[] audioSources;

  void Awake() {
    if(instance == null) {
      instance = this;
      DontDestroyOnLoad(gameObject);
    } else {
      Destroy(gameObject);
    }
  }

  private void Start() {
    audioSources = GetComponents<AudioSource>();
  }

  public void PlaySource1(AudioClip clip) {
    audioSources[0].PlayOneShot(clip);
  }

  public void PlaySource2(AudioClip clip) {
    audioSources[1].PlayOneShot(clip);
  }
}
