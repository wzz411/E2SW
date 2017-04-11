using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class mainScript : MonoBehaviour {
	public Text ask1; 
	public Text ask2; 
	public Text ask3; 
	public Text ask4; 
	public Text correct;
	public Text log;
	string num1, num2, num3, num4, num5, num6, num7, num8;
	int	count =0;
	int cnt = 0;
	string ranNum1, ranNum2, ranNum3, ranNum4;
	string test;

	public void n1()
	{
		num1 = "A";
		if (count == 0) {
			ask1.text = num1.ToString ();
		} else if (count == 1) {
			ask2.text = num1.ToString ();
		} else if (count == 2) {
			ask3.text = num1.ToString ();
		} else {
			ask4.text = num1.ToString ();
		}
		count++;
	}
	public void n2()
	{
		num2 = "B";
		if (count == 0) {
			ask1.text = num2.ToString ();
		} else if (count == 1) {
			ask2.text = num2.ToString ();
		} else if (count == 2) {
			ask3.text = num2.ToString ();
		} else {
			ask4.text = num2.ToString ();
		}
		count++;
	}
	public void n3()
	{
		num3 = "C";
		if (count == 0) {
			ask1.text = num3.ToString ();
		} else if (count == 1) {
			ask2.text = num3.ToString ();
		} else if (count == 2) {
			ask3.text = num3.ToString ();
		} else {
			ask4.text = num3.ToString ();
		}
		count++;
	}
	public void n4()
	{
		num4 = "D";
		if (count == 0) {
			ask1.text = num4.ToString ();
		} else if (count == 1) {
			ask2.text = num4.ToString ();
		} else if (count == 2) {
			ask3.text = num4.ToString ();
		} else {
			ask4.text = num4.ToString ();
		}
		count++;
	}
	public void n5()
	{
		num5 = "E";
		if (count == 0) {
			ask1.text = num5.ToString ();
		} else if (count == 1) {
			ask2.text = num5.ToString ();
		} else if (count == 2) {
			ask3.text = num5.ToString ();
		} else {
			ask4.text = num5.ToString ();
		}
		count++;
	}
	public void n6()
	{
		num6 = "F";
		if (count == 0) {
			ask1.text = num6.ToString ();
		} else if (count == 1) {
			ask2.text = num6.ToString ();
		} else if (count == 2) {
			ask3.text = num6.ToString ();
		} else {
			ask4.text = num6.ToString ();
		}
		count++;
	}
	public void n7()
	{
		num7 = "G";
		if (count == 0) {
			ask1.text = num7.ToString ();
		} else if (count == 1) {
			ask2.text = num7.ToString ();
		} else if (count == 2) {
			ask3.text = num7.ToString ();
		} else {
			ask4.text = num7.ToString ();
		}
		count++;
	}
	public void n8()
	{
		num8 = "H";
		if (count == 0) {
			ask1.text = num8.ToString ();
		} else if (count == 1) {
			ask2.text = num8.ToString ();
		} else if (count == 2) {
			ask3.text = num8.ToString ();
		} else {
			ask4.text = num8.ToString ();
		}
		count++;
	}

	public void enter()
	{
		string c1, c2, c3, c4;
		c1 = (ask1.text);
		c2 = (ask2.text);
		c3 = (ask3.text);
		c4 = (ask4.text);
		if (checkWinner (c1, c2, c3, c4)) {
            Debug.Log("winner");
			//Application.LoadLevel ("winner");
		} else {
			ResetAll ();
		}
	}
	void Start()
	{
		ranNum1 = "F";
		ranNum2 = "A";
		ranNum3 = "C";
		ranNum4 = "E";
		//RE.text = ranNum1 + ranNum2 + ranNum3 + ranNum4;
	}
	bool checkWinner(string num1, string num2, string num3, string num4)
	{
		if (num1.Equals (ranNum1) && num2.Equals (ranNum2) && num3.Equals (ranNum3) && num4.Equals (ranNum4))
			return true;
		//num1.equals(ranNum) check then count for black/white or non, can also just show number correct regardless of order
		else
		Correct ();
		log.text += ask1.text + " " + ask2.text + " " + ask3.text + " " + ask4.text + " " + "Correct:" + cnt + "\n";
			return false;
	}

	void Correct()
	{
        cnt = 0;
		test = ask1.text + ask2.text + ask3.text + ask4.text;
		foreach (char c in test) {
			if (c == 'F') {
				cnt++;
			} else if (c == 'A') {
				cnt++;
			} else if (c == 'C') {
				cnt++;
			} else if (c == 'E') {
				cnt++;
			} 
		}
	}
	void ResetAll()
	{
		ask1.text = "?";
		ask2.text = "?";
		ask3.text = "?";
		ask4.text = "?";
		count = 0;
		cnt = 0;
	}

}
