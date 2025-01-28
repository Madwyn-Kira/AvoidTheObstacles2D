using UnityEngine;

public class PlayerController : EntityBase
{
    [SerializeField] private LayerMask _groundLayer;
    [SerializeField] private float _groundCheckDistance = 0.1f;

    public override void InitializeEntity<T>(T settings)
    {
        base.InitializeEntity(settings);

        _entitySettingsScriptableObject = settings as EntitySettingsScriptableObject;

        base._healthController.Initialize(EntitySettings.MaxHealth);
        base._healthController.OnHealthChanged += ChangeHealth;
        base._healthController.OnDeath += Die;

        ChangeState(new PlayerIdleState());
    }

    private void Update()
    {
        if (_currentState != null)
        {
            _currentState.LocalUpdate();
        }
    }

    private void ChangeHealth(float amount)
    {

    }

    private void Die()
    {
        ChangeState(new EntityDieState());

        GameManager.Instance.ShowEndGamePanel();
    }

    public bool IsGrounded()
    {
        Vector2 origin = transform.position + new Vector3(0f, -GetComponent<Collider2D>().bounds.extents.y + 0.05f);

        RaycastHit2D hit = Physics2D.Raycast(origin, Vector2.down, _groundCheckDistance, _groundLayer);

        return hit.collider != null;
    }

    private void OnDestroy()
    {
        base._healthController.OnHealthChanged -= ChangeHealth;
        base._healthController.OnDeath -= Die;
    }
}
