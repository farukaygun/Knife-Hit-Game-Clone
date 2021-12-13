using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorTransitionController : MonoBehaviour
{
    public static AnimatorTransitionController instance = null;

    public Animator transition;

    void Awake() {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayStart() {
        transition.SetTrigger("Start");
    }

    public void PlayEnd() {
        transition.SetTrigger("End");
    }
}
