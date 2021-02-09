namespace modelos
{
	/// 
	/// <summary>
	/// @author SAMC
	/// </summary>
	public abstract class Cuenta
	{

		protected internal string numero;
		protected internal string nombre;
		protected internal float saldo_actual;
		protected internal string cedula;
		protected internal string estado;
		protected internal float saldo_inicial;

		public Cuenta()
		{
		}

		public Cuenta(string numero, string nombre, float valor_actual, string cedula, string estado, float saldo_inicial)
		{
			this.numero = numero;
			this.nombre = nombre;
			this.saldo_actual = valor_actual;
			this.cedula = cedula;
			this.estado = estado;
			this.saldo_inicial = saldo_inicial;
		}

		public virtual string Numero
		{
			get
			{
				return numero;
			}
			set
			{
				this.numero = value;
			}
		}


		public virtual string Nombre
		{
			get
			{
				return nombre;
			}
			set
			{
				this.nombre = value;
			}
		}


		public virtual float Valor_actual
		{
			get
			{
				return saldo_actual;
			}
			set
			{
				this.saldo_actual = value;
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


		public virtual float Saldo_inicial
		{
			get
			{
				return saldo_inicial;
			}
			set
			{
				this.saldo_inicial = value;
			}
		}


		public abstract float generarIntereses();

		public abstract void actualizarSaldo(float valor, string tipoTransaccion);

		public abstract void mostrar();

		public abstract void cobrarIntereses();



	}

}