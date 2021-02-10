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
            AudioManager.Instance.PlaySound(ClipManager.COIN_ADD_CLIP);
            gameObject.SetActive(false);
        }
    }
}