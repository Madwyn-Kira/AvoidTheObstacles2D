using UnityEngine;

public class FallenTrapCollisionChecker : MonoBehaviour
{
    [SerializeField]
    private LayerMask DestroyLayer;

    [SerializeField]
    private LayerMask DamageDealerLayer;

    private EntityBase _entityBase;

    public void InitializeCkecker(EntityBase entityBase)
    {
        _entityBase = entityBase;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        int collidedLayer = collision.gameObject.layer;

        if ((1 << collidedLayer) == DestroyLayer.value)
        {
            _entityBase.ChangeState(new EntityDieState());
        }
        else if ((1 << collidedLayer) == DamageDealerLayer.value)
        {
            collision.gameObject.GetComponent<EntityBase>().EntityHealthController.TakeDamage(_entityBase.EntitySettings.Damage);
            _entityBase.EntityHealthController.TakeDamage(_entityBase.EntitySettings.MaxHealth);
        }
    }
}
