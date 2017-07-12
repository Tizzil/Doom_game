using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform player;
    public float speed;
    public int hp;
    public int dmg;



    void FixedUpdate()
    {
        EnemyLostSoulControls();



    }

    void EnemyLostSoulControls()
    {
        // пара переменных
        float 
            enemyX = GetComponent<Transform>().position.x,
            enemyY = GetComponent<Transform>().position.y,
            vectorX = 0.0f,
            vectorY = 0.0f,
            playerX = player.GetComponent<Transform>().position.x,
            playerY = player.GetComponent<Transform>().position.y;
        // ...
        vectorX = (playerX - enemyX);
        vectorY = (playerY - enemyY);
        // модуль
        float module = Mathf.Sqrt((Mathf.Pow(vectorX, 2)) + (Mathf.Pow(vectorY, 2)));
        // ...
        vectorX /= module;
        vectorY /= module;
        //  скорость
        vectorX *= speed;
        vectorY *= speed;
        // поехали
        GetComponent<Transform>().position = new Vector2 (enemyX + vectorX, enemyY + vectorY);
    }
}

/*
            EN_Speedx = (Target.x - x);
			EN_Speedy = (Target.y - y);
			
			var module = Math.sqrt(Math.pow(EN_Speedx, 2) + Math.pow(EN_Speedy, 2));
			
			EN_Speedx /= module;
			EN_Speedy /= module;
			
			EN_Speedx *= 7;
			EN_Speedy *= 7;
 */
