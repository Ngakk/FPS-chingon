using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mangos{
	public class DefaultSound : MonoBehaviour {
		
		public AudioSource dj;
		
		void Start(){
			dj = GetComponent<AudioSource>();
		}
		
		public void SelfDespawn(){
			PoolManager.Despawn(gameObject);
		}
		
		public void OnSpawn()
		{
			Invoke("SelfDespawn", dj.clip.length);
			dj.Play();
		}
		
		public void OnDespawn()
		{
			dj.Stop();
		}
		
	}
}
