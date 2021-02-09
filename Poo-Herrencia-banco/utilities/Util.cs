using System;


namespace utilities
{

	/// 
	/// <summary>
	/// @author SAMC
	/// </summary>
	public class Util
	{

		public static string LineaDeposito
		{
			get
			{
				Console.WriteLine("CUENTA      CODIGO          FECHA        VALOR        ESTADO");
				return"CUENTA            CODIGO          FECHA        VALOR       ESTADO";
			}
		}

		public static string LineaRetiro
		{
			get
			{
				Console.WriteLine("CUENTA      CODIGO          FECHA        VALOR         CHEQUE      ESTADO");
				return "CUENTA            CODIGO          FECHA        VALOR       CHEQUE         ESTADO";
			}
		}

		public static string getShortDateString(DateTime date)
		{
			SimpleDateFormat formatter = new SimpleDateFormat("dd-mm-yyyy");
			return formatter.format(date);
		}



	}

}