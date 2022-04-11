using System.Net.NetworkInformation;
using UnityEngine;

public class Knife : MonoBehaviour
{
	[SerializeField] Rigidbody2D rb;

	void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.transform.tag == "Circle")
		{
			GameManager.instance.CounterDecrease();

			rb.velocity = Vector2.zero;
			rb.isKinematic = true;

			transform.SetParent(collision.transform);
		}
		else if (collision.transform.tag == "Knife")
		{
			rb.velocity = Vector2.zero;
			StartCoroutine(GameManager.instance.GameOver());
		}
	}
}
