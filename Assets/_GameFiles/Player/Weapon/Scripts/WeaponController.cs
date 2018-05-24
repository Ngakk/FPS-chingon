using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mangos {
	public class WeaponController : MonoBehaviour {
		
		public Animator anim;
		public Camera cam;
		public GameObject granada;
		public GameObject granadaSpawnPoint;
		static public AxeCollider axeCollider;
		public Weapon weaponState = Weapon.sniper;
		//sniper stats
		public float sniperPower;
		public float sniperFirerate;
		public float sniperMaxAmunition;
		float sniperAmunition;
		float lastSnipershoot;
		//Granade launcher stats
		public float granadaPower;
		public float launcherFirerate;
		public float launcherMaxAmunition;
		float launcherAmunition;
		float lastLaunchershoot;
		//Axe stats
		public float meleeSwingrate;
		float lastMeleeswing;
	
		// Use this for initialization
		void Start () {
			StaticManager.inputManager.weaponController = this;
			PoolManager.PreSpawn(granada, 5);
			PoolManager.SetPoolLimit (granada, 8);
			sniperAmunition = sniperMaxAmunition;
			launcherAmunition = launcherMaxAmunition;
			StaticManager.uiController.SetCurrentAmmo(sniperAmunition.ToString());
			StaticManager.uiController.SetMaxAmmo(sniperMaxAmunition.ToString());
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
				StaticManager.uiController.SetCurrentAmmo(sniperAmunition.ToString());
				StaticManager.uiController.SetMaxAmmo(sniperMaxAmunition.ToString());
				break;
			case 1:
				weaponState = Weapon.granade;
				StaticManager.uiController.SetCurrentAmmo(launcherAmunition.ToString());
				StaticManager.uiController.SetMaxAmmo(launcherMaxAmunition.ToString());
				break;
			case 2:
				weaponState = Weapon.axe;
				StaticManager.uiController.SetCurrentAmmo("-");
				StaticManager.uiController.SetMaxAmmo("-");
				break;
			default :
				break;
			}
		}
		
		public void StartReload(){
			switch(weaponState)
			{
			case Weapon.sniper:
				if(sniperAmunition != sniperMaxAmunition)
					anim.SetTrigger("ReloadSniper");
				break;
			case Weapon.granade:
				if(launcherAmunition != launcherMaxAmunition)
					anim.SetTrigger("ReloadLauncher");
				break;
			default:
				break;
			}
		}
		
		public void Reload(Weapon _w)
		{
			switch(_w)
			{
			case Weapon.sniper:
				sniperAmunition = sniperMaxAmunition;
				StaticManager.uiController.SetCurrentAmmo(sniperAmunition.ToString());
				break;
			case Weapon.granade:
				launcherAmunition++;
				StaticManager.uiController.SetCurrentAmmo(launcherAmunition.ToString());
				
				if(launcherAmunition == launcherMaxAmunition)
					anim.SetTrigger("ReloadEnd");
				
				break;
			default:
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
				
			if(sniperAmunition > 0){
				
				StaticManager.audioManager.PlayGunShot(transform.position);
				StaticManager.fpcontroller.AddTrauma(0.1f);
				
				RaycastHit hit;
				
				Ray rayo = cam.ScreenPointToRay(new Vector3(Screen.width/2f, Screen.height/2, 1));
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
				sniperAmunition--;
				StaticManager.uiController.SetCurrentAmmo(sniperAmunition.ToString());
			}
			else
			{
				StaticManager.audioManager.PlayEmptyShoot(transform.position);
			}
			
			lastSnipershoot = Time.time;
		}

		//Granade Launcher Shoot
		public void StartGranadeAnim(){
			if(Time.time > lastLaunchershoot + launcherFirerate)
				anim.SetTrigger ("ShootGranada");
		}
		
		public void ShootGranada(){
			if(launcherAmunition > 0)
			{
				anim.ResetTrigger("ShootGranada");
	
				Transform go = PoolManager.Spawn(granada, granadaSpawnPoint.transform.position, Quaternion.identity);
				go.GetComponent<Rigidbody>().AddForce((Vector3.Lerp(cam.transform.forward, Vector3.up, 0.2f)).normalized * granadaPower);
				StaticManager.audioManager.PlayGranadaLauncher(transform.position);
				
				launcherAmunition--;
				StaticManager.uiController.SetCurrentAmmo(launcherAmunition.ToString());
			}
			else 
			{
				StaticManager.audioManager.PlayEmptyShoot(transform.position);
			}
			lastLaunchershoot = Time.time;
			
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
		
		//General animation stuff
		public void ClearChangers()
		{

			anim.ResetTrigger("AxeToSniper");
			anim.ResetTrigger("SniperToLauncher");
			anim.ResetTrigger("LauncherToAxe");

		}
		
		public void ClearShooters()
		{
			anim.ResetTrigger("SwingAxe");
			anim.ResetTrigger("ShootGranada");
			anim.ResetTrigger("ShootSniper");
		}
	}
}
