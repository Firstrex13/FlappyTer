using UnityEngine;

public class HealthViewBasic : MonoBehaviour
{
    [SerializeField] private Health _health;

    protected Health Health => _health;

    private void Start()
    {
        UpdateValue();
    }

    private void OnEnable()
    {
        _health.Hit += UpdateValue;
    }

    private void OnDisable()
    {
        _health.Hit -= UpdateValue;
    }

    public virtual void UpdateValue() { }
}
