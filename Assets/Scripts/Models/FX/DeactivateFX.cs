using UnityEngine;


public class DeactivateFX : MonoBehaviour
{
    private TimeRemaining _timeRemainingDeactivateFX;
    private readonly float _timeToDiactivate = 2.0f;

    private void Awake()
    {
        _timeRemainingDeactivateFX = new TimeRemaining(DeactivateGameObject, _timeToDiactivate);
    }

    private void OnEnable()
    {
        _timeRemainingDeactivateFX.AddTimeRemaining();
    }

    private void DeactivateGameObject()
    {
        gameObject.SetActive(false);
        _timeRemainingDeactivateFX.RemoveTimeRemaining();
    }
}