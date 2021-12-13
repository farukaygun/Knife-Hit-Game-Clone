using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    [SerializeField] Button buttonResume;
    [SerializeField] Button buttonExit;    

    // Start is called before the first frame update
    void Start()
    {
        buttonResume.onClick.AddListener(() => Resume()); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Resume() {
        GameManager.instance.Resume();
        gameObject.SetActive(false);
    }
}
