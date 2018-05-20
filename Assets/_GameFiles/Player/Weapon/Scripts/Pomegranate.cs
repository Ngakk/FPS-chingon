using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mangos {
	public class Pomegranate : MonoBehaviour {
	
		public GameObject expArea;
		public GameObject explosionParticle;
		public float lifetime;
		Rigidbody rigi;
		bool isUnstable;
		
		void Start(){
			PoolManager.PreSpawn(expArea, 5);
			PoolManager.SetPoolLimit(expArea, 25);
			PoolManager.PreSpawn(explosionParticle, 10);
			PoolManager.SetPoolLimit(explosionParticle, 35);
			
			rigi = GetComponent<Rigidbody>();
		}
		
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
			rigi.velocity = Vector3.zero;
			PoolManager.Spawn(expArea, transform.position, Quaternion.identity);
			PoolManager.Spawn(explosionParticle, transform.position, Quaternion.identity);
			StaticManager.audioManager.PlayExplosion(transform.position);
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
				rigi.velocity = Vector3.zero;
				rigi.AddForce((hitData.hitPos - hitData.shooterPos).normalized * hitData.power, ForceMode.Impulse);
				CancelInvoke();
				Invoke("SelfDespawn", 10f);
				StaticManager.audioManager.PlayMetalStrike(transform.position);
				break;
			case Weapon.sniper:
				SelfDespawn();
				break;
			case Weapon.granade:
				rigi.AddForce((hitData.hitPos - hitData.shooterPos).normalized * hitData.power, ForceMode.Impulse);
				break;
			default:
				break;
			}
		}
	}
}