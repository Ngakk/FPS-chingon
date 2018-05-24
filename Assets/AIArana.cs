using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mangos
{
    public class AIArana : MonoBehaviour
    {
        Animator anim;
        Rigidbody rigi;
        //Stats
        public float MaxHP;
        float HP;
        [Range(0, 1)]
        public float defense;
        public float attack;
        public float invulnerabilityTime;
        float lastHit;
        bool vulnerable = true;


        Transform player;               // Reference to the player's position.
                                        //PlayerHealth playerHealth;      // Reference to the player's health.
                                        //EnemyHealth enemyHealth;        // Reference to this enemy's health.
        UnityEngine.AI.NavMeshAgent nav;               // Reference to the nav mesh agent.

        void Awake()
        {
            // Set up the references.
            player = GameObject.FindGameObjectWithTag("Player").transform;
            //playerHealth = player.GetComponent <PlayerHealth> ();
            //enemyHealth = GetComponent <EnemyHealth> ();
            nav = GetComponent<UnityEngine.AI.NavMeshAgent>();
        }

        void Start()
        {
            anim = GetComponentInChildren<Animator>();
            rigi = GetComponent<Rigidbody>();
        }

        void Update()
        {
            // If the enemy and the player have health left...
            //if(enemyHealth.currentHealth > 0 && playerHealth.currentHealth > 0)
            //{
            // ... set the destination of the nav mesh agent to the player.
            nav.SetDestination(player.position);
            //}
            // Otherwise...
            //else
            //{
            // ... disable the nav mesh agent.
            //nav.enabled = false;
            //}
            
        }

        public void GetHit(HitData hitData)
        {
            if (vulnerable)
            {
                switch (hitData.weapon)
                {
                    case Weapon.sniper:
                        StartCoroutine("damageStop");
                        HP -= hitData.power * defense;
                        if (HP <= 0)
                            Die();
                        break;
                    case Weapon.granade:
                        StartCoroutine("damageStop");
                        HP -= hitData.power * defense;
                        if (HP <= 0)
                            Die();
                        break;
                    case Weapon.axe:
                        HP = 0;
                        Die();
                        break;
                    default:
                        break;
                }
            }
        }

        IEnumerator damageStop()
        {
            vulnerable = false;
            Vector3 temp = rigi.angularVelocity;
            rigi.angularVelocity = Vector3.zero;
            rigi.gameObject.GetComponentInChildren<MeshRenderer>().material.SetColor("_EmissionColor", Color.white);
            float startTime = Time.time;

            while (Time.time < startTime + invulnerabilityTime)
            {
                rigi.gameObject.GetComponentInChildren<MeshRenderer>().material.SetColor("_EmissionColor", Color.Lerp(Color.white, Color.black, Mathf.InverseLerp(startTime, startTime + invulnerabilityTime, Time.time)));
                yield return null;
            }

            rigi.angularVelocity = temp;
            rigi.gameObject.GetComponentInChildren<MeshRenderer>().material.SetColor("_EmissionColor", Color.black);
            vulnerable = true;
        }

        public void Die()
        {

        }

        public void OnSpawn()
        {

        }

        public void OnDespawn()
        {

        }
    }
}