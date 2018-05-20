using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfBounds : MonoBehaviour {

	void OnTriggerExit(Collider _col)
	{
		_col.gameObject.SetActive(false);
	}
}
