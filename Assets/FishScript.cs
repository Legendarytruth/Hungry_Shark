using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class FishScript : MonoBehaviour
{
    private GameHandler gameHandler;
    private Vector3 moveDir;
    public int points = 5;
    public float speed;
    public bool damage = false;
    public PlayerStats playerStats;
    public Vector3 size;
    private readonly float changeDirTime = 5f;
    private float recentDirChange;
    public float turnSmooth = 0.1f;
    float turnVelocity;

    public NavMeshAgent nav;
    // Start is called before the first frame update
    public void Start()
    {
        gameHandler = GameHandler.Instance;
        playerStats = GameObject.FindGameObjectWithTag("PlayerStats").GetComponent<PlayerStats>();
        nav = gameObject.GetComponent<NavMeshAgent>();
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

    private void moveFish()
    {
        if (Time.time + recentDirChange > changeDirTime)
        {
            recentDirChange = Time.time;
            Vector3 dir = new Vector3(Random.Range(-1f, 1f), 0f, Random.Range(-1f, 1f)).normalized;
            float targetAngle = Mathf.Atan2(dir.x, dir.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnVelocity, turnSmooth);

            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            moveDir = (Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward).normalized * speed * Time.deltaTime;
        }
        nav.Move(moveDir);
    }
    private void Update()
    {
        moveFish();
    }
}
