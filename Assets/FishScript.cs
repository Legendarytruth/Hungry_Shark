using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class FishScript : MonoBehaviour
{
    private GameHandler gameHandler;
    private Vector3 moveDir;
    private Vector3 dir;
    public int points = 5;
    public float speed;
    public bool damage = false;
    public PlayerStats playerStats;
    public Vector3 size;
    private float moveDis = 15f;
    private float recentDirChange;
    public float turnSmooth = 1f;
    float turnVelocity;
    float targetAngle;

    public NavMeshAgent nav;
    // Start is called before the first frame update
    public void Start()
    {
        gameHandler = GameObject.FindGameObjectWithTag("GameHandler").GetComponent<GameHandler>();
        playerStats = GameObject.FindGameObjectWithTag("PlayerStats").GetComponent<PlayerStats>();
        nav = gameObject.GetComponent<NavMeshAgent>();
        nav.speed = speed;
        moveFish();
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
                    //to decrease Points for dangerous fish.
                    //playerStats.removePoints(sizePoints);
                }
                
            }
            else
            {
                playerStats.addPoints(sizePoints);
            }
            gameHandler.decreaseFishCount();
            Destroy(gameObject);
        }
        if(other.tag == "Wall")
        {
            Debug.Log("Destroyed");
            gameHandler.decreaseFishCount();
            Destroy(gameObject);
        }
    }

    private void moveFish()
    {
        dir = new Vector3(this.transform.position.x + Random.Range(-moveDis, moveDis), 1f, this.transform.position.z + Random.Range(-moveDis, moveDis));
        nav.SetDestination(dir);
    }
    private void Update()
    {
       if (nav.remainingDistance <= nav.stoppingDistance)
        {
            moveFish();
        }
    }
}
