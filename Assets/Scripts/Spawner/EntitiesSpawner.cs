using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntitiesSpawner : MonoBehaviour
{
    [Header("Prefabs")]

    [SerializeField]
    private EntitySettingsScriptableObject PlayerPrefab;

    [SerializeField]
    private List<EntitySettingsScriptableObject> EnemiePrefabs = new();

    [SerializeField]
    private List<EntitySettingsScriptableObject> NeitralPrefabs = new();

    [Header("Spawn Positions")]
    [Space(5)]

    [SerializeField]
    private List<Transform> NeitralSpawnPositions = new();

    [SerializeField]
    private List<Transform> EnemiesSpawnPositions = new();

    [Header("Spawn Timers")]
    [Space(5)]

    [SerializeField]
    private float TimeToSpawnNeitrals = 5f;

    [SerializeField]
    private float TimeToSpawnEnemies = 5f;

    private EntityBase _playerController;
    private List<EntityBase> _neitralControllers = new();
    private List<EntityBase> _enemieControllers = new();

    private float _spawnerGlobalTimer = 0;

    private void Start()
    {
        _playerController = Instantiate(PlayerPrefab.EntityPrefab, Vector2.zero, Quaternion.identity);
        _playerController.InitializeEntity(PlayerPrefab);
    }

    private void Update()
    {
        _spawnerGlobalTimer += Time.deltaTime;

        if(_spawnerGlobalTimer >= TimeToSpawnNeitrals)
        {
            SpawnRandomTrap();
            _spawnerGlobalTimer = 0;
        }
    }

    private void SpawnRandomTrap()
    {
        int _rndTrapFromCollection = Random.Range(0, NeitralPrefabs.Count);
        int _rndPositionsForTrapSpawn = Random.Range(0, NeitralSpawnPositions.Count);

        EntityBase _currentNeitral = Instantiate(NeitralPrefabs[_rndTrapFromCollection].EntityPrefab, NeitralSpawnPositions[_rndPositionsForTrapSpawn].position, Quaternion.identity);
        _currentNeitral.InitializeEntity(NeitralPrefabs[_rndTrapFromCollection]);
    }
}
