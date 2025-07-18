using System;

namespace _Project._Scripts.Core.TargetHitting
{
    public interface IDetectPlayer
    {
        public event Action OnPlayerHit;
    }
}