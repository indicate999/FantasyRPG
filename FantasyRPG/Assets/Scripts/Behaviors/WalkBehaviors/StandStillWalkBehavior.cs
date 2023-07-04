using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandStillWalkBehavior : IWalkable
{
    private Transform _transform;
    private Vector3 _position;
    private float _YRotationAngle;

    public StandStillWalkBehavior(Transform transform, Vector3 position, float YRotationAngle)
    {
        _transform = transform;
        _position = position;
        _YRotationAngle = YRotationAngle;
    }

    public void SetStartWalkPoint()
    {
        _transform.position = _position;
        _transform.eulerAngles = new Vector3(0, _YRotationAngle, 0);
    }

    public void Walk()
    {

    }
}
