using System;
using UnityEngine;

public class PlayerShooter : Shooter
{
    [SerializeField] int _counterDmg = 5;
    [SerializeField] int _counterPower = 3;
    
    HitCtrl _counterHitCtrl;
    
    void Update()
    {
        _counterHitCtrl = GetComponent<HitCtrl>();
        _counterHitCtrl.SetParameter(_counterDmg,_counterPower);
    }

    public void Shooter()
    {
        Shot();
    }
    public void Counter(Character chara)
    {
        _counterHitCtrl.DamageEffect(chara);
    }
}
