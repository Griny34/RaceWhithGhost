using UnityEngine;
using Ashsvp;
using UnityEngine.UI;

namespace RaceWithGhost
{
    public class FinishTrigger : MonoBehaviour
    {
        //Отвечает за исполнение определенных деействий по завержению заезда

        [SerializeField] private SwitchTime _switchTime;
        [SerializeField] private Image _menuFinish;
        [SerializeField] private ResetVehicle _resetVehicle;

        private void OnTriggerExit(Collider collider)
        {
            if (collider.TryGetComponent<RecordingPath>(out var _recordingPath))
            {
                _recordingPath.RestartRecord();
                _menuFinish.gameObject.SetActive(true);
                _switchTime.StopTime();
            }
        }
    }
}