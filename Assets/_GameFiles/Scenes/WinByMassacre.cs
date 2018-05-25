using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mangos
{
    public class WinByMassacre : MonoBehaviour
    {
        Box[] victims;
        int alive;

        void Start()
        {
            victims = GetComponentsInChildren<Box>();
            alive = victims.Length;
        }

        public void PrayForTheFallen()
        {
            alive--;
            if(alive == 0)
            {
                Win();   
            }
        }

        void Win()
        {
               
        }

    }
}
