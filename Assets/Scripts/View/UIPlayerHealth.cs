using UnityEngine;
using UnityEngine.UI;


public class UIPlayerHealth : MonoBehaviour, ICalculateHealth
{
    private Image _health;

    private void OnEnable()
    {
        EventBus.Subscribe(this);
        _health = GetComponent<Image>();
    }

    private void OnDisable()
    {
        EventBus.Unsubscribe(this);
    }

    public void CalculateHealth(float health)
    {
        health /= Data.Instance.PlayerData.GetHealth();
        _health.fillAmount = health;
    }
}