using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Mangos
{
    public class WinByMassacre : MonoBehaviour
    {
        Box[] victims;
	    public int alive, dead;
	    public Text youWin, txt1, txt2;
	    
	    void Awake(){
	    	StaticManager.winBoxes = this;
	    }

        void Start()
        {
            victims = GetComponentsInChildren<Box>();
	        alive = victims.Length;
	        dead = 0;
	        txt2.text = alive.ToString();
	        txt1.text = dead.ToString();
        }

        public void PrayForTheFallen()
	    {
		    print("praying");
	        dead += 1;
	        txt1.text = dead.ToString();
	        if(alive == dead)
            {
                Win();   
            }
	   
        }

        void Win()
        {
        	youWin.text = "You Win!";
        }

    }
}
