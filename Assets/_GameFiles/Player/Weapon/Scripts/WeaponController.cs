using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mangos {
	public class WeaponController : MonoBehaviour {
		
		Animator anim;
		public Camera cam;
		//sniper stats
		public float sniperPower;
		
		void Awake(){
			StaticManager.inputManager.weaponController = this;
		}
	
		// Use this for initialization
		void Start () {
			anim = GetComponent<Animator>();
		}
		
		// Update is called once per frame
		void Update () {
			
		}
		
		//Sniper Shoot
		public void StartShootAnim(){
			anim.SetBool("Shoot", true);
		}
		
		public void ShootSniper(){
			Debug.Log("shoot");
			RaycastHit hit;
			
			Ray rayo = cam.ScreenPointToRay(Input.mousePosition);
			if(Physics.Raycast(rayo, out hit))
			{
				HitData hitData;
				hitData.weapon = Weapon.sniper;
				hitData.shooterPos = cam.transform.position;
				hitData.hitPos = hit.point;
				hitData.power = sniperPower;
				
				hit.collider.gameObject.SendMessage("GetHit", hitData, SendMessageOptions.DontRequireReceiver);
			}
		}
		
		public void ShootSniperBullet(){
			
		}
		
		public void EndSniper(){
			anim.SetBool("Shoot", false);
		}
	}
}
