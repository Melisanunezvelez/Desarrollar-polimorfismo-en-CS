namespace cajero
{
	using AhorroMeta = modelos.AhorroMeta;
	using Corriente = modelos.Corriente;
	using Cuenta = modelos.Cuenta;
	using Transaccion = modelos.Transaccion;
	using Banco = transacciones.Banco;

	/// 
	/// <summary>
	/// @author SAMC
	/// </summary>
	public class Cajero
	{
		public static void Main(string[] args)
		{
			Menu menu = new Menu();
			menu.menuPrincipal();
		}

	}

}