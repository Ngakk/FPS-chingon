using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Notice : StateMachineBehaviour {
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		/*if(stateInfo.IsName("JUMP00")){
			animator.GetComponent<UnityChanController>().JumpStart();
		}	
		if(stateInfo.IsName("DAMAGED01")){
			animator.GetComponent<UnityChanController>().DethStart();
		}
		if(stateInfo.IsName("WIN00")){
			animator.GetComponent<UnityChanController>().WinStart();
		}
		if(stateInfo.IsName("WAIT01")){
			animator.GetComponent<UnityChanController>().WaitStart();
		}*/
	}
	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		/*if(stateInfo.IsName("JUMP00")){
			animator.GetComponent<UnityChanController>().JumpEnd();
		}	
		if(stateInfo.IsName("DAMAGED01")){
			animator.GetComponent<UnityChanController>().DethEnd();
		}
		if(stateInfo.IsName("WIN00")){
			animator.GetComponent<UnityChanController>().WinEnd();
		}
		if(stateInfo.IsName("WAIT01")){
			animator.GetComponent<UnityChanController>().WaitEnd();
		}*/
	}

}
