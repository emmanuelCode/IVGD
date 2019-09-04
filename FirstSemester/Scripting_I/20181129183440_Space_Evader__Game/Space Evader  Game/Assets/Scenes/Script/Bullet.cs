using UnityEngine;


public class Bullet : MonoBehaviour
{
        private void Update()
        {

                transform.Translate(Vector3.forward);

        }

//        private void OnTriggerEnter(Collider other)
//        {
//                if (other.tag == "border_cube")
//                {
//                        return;
//                }
//
//                if (other.tag == "enemy")
//                {
//                        Destroy(other.gameObject);
//                }
//                Destroy(other.gameObject);
//        }
}
