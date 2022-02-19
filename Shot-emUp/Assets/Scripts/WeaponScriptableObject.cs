using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableWeapon/ WeaponType")]
public class WeaponScriptableObject : ScriptableObject
{
    public float _fireRate;
    public float _bulletSpeed;
    public GameObject bulletType;

    public WeaponScriptableObject()
    {
        _fireRate = 0.1f;
    }
   
    public WeaponScriptableObject(float fireRate, float bulletSpeed)
    {
        _fireRate = fireRate;
        _bulletSpeed = bulletSpeed;
    }

    public float FireRate
    {
        get { return _fireRate; }
        set { _fireRate = value; }
    }

    public float BulletSpeed
    {
        get { return _bulletSpeed; }
        set { _bulletSpeed = value; }
    }
}

