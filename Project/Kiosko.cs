using System;
using System.Data;
using System.Data.SqlClient;
using System.Net.NetworkInformation;
using System.Windows.Forms;

namespace CSTransporteKiosko
{
    class Kiosko
    {
        private string[] excludedInterfaceNames = { "Hyper-V Virtual", "VMware Virtual", "Microsoft Wi-Fi"};

        private byte _IdKiosko;
        private DateTime _UltimaConexion;
        private DateTime _UltimaOperacion;

        private bool _IsFound = false;

        public byte IdKiosko { get => _IdKiosko; }
        public string Nombre { get; set; }
        public string MacAddress { get; set; }
        public byte IdEmpresa { get; set; }
        public int IdLugar { get; set; }
        public byte IdKioskoConfiguracion { get; set; }
        public byte IdTicketPlantilla { get; set; }
        public bool Activo { get; set; }
        public DateTime UltimaConexion { get => _UltimaConexion; }
        public DateTime UltimaOperacion { get => _UltimaOperacion; }

        public bool IsFound { get => _IsFound; }

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

        public bool CargarPorID(SqlConnection connection, byte idKiosko)
        {
            Cursor.Current = Cursors.WaitCursor;

            try
            {
                SqlCommand command = new SqlCommand("usp_Kiosko_ObtenerPorID", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@IDKiosko", idKiosko);

                Cursor.Current = Cursors.Default;
                return CargarComun(command, "Error al cargar el Kiosko por Id.");
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                CardonerSistemas.Error.ProcessError(ex, "Error al cargar el Kiosko por Id.");
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
                return CargarComun(command, "Error al cargar el Kiosko por MAC Address.");
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                CardonerSistemas.Error.ProcessError(ex, "Error al cargar el Kiosko por MAC Address.");
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
                _IdKiosko = dataReader.GetByte(dataReader.GetOrdinal("IDKiosko"));
                Nombre = dataReader.GetString(dataReader.GetOrdinal("Nombre"));
                MacAddress = dataReader.GetString(dataReader.GetOrdinal("MACAddress"));
                IdEmpresa = dataReader.GetByte(dataReader.GetOrdinal("IDEmpresa"));
                IdLugar = dataReader.GetInt32(dataReader.GetOrdinal("IDLugar"));
                IdKioskoConfiguracion = dataReader.GetByte(dataReader.GetOrdinal("IDKioskoConfiguracion"));
                IdTicketPlantilla = dataReader.GetByte(dataReader.GetOrdinal("IDTicketPlantilla"));
                Activo = dataReader.GetBoolean(dataReader.GetOrdinal("Activo"));
                _UltimaConexion = dataReader.GetDateTime(dataReader.GetOrdinal("UltimaConexion"));
                _UltimaOperacion = dataReader.GetDateTime(dataReader.GetOrdinal("UltimaOperacion"));
                return true;
            }
            catch (Exception ex)
            {
                CardonerSistemas.Error.ProcessError(ex, "Error al cargar las propiedades del Kiosko.");
                return false;
            }
        }
    }
}
