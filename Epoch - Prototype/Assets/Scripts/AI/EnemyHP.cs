using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHP : MonoBehaviour
{
    public float enemyHP = 500f;
    // Start is called before the first frame update
    public void TakeDamage(float damage)
    {
        enemyHP -= damage;
        if(enemyHP <= 0f)
        {
            EnemyDie();
        }
    }

    void EnemyDie()
    {
        Destroy(gameObject);
    }
}
