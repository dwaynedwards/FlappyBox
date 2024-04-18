using UnityEngine;
using UnityEngine.UIElements;

namespace FlappyBox
{
    [RequireComponent(typeof(UIDocument))]
    public class GameOverUI : MonoBehaviour
    {
        #region Fields and Properties

        #region Private

        [SerializeField] private GameManagerSO gameManagerSO;

        private Button _playAgainButton;

        #endregion

        #endregion

        #region Unity Methods

        private void OnEnable()
        {
            _playAgainButton = GetComponent<UIDocument>().rootVisualElement.Q<Button>("PlayAgainButton");
            _playAgainButton.clicked += OnPlayAgainButtonClicked;
        }

        private void OnDisable()
        {
            if (_playAgainButton == null)
            {
                return;
            }

            _playAgainButton.clicked -= OnPlayAgainButtonClicked;
            _playAgainButton = null;
        }

        private void Awake()
        {
            gameManagerSO.OnGameReset += GameReset;
            gameManagerSO.OnGameOver += GameOver;
            GameReset();
        }

        #endregion

        #region Methods

        #region Private

        private void GameReset()
        {
            gameObject.SetActive(false);
        }

        private void GameOver()
        {
            gameObject.SetActive(true);
        }

        private void OnPlayAgainButtonClicked()
        {
            gameManagerSO.OnGameReset?.Invoke();
        }

        #endregion

        #endregion
    }
}
