using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField] Text textTapToPlay;

    // Start is called before the first frame update
    void Start()
    {
        AnimatorTransitionController.instance.PlayEnd();
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0)) {
            textTapToPlay.enabled = false;
            SceneLoader.instance.LoadNextScene();
        }
    }
}
