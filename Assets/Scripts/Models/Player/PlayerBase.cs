using UnityEngine;


public abstract class PlayerBase : MonoBehaviour
{
    protected PlayerAnimations playerAnimations;
    protected PlayerHealth playerHealth;
    protected PlayerMove playerMove;
    protected PlayerData playerData;

    protected bool isPlayerAlive;

    protected virtual void Awake()
    {
        playerData = Data.Instance.PlayerData;

        isPlayerAlive = true;
    }

    public virtual void Execute(Vector2 pos) { }
}