using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mangos {
	public class Pomegranate : MonoBehaviour {
	
		public GameObject expArea;
		
		void SelfDespawn(){
			Expurosion();
			PoolManager.Despawn(gameObject);
		}
		
		void OnSpawn(){
			Invoke("SelfDespawn", 3f);
			expArea.SetActive(false);
		}
		
		void OnDespawn(){
			CancelInvoke();
			GetComponent<Rigidbody>().velocity = Vector3.zero;
		}
		
		void Expurosion(){
			expArea.SetActive(true);
		}
		
		void OnTriggerEnter(Collider _col){
			Mangos.HitData hitData;
			hitData.weapon = Weapon.granade;
			hitData.shooterPos = gameObject.transform.position;
			hitData.hitPos = _col.gameObject.transform.position;
			hitData.power = 50;
			
			_col.gameObject.SendMessage("GetHit", hitData, SendMessageOptions.DontRequireReceiver);
		}
	}
}