using UnityEngine;

[CreateAssetMenu(fileName = "NewEntitySettings", menuName = "Create Entity Settings Object")]
public class EntitySettingsScriptableObject : ScriptableObject
{
    public EntityBase EntityPrefab;

    public int MaxHealth = 100;
    public float Speed = 9;
    public int Damage = 0;
}
