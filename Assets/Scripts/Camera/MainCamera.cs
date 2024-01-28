using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    Animator animator;

    public static MainCamera instance;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
       animator = GetComponent<Animator>(); 
    }

    public void ShakeCamera()
    {
        animator.SetTrigger("Shake");
    }
}
