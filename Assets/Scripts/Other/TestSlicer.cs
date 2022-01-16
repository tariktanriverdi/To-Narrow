using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EzySlice;
public class TestSlicer : MonoBehaviour
{

    [SerializeField] Material mat;
    [SerializeField] LayerMask mask;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch inputTouch = Input.GetTouch(0);

            if (inputTouch.phase == TouchPhase.Began)
            {
                Debug.Log("touched");
                Collider[] objectToCut = Physics.OverlapBox(transform.position, new Vector3(1f, 1f, 1f), transform.rotation, mask);
                foreach (Collider obj in objectToCut)
                {
                    SlicedHull cutedObj = Cut(obj.GetComponent<Collider>().gameObject, mat);
                    GameObject cutedUp = cutedObj.CreateUpperHull(obj.gameObject, mat);
                    GameObject cutedLow = cutedObj.CreateLowerHull(obj.gameObject, mat);
                    obj.gameObject.SetActive(false);

                    AddCompomentsToObj(cutedUp);
                    AddCompomentsToObj(cutedLow);
                }
            }
        }


    }


    public SlicedHull Cut(GameObject obj, Material mat)
    {
        Debug.Log("sliced" + gameObject.transform.tag);
        return obj.Slice(transform.position, transform.up, mat);
    }
    public void AddCompomentsToObj(GameObject obj)
    {
        Debug.Log("added components");
        obj.AddComponent<MeshCollider>().convex = true;
        obj.AddComponent<Rigidbody>();
        obj.GetComponent<Rigidbody>().interpolation = RigidbodyInterpolation.Interpolate;
        obj.GetComponent<Rigidbody>().AddExplosionForce(100, obj.transform.position, 20);
       // obj.GetComponent<Rigidbody>().useGravity=false;
        obj.layer=3;

    }
}
