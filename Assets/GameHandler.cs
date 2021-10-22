using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameHandler : MonoBehaviour
{
    public GameObject pointFish;
    public GameObject damageFish;
    public int numofFishSpawn = 100;
    public int fishCount = 0;
    public PlayerStats playerStats;

    public float minSpeed = 1f;
    public float maxSpeed = 5f;
    public float minSize = 1f;
    public float maxSize = 3f;
    // Start is called before the first frame update
    void Start()
    {
    }

    private void spawnFish()
    {
        Vector3 area = new Vector3(Random.Range(-250f, 250f), 1, Random.Range(-250f, 250f));
        if(Random.Range(0f, 5f) > 2)
        {
            GameObject fish = Instantiate(pointFish, area, Quaternion.identity) as GameObject;
            FishScript fishScript = fish.GetComponent<FishScript>();
            Vector3 size = new Vector3(Random.Range(minSize, maxSize), Random.Range(minSize, maxSize), Random.Range(minSize, maxSize));
            fishScript.setDamage(false);
            fishScript.setSpeed(Random.Range(minSpeed, maxSpeed));
            fishScript.setSize(size);
            fish.transform.localScale = size;

        }
        else
        {
            GameObject fish = Instantiate(damageFish, area, Quaternion.identity) as GameObject;
            FishScript fishScript = fish.GetComponent<FishScript>();
            Vector3 size = new Vector3(Random.Range(minSize, maxSize), Random.Range(minSize, maxSize), Random.Range(minSize, maxSize));
            fishScript.setDamage(true);
            fishScript.setSpeed(Random.Range(minSpeed, maxSpeed));
            fishScript.setSize(size);
            fish.transform.localScale = size;
        }
        
    }

    public void decreaseFishCount()
    {
        fishCount -= 1;
    }
    // Update is called once per frame
    void Update()
    {
        if(fishCount < numofFishSpawn)
        {
            spawnFish();
            fishCount += 1;
        }

        if(playerStats.health <= 0)
        {
            SceneManager.LoadScene("EndScene");
        }
    }
}
