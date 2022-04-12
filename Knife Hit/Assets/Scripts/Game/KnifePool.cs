using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifePool : MonoBehaviour
{
	public static KnifePool instance;

	public List<GameObject> pooledKnives;
	public GameObject knifeToPool;
	int amountToPool = 12;

	void Awake()
	{
		instance = this;

		pooledKnives = new List<GameObject>();
		GameObject tmp;

		for (int i = 0; i < amountToPool; i++)
		{
			tmp = Instantiate(knifeToPool);
			tmp.SetActive(false);
			pooledKnives.Add(tmp);
		}
	}

	public GameObject GetPooledKnife()
	{
		for (int i = 0; i < amountToPool; i++)
		{
			if (!pooledKnives[i].activeInHierarchy)
			{
				return pooledKnives[i];
			}
		}
		return null;
	}
}
