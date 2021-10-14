using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class DeathHandler : MonoBehaviour
{
    public PlayerStats playerStats;
    public TextMeshProUGUI totalPoints;
    // Start is called before the first frame update
    void Start()
    {
        playerStats = GameObject.FindGameObjectWithTag("PlayerStats").GetComponent<PlayerStats>();
        totalPoints.text = "Total Points: " + playerStats.totalPoints;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
