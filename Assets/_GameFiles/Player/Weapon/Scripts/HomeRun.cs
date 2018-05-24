using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mangos{
	public class HomeRun : MonoBehaviour {
	
		public float power;
		public Camera cam;
	
		void OnTriggerStay(Collider _col)
		{
			HitData hitData;
			hitData.hitPos = cam.gameObject.transform.forward;
			hitData.shooterPos = Vector3.zero;
			hitData.weapon = Weapon.homeRun;
			hitData.power = power; 
			hitData.rayHit = new RaycastHit();
			_col.gameObject.SendMessage("GetHit", hitData, SendMessageOptions.DontRequireReceiver);
		}
		
	}
}
