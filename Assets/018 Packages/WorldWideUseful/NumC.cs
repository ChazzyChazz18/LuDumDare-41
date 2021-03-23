using System;

/// NumC.cs a class that allows you to change a given number into another format (return Strings)
public static class NumC {

	// Methods

	#region Methods

	/// This method change a number (seconds) into time format, Ex:(12,600.secs = 03:30 or 37,553.secs = 10:25:53)
	public static string TimeFormat (float num) {
		TimeSpan time = TimeSpan.FromSeconds (num);

		string str;

		if (num < 3600) {
			str = string.Format ("{0:00}:{1:00}",
				time.Minutes,
				time.Seconds);
		} else {
			str = string.Format ("{0:00}:{1:00}:{2:00}",
				time.Hours,
				time.Minutes,
				time.Seconds);
		}
		
		return str;
	}// numbersTimeFormat End

	/// This method change a number into a more readable big format, Ex:(1,000 = 1K | 1,000,000 = 1M | 1,000,000,000 = 1B)
	public static string BigFormat (float num) {
		float numStr;
		string suffix;

		// If num is less than 1,000 then show the number as it is
		if (num < 1000f) {//1,000
			//999
			numStr = num;
			suffix = "";
		} 
		// If num is less than 1,000,000 then show for ex 900,000 = 900K
		else if (num < 1000000f) {//1,000,000
			//999K = 999,999
			numStr = num / 1000f;// num/1K
			suffix = "K";
		} 
		// If num is less than 1,000,000,000 then show for ex 900,000,000 = 900m
		else if (num < 1000000000f) {//1,000,000,000
			//999M = 999,999,999
			numStr = num / 1000000f;// num/1M
			suffix = "M";
		} 
		// If num is less than 1,000,000,000,000 then show for ex 900,000,000,000 = 900B
		else if (num < 1000000000000f) {//1,000,000,000,000
			//999b = 999,999,999,999
			numStr = num / 1000000000f;// num/1B
			suffix = "B";
		} 
		// If num is less than 1,000,000,000,000,000 then show for ex 900,000,000,000,000 = 900T
		else if (num < 1000000000000000f) {//1,000,000,000,000,000
			//999t = 999,999,999,999,999
			numStr = num / 1000000000000f;// num/1T
			suffix = "T";
		} 
		// If num is less than 1,000,000,000,000,000,000 then show for ex 900,000,000,000,000,000 = 900aa
		else if (num < 1000000000000000000f){
			//999aa = 999,999,999,999,999,999
			numStr = num / 1000000000000000f;// num/1aa
			suffix = "aa";
		}
		// If num is less than 1,000,000,000,000,000,000,000 then show for ex 900,000,000,000,000,000,000 = 900ab
		else if (num < 1000000000000000000000f){
			//999ab = 999,999,999,999,999,999,999
			numStr = num / 1000000000000000000f;// num/1ab
			suffix = "ab";
		}
		// If num is less than 1,000,000,000,000,000,000,000,000 then show for ex 900,000,000,000,000,000,000,000 = 900ac
		else if (num < 1000000000000000000000000f){
			//999ac = 999,999,999,999,999,999,999,999
			numStr = num / 1000000000000000000000f;// num/1ac
			suffix = "ac";
		}
		// If num is less than 1,000,000,000,000,000,000,000,000,000 then show for ex 900,000,000,000,000,000,000,000,000 = 900ad
		else if (num < 1000000000000000000000000000f){
			//999ad = 999,999,999,999,999,999,999,999,999
			numStr = num / 1000000000000000000000000f;// num/1ad
			suffix = "ad";
		}
		// If num is less than 1,000,000,000,000,000,000,000,000,000,000 then show for ex 900,000,000,000,000,000,000,000,000,000 = 900ae
		else{
			//999ae = 999,999,999,999,999,999,999,999,999,999
			numStr = num / 1000000000000000000000000000f;// num/1ae
			suffix = "ae";
		}

		if (num > 1000) {
			return numStr.ToString ("###.##") + suffix;
		} else {
			return numStr.ToString ("###") + suffix;
		}

	}// numberFormat End

	#endregion Methods

}// End of class NumC
