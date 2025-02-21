using UnityEngine;

namespace Camera
{
    public class MoveCamera : MonoBehaviour
    {
        public Transform firstPersonCameraPosition;
        public Transform thirdPersonCameraPosition;
        bool firstPerson = true;
        bool thirdPerson = false;

        void Update()
        {
            bool SwitchPerspective = Input.GetKey("h");
        
        
            if (SwitchPerspective)
            {
                if (firstPerson)
                {
                    firstPerson = false;
                    thirdPerson = true;
                }
                else
                {
                    firstPerson = true;
                    thirdPerson = false;
                }
            }

            if (firstPerson)
            {
                transform.position = firstPersonCameraPosition.position;
                transform.rotation = firstPersonCameraPosition.rotation;
            }
            else if (thirdPerson)
            {
                transform.position = thirdPersonCameraPosition.position;
                transform.rotation = thirdPersonCameraPosition.rotation;
            }
        }
    }
}
