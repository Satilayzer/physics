using UnityEngine;

public class FireShell : MonoBehaviour
{
	private float _speed = 15;
	private float _rotationSpeed = 2f;
	private float _moveSpeed = 3;
	private int _frameCounter;
	private int _framesBetweenShots = 10;

	public GameObject bullet;
	public GameObject turret;
	public GameObject enemy;
	public Transform turretBase;

	private void Update()
	{
		var direction = (enemy.transform.position - transform.position).normalized;
		var lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
		transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * _rotationSpeed);

		var angle = RotateTurret();
		if (angle != null)
		{
			_frameCounter++;
			if (_frameCounter >= _framesBetweenShots)
			{
				CreateBullet();
				_frameCounter = 0;
			}
		}
		else
		{
			transform.Translate(0, 0, Time.deltaTime * _moveSpeed);
			_frameCounter = 0;
		}
	}

	private float? RotateTurret()
	{
		var angle = CalculateAngle(false);
		if (angle != null)
		{
			turretBase.localEulerAngles = new Vector3(360f - angle.Value, 0f, 0f);
		}
		return angle;
	}

	private void CreateBullet()
	{
		var shell = Instantiate(bullet, turret.transform.position, turret.transform.rotation);
		shell.GetComponent<Rigidbody>().linearVelocity = _speed * turretBase.forward;
	}

	private float? CalculateAngle(bool low)
	{
		var target = enemy.transform.position - transform.position;
		const float y = 0f;
		var x = target.magnitude - 1;
		const float gravity = 9.8f;
		var sSqr = _speed * _speed;
		var underTheSqrRoot = sSqr * sSqr - gravity * (gravity * x * x + 2f * y * sSqr);

		if (underTheSqrRoot >= 0f)
		{
			var root = Mathf.Sqrt(underTheSqrRoot);
			var highAngle = sSqr + root;
			var lowAngle = sSqr - root;

			if (low) return Mathf.Atan2(lowAngle, gravity * x) * Mathf.Rad2Deg;
			return Mathf.Atan2(highAngle, gravity * x) * Mathf.Rad2Deg;
		}

		return null;
	}
}