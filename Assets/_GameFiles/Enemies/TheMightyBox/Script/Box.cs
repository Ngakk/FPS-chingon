using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mangos{
	public class Box : MonoBehaviour {
	
		Rigidbody rigi;
		// Use this for initialization
		void Start () {
			rigi = GetComponent<Rigidbody>();
		}
		
		// Update is called once per frame
		void Update () {
			
		}
		
		public void GetHit(HitData hitData){
			rigi.AddForce((hitData.hitPos - hitData.shooterPos).normalized * hitData.power);
		}
	}
}