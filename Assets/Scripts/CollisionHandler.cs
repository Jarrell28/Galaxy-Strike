using UnityEngine;

public class CollisionHandler : MonoBehaviour
{

    [SerializeField] GameObject playerDestroyedVfx;
    GameSceneManager gameSceneManager;

    private void Start(){
        gameSceneManager = FindFirstObjectByType<GameSceneManager>();
    }

    void OnTriggerEnter(Collider other)
    {
        Instantiate(playerDestroyedVfx, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
        gameSceneManager.ReloadLevel();
    }
}
