using UnityEngine;
using UnityEngine.Pool;
using Random = UnityEngine.Random;

namespace FlappyBox
{
    public class PipeSpawner : MonoBehaviour
    {
        #region Fields and Properties

        #region Private

        [SerializeField] private SpawnerSO spawnerSO;
        [SerializeField] private Transform pipesPrefab;
        [SerializeField] private int poolAmount = 5;
        [SerializeField] private int spawnRate = 4;
        [SerializeField] private float heightOffset = 7;

        private IObjectPool<Transform> _pooledPipes;
        private float _timer = 0;

        #endregion

        #endregion

        #region Unity Methods

        private void Awake()
        {
            _pooledPipes = new ObjectPool<Transform>(CreatePipe,
                                                     OnGetPipe,
                                                     OnReleasePipe,
                                                     OnDestroyPipe,
                                                     true,
                                                     poolAmount,
                                                     poolAmount);
            transform.position = new Vector3(spawnerSO.xPos, 0, 0);
            spawnerSO.OnRelease = Release;
        }

        private void Start()
        {
            _pooledPipes.Get();
        }

        private void Update()
        {
            if (_timer < spawnRate)
            {
                _timer += Time.deltaTime;
                return;
            }

            _pooledPipes.Get();
            _timer = 0;
        }

        #endregion

        #region Methods

        #region Private

        private Transform CreatePipe()
        {
            var pipe = Instantiate(pipesPrefab, transform.position, transform.rotation, transform);
            pipe.gameObject.SetActive(false);
            return pipe;
        }

        // Called when an item is returned to the pool using Release
        private static void OnReleasePipe(Transform pipe)
        {
            pipe.gameObject.SetActive(false);
        }

        // Called when an item is taken from the pool using Get
        private void OnGetPipe(Transform pipe)
        {
            pipe.localPosition = new Vector3(0, Random.Range(-heightOffset, heightOffset), 0);
            pipe.gameObject.SetActive(true);
        }

        // If the pool capacity is reached then any items returned will be destroyed.
        // We can control what the destroy behavior does, here we destroy the GameObject.
        private static void OnDestroyPipe(Transform pipe)
        {
            Destroy(pipe.gameObject);
        }

        private void Release(Transform pipe)
        {
            _pooledPipes.Release(pipe);
        }

        #endregion

        #endregion
    }
}
