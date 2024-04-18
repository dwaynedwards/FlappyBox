using UnityEngine;

namespace FlappyBox
{
    [RequireComponent(typeof(BoxCollider2D))]
    public class HitBox : MonoBehaviour
    {
        #region Fields and Properties

        #region Private

        [SerializeField] private GameManagerSO gameManagerSO;

        #endregion

        #endregion

        #region Unity Methods

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (!other.gameObject.CompareTag("Player"))
            {
                return;
            }

            gameManagerSO.isGameOver = true;
            gameManagerSO.OnGameOver?.Invoke();
        }

        #endregion
    }
}
