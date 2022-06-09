using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivePerk : MonoBehaviour
{
    [SerializeField] int _firstAnimationTime;
    [SerializeField] Animator _animator;

    [SerializeField] SpriteRenderer _spriteRenderer;

    private void Start()
    {
        StartCoroutine(PlayAnimation());
    }


    IEnumerator PlayAnimation()
    {
        yield return new WaitForSeconds(_firstAnimationTime);
        _animator.SetTrigger("reflect");
        _firstAnimationTime = Random.Range(2,4);
        StartCoroutine(PlayAnimation());
    }
}
