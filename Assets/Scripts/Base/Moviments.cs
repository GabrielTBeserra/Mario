using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Base
{
    public class Moviments
    {

        [SerializeField] public bool isGrounded { get; set; }
        [SerializeField] public bool isCrounched { get; set; }
        [SerializeField] public bool isRunning { get; set; }


        public Moviments()
        {
            isGrounded = false;
            isCrounched = false;
            isRunning = false;
        }
    }
}
