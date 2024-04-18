using UnityEngine;

namespace FlappyBox
{
    [RequireComponent(typeof(BoxCollider2D))]
    public class PipesMover : MonoBehaviour
    {
        #region Fields and Properties

        #region Private

        [SerializeField] private GameManagerSO gameManagerSO;
        [SerializeField] private SpawnerSO spawnerSO;
        [SerializeField] private float moveSpeed = 5;
        [SerializeField] private int successPoints = 1;

        #endregion

        #endregion

        #region Unity Methods

        private void Awake()
        {
            gameManagerSO.OnGameReset += GameReset;
        }

        private void Update()
        {
            transform.position += Vector3.left * (moveSpeed * Time.deltaTime);
            if (transform.position.x < -spawnerSO.xPos)
            {
                spawnerSO.OnRelease?.Invoke(transform);
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (gameManagerSO.isGameOver || !other.CompareTag("Player"))
            {
                return;
            }

            gameManagerSO.AddScore(successPoints);
        }

        #endregion

        #region Methods

        #region Private

        private void GameReset()
        {
            if (!gameObject.activeSelf)
            {
                return;
            }

            spawnerSO.OnRelease?.Invoke(transform);
        }

        #endregion

        #endregion
    }
}
