using UnityEngine;

public class CreditGame : MonoBehaviour
{
	public GameObject mainObject;
	public GameObject creditObject;

	
    void Start()
    {
        creditObject.SetActive(false);
    }

    public void OpenCredit(bool isOpen)
    {
	    mainObject.SetActive(!isOpen);
	    creditObject.SetActive(isOpen);
    }
}
