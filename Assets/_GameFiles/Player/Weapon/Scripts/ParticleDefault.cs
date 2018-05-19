using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mangos{
	public class ParticleDefault : MonoBehaviour {
	
		ParticleSystem ps;
	
		public float lifetime;
		// Use this for initialization
		void Start () {
			Invoke("SelfDespawn", lifetime);
		}
		
		void SelfDespawn(){
			PoolManager.Despawn(gameObject);
		}
		
		void OnDespawn()
		{
			ps.Stop();
		}
		
		void OnSpawn(){
			ps.Play();
		}
	}
}
