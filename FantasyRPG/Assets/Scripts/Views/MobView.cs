using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobView : MonoBehaviour
{
    private MobPresenter _presenter;

    private MobDataContainer _mobContainer;

    private void Start()
    {
        
    }

    private void Update()
    {
        
    }

    public void Init(MobDataContainer mobContainer)
    {
        _mobContainer = mobContainer;
        _presenter = new MobPresenter(this);
    }

    public MobDataContainer GetData()
    {
        return _mobContainer;
    }
}
