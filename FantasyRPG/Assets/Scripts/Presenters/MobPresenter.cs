using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobPresenter : MonoBehaviour
{
    private MobView _view;
    private MobModel _model;

    public MobPresenter(MobView view)
    {
        _view = view;
        _model = new MobModel(_view.GetData());
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
