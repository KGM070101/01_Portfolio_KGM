using UnityEngine;

public class Player_SecondCollider : MonoBehaviour
{
    private void Start()
    {
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Player_SecondCollider"),
                                       LayerMask.NameToLayer("Rain"), true);
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Player_SecondCollider"),
                                       LayerMask.NameToLayer("Rain3"), true);
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Player_SecondCollider"),
                                       LayerMask.NameToLayer("Rain3_Hard"), true);
    }
}
