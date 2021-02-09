using Interfaces;
using UnityEngine;


public class InputController: BaseController, IExecute, IInitialization, IFixExecute, IInitializationPlayer
{
    private PlayerData _playerData;
    private Vector2 _input;

    private WeaponManager _weaponManager;
    private bool _isCanShoot;
    private bool _isHoldAttack;

    public InputController()
    {
        _playerData = Data.Instance.PlayerData;
        EventBus.Subscribe(this);
    }

    public void Initialization()
    {
        _isCanShoot = true;
    }

#if UNITY_STANDALONE || UNITY_WEBGL || UNITY_EDITOR || UNITY_WSA

    public void Execute()
    {
        if (!Interface.MainMenu.isActiveAndEnabled)
        {
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                _weaponManager.SwitchWeapon();
            }

            if (Input.GetKey(KeyCode.Space))
            {
                _isHoldAttack = true;
            }
            else
            {
                _weaponManager.ResetAttack();
                _isHoldAttack = false;
            }

            if (_isHoldAttack && _isCanShoot)
            {
                _weaponManager.Attack();
            }
        }
    }

    public void FixExecute()
    {
        if (!Interface.MainMenu.isActiveAndEnabled)
        {
            _input.x = Input.GetAxis(AxisManager.HORIZONTAL);
            _input.y = Input.GetAxis(AxisManager.VERTICAL);

            _playerData.playerBase.Execute(_input);
        }
    }


#if UNITY_IOS || UNITY_ANDROID

#endif
#endif

    public void InitializationPlayer()
    {
        _playerData.Initialization();
        _weaponManager = Object.FindObjectOfType<WeaponManager>();
    }
}