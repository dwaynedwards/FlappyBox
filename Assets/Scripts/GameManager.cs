using UnityEngine;

namespace FlappyBox
{
    public class GameManager : MonoBehaviour
    {
        #region Fields and Properties

        #region Private

        [SerializeField] private GameManagerSO gameManagerSO;

        #endregion

        #endregion

        #region Unity Methods

        private void Awake()
        {
            gameManagerSO.OnGameReset += GameReset;
            GameReset();
        }

        #endregion

        #region Methods

        #region Private

        private void GameReset()
        {
            gameManagerSO.Reset();
        }

        #endregion

        #endregion
    }
}
