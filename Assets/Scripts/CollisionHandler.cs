using UnityEngine;

public class CollisionHandler : MonoBehaviour
{

    [SerializeField] GameObject playerDestroyedVfx;

    void OnTriggerEnter(Collider other)
    {
        Instantiate(playerDestroyedVfx, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
}
