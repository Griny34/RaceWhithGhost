using System;
using UnityEngine;

namespace RaceWithGhost
{
    public class StartTrigger : MonoBehaviour
    {
        //Отвечает за исполнение определенных деействий при пересечении линии старт

        [SerializeField] private MovementGhost _movementGhost;
        [SerializeField] private SwitchTime _switchTime;
        [SerializeField] private CounterRace _counterRace;

        public event Action<int> ChangedNumberRace;

        private void OnTriggerEnter(Collider collider)
        {
            if (collider.TryGetComponent<RecordingPath>(out var _recordingPath))
            {
                if (_counterRace.GetValue() == 0)
                {
                    _recordingPath.StartRecord();

                    ChangeRace();
                }
                else
                {
                    _switchTime.StartTime();
                    _movementGhost.gameObject.SetActive(true);

                    _recordingPath.StartRecord();
                    _movementGhost.StartMove();

                    ChangeRace();
                }

            }
        }

        private void ChangeRace()
        {
            _counterRace.AddCount();
            ChangedNumberRace?.Invoke(_counterRace.GetValue());
        }
    }
}