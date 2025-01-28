using UnityEngine;

public class NeitralController : EntityBase
{
    [SerializeField]
    private FallenTrapCollisionChecker _fallenTrapCollisionChecker;

    public override void InitializeEntity<T>(T settings)
    {
        base.InitializeEntity(settings);

        _entitySettingsScriptableObject = settings as EntitySettingsScriptableObject;

        base._healthController.Initialize(EntitySettings.MaxHealth);
        base._healthController.OnHealthChanged += ChangeHealth;
        base._healthController.OnDeath += Die;

        _fallenTrapCollisionChecker.InitializeCkecker(this);

        ChangeState(new NeitralIdleState());
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
    }

    private void OnDestroy()
    {
        base._healthController.OnHealthChanged -= ChangeHealth;
        base._healthController.OnDeath -= Die;
    }
}
