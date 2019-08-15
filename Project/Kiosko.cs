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
        #region Propiedades

        private string[] excludedInterfaceNames = { "Hyper-V Virtual", "VMware Virtual", "Microsoft Wi-Fi"};

        // Entity definition properties

        private const string EntityDBName = "Kiosko";

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

        private string EntityLoadByIdErrorMessage = String.Format("Error al cargar {0} {1} por Id.", EntityDisplayNameIsFemale? " la " : " el ", EntityDisplayName);
        private string EntityLoadByMacAddressErrorMessage = String.Format("Error al cargar {0} {1} por MAC Address.", EntityDisplayNameIsFemale ? " la " : " el ", EntityDisplayName);
        private string EntityLoadPropertiesErrorMessage = String.Format("Error al cargar las propiedades de {0} {1}.", EntityDisplayNameIsFemale ? " la " : " el ", EntityDisplayName);

        // Object internal properties

        private byte _IdKiosko;
        private DateTime? _UltimaConexion;
        private DateTime? _UltimaOperacion;

        private bool _IsFound = false;

        // Related entities
        private KioskoConfiguracion _KioskoConfiguracion;

        // Public properties

        public byte IdKiosko { get => _IdKiosko; }
        public string Nombre { get; set; }
        public string MacAddress { get; set; }
        public byte IdEmpresa { get; set; }
        public int IdLugar { get; set; }
        public byte IdKioskoConfiguracion { get; set; }
        public byte IdTicketPlantilla { get; set; }
        public bool Activo { get; set; }
        public DateTime? UltimaConexion { get => _UltimaConexion; }
        public DateTime? UltimaOperacion { get => _UltimaOperacion; }

        public KioskoConfiguracion KioskoConfiguracion { get => _KioskoConfiguracion; }

        public bool IsFound { get => _IsFound; }

        #endregion

        #region Otros métodos

        public string ObtenerMacAddressLocal()
        {
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

        #region Carga de datos desde la base

        public bool CargarPorID(SqlConnection connection, byte idKiosko)
        {
            Cursor.Current = Cursors.WaitCursor;

            try
            {
                SqlCommand command = new SqlCommand("usp_Kiosko_ObtenerPorID", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@IDKiosko", idKiosko);

                Cursor.Current = Cursors.Default;
                return CargarComun(command, EntityLoadByIdErrorMessage);
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
                return CargarComun(command, EntityLoadByMacAddressErrorMessage);
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                CardonerSistemas.Error.ProcessError(ex, EntityLoadByMacAddressErrorMessage);
                return false;
            }
        }

        private bool CargarComun(SqlCommand command, string errorMessage)
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
                _IdKiosko = dataReader.GetByte(dataReader.GetOrdinal(EntityFieldNameIdKiosko));
                Nombre = dataReader.GetString(dataReader.GetOrdinal(EntityFieldNameNombre));
                MacAddress = SQLServer.DataReaderGetStringSafeAsEmpty(dataReader, EntityFieldNameMacAddress);
                IdEmpresa = dataReader.GetByte(dataReader.GetOrdinal(EntityFieldNameIdEmpresa));
                IdLugar = dataReader.GetInt32(dataReader.GetOrdinal(EntityFieldNameIdLugar));
                IdKioskoConfiguracion = dataReader.GetByte(dataReader.GetOrdinal(EntityFieldNameIdKioskoConfiguracion));
                IdTicketPlantilla = dataReader.GetByte(dataReader.GetOrdinal(EntityFieldNameIdTicketPlantilla));
                Activo = dataReader.GetBoolean(dataReader.GetOrdinal(EntityFieldNameActivo));
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

        #region Entidades relacionadas

        public bool CargarRelacionadoKioskoConfiguracion(SqlConnection connection)
        {
            _KioskoConfiguracion = new KioskoConfiguracion();
            return _KioskoConfiguracion.CargarPorID(connection, IdKioskoConfiguracion);
        }

        #endregion
    }
}
