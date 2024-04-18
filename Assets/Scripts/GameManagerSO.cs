using System;
using UnityEngine;

namespace FlappyBox
{
    [CreateAssetMenu(fileName = "GameManagerSO", menuName = "Scriptable Objects/GameManagerSO", order = 2)]
    public class GameManagerSO : ScriptableObject
    {
        #region Fields and Properties

        #region Public

        public Action OnGameReset = null;
        public Action OnGameOver = null;
        public bool isGameOver = false;
        public int Score = 0;

        #endregion

        #endregion

        #region Methods

        #region Public

        public void Reset()
        {
            Score = 0;
            isGameOver = false;
        }

        public void AddScore(int scoreToAdd)
        {
            Score += scoreToAdd;
        }

        #endregion

        #endregion
    }
}
