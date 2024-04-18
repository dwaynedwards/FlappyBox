using UnityEngine;

namespace FlappyBox
{
    [RequireComponent(typeof(SpriteRenderer), typeof(Rigidbody2D), typeof(BoxCollider2D))]
    public class Box : MonoBehaviour
    {
        #region Fields and Properties

        #region Private

        [SerializeField] private GameManagerSO gameManagerSO;
        [SerializeField] private Rigidbody2D rigidBody2D;
        [SerializeField] private int flapSpeed;

        private bool _canFlap;

        #endregion

        #endregion

        #region Unity Methods

        private void Awake()
        {
            gameManagerSO.OnGameReset += GameReset;
            gameManagerSO.OnGameOver += GameOver;
            GameReset();
        }

        private void Update()
        {
            HandleFlap();
        }

        #endregion

        #region Methods

        #region Private

        public void GameReset()
        {
            rigidBody2D.velocity = Vector2.zero;
            transform.position = Vector3.zero;
            _canFlap = true;
        }

        public void GameOver()
        {
            _canFlap = false;
        }

        private void HandleFlap()
        {
            if (!_canFlap || !Input.GetKeyDown(KeyCode.Space))
            {
                return;
            }

            rigidBody2D.velocity = Vector2.up * flapSpeed;
        }

        #endregion

        #endregion
    }
}
