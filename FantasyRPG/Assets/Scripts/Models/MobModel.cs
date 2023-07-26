using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobModel
{
    public string MobName { get; set; }
    public float MobHealth { get; set; }
    public float MobAttack { get; set; }

    public MobModel(MobDataContainer mobContainer)
    {
        MobName = mobContainer.MobName;
        MobHealth = mobContainer.MobHealth;
        MobAttack = mobContainer.MobAttack;
    }
}
