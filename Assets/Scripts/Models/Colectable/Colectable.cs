using UnityEngine;


public class Colectable : MonoBehaviour
{
    private int _coinCount = 0;

    private void OnTriggerEnter2D(Collider2D target)
    {
        var player = target.GetComponent<PlayerBase>();
        if (player)
        {
            _coinCount++;
            gameObject.SetActive(false);
        }
    }
}