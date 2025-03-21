using UnityEngine;

public class Collectable : MonoBehaviour
{
    public CollectableType type;
   //player walks into collectable object
   //add collectable to player
   //delete collectable from scene
   public Sprite icon;

   public Rigidbody2D rb2d;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

   private void OnTriggerEnter2D(Collider2D collision)
   {
        Player player = collision.GetComponent<Player>();

        if(player)
        {
            player.inventory.Add(this);
            Destroy(this.gameObject);
        }
   }
}

public enum CollectableType
{
    NONE, PUMPKIN_SEED
}