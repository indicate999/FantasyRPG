using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Camera", menuName = "ScriptableObjects/Camera")]
public class CameraData : ScriptableObject
{
	[SerializeField] private float zoomScale;
	[SerializeField] private float offsetY;
	[SerializeField] private float startDistance;
	[SerializeField] private float minDistance;
	[SerializeField] private float maxDistance;
	[SerializeField] private float sensitivity;
	[SerializeField] private float minYAngle;
	[SerializeField] private float maxYAngle;

	public float ZoomScale => zoomScale;
	public float OffsetY => offsetY;
	public float StartDistance => startDistance;
	public float MinDistance => minDistance;
	public float MaxDistance => maxDistance;
	public float Sensitivity => sensitivity;
	public float MinYAngle => minYAngle;
	public float MaxYAngle => maxYAngle;
}
