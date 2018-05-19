using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mangos{
	public class HomeRun : MonoBehaviour {
	
		public float power;
	
		void OnTriggerStay(Collider _col)
		{
			HitData hitData;
			hitData.hitPos = GetComponentInParent<Camera>().gameObject.transform.forward;
			hitData.shooterPos = Vector3.zero;
			hitData.weapon = Weapon.homeRun;
			hitData.power = power; 
			_col.gameObject.SendMessage("GetHit", hitData, SendMessageOptions.DontRequireReceiver);
		}
		
	}
}
