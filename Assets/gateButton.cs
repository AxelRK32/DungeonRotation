using UnityEngine;

public class gateButton : MonoBehaviour
{ 
    public Animator buttonAnimator;
    public string buttonPressAnimation = "ButtonPressed";
    public GateController GateController;  
    private bool isButtonActive = true; 


private void Start()
{
    isButtonActive = true; // Ensure it's true at the start
}

private void OnTriggerEnter(Collider other)
{
    if (isButtonActive && other.CompareTag("Player")) 
    {
        Debug.Log(other.gameObject.name);
        buttonAnimator.SetTrigger("PressButtonTrigger");
        GateController.OpenGate();
        isButtonActive = false; 
    }
}
}

