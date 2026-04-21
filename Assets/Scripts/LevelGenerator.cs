using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] GameObject chunkPrefab;
    [SerializeField] int startingChunkAmount=12; 
    [SerializeField] Transform chunkParent;
    [SerializeField]float chunkLenght=10f;
    [SerializeField] float moveSpeed=8f;
    GameObject[] chuncks=new GameObject[12];
    void Start()
    {
        SpawnChunks();

    }
    void Update()
    {
        MoveChunks();
    }

     void SpawnChunks()
    {
        for (int i = 0; i < startingChunkAmount; i++)
        {
            float spawnPositionZ = CalculateSpawnPositionZ(i);
            Vector3 chunkSpawnPos = new Vector3(transform.position.x, transform.position.y, spawnPositionZ);
            GameObject newChunk= Instantiate(chunkPrefab, chunkSpawnPos, Quaternion.identity, chunkParent);

            chuncks[i]=newChunk;
        }
    }

     float CalculateSpawnPositionZ(int i)
    {
        float spawnPositionZ;

        if (i == 0)
        {
            spawnPositionZ = transform.position.z;
        }
        else
        {
            spawnPositionZ = transform.position.z + (i * chunkLenght);
        }

        return spawnPositionZ;
    }

   void MoveChunks()
    {
        for (int i = 0; i < chuncks.Length; i++)
        {
            chuncks[i].transform.Translate(-transform.forward*(moveSpeed*Time.deltaTime));
        }
    }
}
