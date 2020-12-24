using UnityEngine;


public class PlayerArmController : MonoBehaviour
{
    public Sprite oneHandSprite;
    public Sprite twoHandSprite;

    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void ChangeToOneHand()
    {
        _spriteRenderer.sprite = oneHandSprite;
    }

    public void ChangeToTwoHand()
    {
        _spriteRenderer.sprite = twoHandSprite;
    }
}