using UnityEngine;

public class InputBroadcaster : MonoBehaviour
{
    public bool IsTapPressed { get; private set; } = false;

    private void Update()
    {
        //Note: put better Input Detection here. This code is
        //      just a placeholder for now. We will need to detect
        // for new Unity Input System, Touch Input, and Mouse Input
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    IsTapPressed = true;
                    break;
                case TouchPhase.Ended:
                    IsTapPressed = false;
                    break;
            }
        }
    }
}
