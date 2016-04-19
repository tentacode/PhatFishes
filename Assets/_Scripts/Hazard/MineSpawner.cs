using UnityEngine;
using System.Collections;

public class MineSpawner : MonoBehaviour
{
    public GameObject minePrefab;
    public float spanwInterval;
    public float minX = -22;
    public float maxX = 22;

	void Start()
	{
        Invoke("SpawnMine", spanwInterval);
	}

	void SpawnMine()
	{
        Vector3 spawnPoint = new Vector3(
            Random.Range(minX, maxX),
            transform.position.y,
            0
        );

        Instantiate(minePrefab, spawnPoint, Quaternion.identity);

        Invoke("SpawnMine", spanwInterval);
	}
}
