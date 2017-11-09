using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class LaserToPlayer : MonoBehaviour
{
	private static GameObject laserPrefab;

	public Transform firepoint;

	[RuntimeInitializeOnLoadMethod]
	static void Init()
	{
		laserPrefab = Resources.Load<GameObject>("Mob/Projectile/Laser");
	}

	void Awake()
	{
		if (firepoint == null)
			firepoint = transform;
	}

	public void OnAttack()
	{
		var p = Instantiate(laserPrefab);
		var ln = p.GetComponent<LineRenderer>();

		ln.SetPositions(new Vector3[]
		{
			firepoint.position,
			PlayerController.instance.transform.position + Random.onUnitSphere * Random.Range(0.1f, 0.3f)
		});
	}
}
