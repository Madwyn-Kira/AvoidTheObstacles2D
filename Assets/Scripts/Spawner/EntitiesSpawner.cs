using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntitiesSpawner : MonoBehaviour
{
    [SerializeField]
    private EntitySettingsScriptableObject PlayerPrefab;

    [SerializeField]
    private List<EntitySettingsScriptableObject> EnemiePrefabs = new();

    [SerializeField]
    private List<EntitySettingsScriptableObject> NeitralPrefabs = new();

    private EntityBase _playerController;
    private List<EntityBase> _neitralControllers = new();
    private List<EntityBase> _enemieControllers = new();

    private void Start()
    {
        _playerController = Instantiate(PlayerPrefab.EntityPrefab, Vector2.zero, Quaternion.identity);
        _playerController.InitializeEntity(PlayerPrefab);
    }
}
