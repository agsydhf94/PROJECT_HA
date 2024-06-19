using HA;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamagable
{
    public float enemyHp = 100.0f;
    public bool isDead = false;



    private void Update()
    {
        if (enemyHp > 0)
        {
            isDead = false;
        }
        else
        {
            isDead = true;
            gameObject.SetActive(!isDead);

        }
    }

    

    
    public void Damage()
    {
        if(!isDead)
        {
            enemyHp -= 20.0f;
        }
    }

    
}
