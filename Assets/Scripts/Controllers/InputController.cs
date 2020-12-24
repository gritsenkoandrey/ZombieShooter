using Interfaces;
using UnityEngine;


public class InputController: IExecute, IInitialization
{
    private PlayerData _playerData;
    private Vector2 _input;

    private WeaponManager _weaponManager;
    public bool canShoot;
    private bool isHoldAttack;

    public InputController()
    {
        _playerData = Data.Instance.PlayerData;
        _playerData.Initialization();
    }

    public void Initialization()
    {
        _weaponManager = Object.FindObjectOfType<WeaponManager>();
        canShoot = true;
    }

    public void Execute()
    {
#if UNITY_STANDALONE || UNITY_WEBGL || UNITY_EDITOR || UNITY_WSA

        _input.x = Input.GetAxis(AxisManager.HORIZONTAL);
        _input.y = Input.GetAxis(AxisManager.VERTICAL);

        _playerData.PlayerMove.Execute(_input);

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            _weaponManager.SwitchWeapon();
        }

        if (Input.GetKey(KeyCode.Space))
        {
            isHoldAttack = true;
        }
        else
        {
            _weaponManager.ResetAttack();
            isHoldAttack = false;
        }

        if (isHoldAttack && canShoot)
        {
            _weaponManager.Attack();
        }

#endif

#if UNITY_IOS || UNITY_ANDROID

#endif
    }
}