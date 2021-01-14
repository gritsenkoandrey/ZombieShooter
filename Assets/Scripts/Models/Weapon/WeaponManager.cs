using System.Collections.Generic;
using UnityEngine;


public class WeaponManager : MonoBehaviour
{
    [SerializeField] private List<WeaponBase> _weaponsUnlocked = null;
    [SerializeField] private WeaponBase[] _totalWeapon = null;
    private WeaponBase _currentWeapon;
    private int _currentWeaponIndex;
    private TypeControlAttack _currentTypeControl;
    private PlayerArmController[] _armController;
    private PlayerAnimations _playerAnim;
    private bool _isShooting;

    [SerializeField] private GameObject _meleeDamagePoint = null;

    private void Awake()
    {
        _playerAnim = GetComponent<PlayerAnimations>();
        LoadActiveWeapons();
        _currentWeaponIndex = (int)TypeWeaponName.Pistol;
    }

    private void Start()
    {
        _armController = GetComponentsInChildren<PlayerArmController>();
        // set the first weapon to be pistol
        ChangeWeapon(_weaponsUnlocked[_currentWeaponIndex]);
        _playerAnim.PlayerSwitchWeaponAnimation((int)_weaponsUnlocked[_currentWeaponIndex].weapon.typeWeapon);
    }

    private void LoadActiveWeapons()
    {
        for (int i = 0; i < _totalWeapon.Length; i++)
        {
            _weaponsUnlocked.Add(_totalWeapon[i]);
        }
    }

    public void SwitchWeapon()
    {
        _currentWeaponIndex++;
        _currentWeaponIndex = (_currentWeaponIndex >= _weaponsUnlocked.Count) ? 0 : _currentWeaponIndex;
        _playerAnim.PlayerSwitchWeaponAnimation((int)_weaponsUnlocked[_currentWeaponIndex].weapon.typeWeapon);
        ChangeWeapon(_weaponsUnlocked[_currentWeaponIndex]);
    }

    private void ChangeWeapon(WeaponBase newWeapon)
    {
        if (_currentWeapon)
        {
            _currentWeapon.gameObject.SetActive(false);
        }
        _currentWeapon = newWeapon;
        _currentTypeControl = newWeapon.weapon.typeControlAttack;
        newWeapon.gameObject.SetActive(true);
        if (newWeapon.weapon.typeWeapon == TypeWeapon.TwoHand)
        {
            for (int i = 0; i < _armController.Length; i++)
            {
                _armController[i].ChangeToTwoHand();
            }
        }
        else
        {
            for (int i = 0; i < _armController.Length; i++)
            {
                _armController[i].ChangeToOneHand();
            }
        }
    }

    public void Attack()
    {
        if (_currentTypeControl == TypeControlAttack.Hold)
        {
            _currentWeapon.CallAttack();
        }
        else if (_currentTypeControl == TypeControlAttack.Click)
        {
            if (!_isShooting)
            {
                _currentWeapon.CallAttack();
                _isShooting = true;
            }
        }
    }

    public void ResetAttack()
    {
        _isShooting = false;
    }

    private void AllowCollisionDetection()
    {
        print("Allow");
        _meleeDamagePoint.SetActive(true);
    }

    private void DenyCollisionDetection()
    {
        print("Deny");
        _meleeDamagePoint.SetActive(false);
    }
}