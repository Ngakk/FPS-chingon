using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mangos {
	public class WeaponController : MonoBehaviour {
		
		Animator anim;
		public Camera cam;
		public GameObject granada;
		public GameObject granadaSpawnPoint;
		//sniper stats
		public float sniperPower;
		public float granadaPower;
		public Weapon weaponState = Weapon.sniper;
	
		// Use this for initialization
		void Start () {
			anim = GetComponent<Animator>();
			StaticManager.inputManager.weaponController = this;
			PoolManager.PreSpawn(granada, 5);
		}
		
		// Update is called once per frame
		void Update () {
			
		}

		//Weapon change
		public void ChangeWeapon(){
			switch (weaponState) {
			case Weapon.sniper:
				anim.SetTrigger ("SniperToLauncher");
				break;
			case Weapon.granade:
				anim.SetTrigger ("LauncherToAxe");
				break;
			case Weapon.axe:
				anim.SetTrigger ("AxeToSniper");
				break;
			default:
				break;
			}
		}

		public void SetWeapon(int s){
			switch (s) {
			case 0:
				weaponState = Weapon.sniper;
				break;
			case 1:
				weaponState = Weapon.granade;
				break;
			case 2:
				weaponState = Weapon.axe;
				break;
			default :
				break;
			}
		}
		
		//Sniper Shoot
		public void StartShootAnim(){
			anim.SetTrigger("ShootSniper");
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
			
		}

		//Granade Launcher Shoot
		public void StartGranadeAnim(){
			anim.SetTrigger ("ShootGranada");
		}
		
		public void ShootGranada(){
			Transform go = PoolManager.Spawn(granada, granadaSpawnPoint.transform.position, Quaternion.identity);
			go.GetComponent<Rigidbody>().AddForce(cam.transform.forward * granadaPower);
		}
	}
}
