using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class AnimationManager : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            SetKickBallTrigger();
        }
    }

    public void TriggerDolphinExcitement()
    {
        if (_animator.gameObject.tag == "Kim")
        {
            _animator.SetTrigger("SawDolphin");
        }
    }

    private void SetKickBallTrigger()
    {
        if (_animator.gameObject.tag == "Nina")
        {
            _animator.SetTrigger("KickBall");
            GameObject.Find("BeachBall").GetComponent<Animator>().SetTrigger("BallKicked");
        }
    }
}