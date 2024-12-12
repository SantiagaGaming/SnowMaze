using UnityEngine;
using System.Collections;

public class FollowCamera : MonoBehaviour
{

	[SerializeField]private float _interpVelocity;
	[SerializeField] private GameObject _target;
	[SerializeField] private Vector3 _offset;
	Vector3 _targetPos;

	private void Start()
	{
		_targetPos = transform.position;
	}

	private void FixedUpdate()
	{
		if (_target)
		{
			Vector3 posNoZ = transform.position;
			posNoZ.z = _target.transform.position.z;

			Vector3 targetDirection = _target.transform.position - posNoZ;

			_interpVelocity = targetDirection.magnitude * 5f;

			_targetPos = transform.position + (targetDirection.normalized * _interpVelocity * Time.deltaTime);

			transform.position = Vector3.Lerp(transform.position, _targetPos + _offset, 0.25f);
		}
	}
}
