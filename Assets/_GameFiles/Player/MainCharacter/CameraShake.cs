using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour {


	public float trauma;
	public float traumaCureRate;
	public float maxYaw;
	public float maxPitch;
	public float maxRoll;
	public float maxOffset;
	Quaternion preRotation;
	Quaternion shaked;
	
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		trauma -= traumaCureRate * Time.deltaTime;
		
		if(trauma < 0)
			trauma = 0;
			
		ShakeCamera();
		
		if(Input.GetKeyDown(KeyCode.T))
		{
			AddTrauma(0.2f);
		}
	}
	
	public void AddTrauma(float _t)
	{
		trauma += _t;
	}
	
	public void ShakeCamera(){
		
		float yaw, pitch, roll, offsetX, offsetY, offsetZ;
		
		yaw = maxYaw * GetShake() * Random.Range(-1, 1);
		pitch = maxPitch * GetShake() * Random.Range(-1, 1);
		roll = maxRoll * GetShake() * Random.Range(-1, 1);
		offsetX = maxOffset * GetShake() * Random.Range(-1, 1);
		offsetY = maxOffset * GetShake() * Random.Range(-1, 1);
		offsetZ = maxOffset * GetShake() * Random.Range(-1, 1);
		
		preRotation = gameObject.transform.rotation;
		shaked = gameObject.transform.rotation;
		
		shaked.SetEulerRotation(transform.rotation.x + yaw, transform.rotation.y + pitch, transform.rotation.z + roll);
		
		gameObject.transform.rotation = shaked;
	}
	
	public float GetShake(){
		return trauma*trauma;
	}
	
}
