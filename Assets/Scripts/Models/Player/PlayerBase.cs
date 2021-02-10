using UnityEngine;


public abstract class PlayerBase : MonoBehaviour
{
    protected PlayerAnimations playerAnimations;
    protected PlayerHealth playerHealth;
    protected PlayerMove playerMove;
    protected PlayerData playerData;

    private static bool _isPlayerAlive;

    public static bool IsPlayerAlive
    {
        get { return _isPlayerAlive; }
        protected set { _isPlayerAlive = value; }
    }

    protected virtual void Awake()
    {
        playerData = Data.Instance.PlayerData;

        IsPlayerAlive = true;
    }

    public virtual void Execute(Vector2 pos) { }
}