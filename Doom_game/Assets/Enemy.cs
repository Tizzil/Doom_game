using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform player;
    public float speed;
    public int hp;
    public int dmg;



    void Update()
    {
        EnemyLostSoulControls();



    }

    void EnemyLostSoulControls()
    {
        // пара переменных
        float 
            enemyX = transform.position.x,
            enemyY = transform.position.y,
            vectorX = 0.0f,
            vectorY = 0.0f,
            playerX = player.transform.position.x,
            playerY = player.transform.position.y;
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

        Vector2 vector1 = new Vector2(enemyX, enemyY),
                vector2 = new Vector2(enemyX + vectorX, enemyY + vectorY);

        transform.position = Vector2.Lerp(vector1, vector2, Time.deltaTime);
        
            //(Mathf.Lerp(enemyX, enemyX + vectorX, 1), (Mathf.Lerp(enemyY, enemyY + vectorY, 1)));
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
