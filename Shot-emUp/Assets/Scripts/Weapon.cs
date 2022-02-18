using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableWeapon/ WeaponType")]
public class Weapon : ScriptableObject
{
    public float _fireRate;
    public float _bulletSpeed;
    public GunType _gunType;
    public GameObject bulletType;

    public Weapon()
    {
        _fireRate = 0.5f;
        _gunType = GunType.Type0;
    }
   
    public Weapon(float fireRate, float bulletSpeed, GunType gunType)
    {
        _fireRate = fireRate;
        _gunType = gunType;
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

    public GunType TypeOfGun
    {
        get { return _gunType; }
        set { _gunType = value; }
    }

}

public enum GunType
{
    Type0, Type1, EnemyType0, EnemyType1, EnemyType2, EnemyType3
}
