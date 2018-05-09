using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mangos {
	public class Pomegranate : MonoBehaviour {
	
		// Use this for initialization
		void Start () {
			
		}
		
		// Update is called once per frame
		void Update () {
			
		}
		
		void SelfDespawn(){
			PoolManager.Despawn(gameObject);
		}
		
		void OnSpawn(){
			Invoke("SelfDespawn", 3f);
		}
		
		void OnDespawn(){
			CancelInvoke();
			GetComponent<Rigidbody>().velocity = Vector3.zero;
		}
	}
}