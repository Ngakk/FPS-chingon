﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mangos{
	public class Explosion : MonoBehaviour {
	
		public float power;
		public float explosionDuration;
		// Use this for initialization
		void Start () {
	
		}
		
		// Update is called once per frame
		void Update () {
			
		}
		
		void OnSpawn()
		{
			Invoke("Expurosion", explosionDuration);
		}
		
		void OnTriggerEnter(Collider _col){
			Mangos.HitData hitData;
			hitData.weapon = Weapon.granade;
			hitData.shooterPos = gameObject.transform.position;
			hitData.hitPos = _col.gameObject.transform.position;
			hitData.power = power;
				
			_col.gameObject.SendMessage("GetHit", hitData, SendMessageOptions.DontRequireReceiver);
		}
		
		void Expurosion(){
			PoolManager.Despawn(gameObject);
		}
	}
}