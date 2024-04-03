using UnityEngine;

public class AnimationController : MonoBehaviour
{
    public Animator animator;
    private StaminaConroller staminaController;
    private void Start()
    {
        animator = GetComponent<Animator>();
        staminaController = StaminaConroller.instance;
    }

    void Update()
    {
        if (staminaController != null && staminaController.GetCurrentFuelAmount() <= 0)
        {
            animator.SetTrigger("StaminaEmpty"); // Trigger the "StaminaEmpty" animation
        }
    }
}