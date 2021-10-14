using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class FishScript : MonoBehaviour
{
    private GameHandler gameHandler;
    public int points = 5;
    public float speed;
    public bool damage = false;
    public PlayerStats playerStats;
    public Vector3 size;
    private readonly float changeDirTime = 5f;
    private float recentDirChange;
    // Start is called before the first frame update
    public void Start()
    {
        gameHandler = GameHandler.Instance;
        playerStats = GameObject.FindGameObjectWithTag("PlayerStats").GetComponent<PlayerStats>();
        //moveFish();
    }

    public void setSize(Vector3 num)
    {
        size = num;
    }

    public void setDamage(bool dam)
    {
        damage = dam;
    }

    public void setSpeed(float num)
    {
        speed = num;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            int sizePoints = (int)(size.x+size.y+size.z/3) * points;
            if (damage)
            {
                
                if(playerStats.totalPoints - sizePoints < 0)
                {
                    playerStats.damagePlayer();
                    playerStats.totalPoints = 0;
                }
                else
                {
                    playerStats.damagePlayer();
                    playerStats.removePoints(sizePoints);
                }
                
            }
            else
            {
                playerStats.addPoints(sizePoints);
            }
            
            Destroy(gameObject);
        }
    }
}
