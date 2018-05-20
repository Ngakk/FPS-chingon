using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mangos{
	public class Agujereable : MonoBehaviour {
	
		public GameObject agujero;
		
		void Start()
		{
			PoolManager.PreSpawn(agujero, 10);
			PoolManager.SetPoolLimit(agujero, 60);
		}
		
		public void GetHit(HitData hitData)
		{
			switch(hitData.weapon)
			{
			case Weapon.sniper:
				Transform go = PoolManager.Spawn(agujero, hitData.rayHit.point, Quaternion.identity);
				Vector3 s = hitData.rayHit.normal;
				
				go.rotation = Quaternion.FromToRotation(Vector3.back, s);
				go.position += (s*0.005f);
				break;
			default:
				break;
			}
		}
	}
}
