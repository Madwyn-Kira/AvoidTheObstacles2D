public class NeitralController : EntityBase
{
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
    }

    private void OnDestroy()
    {
        base._healthController.OnHealthChanged -= ChangeHealth;
        base._healthController.OnDeath -= Die;
    }
}