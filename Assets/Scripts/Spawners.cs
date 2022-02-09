using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawners : MonoBehaviour
{

    public List<GameObject> spawnables; //Enemies that this can spawn
    public List<Transform> spawners; // Enemies spawn at these

    public GameObject newWaveBanner;
    public GameManager gameManager;


    public List<GameObject> currentEnemies; //Enemies currently on board

    public int currentWave = 0;

    WaveCounter waveCounter;

    private void Awake()
    {
        waveCounter = FindObjectOfType<WaveCounter>();
        gameManager = FindObjectOfType<GameManager>();
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnerGameplayLoop());
    }

    IEnumerator SpawnerGameplayLoop()
    {

        while (gameManager.playerIsAlive)
        {

            yield return new WaitForSeconds(1);

            NullCheck(); //Check for null spots on list

            //count how many enemies are left, if zero a new wave starts!
            if (currentEnemies.Count == 0)
            {
                currentWave++;

                waveCounter.CountWave(currentWave);
                //Next wave incoming sound/graphic here?!

                if (gameManager.playerIsAlive == false)
                {
                    break;
                }

                if (currentWave != 1)
                {
                    newWaveBanner.SetActive(true);
                }

                //Delay before next wave!
                yield return new WaitForSeconds(1);
                newWaveBanner.SetActive(false);

                int enemiesToSpawn = currentWave * 2;
                for (int i = 0; i < enemiesToSpawn; i++)
                {
                    if (gameManager.playerIsAlive == false)
                    {
                        break;
                    }
                    SpawnRandomEnemy();
                    yield return new WaitForSeconds(0.8f);
                }

            }

        }

    }

    void SpawnRandomEnemy()
    {
        //Instantiate a random enemy from the spawnables list, at a random spawner
        Vector3 spawnPosition = spawners[Random.Range(0, spawners.Count)].transform.position;
        GameObject newEnemyType = spawnables[Random.Range(0, spawnables.Count)];
        GameObject newEnemy = Instantiate(newEnemyType, spawnPosition, Quaternion.identity);
        currentEnemies.Add(newEnemy);
    }

    void NullCheck()
    {
        for (int i = 0; i < currentEnemies.Count; i++)
        {
            if (currentEnemies[i] == null)
            {
                currentEnemies.Remove(currentEnemies[i]);
            }
        }
    }

}
