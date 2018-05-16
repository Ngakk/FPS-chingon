using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mangos {
	public class Pomegranate : MonoBehaviour {
	
		public GameObject expArea;
		public float lifetime;
		
		void SelfDespawn(){
			PoolManager.Despawn(gameObject);
		}
		
		void OnSpawn(){
			Invoke("SelfDespawn", lifetime);
			gameObject.GetComponentInChildren<MeshRenderer>().enabled = true;
		}
		
		void OnDespawn(){
			CancelInvoke();
			GetComponent<Rigidbody>().velocity = Vector3.zero;
			PoolManager.Spawn(expArea, transform.position, Quaternion.identity);
		}
	}
}