using UnityEngine;

public class PlayerCollisionHandler : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] float changeMoveSpeedAmount=-2f;

    LevelGenerator levelGenerator;
    void Start()
    {
        levelGenerator=FindFirstObjectByType<LevelGenerator>();
    }
    void OnCollisionEnter(Collision other)
    {
        levelGenerator.ChangeChunkMoveSpeed(changeMoveSpeedAmount);
        animator.SetTrigger("Hit");
    }
}
