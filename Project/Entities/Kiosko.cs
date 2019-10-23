using System;
using System.Data;
using System.Data.SqlClient;
using System.Net.NetworkInformation;
using System.Windows.Forms;
using CardonerSistemas.Database.ADO;

namespace CSTransporteKiosko
{
    class Kiosko
    {

        #region Entity definition properties

        private const string EntityFieldNameIdKiosko = "IDKiosko";
        private const string EntityFieldNameNombre = "Nombre";
        private const string EntityFieldNameMacAddress = "MACAddress";
        private const string EntityFieldNameIdEmpresa = "IDEmpresa";
        private const string EntityFieldNameIdLugar = "IDLugar";
        private const string EntityFieldNameIdKioskoConfiguracion = "IDKioskoConfiguracion";
        private const string EntityFieldNameIdTicketPlantilla = "IDTicketPlantilla";
        private const string EntityFieldNameActivo = "Activo";
        private const string EntityFieldNameUltimaConexion = "UltimaConexion";
        private const string EntityFieldNameUltimaOperacion = "UltimaOperacion";

        private const bool EntityDisplayNameIsFemale = false;
        private const string EntityDisplayName = "Kiosko";

        private string EntityLoadByIdErrorMessage = String.Format("Error al cargar {0} {1} por Id.", EntityDisplayNameIsFemale ? " la " : " el ", EntityDisplayName);
        private string EntityLoadByMacAddressErrorMessage = String.Format("Error al cargar {0} {1} por MAC Address.", EntityDisplayNameIsFemale ? " la " : " el ", EntityDisplayName);

        private string EntityLoadErrorMessage;
        private string EntityLoadPropertiesErrorMessage;

        public Kiosko()
        {
            EntityLoadErrorMessage = CardonerSistemas.Database.Framework.Lite.GetEntityLoadErrorMessage(EntityDisplayName, EntityDisplayNameIsFemale);
            EntityLoadPropertiesErrorMessage = CardonerSistemas.Database.Framework.Lite.GetEntityLoadPropertiesErrorMessage(EntityDisplayName, EntityDisplayNameIsFemale);
        }

        #endregion

        #region Object private properties

        private byte _IdKiosko;
        private string _Nombre;
        private string _MacAddress;
        private byte _IdEmpresa;
        private int _IdLugar;
        private byte _IdKioskoConfiguracion;
        private byte? _IdTicketPlantilla;
        private bool _Activo;
        private DateTime? _UltimaConexion;
        private DateTime? _UltimaOperacion;

        private bool _IsFound = false;

        #endregion

        #region Object public properties

        public byte IdKiosko { get => _IdKiosko; }
        public string Nombre { get => _Nombre; set => _Nombre = value; }
        public string MacAddress { get => _MacAddress; set => _MacAddress = value; }
        public byte IdEmpresa { get => _IdEmpresa; set => _IdEmpresa = value; }
        public int IdLugar { get => _IdLugar; set => _IdLugar = value; }
        public byte IdKioskoConfiguracion { get => _IdKioskoConfiguracion; set => _IdKioskoConfiguracion = value; }
        public byte? IdTicketPlantilla { get => _IdTicketPlantilla; set => _IdTicketPlantilla = value; }
        public bool Activo { get => _Activo; set => _Activo = value; }
        public DateTime? UltimaConexion { get => _UltimaConexion; }
        public DateTime? UltimaOperacion { get => _UltimaOperacion; }

        public bool IsFound { get => _IsFound; }

        #endregion

        #region Related entities

        private Empresa _Empresa;
        private KioskoConfiguracion _KioskoConfiguracion;

        public Empresa Empresa { get => _Empresa; }
        public KioskoConfiguracion KioskoConfiguracion { get => _KioskoConfiguracion; }

        public bool EmpresaCargar(SqlConnection connection)
        {
            _Empresa = new Empresa();
            return _Empresa.CargarPorID(connection, _IdEmpresa);
        }

        public bool KioskoConfiguracionCargar(SqlConnection connection)
        {
            _KioskoConfiguracion = new KioskoConfiguracion();
            return _KioskoConfiguracion.CargarPorID(connection, _IdKioskoConfiguracion);
        }

        #endregion

        #region Other methods

        public string ObtenerMacAddressLocal()
        {
            string[] excludedInterfaceNames = { "Hyper-V Virtual", "VMware Virtual", "Microsoft Wi-Fi" };

            Cursor.Current = Cursors.WaitCursor;

            foreach (NetworkInterface ni in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (ni.NetworkInterfaceType == NetworkInterfaceType.Ethernet | ni.NetworkInterfaceType == NetworkInterfaceType.Wireless80211)
                {
                    if(ni.OperationalStatus == OperationalStatus.Up)
                    {
                        bool excluded = false;
                        foreach (string excludedInterfaceName in excludedInterfaceNames)
                        {
                            if (ni.Description.StartsWith(excludedInterfaceName))
                            {
                                excluded = true;
                                break;
                            }
                        }
                        if (!excluded)
                        {
                            Cursor.Current = Cursors.Default;
                            return ni.GetPhysicalAddress().ToString();
                        }
                    }
                }
            }
            Cursor.Current = Cursors.Default;
            return String.Empty;
        }

        #endregion

        #region Load data from database

        public bool CargarPorID(SqlConnection connection, byte idKiosko)
        {
            Cursor.Current = Cursors.WaitCursor;

            try
            {
                SqlCommand command = new SqlCommand("usp_Kiosko_ObtenerPorID", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@IDKiosko", idKiosko);

                Cursor.Current = Cursors.Default;
                return CargarEjecutar(command, EntityLoadByIdErrorMessage);
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                CardonerSistemas.Error.ProcessError(ex, EntityLoadByIdErrorMessage);
                return false;
            }
        }

        public bool CargarPorMacAddress(SqlConnection connection, string macAddress)
        {
            Cursor.Current = Cursors.WaitCursor;

            try
            {
                SqlCommand command = new SqlCommand("usp_Kiosko_ObtenerPorMAC", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@MACAddress", macAddress);

                Cursor.Current = Cursors.Default;
                return CargarEjecutar(command, EntityLoadByMacAddressErrorMessage);
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                CardonerSistemas.Error.ProcessError(ex, EntityLoadByMacAddressErrorMessage);
                return false;
            }
        }

        private bool CargarEjecutar(SqlCommand command, string errorMessage)
        {
            try
            {
                SqlDataReader dataReader;
                dataReader = command.ExecuteReader(CommandBehavior.SingleRow);
                command.Dispose();
                command = null;

                _IsFound = dataReader.HasRows;

                if (IsFound)
                {
                    dataReader.Read();

                    if (CargarPropiedades(dataReader))
                    {
                        dataReader.Close();
                        dataReader = null;
                        return true;
                    }
                    else
                    {
                        dataReader.Close();
                        dataReader = null;
                        return false;
                    }
                }
                else
                {
                    dataReader.Close();
                    dataReader = null;
                    return true;
                }
            }
            catch (Exception ex)
            {
                CardonerSistemas.Error.ProcessError(ex, errorMessage);
                return false;
            }
        }

        private bool CargarPropiedades(SqlDataReader dataReader)
        {
            try
            {
                _IdKiosko = SQLServer.DataReaderGetByte(dataReader, EntityFieldNameIdKiosko);
                _Nombre = SQLServer.DataReaderGetString(dataReader, EntityFieldNameNombre);
                _MacAddress = SQLServer.DataReaderGetStringSafeAsEmpty(dataReader, EntityFieldNameMacAddress);
                _IdEmpresa = SQLServer.DataReaderGetByte(dataReader, EntityFieldNameIdEmpresa);
                _IdLugar = SQLServer.DataReaderGetInteger(dataReader, EntityFieldNameIdLugar);
                _IdKioskoConfiguracion = SQLServer.DataReaderGetByte(dataReader, EntityFieldNameIdKioskoConfiguracion);
                _IdTicketPlantilla = SQLServer.DataReaderGetByteSafeAsNull(dataReader, EntityFieldNameIdTicketPlantilla);
                _Activo = SQLServer.DataReaderGetBoolean(dataReader, EntityFieldNameActivo);
                _UltimaConexion = SQLServer.DataReaderGetDateTimeSafeAsNull(dataReader, EntityFieldNameUltimaConexion);
                _UltimaOperacion = SQLServer.DataReaderGetDateTimeSafeAsNull(dataReader, EntityFieldNameUltimaOperacion);
                return true;
            }
            catch (Exception ex)
            {
                CardonerSistemas.Error.ProcessError(ex, EntityLoadPropertiesErrorMessage);
                return false;
            }
        }

        #endregion

        #region Save data to database

        public bool ActualizarUltimaConexion(SqlConnection connection, byte idKiosko)
        {
            Cursor.Current = Cursors.WaitCursor;

            try
            {
                SqlCommand command = new SqlCommand("usp_Kiosko_ActualizarUltimaConexion", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@IDKiosko", idKiosko);

                command.ExecuteNonQuery();

                command.Dispose();
                command = null;

                Cursor.Current = Cursors.Default;
                return true;
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                CardonerSistemas.Error.ProcessError(ex, "Error al actualizar la última conexión del Kiosko.");
                return false;
            }
        }

        public bool ActualizarUltimaOperacion(SqlConnection connection, byte idKiosko)
        {
            Cursor.Current = Cursors.WaitCursor;

            try
            {
                SqlCommand command = new SqlCommand("usp_Kiosko_ActualizarUltimaOperacion", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@IDKiosko", idKiosko);

                command.ExecuteNonQuery();

                command.Dispose();
                command = null;

                Cursor.Current = Cursors.Default;
                return true;
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                CardonerSistemas.Error.ProcessError(ex, "Error al actualizar la última operación del Kiosko.");
                return false;
            }
        }

        #endregion

    }
}
