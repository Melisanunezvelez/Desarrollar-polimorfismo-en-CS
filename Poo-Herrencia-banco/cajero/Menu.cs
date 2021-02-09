using AhorroMeta = modelos.AhorroMeta;
using Corriente = modelos.Corriente;
using Cuenta = modelos.Cuenta;
using Banco = transacciones.Banco;
using System;

namespace cajero
{
	/*
	<summary>
 	@author SAMC
	</summary>
    */

	public class Menu
	{
		private Banco banco = new Banco();
		private Scanner entrada = new Scanner(System.in);

		public virtual void menuPrincipal()
		{

			bool continuar = true;
			int seleccion, op;

			do
			{
				Console.WriteLine("--------BIENVENIDO--------");
				Console.WriteLine("----BANCO CONSORCIOS SAMC SA----");
				Console.WriteLine("-----MENU PRINCIPAL-----");
				Console.WriteLine("     1. CREAR CUENTA AHORRO META  ");
				Console.WriteLine("     2. CREAR CUENTA CORRIENTE   ");
				Console.WriteLine("     3. CREAR CUENTA AHORRO   ");
				Console.WriteLine("     4. TRANSACCIONES ");
				Console.WriteLine("     5. SALIR    ");

				seleccion = entrada.Next();
				entrada.nextLine();
				switch (seleccion)
				{

					case 1:
						if (banco.obtenerNumeroCuentas() < 5) {
							crearCuentaAhorroMeta();
						}
						else
						{
							Console.Error.WriteLine("Error: Ya se han registrado 5 cuentas, limite alcanzado");
						}

						break;
					case 2:
						if (banco.obtenerNumeroCuentas() < 5)
						{
							crearCuentaCorriente();
						}
						else
						{
							Console.Error.WriteLine("Error: Ya se han registrado 5 cuentas, limite alcanzado");
						}
						break;
					case 3:
						if (banco.obtenerNumeroCuentas() > 0)
						{
							iniciarSesionCajero();
						}
						else
						{
							Console.Error.WriteLine("Error: No existen cuentas registradas en el banco aún");
						}
						break;
					case 4:
						Console.WriteLine("-----------------------------");
						Console.WriteLine(" ¡Gracias !, Vuelva pronto.");
						Console.WriteLine("-----------------------------");
						Environment.Exit(0);
						break;
					default:
						Console.WriteLine("-------------------------------------------------");
						Console.WriteLine("Opcion no disponible Intente nuevamente porfavor.");
						Console.WriteLine("-------------------------------------------------");
					break;
				}

				do
				{
					Console.WriteLine("¿Desea seguir usando el cajero? (1 = Si, 0 = No)");
					op = entrada.Next();
					if (op < 0 || op > 1)
					{
						Console.Error.WriteLine("Error: opcion invalida");
					}

				} while (op < 0 || op > 1);

			} while (continuar);

		}

		private void crearCuentaAhorroMeta()
		{
			AhorroMeta ahorro = new AhorroMeta();

			string nombre, cedula;
			float ahorro_meta, saldo_inicial;

			Console.WriteLine("Ingrese nombre del titular: ");
			nombre = entrada.nextLine();
			Console.WriteLine("Ingrese cedula del titular: ");
			cedula = entrada.nextLine();

			do
			{
				Console.WriteLine("Ingrese meta de ahorros: ");
				ahorro_meta = entrada.nextFloat();
				if (ahorro_meta < 100)
				{
					Console.Error.WriteLine("Error: meta de ahorros no puede ser menor a $100");
				}
			} while (ahorro_meta < 100);

			do
			{
				Console.WriteLine("Ingrese saldo inicial: ");
				saldo_inicial = entrada.nextFloat();
				if (saldo_inicial < 1)
				{
					Console.Error.WriteLine("Error: saldo inicial no puede ser menor a $1");
				}
			} while (saldo_inicial < 1);

			ahorro.Numero = banco.getNumeroCuenta("A");
			ahorro.Nombre = nombre;
			ahorro.Cedula = cedula;
			ahorro.Ahorro_meta = ahorro_meta;
			ahorro.Saldo_inicial = saldo_inicial;
			ahorro.Valor_actual = saldo_inicial;
			ahorro.Estado = "A";

			banco.registrarCuenta(ahorro);

			Console.WriteLine("El numero de cuenta generado es: " + ahorro.Numero);
		}

		private void crearCuentaCorriente()
		{
			Corriente corriente = new Corriente();

			string nombre, cedula, oficial_cta;
			float saldo_inicial;

			Console.WriteLine("Ingrese nombre del oficial de la cuenta: ");
			oficial_cta = entrada.nextLine();
			Console.WriteLine("Ingrese nombre del titular: ");
			nombre = entrada.nextLine();
			Console.WriteLine("Ingrese cedula del titular: ");
			cedula = entrada.nextLine();

			do
			{
				Console.WriteLine("Ingrese saldo inicial: ");
				if (saldo_inicial < 1000) {
                Console.Error.WriteLine("Error: saldo inicial no puede ser menor a $1000");
            }
        } while (saldo_inicial < 1000);

		corriente.Numero = banco.getNumeroCuenta("C");
        corriente.Oficial_cta = oficial_cta;
        corriente.Nombre = nombre;
        corriente.Cedula = cedula;
        corriente.Saldo_inicial = saldo_inicial;
        corriente.Valor_actual = saldo_inicial;
        corriente.Estado = "A";

        banco.registrarCuenta(corriente);

        Console.WriteLine("El numero de cuenta generado es: " + corriente.getNumero());
    }	

	 private void iniciarSesionCajero() {

        Cuenta cuenta;
        do {
            Console.WriteLine("Ingrese numero de la cuenta: ");
            String numero = entrada.nextLine();
            cuenta = banco.buscarCuenta(numero);
            if (cuenta == null) {
                Console.Error.WriteLine("Error: No existe cuenta con ese numero");
            }
        } while (cuenta == null);
        MenuTransaccion menuTransaccion = new MenuTransaccion(banco, cuenta);
        menuTransaccion.mostrarMenu();
	 }
	}
}

    
		
		

	



