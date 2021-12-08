using UnityEngine;

public class FlipToHazard : MonoBehaviour
{

   
    public float rotationSpeed;
    private float rotZ;
    public bool ClockWise;





    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {

        if (ClockWise == true)
        {
            rotZ -= Time.deltaTime * rotationSpeed;

        }
        else
        {
            rotZ += Time.deltaTime * rotationSpeed; ;
        }

        if (rotZ < 90)
        {

            transform.rotation = Quaternion.Euler(0, 0, rotZ);
            

        }

        if (rotZ == 180)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            
        }

        



    }
}
