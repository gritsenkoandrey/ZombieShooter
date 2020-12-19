using System.Collections.Generic;


public static class TagManager
{
    private static readonly Dictionary<TypeTag, string> _tags;

    static TagManager()
    {
        _tags = new Dictionary<TypeTag, string>
        {
            {TypeTag.PLAYER, "Player" },
            {TypeTag.PLAYER_HEALTH, "PlayerHealth" },
            {TypeTag.BACKGROUND, "Background" },
            {TypeTag.BULLET, "Bullet" },
            {TypeTag.FENCE, "Fence" },
            {TypeTag.ROCKET_MISSILE, "RocketMissile" },
            {TypeTag.FIRE_BULLET, "FireBullet" },
            {TypeTag.ZOMBIE_HEALTH, "ZombieHealth" },
            {TypeTag.MELEE_WEAPON, "MeleeWeapon" },
            {TypeTag.COIN, "Coin" }
        };
    }

    public static string GetTag(TypeTag tagType)
    {
        return _tags[tagType];
    }
}