using System;
using UnityEngine;

namespace FlappyBox
{
    [CreateAssetMenu(fileName = "SpawnerSO", menuName = "Scriptable Objects/SpawnerSO", order = 0)]
    public class SpawnerSO : ScriptableObject
    {
        public int xPos;
        public Action<Transform> OnRelease;
    }
}
