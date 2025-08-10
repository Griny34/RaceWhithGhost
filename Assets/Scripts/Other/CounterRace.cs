using UnityEngine;

namespace RaceWithGhost
{
    public class CounterRace : MonoBehaviour
    {
        //Для подсчета заездов

        private int _numberRace = 0;

        public void AddCount()
        {
            _numberRace++;
        }

        public int GetValue()
        {
            return _numberRace;
        }
    }
}