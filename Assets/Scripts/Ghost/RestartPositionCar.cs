using UnityEngine;

namespace RaceWithGhost
{
    public class RestartPositionCar : MonoBehaviour
    {
        [SerializeField] private MovementGhost _movementGhost;

        private Vector3 _startPositionGhost;

        //Сохраняется стратовая позиция призрака
        //Используется при перезапуске гонки

        private void Awake()
        {
            _startPositionGhost = _movementGhost.transform.position;
        }

        public void RestartPosition()
        {
            _movementGhost.transform.position = _startPositionGhost;
        }
    }
}