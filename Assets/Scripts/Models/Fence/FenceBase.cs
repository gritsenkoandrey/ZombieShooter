using UnityEngine;


public abstract class FenceBase : MonoBehaviour
{
    protected bool isFenceAlive;

    protected virtual void Awake()
    {
        isFenceAlive = true;
    }
}