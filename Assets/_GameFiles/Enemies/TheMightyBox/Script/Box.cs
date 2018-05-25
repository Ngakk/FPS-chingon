using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mangos{
	public class Box : MonoBehaviour {
	
		Rigidbody rigi;
		public float breakingPoint;
		public float forceVariance;
		bool alreadyPrayed = false;
		// Use this for initialization
		void Start () {
			rigi = GetComponent<Rigidbody>();
		}
		
		// Update is called once per frame
		void Update () {
			
		}
		
		public void GetHit(HitData hitData){
			switch(hitData.weapon){
			case Weapon.sniper:
				rigi.AddForce((hitData.hitPos - hitData.shooterPos).normalized * hitData.power);
				break;
			case Weapon.granade:
				rigi.AddForce((hitData.hitPos - hitData.shooterPos) * hitData.power, ForceMode.Impulse);
				break;
			case Weapon.axe:
				rigi.AddForce((hitData.hitPos - hitData.shooterPos) * hitData.power, ForceMode.Impulse);
				Break();
				break;
			default:
				break;
			}
		}
		
		void OnCollisionEnter(Collision _col)
		{
            Debug.Log(_col.relativeVelocity.magnitude);
            if (_col.relativeVelocity.magnitude > breakingPoint)
			{
				Break();
			}
		}
		
		public void Break(){
       
            GetComponent<BoxCollider>().enabled = false;
			
			BoxCollider[] hijos = GetComponentsInChildren<BoxCollider>();
			for(int i = 0; i < hijos.Length; i++)
			{
				hijos[i].enabled = true;
				hijos[i].gameObject.AddComponent<Rigidbody>();
				hijos[i].gameObject.GetComponent<Transform>().SetParent(null, true);
                hijos[i].gameObject.AddComponent<Box1>();
			}

			if(!alreadyPrayed)
				StaticManager.winBoxes.PrayForTheFallen();
        		
			alreadyPrayed = true;

			Destroy(gameObject);
		}
	}
}