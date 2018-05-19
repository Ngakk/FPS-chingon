using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mangos {
	public class Pomegranate : MonoBehaviour {
	
		public GameObject expArea;
		public float lifetime;
		bool isUnstable;
		
		void SelfDespawn(){
			PoolManager.Despawn(gameObject);
		}
		
		void OnSpawn(){
			Invoke("SelfDespawn", lifetime);
			gameObject.GetComponentInChildren<MeshRenderer>().enabled = true;
			isUnstable = false;
		}
		
		void OnDespawn(){
			CancelInvoke();
			GetComponent<Rigidbody>().velocity = Vector3.zero;
			PoolManager.Spawn(expArea, transform.position, Quaternion.identity);
		}
		
		void OnCollisionEnter(Collision _col)
		{
			if(isUnstable)
				PoolManager.Despawn(gameObject);
		}
		
		public void GetHit(HitData hitData)
		{
			print("got hit pomegranate");
			switch(hitData.weapon)
			{
			case Weapon.homeRun:
				isUnstable = true;
				GetComponent<Rigidbody>().velocity = Vector3.zero;
				GetComponent<Rigidbody>().AddForce((hitData.hitPos - hitData.shooterPos).normalized * hitData.power, ForceMode.Impulse);
				CancelInvoke();
				Invoke("SelfDespawn", 10f);
				break;
			default:
				break;
			}
		}
	}
}