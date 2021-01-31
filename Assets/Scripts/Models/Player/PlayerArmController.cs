using UnityEngine;


public class PlayerArmController : PlayerBase
{
    [SerializeField] private Sprite _oneHandSprite = null;
    [SerializeField] private Sprite _twoHandSprite = null;

    private SpriteRenderer _spriteRenderer;

    protected override void Awake()
    {
        base.Awake();
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