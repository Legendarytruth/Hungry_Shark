using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UIHandler : MonoBehaviour
{
    public TextMeshProUGUI health;
    public TextMeshProUGUI points;
    public PlayerStats playerStats;
    public TextMeshProUGUI totalPoints;
    // Start is called before the first frame update
    void Start()
    {
        playerStats = GameObject.FindGameObjectWithTag("PlayerStats").GetComponent<PlayerStats>();
        if (health != null)
        {
            health.text = "Health: " + playerStats.health;
            points.text = "Points: " + playerStats.totalPoints;
        }
        if(totalPoints != null)
        {
            totalPoints.text = "Total Points: " + playerStats.totalPoints;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (health != null)
        {
            health.text = "Health: " + playerStats.health;
            points.text = "Points: " + playerStats.totalPoints;
        }
    }
}
