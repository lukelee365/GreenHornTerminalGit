using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Email1Try : MonoBehaviour {
	public Text contentText;

	// Use this for initialization
	void Start () {
		contentText.text = "Sent: 17 March 2017 at 03:23 pm\nTo: louis@futurearcadia.com\n\nSubject Line: Request for meeting from IPCC\n\nTo Jeremy Lane,\n\nThis is the third and final outreach notice from the  Intergovernmental Panel On Climate Change (IPCC) to the Arcadia Corp board.  We have been attempting to contact you since December of last year and to date have had no reply.\n\n The United Nations Environment Programme (UNEP) and the World Meteorological Organization (WMO) have been working since 1988 to provide the world with a clear scientific view on the current state of knowledge in climate change and its potential environmental and socio-economic impacts. \n\nAs you know we have been very interested in your organization's claim for a revolutionary new living environment with can also mitigate the causes of climate change and create carbon neutral future cities.  \n\nWe have concerns about scientific underpinnings and resources involved in your proposals. The implications of your proposals are global in nature and we strongly advise that you consult with the IPCC before proceeding, we can provide balanced scientific information which seems to have been overlooked in your proposals. \n\nWe have many concerns about your project and have been trying to set up a meeting, please get back to me as soon as possible. \n\nRegards,\nPatricia\n—\nIntergovernmental Panel On Climate Change\nC/O World Meteorological Organization\n7bis Avenue de la Paix \nC.P. 2300\nCH- 1211 Geneva 2, Switzerland\n\n<size = 15>This email and any files transmitted with it are confidential and intended solely for the use of the individual or entity to whom they are addressed. If you have received this email in error, please notify the system manager. This message contains confidential information and is intended only for the individual named. If you are not the named addressee, you should not disseminate, distribute or copy this email. Please notify the sender immediately by email if you have received this email by mistake and delete this email from your system. If you are not the intended recipient, you are notified that disclosing, copying, distributing or taking any action in reliance on the contents of this information is strictly prohibited.</size>\n\n";
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
