using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    private static PlayerStats _instance;
    public static PlayerStats Instance { get { return _instance; } }
    public int totalPoints = 0;
    public int health = 5;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    public void addPoints(int num)
    {
        totalPoints += num;
    }

    public void removePoints(int num)
    {
        totalPoints -= num;
    }

    public void damagePlayer()
    {
        health -= 1;
    }
    
    public void healPlayer()
    {
        health += 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
