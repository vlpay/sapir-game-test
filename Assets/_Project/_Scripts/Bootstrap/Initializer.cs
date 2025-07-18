using _Project._Scripts.Core.TargetHitting;
using _Project._Scripts.Core.UI;
using TMPro;
using UnityEngine;

namespace _Project._Scripts.Bootstrap
{
    public class Initializer : MonoBehaviour
    {
        [SerializeField] private GameObject _playerPrefab;
        [SerializeField] private GameObject _targetPrefab;
        [SerializeField] private Vector3 _targetPosition = new Vector3(0f, 0f, 15f);
        [SerializeField] private GameObject _camera;
        [SerializeField] private Vector3 _cameraPosition = new Vector3(0, 10f, 0f);
        [SerializeField] private Vector3 _cameraRotation = new Vector3(75f, 0f, 0f);
        [Space]
        [SerializeField] private int _scoreStep = 1;
        [Header("UI")]
        [SerializeField] private ScoreLabel _scoreLabel;
        
        private GameObject _target;
        
        private void Awake()
        {
            SpawnPlayer();
            SpawnTarget();
            SetCamera();
            InitializeUI();
        }

        private void InitializeUI()
        {
            _scoreLabel.Initialize(_target.GetComponent<IDetectPlayer>(), _scoreStep);
        }

        private void SpawnPlayer()
        {
            if (_playerPrefab == null)
            {
                Debug.LogError("No player prefab assigned!");
                return;
            }
            
            var player = Instantiate(_playerPrefab, new Vector3(0f, 0f, 0f), Quaternion.identity);
            player.name = "Player";
            player.tag = "Player";
        }

        private void SpawnTarget()
        {
            if (_targetPrefab == null)
            {
                Debug.LogError("No target prefab assigned!");
                return;
            }
            var target = Instantiate(_targetPrefab, _targetPosition, Quaternion.identity);

            _target = target;
        }

        private void SetCamera()
        {
            
            _camera.transform.position = _cameraPosition;
            _camera.transform.rotation = Quaternion.Euler(_cameraRotation);
        }
    }
}

