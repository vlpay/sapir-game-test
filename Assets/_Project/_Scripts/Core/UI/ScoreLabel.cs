using _Project._Scripts.Core.TargetHitting;
using TMPro;
using UnityEngine;

namespace _Project._Scripts.Core.UI
{
    [RequireComponent(typeof(TMP_Text))]
    public class ScoreLabel: MonoBehaviour
    {
        private TMP_Text _text;
        private IDetectPlayer _playerDetect;
        private int _scoreStep;
        
        private int _score = 0;
        
        private void OnValidate()
        {
            _text = GetComponent<TMP_Text>();
        }

        public void Initialize(IDetectPlayer playerDetect, int scoreStep)
        {
            _scoreStep = scoreStep;
            _playerDetect = playerDetect;
            _playerDetect.OnPlayerHit += UpdateScore;
        }

        private void OnDisable()
        {
            if (_playerDetect == null)
                return;
            
            _playerDetect.OnPlayerHit -= UpdateScore;
        }

        private void UpdateScore()
        {
            _score += _scoreStep;
            _text.text = _score.ToString();
        }
    }
}