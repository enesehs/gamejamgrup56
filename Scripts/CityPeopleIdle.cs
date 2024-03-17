using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CityPeopleIdle
{
    public class CityPeopleIdle : MonoBehaviour
    {
        private AnimationClip[] myClips;
        private Animator animator;

        void Start()
        {
            animator = GetComponent<Animator>();
            if (animator != null)
            {
                myClips = animator.runtimeAnimatorController.animationClips;
                PlayAnyClip();
                StartCoroutine(ShuffleClips());
            }

        }

        void PlayAnyClip()
        {
            var cl = myClips[0];
            animator.CrossFadeInFixedTime(cl.name, 1.0f, -1, Random.value * cl.length);
        }

        IEnumerator ShuffleClips()
        {
            while (true)
            {
                yield return new WaitForSeconds(15.0f + Random.value * 5.0f);
                PlayAnyClip();
            }
        }

    }
}
