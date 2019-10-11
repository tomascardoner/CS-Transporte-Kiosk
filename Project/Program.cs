using CardonerSistemas.Database.ADO;
using CardonerSistemas.PointOfSale;
using System;
using System.Windows.Forms;

namespace CSTransporteKiosko
{
    static class Program
    {
        /// <summary>
        /// Application for CS-Transporte Kiosko
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            #region Objects creation

            // Bases de datos y entidades
            SQLServer dbLocal = new SQLServer();
            SQLServer dbEmpresa = new SQLServer();
            Kiosko kiosko = new Kiosko();
            TicketPlantilla ticket = new TicketPlantilla();
            Printer printer = new Printer();

            #endregion

            if (!InicializarKiosko(ref kiosko, ref dbLocal, ref dbEmpresa, ref ticket, ref printer))
            {
                return;
            }

            // Create message box window and set appearance
            FormMessageBox messageBox = new FormMessageBox();
            messageBox.SetAppearance(kiosko.KioskoConfiguracion);

            // Create welcome window and set appearance
            FormWelcome welcome = new FormWelcome();
            welcome.SetAppearance(kiosko.KioskoConfiguracion);

            // Create steps window and set appearance
            FormSteps steps = new FormSteps();
            steps.SetAppearance(kiosko.KioskoConfiguracion);

            do
            {
                steps.Hide();
                welcome.ShowDialog();

                steps.PrepararParaMostrar(dbLocal, dbEmpresa, kiosko, messageBox, ticket, printer);
                if (steps.ShowDialog() == DialogResult.Cancel)
                {
                    break;
                }                    
            } while (true);

            #region Close and clean-up objects

            welcome.Close();
            steps.Close();
            messageBox.Close();

            dbLocal.Close();
            dbEmpresa.Close();
            printer.Close();

            #endregion

        }

        #region Kiosko init

        static private bool InicializarKiosko(ref Kiosko kiosko, ref SQLServer dbLocal, ref SQLServer dbEmpresa, ref TicketPlantilla ticket, ref Printer printer)
        {
            // Conecto a la base de datos de la aplicación
            if (!PrepararConexionABaseDeDatosLocal(ref dbLocal))
            {
                return false;
            }

            // Cargo los datos del Kiosko a partir de la Mac Address de la PC
            string macAddress = kiosko.ObtenerMacAddressLocal();
            if (!kiosko.CargarPorMacAddress(dbLocal.Connection, macAddress))
            {
                return false;
            }
            if (!kiosko.IsFound)
            {
                // La Mac Address del Kiosko no está en la base de datos, guardo en el log
                AgregarEventLog(ref dbLocal, EventLog.TipoLoginFallido, 0, EventLog.MensajeLoginFallido, String.Format("MAC Address: {0}", macAddress));
                MessageBox.Show("La MAC Address del Kiosko no está registrada en la base de datos.");
                return false;
            }

            // Cargo los datos de la Empresa para la que está configurada el Kiosko
            // y conecto a la base de datos respectiva
            if (!kiosko.EmpresaCargar(dbLocal.Connection))
            {
                return false;
            }
            if (!PrepararConexionABaseDeDatosEmpresa(ref dbEmpresa, kiosko.Empresa.DatabaseName))
            {
                return false;
            }

            // Cargo la configuración del Kiosko (Logos, Colores, Tipografías, Tiempos, Ticket, etc)
            if (!kiosko.KioskoConfiguracionCargar(dbLocal.Connection))
            {
                return false;
            }
            if (!kiosko.KioskoConfiguracion.KioskoConfiguracionValoresCargar(dbLocal.Connection))
            {
                return false;
            }

            // Cargo el formato del Ticket a imprimir para entregar al cliente
            if (!(kiosko.IdTicketPlantilla.HasValue && ticket.CargarPorID(dbLocal.Connection, kiosko.IdTicketPlantilla.Value) && ticket.IsFound))
            {
                return false;
            }
            if (!ticket.TicketPlantillaComandosCargar(dbLocal.Connection))
            {
                return false;
            }

            if (!PreparaImpresora(ref printer, kiosko.KioskoConfiguracion.ValorPOSPrinterClaimTimeoutSeconds))
            {
                if (!System.Diagnostics.Debugger.IsAttached)
                {
                    return false;
                }
            }

            // Se completó todo correctamente
            AgregarEventLog(ref dbLocal, EventLog.TipoLoginExitoso, kiosko.IdKiosko, EventLog.MensajeLoginExitoso, String.Empty);
            return true;
        }

        static private void AgregarEventLog(ref SQLServer dbLocal, string tipo, byte IdKiosko, string mensaje, string notas)
        {
            EventLog eventLog = new EventLog
            {
                Tipo = tipo,
                IdKiosko = IdKiosko,
                Mensaje = mensaje,
                Notas = notas
            };
            eventLog.Agregar(dbLocal.Connection);
        }

        static private bool PreparaImpresora(ref Printer printer, int claimTimeout)
        {
            return printer.GetOpenClaimAndEnable(Properties.Settings.Default.POSPrinterName, claimTimeout);
        }

        #endregion

        #region Database

        static private bool PrepararConexionABaseDeDatosLocal(ref SQLServer dbLocal)
        {
            dbLocal.ApplicationName = CardonerSistemas.My.Application.Info.Title;
            dbLocal.Datasource = Properties.Settings.Default.DatabaseDatasource;
            dbLocal.InitialCatalog = Properties.Settings.Default.DatabaseDatabase;
            dbLocal.UserID = Properties.Settings.Default.DatabaseUserID;
            if (Properties.Settings.Default.DatabasePassword.Trim().Length == 0)
            {
                dbLocal.Password = "";
            }
            else
            {
                CardonerSistemas.Encrypt.TripleDES decrypter = new CardonerSistemas.Encrypt.TripleDES(CardonerSistemas.Constants.PublicEncryptionPassword);
                string decryptedPassword = "";
                if (decrypter.Decrypt(Properties.Settings.Default.DatabasePassword, ref decryptedPassword))
                {
                    dbLocal.Password = decryptedPassword;
                }
                decrypter.Dispose();
            }
            dbLocal.WorkstationID = "";
            dbLocal.CreateConnectionString();

            return dbLocal.Connect();
        }

        static private bool PrepararConexionABaseDeDatosEmpresa(ref SQLServer dbEmpresa, string databaseName)
        {
            dbEmpresa.ApplicationName = CardonerSistemas.My.Application.Info.Title;
            dbEmpresa.Datasource = Properties.Settings.Default.DatabaseDatasource;
            dbEmpresa.InitialCatalog = databaseName;
            dbEmpresa.UserID = Properties.Settings.Default.DatabaseUserID;
            if (Properties.Settings.Default.DatabasePassword.Trim().Length == 0)
            {
                dbEmpresa.Password = "";
            }
            else
            {
                CardonerSistemas.Encrypt.TripleDES decrypter = new CardonerSistemas.Encrypt.TripleDES(CardonerSistemas.Constants.PublicEncryptionPassword);
                string decryptedPassword = "";
                if (decrypter.Decrypt(Properties.Settings.Default.DatabasePassword, ref decryptedPassword))
                {
                    dbEmpresa.Password = decryptedPassword;
                }
                decrypter.Dispose();
            }
            dbEmpresa.WorkstationID = "";
            dbEmpresa.CreateConnectionString();

            return dbEmpresa.Connect();
        }

        #endregion

    }
}
