using System;

namespace modelos
{
	using Util = utilities.Util;

	/// 
	/// <summary>
	/// @author SAMC
	/// </summary>
	public class Transaccion
	{

		private int codigo;
		private string cedula;
		private string numero_cuenta;
		private string tipo;
		private DateTime fecha_transaccion;
		private float valor;
		private string numero_cheque;
		private string estado;

		public Transaccion(int codigo, string cedula, string numero_cuenta, string tipo, DateTime fecha_transaccion, float valor, string numero_cheque, string estado)
		{
			this.codigo = codigo;
			this.cedula = cedula;
			this.numero_cuenta = numero_cuenta;
			this.tipo = tipo;
			this.fecha_transaccion = fecha_transaccion;
			this.valor = valor;
			this.numero_cheque = numero_cheque;
			this.estado = estado;
		}

		public Transaccion()
		{
		}

		public virtual int Codigo
		{
			get
			{
				return codigo;
			}
			set
			{
				this.codigo = value;
			}
		}


		public virtual string Cedula
		{
			get
			{
				return cedula;
			}
			set
			{
				this.cedula = value;
			}
		}


		public virtual string Numero_cuenta
		{
			get
			{
				return numero_cuenta;
			}
			set
			{
				this.numero_cuenta = value;
			}
		}


		public virtual string Tipo
		{
			get
			{
				return tipo;
			}
			set
			{
				this.tipo = value;
			}
		}


		public virtual DateTime Fecha_transaccion
		{
			get
			{
				return fecha_transaccion;
			}
			set
			{
				this.fecha_transaccion = value;
			}
		}


		public virtual float Valor
		{
			get
			{
				return valor;
			}
			set
			{
				this.valor = value;
			}
		}


		public virtual string Numero_cheque
		{
			get
			{
				return numero_cheque;
			}
			set
			{
				this.numero_cheque = value;
			}
		}


		public virtual string Estado
		{
			get
			{
				return estado;
			}
			set
			{
				this.estado = value;
			}
		}


		public virtual void mostrar()
		{

			switch (tipo)
			{
				case "D":
					Console.WriteLine(numero_cuenta + "         " + codigo + "         " + Util.getShortDateString(fecha_transaccion) + "         $" + valor + "         " + estado);
					break;
				case "R":
					Console.WriteLine(numero_cuenta + "         " + codigo + "         " + Util.getShortDateString(fecha_transaccion) + "         $" + valor + "         " + numero_cheque + "         " + estado);
					break;
				default:
					Console.WriteLine("TIPO TRANSACCION INVALIDA");
					break;
			}


		}



	}

}