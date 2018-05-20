﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mangos {	
	
	enum soundIndx : int{
		gunShot = 0,
		granadeLauncher,
		explosion,
		swoosh,
		metalStrike
	}
	
	
	
	public class AudioManager : MonoBehaviour {

		public float volumeSFX = 1;
		public float volumeMusic = 1;
		public float MasterVolume = 1;

		public AudioClip[] clips;
		public int[] maxSimultaneousClip;
		public GameObject soundMaker;
		public int maxSimultaneousSounds;
		List<GameObject> sounds = new List<GameObject>();
		
		
		void Awake(){
			StaticManager.audioManager = this;
		}
		
		void Start()
		{
			for(int i = 0; i < clips.Length; i++)
			{
				GameObject temp = new GameObject();
				
				temp.AddComponent<AudioSource>();
				temp.GetComponent<AudioSource>().clip = clips[i];
				temp.AddComponent<DefaultSound>();
				temp.GetComponent<DefaultSound>().dj = temp.GetComponent<AudioSource>();
				temp.name = "soundMaker" + i.ToString();
				sounds.Add(temp);
				PoolManager.PreSpawn(sounds[i], (int)Mathf.Round(maxSimultaneousClip[i]/2));
				PoolManager.SetPoolLimit(sounds[i], maxSimultaneousClip[i]);
			}
			print("audio manager start ended");
		}
		
		
		public void PlayIndexedSound(int i, Vector3 pos){
			PoolManager.Spawn(sounds[i], pos, Quaternion.identity);
		}
		public void PlayExplosion(Vector3 pos){
			PoolManager.Spawn(sounds[(int)soundIndx.explosion], pos, Quaternion.identity);
		}
		public void PlayGranadaLauncher(Vector3 pos){
			PoolManager.Spawn(sounds[(int)soundIndx.granadeLauncher], pos, Quaternion.identity);
		}
		public void PlayGunShot(Vector3 pos){
			PoolManager.Spawn(sounds[(int)soundIndx.gunShot], pos, Quaternion.identity);
		}
		public void PlaySwoosh(Vector3 pos){
			PoolManager.Spawn(sounds[(int)soundIndx.swoosh], pos, Quaternion.identity);
		}
		public void PlayMetalStrike(Vector3 pos){
			PoolManager.Spawn(sounds[(int)soundIndx.metalStrike], pos, Quaternion.identity);
		}
	}
}

