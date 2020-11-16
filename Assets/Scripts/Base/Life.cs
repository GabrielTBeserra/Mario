using UnityEngine;

namespace Assets.Scripts.Base
{
    public class Life
    {
        private static int ZERO = 0;
        [SerializeField]
        private int life;
        [SerializeField]
        private int TotalLife;

        public Life(int life)
        {
            TotalLife = life;
            this.life = life;
        }

        public void increaseLife(int v)
        {
            if ((life += v) >= TotalLife)
                life = TotalLife;
            else
                life += v;
        }

        public void decreaseLife(int v)
        {
            if (life > ZERO)
            {
                life -= v;
            }
            else
            {
                life = ZERO;
            }
        }

        public bool isEmpty()
        {
            return life <= 0 ? true : false;
        }

        public void restart()
        {
            life = TotalLife;
        }

        public int currentLife()
        {
            return life;
        }

        public int maxLife()
        {
            return TotalLife;
        }
    }
}
