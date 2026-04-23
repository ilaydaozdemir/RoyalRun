using UnityEngine;

public class PlayerCollisionHandler : MonoBehaviour
{
    [SerializeField] Animator animator;
    void OnCollisionEnter(Collision other)
    {
        animator.SetTrigger("Hit");
    }
}
