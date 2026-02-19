using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeLevel : MonoBehaviour
{
    [SerializeField] GameObject playerLife;
    [SerializeField] GameObject inventory;
    [SerializeField] GameObject player;
    [SerializeField] GameObject gameCamera;
    [SerializeField] GameObject cinemachineCamera;
    [SerializeField] GameObject toggleInventory;

    [SerializeField] int sceneToLoad = 2;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            DontDestroyOnLoad(playerLife);
            DontDestroyOnLoad(inventory);
            DontDestroyOnLoad(player);
            DontDestroyOnLoad(gameCamera);
            DontDestroyOnLoad(cinemachineCamera);
            DontDestroyOnLoad(toggleInventory);

            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
