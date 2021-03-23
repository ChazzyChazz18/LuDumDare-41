using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// FastMath.cs is a class that contains a diverse amount of math formulas/ ecuations (methods) ready to use.
public static class FastMath {

	// Methods

	#region Methods

	#region Porcentage

	/// Here we get the porcentage of a given number with his porcent amount. Ex: 10 is the *6.66%* of 150
	public static float GetPorcentageA (float total, float porcentAmount) {
		float porcentage;

		porcentage = (porcentAmount / total) * 100;

		return porcentage;
	}// GetPorcentageA End

	/// Here we get the number of a given porcentage with his porcent amount. Ex: 4 is the 50% of *8*
	public static float GetPorcentageB (float porcentAmount, float porcentage) {
		float total;

		total = (porcentAmount / porcentage) * 100;

		return total;
	}// GetPorcentageB End

	/// Here we get the porcent amount of a given number with his porcentage. Ex: the 25% of 200 is *50*
	public static float GetPorcentageC (float porcentage, float total) {
		float porcentAmount;

		porcentAmount = (porcentage * total) / 100;

		return porcentAmount;
	}// GetPorcentageC End

	#endregion Porcentage

	#region ColorAlpha

	public static IEnumerator AlphaController (Color objColor, float timer, float alphaPorcent) {

		float startAlphaSprite = objColor.a;

		float rate = 1.0f / timer;
		float progress = 0.0f;

		while(progress < 1.1){
			Color tempSpriteColor = objColor;

			objColor = new Color (
				tempSpriteColor.r, 
				tempSpriteColor.g, 
				tempSpriteColor.b, 
				Mathf.Lerp (startAlphaSprite, alphaPorcent, progress)
			);

			progress += rate * Time.deltaTime;

			yield return null;
		}
		
	}


	#endregion ColorAlpha

	#region Test

	/*public static float GetAMultipleOf (float num, float multiple) {
		float result;
		//float randomNum;

		 

		return result;
	}*/

	#endregion Test

	#region GenerationalFraction

	// here we get the generational fraction for exact decimal
	public static string GetGenFra1 (double num) { //done
		string numToStr = num.ToString ();
		string[] temp = numToStr.Split('.');

		//int integer = Convert.ToInt32(temp [0]);
		//int decim = Convert.ToInt32(temp [1]);

		// here we get a numerator by just "extracting" the point of the decimal number
		string strNumerator = temp [0] + temp [1];

		double numerator = Convert.ToDouble (strNumerator);

		// here we get the denominator by taking 1 and adding as many 0 as digits the decimal part of the number has
		string strDenominator = "1";

		for(int i = 0; i < temp[1].Length; i++){
			strDenominator += "0";
		}

		double denominator = Convert.ToDouble (strDenominator);
			
		return numerator + " / " + denominator;

	}// GetGenFra1 End

	// here we get the generational fraction for pure periodic decimal
	public static string GetGenFra2 (double num) { //still to fix
		string numToStr = num.ToString ();
		string[] temp = numToStr.Split('.');

		int integer = Convert.ToInt32(temp [0]);
		//int decim = Convert.ToInt32(temp [1]);

		// here we get a numerator by just "extracting" the point of the decimal number
		string strNumerator = temp [0] + temp [1];

		double numerator = Convert.ToDouble (strNumerator) - integer;

		// here we get the denominator by taking 1 and adding as many 0 as digits the decimal part of the number has
		string strDenominator = "";

		for(int i = 0; i < temp[1].Length; i++){
			strDenominator += "9";
		}

		double denominator = Convert.ToDouble (strDenominator);

		return numerator + " / " + denominator;
	}// GetGenFra2 End

	// here we get the generational fraction for periodic mixed decimal
	/*public static string GetGenFra3 (double num) { // still to do
		string numToStr = num.ToString ();
		string[] temp = numToStr.Split('.');

		int integer = Convert.ToInt32(temp [0]);
		//int decim = Convert.ToInt32(temp [1]);

		// here we get a numerator by just "extracting" the point of the decimal number
		string strNumerator = temp [0] + temp [1];

		double numerator = Convert.ToDouble (strNumerator) - integer;

		// here we get the denominator by taking 1 and adding as many 0 as digits the decimal part of the number has
		string strDenominator = "";

		for(int i = 0; i < temp[1].Length; i++){
			strDenominator += "9";
		}

		double denominator = Convert.ToDouble (strDenominator);

		return numerator + " / " + denominator;
	}// GetGenFra3 End */

	#endregion GenerationalFraction

	#endregion Methods

}// End of FastMath Class