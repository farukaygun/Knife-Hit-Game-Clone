using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorTransitionController : MonoBehaviour
{
    public static AnimatorTransitionController instance = null;

    public Animator transition;
    public Animator knife;

    void Awake() {
        instance = this;
    }

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        
    }

    public void PlayStart() {
        transition.SetTrigger("Start");
    }

    // TODO
    public void PlayEnd() {
        transition.SetTrigger("End");
    }

    // TODO
    public void PlayKnifeRotate() {
        knife.SetTrigger("Rotate");
    }
}
