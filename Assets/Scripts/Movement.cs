using UnityEngine;

// This class controls the movement of the character in the game.
public class Movement : MonoBehaviour
{
  // Speed of the character's movement (units per second)
  public float speed;
  
  public Animator animator; 

  // Update is called once per frame. Handles character movement based on player input.

  private Vector3 direction;
  
  private void Update()
  {
    // Get horizontal(A,D) and vertical(W,S) input from player
    float horizontal = Input.GetAxisRaw("Horizontal");
    float vertical = Input.GetAxisRaw("Vertical"); 

    // Create a direction vector based on input. Z is set to 0 for 2D movement. 
    direction = new Vector3(horizontal, vertical).normalized;

    AnimateMovement(direction);

  }

  private void FixedUpdate()
  {
    // Update the position of the character based on direction, speed, and time elapsed (FUNCTION)
    transform.position += direction * speed * Time.deltaTime;
  }

  private void AnimateMovement(Vector3 direction)
  {
    if(animator != null)
    {
      if(direction.magnitude > 0)
      {
        animator.SetBool("isMoving", true);

        animator.SetFloat("horizontal", direction.x);
        animator.SetFloat("vertical", direction.y);
      }
      else 
      {
        animator.SetBool("isMoving", false);
      }
    }
  }
}
