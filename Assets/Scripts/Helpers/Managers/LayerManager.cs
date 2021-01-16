using UnityEngine;


public static class LayerManager
{
    private const string DEFAULT = "Default";
    private const string WATER = "Water";
    private const string UI = "UI";
    private const string TRANSPARENT_FX = "TransparentFX";
    private const string IGNORE_RAYCAST = "Ignore Raycast";
    private const string PLAYER_LAYER = "Player";
    private const string BULLET_LAYER = "Bullet";
    private const string ZOMBIE_HEALTH = "ZombieHealth";
    private const string PLAYER_HEALTH = "PlayerHealth";
    private const string FENCE_HEALTH = "FenceHealth";

    public const int DEFAULT_LAYER = 0;

    public static int DefaultLayer { get; }
    public static int PlayerLayer { get; }
    public static int BulletLayer { get; }
    public static int ZombieHealthLayer { get; }
    public static int PlayerHealthLayer { get; }
    public static int UiLayer { get; }
    public static int IgnoreRaycastLayer { get; }
    public static int ZombieAttackLayer { get; }

    static LayerManager()
    {
        IgnoreRaycastLayer = LayerMask.GetMask(IGNORE_RAYCAST, WATER);
        UiLayer = LayerMask.GetMask(UI);
        DefaultLayer = LayerMask.GetMask(DEFAULT);
        PlayerLayer = LayerMask.GetMask(PLAYER_LAYER);
        BulletLayer = LayerMask.GetMask(BULLET_LAYER);
        ZombieHealthLayer = LayerMask.GetMask(ZOMBIE_HEALTH);
        PlayerHealthLayer = LayerMask.GetMask(PLAYER_HEALTH);
        ZombieAttackLayer = LayerMask.GetMask(PLAYER_HEALTH, FENCE_HEALTH);
    }
}