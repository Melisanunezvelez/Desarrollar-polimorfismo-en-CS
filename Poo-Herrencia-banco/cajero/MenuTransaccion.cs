using Cuenta = modelos.Cuenta;
using Transaccion = modelos.Transaccion;
using Banco = transacciones.Banco;
using System;

namespace cajero
{
	/*
	/// <summary>
	 @author SAMC
	/// </summary>
	*/

	public class MenuTransaccion
	{

		//internal Scanner entrada = new Scanner(System.in);
		internal Banco banco;
		internal Cuenta cuenta;

		public MenuTransaccion(Banco banco, Cuenta cuenta)
		{
			this.banco = banco;
			this.cuenta = cuenta;
		}

		public virtual void mostrarMenu()
		{
			bool continuar = false;
			int seleccion, op;
			do
			{

				Console.WriteLine("-----TRANSACCIONES-----");
				Console.WriteLine("     1. DEPOSITO.  ");
				Console.WriteLine("     2. RETIRO.   ");
				Console.WriteLine("     3. CONSULTA DE SALDO ACTUAL. ");
				Console.WriteLine("     4. CONSULTA DE TRANSACCIONES POR CLIENTE.    ");
				Console.WriteLine("     5. REGRESAR AL MENU PRINCIPAL.    ");

				seleccion = entrada.Next();

				switch (seleccion)
				{
					case 1:
						if (cuenta.Numero[0] == '1')
						{
							Deposito_Retiro("D", "A");
						}
						else
						{
							Deposito_Retiro("D", "C");
						}
	//                    cuenta = banco.buscarCuenta(cuenta.getNumero());
						break;
					case 2:
						if (cuenta.Numero[0] == '1')
						{
							Deposito_Retiro("R", "A");
						}
						else
						{
							Deposito_Retiro("R", "C");
						}
	//                    cuenta = banco.buscarCuenta(cuenta.getNumero());
						break;
					case 3:
						consultarSaldoActual();
						break;
					case 4:
						consultaTransaccionesCliente();
						break;
					case 5:
						Console.WriteLine("-----------------------------");
						Menu mp = new Menu();
						mp.menuPrincipal();
						Console.WriteLine("-----------------------------");
						break;
					default:
						Console.WriteLine("-------------------------------------------------");
						Console.WriteLine("Opcion no disponible Intente nuevamente porfavor.");
						Console.WriteLine("-------------------------------------------------");
					break;
				}


			} while (continuar);

		}

		private Transaccion Deposito_Retiro(string tipoTransaccion, string tipoCuenta)
		{
			entrada.nextLine();
			string numero = null, numCheque;
			float valor;

			Transaccion transaccion = new Transaccion();

			Console.WriteLine("Ingrese numero de cuenta: ");
			numero = entrada.nextLine();



			if (tipoCuenta.Equals("C"))
			{
				Console.WriteLine("Ingrese numero de cheque: ");
				numCheque = entrada.nextLine();
			}
			else
			{
				numCheque = "-1";
			}
			cuenta = banco.buscarCuenta(numero);
			if (cuenta != null)
			{

			Console.WriteLine("Ingrese monto: ");
			valor = entrada.nextFloat();

			transaccion.Codigo = banco.obtenerCodigoTransaccion();
			transaccion.Cedula = cuenta.Cedula;
			transaccion.Numero_cuenta = numero;
			transaccion.Numero_cheque = numCheque;
			transaccion.Tipo = tipoTransaccion;
			transaccion.Valor = valor;
			transaccion.Fecha_transaccion = DateTime.Now;
			transaccion.Estado = "A";

			banco.realizarTransaccion(transaccion);

			return transaccion;
			}

			Console.Error.WriteLine("Error: No existe cuenta con ese numero");
			return null;
		}


		private void consultarSaldoActual()
		{

			Cuenta cta = banco.buscarCuenta(cuenta.Numero);
			Console.WriteLine("Saldo en cuenta: $" + cta.Valor_actual);

		}

		private void consultaTransaccionesCliente()
		{

		   banco.mostrarTransaccion(cuenta);

		}

		public virtual void tipoTransaciones()
		{
			Transaccion t = new Transaccion();
			for (int i = 0; i < 1; i++)
			{
				Console.WriteLine("Igrese el tipo de transaccion: \n" + "D =  DEPOSITO  R = RETIRO");
				t.Tipo = entrada.next();
				Console.WriteLine("Ingrese el numero  de Cuenta:");
				t.Numero_cuenta = entrada.next();
				Console.WriteLine("Ingrese el numero de Cedula: ");
				t.Cedula = entrada.next();
				Console.WriteLine("Ingrese el valor");
				Console.Write("$");
				t.Valor = entrada.nextFloat();
				banco.realizarTransaccion(t);
			}
		}
	}
}

		
	


