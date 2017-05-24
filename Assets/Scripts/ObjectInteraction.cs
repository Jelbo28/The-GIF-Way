using UnityEngine;
using UnityEngine.UI;

public class ObjectInteraction : MonoBehaviour
{
	[SerializeField] private Image crosshair;
	[SerializeField] private Color crosshairHighlight;
	[SerializeField] private Color crosshairNormal;
	[SerializeField] private Text infoText;
	private bool indexUp;
	[SerializeField] private float viewDistance;
	[SerializeField]
	private float clickBuffer;
	private float origClickBuffer;
	[SerializeField]
	private bool lookedAt = false;
    private bool visible = false;
    [SerializeField]
    private Transform prevTransform;

	private void Awake()
	{
		origClickBuffer = clickBuffer;
	}

	private void Update()
	{
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;

		if (Physics.Raycast(ray, out hit, viewDistance))
		{
			Debug.DrawLine(ray.origin, hit.point);

			if (hit.transform.tag == "Interactable" && hit.transform != prevTransform)
			{
                infoText.text = hit.transform.GetComponent<ObjectInfo>().name;

                if (!visible)
                {
                    infoText.text = hit.transform.GetComponent<ObjectInfo>().name;
                    infoText.GetComponentInParent<Animator>().SetBool("Appear", true);
                    crosshair.color = crosshairHighlight;
                    visible = true;
                }


				if (Input.GetMouseButtonDown(0) && clickBuffer <= 0)
				{
					//Debug.Log("Ayyy");
					clickBuffer = origClickBuffer;

				}

				else if(clickBuffer > 0)
				{
					clickBuffer -= Time.deltaTime;
				}
                prevTransform = hit.transform;
                //Debug.Log(prevTransform);
				lookedAt = true;
			}
			else if (hit.transform.tag == "Untagged")
			{
				CardDown();
			}
		}
		else
		{
			CardDown();
		}
	}

	void CardDown()
	{
        if (visible)
        {
            infoText.GetComponentInParent<Animator>().SetBool("Appear", false);
            //infoText.text = "";
            lookedAt = false;
            crosshair.color = crosshairNormal;
            visible = false;
        }


	}
}