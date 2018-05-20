using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mangos{
	public class DefaultPoolItem : MonoBehaviour {
		
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
	
		}
			
		void OnSpawn(){
			Invoke("SelfDespawn", lifetime);
			
		}
	}
}
