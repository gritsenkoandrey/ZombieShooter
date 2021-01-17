using Interfaces;
using UnityEngine;


public class InputController: IExecute, IInitialization, IFixExecute
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

#if UNITY_STANDALONE || UNITY_WEBGL || UNITY_EDITOR || UNITY_WSA

    public void Execute()
    {
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
    }

    public void FixExecute()
    {
        _input.x = Input.GetAxis(AxisManager.HORIZONTAL);
        _input.y = Input.GetAxis(AxisManager.VERTICAL);

        _playerData.PlayerMove.Execute(_input);
    }

#if UNITY_IOS || UNITY_ANDROID

#endif
#endif
}