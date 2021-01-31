using System.Collections.Generic;


public static class ZombieList
{
    private readonly static List<ZombieBase> _zombieList;

    static ZombieList()
    {
        _zombieList = new List<ZombieBase>();
    }

    public static void AddZombieToList(ZombieBase zombie)
    {
        if (!_zombieList.Contains(zombie))
        {
            _zombieList.Add(zombie);
            zombie.OnDieChange += RemoveZombieToList;
        }
    }

    public static void RemoveZombieToList(ZombieBase zombie)
    {
        if (!_zombieList.Contains(zombie))
        {
            return;
        }
        zombie.OnDieChange -= RemoveZombieToList;
        _zombieList.Remove(zombie);
    }

    public static void Execute()
    {
        for (int i = 0; i < _zombieList.Count; i++)
        {
            _zombieList[i].Execute();
        }
    }
}