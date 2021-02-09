

using System;
using AhorroMeta = modelos.AhorroMeta;
using Corriente = modelos.Corriente;
using Cuenta = modelos.Cuenta;
using Transaccion = modelos.Transaccion;
using Util = utilities.Util;


namespace transacciones
{
	/*
	/// <summary>
 @author SAMC
	/// </summary>
	*/

	public class Banco
	{

		private Cuenta[] cuentas = new Cuenta[5];
		private Transaccion[] transacciones = new Transaccion[50];

		public Banco()
		{
			for (int x = 0; x < transacciones.Length; x++)
			{
				transacciones[x] = null;
			}

			for (int x = 0; x < cuentas.Length; x++)
			{
				cuentas[x] = null;
			}
		}

		public virtual void registrarCuenta(Cuenta cuenta)
		{
			for (int x = 0; x < cuentas.Length; x++)
			{
				if (cuentas[x] == null)
				{
					cuentas[x] = cuenta;
					break;
				}
			}
		}

		public virtual int obtenerNumeroCuentas()
		{
			int c = 0;
			for (int x = 0; x < cuentas.Length; x++)
			{
				if (cuentas[x] != null)
				{
					c++;
				}
			}
			return c;
		}

		public virtual Cuenta buscarCuenta(string numero)
		{ //Buscar
			Cuenta cuenta = null;
			for (int x = 0; x < cuentas.Length; x++)
			{
				if (cuentas[x] != null)
				{
					if (cuentas[x].Numero.Equals(numero))
					{
						cuenta = cuentas[x];
						break;
					}
				}
			}
			return cuenta;
		}

		public virtual Cuenta buscarCuentaPorCliente(string cedula)
		{ //Buscar
			Cuenta cuenta = null;
			for (int x = 0; x < cuentas.Length; x++)
			{
				if (cuentas[x] != null)
				{
					if (cuentas[x].Cedula.Equals(cedula))
					{
						cuenta = cuentas[x];
						break;
					}
				}
			}
			return cuenta;
		}

		public virtual int obtenerCodigoTransaccion()
		{

			int codigo = 1;

			for (int x = 0; x < transacciones.Length; x++)
			{
				if (transacciones[x] != null)
				{
					codigo = transacciones[x].Codigo + 1;
				}
			}

			return codigo;
		}

		public virtual void realizarTransaccion(Transaccion transaccion)
		{

			for (int x = 0; x < transacciones.Length; x++)
			{
				if (transacciones[x] == null)
				{
					transacciones[x] = transaccion;
					break;
				}
			}

			for (int x = 0; x < cuentas.Length; x++)
			{
				if (cuentas[x] != null)
				{
					if (cuentas[x].Numero.Equals(transaccion.Numero_cuenta))
					{
						cuentas[x].actualizarSaldo(transaccion.Valor, transaccion.Tipo);
					}
				}

			}

		}

		public virtual void mostrarCuentas()
		{
			for (int x = 0; x < cuentas.Length; x++)
			{
				if (cuentas[x] != null)
				{
					cuentas[x].mostrar();
				}
			}
		}

		public virtual void mostrarTransaccion(Cuenta cuenta)
		{ //Quiebre de control

			Transaccion[] filtro = getTransaccionesCliente(cuenta.Cedula);

			filtro = ordenarPorTipo(filtro);

			Transaccion[] depositos = new Transaccion[filtro.Length];
			Transaccion[] retiros = new Transaccion[filtro.Length];

			for (int x = 0; x < filtro.Length; x++)
			{
				if (filtro[x] != null)
				{
					if (filtro[x].Tipo.Equals("D"))
					{
						insertarEnArreglo(depositos, filtro[x]);
					}
					else if (filtro[x].Tipo.Equals("R"))
					{
						insertarEnArreglo(retiros, filtro[x]);
					}
				}
			}

			imprimirTransacciones(depositos, retiros, cuenta);

		}

		private void imprimirTransacciones(Transaccion[] depositos, Transaccion[] retiros, Cuenta cuenta)
		{
	//      System.out.println("Tipo de Cuenta:"+ cuenta.);
			Console.WriteLine("CEDULA: " + cuenta.Cedula);
			Console.WriteLine("CLIENTE: " + cuenta.Nombre);
			Console.WriteLine("DEPOSITOS");
			Util.LineaDeposito;
			int d = 0, r = 0;
			for (int x = 0; x < depositos.Length; x++)
			{
				if (depositos[x] != null)
				{
					depositos[x].mostrar();
					d++;
				}
			}
			Console.WriteLine("TOTAL DE DEPOSITOS: " + d);
			Console.WriteLine("RETIROS");
			Util.LineaRetiro;
			for (int x = 0; x < retiros.Length; x++)
			{
				if (retiros[x] != null)
				{
					retiros[x].mostrar();
					r++;
				}
			}
			Console.WriteLine("TOTAL DE RETIROS: " + r);
			Console.WriteLine("TOTAL DE TRANSACCIONES: " + (d + r));
		}

		private void insertarEnArreglo(Transaccion[] transacciones, Transaccion transaccion)
		{
			for (int x = 0; x < transacciones.Length; x++)
			{
				if (transacciones[x] == null)
				{
					transacciones[x] = transaccion;
					break;
				}
			}
		}
	}
}
