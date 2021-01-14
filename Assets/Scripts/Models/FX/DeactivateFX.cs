using UnityEngine;


public class DeactivateFX : MonoBehaviour
{
    private void OnEnable()
    {
        Invoke(nameof(DeactivateGameObject), 2.0f);
    }

    private void DeactivateGameObject()
    {
        gameObject.SetActive(false);
    }
}