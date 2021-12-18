using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circle : MonoBehaviour
{
    public static Circle instance = null;

    public float rotationSpeed = 5f;

    void Awake() {
        instance = this;    
    }

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("ChangeRotation", 5f, 5f);
    }

    // Update is called once per frame
    void Update()
    {
    }

    void FixedUpdate() {
        if (Time.timeScale == 0) return; // for pause game
        transform.Rotate(0, 0, rotationSpeed);
    }

    void ChangeRotation() {
        rotationSpeed = Random.Range(-5f, 5f);

        while (rotationSpeed <= 2 && rotationSpeed >= 0 ||
                rotationSpeed >= -2 && rotationSpeed <= 0
                )
            rotationSpeed = Random.Range(-5f, 5f);
    }
}
