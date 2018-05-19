using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mangos {
	public class AxeCollider : MonoBehaviour {
		
		Animator anim;
		public float power;
		
		// Use this for initialization
		void Awake () {
			Mangos.WeaponController.axeCollider = this;
		}
		
		void Start(){
			anim = GetComponentInParent<Animator>();
		}
		
		// Update is called once per frame
		void Update () {
			
		}
		
		//Axe swing
		public void StartAxeSwingAnimation(){
			anim.SetTrigger("SwingAxe");
		}
		
		public void AxeSwing(){
			anim.ResetTrigger("SwingAxe");
			GetComponentInChildren<MeshCollider>().enabled = true;
			GetComponentInChildren<BoxCollider>().enabled = true;
		}
		
		public void EndSwing(){
			GetComponentInChildren<MeshCollider>().enabled = false;
			GetComponentInChildren<BoxCollider>().enabled = false;
		}
		
		void OnCollisionEnter(Collision _col)
		{
			HitData hitData;
			hitData.weapon = Weapon.axe;
			hitData.shooterPos = gameObject.transform.position;
			hitData.hitPos = _col.gameObject.transform.position;
			hitData.power = power;
			_col.gameObject.SendMessage("GetHit", hitData, SendMessageOptions.DontRequireReceiver);
		}
	}
}
