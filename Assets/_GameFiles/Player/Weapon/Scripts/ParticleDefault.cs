using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mangos{
	public class ParticleDefault : MonoBehaviour {
	
		public ParticleSystem ps;
	
		public float lifetime;
		// Use this for initialization
		void Start () {
			ps = GetComponent<ParticleSystem>();
		}
		
		void SelfDespawn(){
			PoolManager.Despawn(gameObject);
		}
		
		void OnDespawn()
		{
			ps.Stop();
		}
		
		void OnSpawn(){
			Invoke("SelfDespawn", lifetime);
			ps.Play();
		}
	}
}
