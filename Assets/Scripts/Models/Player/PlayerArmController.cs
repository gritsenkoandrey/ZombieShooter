using UnityEngine;


public class PlayerArmController : PlayerBase
{
    [SerializeField] private Sprite _oneHandSprite = null;
    [SerializeField] private Sprite _twoHandSprite = null;

    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void ChangeToOneHand()
    {
        _spriteRenderer.sprite = _oneHandSprite;
    }

    public void ChangeToTwoHand()
    {
        _spriteRenderer.sprite = _twoHandSprite;
    }
}