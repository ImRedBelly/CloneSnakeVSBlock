using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header("General")]
    [SerializeField] private Transform container;
    [SerializeField] private int repeatCount;
    [SerializeField] private int distanceBetweenFullLine;
    [SerializeField] private int distanceBetweenRandomLine;

    [Header("Block")]
    [SerializeField] private Block blockTemplate;
    [SerializeField] private int blockSpawnChance;

    [Header("Wall")]
    [SerializeField] private Wall wallTemplate;
    [SerializeField] private int wallSpawnChance;

    [Header("Bonus")]
    [SerializeField] private Bonus bonusTemplate;
    [SerializeField] private int bonusSpawnChance;

    private BlockSpawnPoint[] blockSpawnPoints;
    private WallSpawnPoint[] wallSpawnPoints;
    private BonusSpawnPoint[] bonusSpawnPoints;
    private void Start()
    {
        blockSpawnPoints = GetComponentsInChildren<BlockSpawnPoint>();
        wallSpawnPoints = GetComponentsInChildren<WallSpawnPoint>();
        bonusSpawnPoints = GetComponentsInChildren<BonusSpawnPoint>();

        for (int i = 0; i < repeatCount; i++)
        {
            MoveSpawner(distanceBetweenFullLine);


            GenerateRandomElements(bonusSpawnPoints, bonusTemplate.gameObject, bonusSpawnChance, 0.9f);
            GenerateRandomElements(wallSpawnPoints, wallTemplate.gameObject, wallSpawnChance, distanceBetweenFullLine * 2, distanceBetweenRandomLine / 2f);
            GenerateFullLine(blockSpawnPoints, blockTemplate.gameObject);

            MoveSpawner(distanceBetweenRandomLine);


            GenerateRandomElements(bonusSpawnPoints, bonusTemplate.gameObject, bonusSpawnChance, 0.9f);
            GenerateRandomElements(wallSpawnPoints, wallTemplate.gameObject, wallSpawnChance, distanceBetweenRandomLine * 2, distanceBetweenRandomLine / 2f);
            GenerateRandomElements(blockSpawnPoints, blockTemplate.gameObject, blockSpawnChance);
        }
    }
    private void GenerateFullLine(SpawnPoint[] spawnPoints, GameObject generatedElement)
    {
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            GenerateElement(spawnPoints[i].transform.position, generatedElement);
        }

    }
    private void GenerateRandomElements(SpawnPoint[] spawnPoints, GameObject generatedElement, int spawnChance, float scaleY = 1.4f, float offetY = 0)
    {
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            if (Random.Range(0, 100) < spawnChance)
            {
                GameObject element = GenerateElement(spawnPoints[i].transform.position, generatedElement, offetY);
                element.transform.localScale = new Vector2(element.transform.localScale.x, scaleY);
            }
        }
    }
    private GameObject GenerateElement(Vector3 spawnPoint, GameObject generatedElement, float offsetY = 0)
    {
        spawnPoint.y -= offsetY;
        return Instantiate(generatedElement, spawnPoint, Quaternion.identity, container);
    }
    private void MoveSpawner(int distanceY)
    {
        transform.position = new Vector3(transform.position.x, transform.position.y + distanceY, transform.position.z);
    }
}
