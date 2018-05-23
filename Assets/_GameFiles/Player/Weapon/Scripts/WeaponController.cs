using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mangos {
	public class WeaponController : MonoBehaviour {
		
		Animator anim;
		public Camera cam;
		public GameObject granada;
		public GameObject granadaSpawnPoint;
		static public AxeCollider axeCollider;
		public Weapon weaponState = Weapon.sniper;
		//sniper stats
		public float sniperPower;
		public float sniperFirerate;
		float lastSnipershoot;
		//Granade launcher stats
		public float granadaPower;
		public float launcherFirerate;
		float lastLaunchershoot;
		//Axe stats
		public float meleeSwingrate;
		float lastMeleeswing;
	
		// Use this for initialization
		void Start () {
			anim = GetComponent<Animator>();
			StaticManager.inputManager.weaponController = this;
			PoolManager.PreSpawn(granada, 5);
			PoolManager.SetPoolLimit (granada, 8);
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
			if(Time.time > lastSnipershoot + sniperFirerate)
				anim.SetTrigger("ShootSniper");
		}
		
		public void ShootSniper(){
			anim.ResetTrigger("ShootSniper");
			
			StaticManager.audioManager.PlayGunShot(transform.position);
			
			RaycastHit hit;
			
			Ray rayo = cam.ScreenPointToRay(Input.mousePosition);
			if(Physics.Raycast(rayo, out hit))
			{
				HitData hitData;
				hitData.weapon = Weapon.sniper;
				hitData.shooterPos = cam.transform.position;
				hitData.hitPos = hit.point;
				hitData.power = sniperPower;
				hitData.rayHit = hit;
				
				hit.collider.gameObject.SendMessage("GetHit", hitData, SendMessageOptions.DontRequireReceiver);
			}
			
			lastSnipershoot = Time.time;
		}
		
		public void ShootSniperBullet(){
			
		}
		
		public void EndSniper(){
			
		}

		//Granade Launcher Shoot
		public void StartGranadeAnim(){
			if(Time.time > lastLaunchershoot + launcherFirerate)
				anim.SetTrigger ("ShootGranada");
		}
		
		public void ShootGranada(){
			anim.ResetTrigger("ShootGranada");

			Transform go = PoolManager.Spawn(granada, granadaSpawnPoint.transform.position, Quaternion.identity);
			go.GetComponent<Rigidbody>().AddForce((Vector3.Lerp(cam.transform.forward, Vector3.up, 0.2f)).normalized * granadaPower);
			
			lastLaunchershoot = Time.time;
			
			StaticManager.audioManager.PlayGranadaLauncher(transform.position);
		}
		
		//Axe swing
		public void StartAxeSwingAnimation(){
			if(Time.time > lastMeleeswing + meleeSwingrate){
				anim.SetTrigger("SwingAxe");
				axeCollider.StartAxeSwingAnimation();
			}
		}
		
		public void AxeSwing(){
			anim.ResetTrigger("SwingAxe");
			lastMeleeswing = Time.time;
		}
		
		
		public void AxeSound(){
			StaticManager.audioManager.PlaySwoosh(transform.position);
		}
		
		public bool CheckGranadeProximity(){
			return true;
		}
		
		//General animation stuff
		public void ClearTriggers()
		{
			anim.ResetTrigger("SwingAxe");
			anim.ResetTrigger("ShootGranada");
			anim.ResetTrigger("ShootSniper");
		}
	}
}
