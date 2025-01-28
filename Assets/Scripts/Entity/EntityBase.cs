using System;
using UnityEngine;

public abstract class EntityBase : MonoBehaviour
{
    [SerializeField]
    private Animator _entityAnimator;

    [SerializeField]
    private Rigidbody2D _rigidbody;

    public Animator EntityAnimator { get { return _entityAnimator; } }
    public Rigidbody2D EntityRigidbody { get { return _rigidbody; } }
    public EntitySettingsScriptableObject EntitySettings { get { return _entitySettingsScriptableObject; } }
    public HealthController EntityHealthController { get { return _healthController; } }

    public event Action<EntityBase> OnEntityDestroy;

    protected HealthController _healthController;
    protected StateMachine _currentState;
    protected EntitySettingsScriptableObject _entitySettingsScriptableObject;

    public virtual void InitializeEntity<T>(T settings)
    {
        _entityAnimator = GetComponent<Animator>();
        _healthController = GetComponent<HealthController>();
    }

    public virtual void ChangeState(StateMachine _state)
    {
        if (_currentState != null)
            _currentState.ExitState();

        _currentState = _state;
        _currentState.EnterState(this);
    }

    public void DestroyEntity()
    {
        OnEntityDestroy?.Invoke(this);
        Destroy(gameObject);
    }
}
