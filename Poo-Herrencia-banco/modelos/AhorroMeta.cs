using System;

namespace modelos
{
	/// 
	/// <summary>
	/// @author SAMC
	/// </summary>
	public class AhorroMeta : Cuenta
	{

		private float ahorro_meta;

		public AhorroMeta()
		{
		}

		public AhorroMeta(float ahorro_meta)
		{
			this.ahorro_meta = ahorro_meta;
		}

		public AhorroMeta(float ahorro_meta, string numero, string nombre, float valor_actual, string cedula, string estado, float saldo_inicial) : base(numero, nombre, valor_actual, cedula, estado, saldo_inicial)
		{
			this.ahorro_meta = ahorro_meta;
		}

		public virtual float Ahorro_meta
		{
			get
			{
				return ahorro_meta;
			}
			set
			{
				if (value < 100)
				{
					Console.Error.WriteLine("ERROR: META DE AHORRO MINIMA PERMITIDA ES DE $100");
					return;
				}
				this.ahorro_meta = value;
			}
		}


		public override float generarIntereses()
		{
			float interes;
			interes = saldo_actual * 0.02f;
			return interes;
		}

		public override void actualizarSaldo(float valor, string tipoTransaccion)
		{
			switch (tipoTransaccion)
			{
				case "D":
					depositar(valor);
					break;
				case "R":
					retirar(valor);
					break;
				default:
					Console.Error.WriteLine("¡TIPO DE TRANSACCION INVALIDA!");
				break;
			}
		}

		public override void mostrar()
		{
			Console.WriteLine("TIPO: AHORRO META");
			Console.WriteLine("TITULAR:" + nombre);
			Console.WriteLine("IDENTIFICACION: " + cedula);
			Console.WriteLine("NUMERO CUENTA: " + numero);
		}

		public override void cobrarIntereses()
		{

		}

		private void depositar(float valor)
		{
			if (valor < 1)
			{
				Console.Error.WriteLine("ERROR: CANTIDAD A DEPOSITAR NO PUEDE SER INFERIOR A $1");
				return;
			}
			if (saldo_actual == 0)
			{
				saldo_actual += (float)(valor - (valor * 0.05));
				Console.WriteLine("INFORMACION: DEPOSITO HECHO EXITOSAMENTE CON PENALIZACION DEL 5% POR SALDO CERO");
			}
			else
			{
				saldo_actual += valor;
				Console.WriteLine("INFORMACION: DEPOSITO HECHO EXITOSAMENTE");
			}
		}

		private void retirar(float valor)
		{
			if (saldo_actual < this.ahorro_meta)
			{
				Console.Error.WriteLine("ERROR: AUN NO HA ALCANZADO SU META DE AHORRO, NO PUEDE HACER RETIROS AÚN");
				return;
			}
			if (valor > (saldo_actual * 0.95))
			{
				Console.Error.WriteLine("ERROR: NO PUEDE RETIRAR MAS DEL 95% DE SUS AHORROS");
			}
			else
			{
				saldo_actual -= valor;
				Console.WriteLine("INFORMACION: RETIRO HECHO EXITOSAMENTE");
			}

		}

	}

}