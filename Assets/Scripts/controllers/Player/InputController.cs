using Assets.Scripts.Base;
using Assets.Scripts.Interfaces;
using UnityEngine;

namespace Assets.Scripts.controllers.Player
{
    class InputController : MonoBehaviour
    {
        private IMove move;
        private Moviments moviments;

        private void Start()
        {
            move = GameObject.FindGameObjectWithTag("Mario").GetComponent<IMove>();
            moviments = GameObject.FindGameObjectWithTag("Mario").GetComponent<MarioController>().moviments;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                move.Jump();
            }

            if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            {
                move.Crounch();
                moviments.isCrounched = true;
            }
            else
            {
                moviments.isCrounched = false;
            }

            if (Input.GetKey(KeyCode.LeftShift))
            {
                if (!moviments.isCrounched)
                {
                    move.Run();
                }

                moviments.isRunning = true;
            }
            else
            {
                moviments.isRunning = false;
            }
        }
    }
}
