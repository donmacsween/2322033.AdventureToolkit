using UnityEngine;

public class SwapFish : MonoBehaviour
{
    [SerializeField] GameObject fish1;
    [SerializeField] GameObject fish2;

    public void Swap()
    {
        if(fish1.activeSelf == true)
        {
            fish1.SetActive(false);
            fish2.SetActive(true);
        }
        else
        {
            fish1.SetActive(true);
            fish2.SetActive(false);
        }
    }
}
