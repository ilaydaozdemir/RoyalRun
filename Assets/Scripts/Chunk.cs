using System.Collections.Generic;
using UnityEngine;

public class Chunk : MonoBehaviour
{
[SerializeField] GameObject fencePrafeb;
[SerializeField] GameObject applePrafeb;
[SerializeField] GameObject coinPrafeb;
[SerializeField] float appleSpawnChance=.3f;
[SerializeField] float coinSpawnChance=.5f;
[SerializeField] float coinLength=2f;
[SerializeField] float[] lanes={-2.5f,0,2.5f};
List<int> availableLanes=new List<int>{0,1,2};
    void Start()
    {
        SpawnFence();
        SpawnApple();
        SpawnCoin();
    }
    void SpawnFence()
    {

        int fencesToSpawn=Random.Range(0,lanes.Length);

        for (int i = 0; i < fencesToSpawn; i++)
        {
            if (availableLanes.Count <= 0)
            {
                break;
            }
            int selectedLane = SelectLane();

            Vector3 spawnPosition = new Vector3(lanes[selectedLane], transform.position.y, transform.position.z);
            Instantiate(fencePrafeb, spawnPosition, Quaternion.identity, this.transform);
        }

    }

     int SelectLane()
    {
        int randomLaneIndex = Random.Range(0, availableLanes.Count);
        int selectedLane = availableLanes[randomLaneIndex];
        availableLanes.RemoveAt(randomLaneIndex);
        return selectedLane;
    }

    void SpawnApple()
    { 
        if(Random.value>appleSpawnChance)
        {
            return;
        }
        if(availableLanes.Count<=0)
        {
            return;
        }
        int selectedLane = SelectLane();

        Vector3 spawnPosition = new Vector3(lanes[selectedLane], transform.position.y, transform.position.z);
        Instantiate(applePrafeb, spawnPosition, Quaternion.identity, this.transform);
    }
     void SpawnCoin()
    { 
        if(Random.value>coinSpawnChance)
        {
            return;
        }
        if(availableLanes.Count<=0)
        {
            return;
        }
        int selectedLane = SelectLane();
        int maxCoins=6;
        int coinsToSpawn=Random.Range(1,maxCoins);
        float topOfZPos=transform.position.z+(coinLength*2f);

        for (int i = 0; i < coinsToSpawn; i++)
        {
          float spawnPositionZ=topOfZPos-(i*coinLength);
          Vector3 spawnPosition = new Vector3(lanes[selectedLane], transform.position.y, spawnPositionZ);
          Instantiate(coinPrafeb, spawnPosition, Quaternion.identity, this.transform);
        }


    }
}
