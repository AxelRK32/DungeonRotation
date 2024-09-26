using UnityEngine;

public class GateController : MonoBehaviour
{
    public Animator gateAnimator; 
    public string gateAnimation1 = "GateOpen"; 

    private bool isGateOpen = false;  

    
    public void OpenGate()
    {
        if (!isGateOpen)
        {
            gateAnimator.SetTrigger("openGateTrigger");
            isGateOpen = true;
        }
    }
}