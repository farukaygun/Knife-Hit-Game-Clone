using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BladePool : MonoBehaviour
{
    public static BladePool instance;

    public List<GameObject> pooledBlades;
    public GameObject bladeToPool;
    int amountToPool = 12;

    void Awake() {
        instance = this;    
    }

    // Start is called before the first frame update
    void Start()
    {
        pooledBlades = new List<GameObject>();
        GameObject tmp;

        for (int i = 0; i < amountToPool; i++) {
            tmp = Instantiate(bladeToPool);
            tmp.SetActive(false);
            pooledBlades.Add(tmp);
        }
    }

    public GameObject GetPooledBlade() {
        for (int i = 0; i < amountToPool; i++) {
            if (!pooledBlades[i].activeInHierarchy) {
                return pooledBlades[i];
            }
        }
        return null;
    }
}
