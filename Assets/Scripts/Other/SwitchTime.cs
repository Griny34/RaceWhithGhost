using UnityEngine;

namespace RaceWithGhost
{
    public class SwitchTime : MonoBehaviour
    {
        //Остановка и запуск Time

        public void StopTime()
        {
            Time.timeScale = 0;
        }

        public void StartTime()
        {
            Time.timeScale = 1;
        }
    }
}