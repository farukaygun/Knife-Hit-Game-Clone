using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blade : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.transform.tag == "Circle") {
            print("if " + collision.transform.tag);
            GameManager.instance.StabbedBlade();
            transform.SetParent(collision.transform);
        }
        else if (collision.transform.tag == "Blade") {
            print("else if " + collision.transform.tag);
            GameManager.instance.GameOver();
        }
    }
}
