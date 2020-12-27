using UnityEngine;


public class GameplayController : MonoBehaviour
{
    public static GameplayController Instance;

    [HideInInspector] public bool isBulletAndFXCreated = false;
    [HideInInspector] public bool isRocketBulletCreated = false;

    private void Awake()
    {
        MakeInstance();
    }

    private void OnDisable()
    {
        Instance = null;
    }

    private void MakeInstance()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
}