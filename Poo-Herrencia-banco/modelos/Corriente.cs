using System;

namespace modelos
{
	/// 
	/// <summary>
	/// @author SAMC
	/// </summary>
	public class Corriente : Cuenta
	{

		private string oficial_cta;
		private float sobre_giro;

		public Corriente()
		{
		}

		public Corriente(string oficial_cta, float sobre_giro)
		{
			this.oficial_cta = oficial_cta;
			this.sobre_giro = sobre_giro;
		}

		public Corriente(string oficial_cta, float sobre_giro, string numero, string nombre, float valor_actual, string cedula, string estado, float saldo_inicial) : base(numero, nombre, valor_actual, cedula, estado, saldo_inicial)
		{
			this.oficial_cta = oficial_cta;
			this.sobre_giro = sobre_giro;
		}

		public virtual string Oficial_cta
		{
			get
			{
				return oficial_cta;
			}
			set
			{
				this.oficial_cta = value;
			}
		}


		public virtual float Sobre_giro
		{
			get
			{
				return sobre_giro;
			}
			set
			{
				this.sobre_giro = value;
			}
		}


		public override float Saldo_inicial
		{
			set
			{
				if (value < 1000)
				{
					Console.Error.WriteLine("ERROR: SALDO INICIAL MINIMO DEBE SER $1000");
				}
				this.saldo_inicial = value;
			}
		}

		public override float generarIntereses()
		{
			float interes;
			interes = this.sobre_giro * 0.16f;
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
			Console.WriteLine("TIPO: CORRIENTE");
			Console.WriteLine("TITULAR:" + nombre);
			Console.WriteLine("IDENTIFICACION: " + cedula);
			Console.WriteLine("NUMERO CUENTA: " + numero);
		}

		public override void cobrarIntereses()
		{
			if (sobre_giro > 0)
			{
				saldo_actual -= this.sobre_giro * 0.16f;
				Console.WriteLine("INFORMACION: INTERES COBRADO");
			}
		}

		private void depositar(float valor)
		{
			if (valor < 50)
			{
				Console.Error.WriteLine("ERROR: DEPOSITO MINIMO PERMITIDO ES DE $50 ");
				return;
			}
			saldo_actual += valor;
			Console.WriteLine("INFORMACION: DEPOSITO HECHO EXITOSAMENTE");
		}

		private void retirar(float valor)
		{
			if (valor > saldo_actual)
			{
				sobre_giro = valor - saldo_actual;
				Console.WriteLine("INFORMACION: SALDO EN CUENTA INSUFICIENTE, SE HA REALIZO SOBREGIRO POR LA CANTIDAD FALTANTE");
			}
			saldo_actual -= valor;
			Console.WriteLine("INFORMACION: RETIRO HECHO CORRECTAMENTE");
		}

	}

}