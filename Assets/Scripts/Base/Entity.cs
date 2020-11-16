using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Base
{
    public class Entity: MonoBehaviour
    {
        [SerializeField]
        public Life life;
        [SerializeField]
        public Moviments moviments;
    }
}
