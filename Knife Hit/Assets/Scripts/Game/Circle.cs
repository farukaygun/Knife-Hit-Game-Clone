using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circle : MonoBehaviour
{
	public static Circle instance = null;

	Rigidbody2D rb;
	public float rotationSpeed = 5f;

	void Awake()
	{
		instance = this;
	}

	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		InvokeRepeating("ChangeRotation", 4f, 4f);
	}

	void Update()
	{
	}

	void FixedUpdate()
	{
		if (Time.timeScale == 0)
			return; // for pause game
		rb.rotation += rotationSpeed * Time.deltaTime * 40; // for physics works rotate rb instead of transform.
	}

	void ChangeRotation()
	{
		rotationSpeed = Random.Range(-5f, 5f);

		// if rotation speed is less than 2, wood rotates too slow.
		while (rotationSpeed <= 2 && rotationSpeed >= 0 ||
				rotationSpeed >= -2 && rotationSpeed <= 0
				)
			rotationSpeed = Random.Range(-5f, 5f);
	}
}
