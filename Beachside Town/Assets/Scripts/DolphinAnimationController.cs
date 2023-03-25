using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DolphinAnimationController : MonoBehaviour
{
    [SerializeField] private AnimationClip dolphinClip;
    [SerializeField] private Animator _animatorKim;

    // Start is called before the first frame update
    void Start()
    {
        AnimationEvent animationEvent = new AnimationEvent();
        animationEvent.functionName = "TriggerDolphinExcitement";
        animationEvent.time = 4f;
        dolphinClip.AddEvent(animationEvent);
    }

    public void TriggerDolphinExcitement()
    {
        _animatorKim.SetTrigger("SawDolphin");
    }
}