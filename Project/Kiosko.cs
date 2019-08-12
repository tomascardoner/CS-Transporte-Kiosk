using System;
using System.Data;
using System.Data.SqlClient;
using System.Net.NetworkInformation;
using CardonerSistemas.Database.ADO;

namespace CSTransporteKiosk
{
    class Kiosko
    {
        private string[] excludedInterfaceNames = { "Hyper-V Virtual", "VMware Virtual", "Microsoft Wi-Fi"};

        public byte IdKiosko { get; set; }
        public string Nombre { get; set; }
        public string MacAddress { get; set; }
        public byte IdEmpresa { get; set; }
        public int IdLugar { get; set; }
        public byte IdKioskoConfiguracion { get; set; }
        public byte IdTicketPlantilla { get; set; }
        public bool Activo { get; set; }
        public DateTime UltimaConexion { get; set; }
        public DateTime UltimaOperacion { get; set; }

        public string ObtenerMacAddressLocal()
        {
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
                            return ni.GetPhysicalAddress().ToString();
                        }
                    }
                }
            }
            return String.Empty;
        }

        public bool CargarPorID(SQLServer database, byte idKiosko)
        {
            try
            {
                SqlCommand command = new SqlCommand("usp_Kiosko_ObtenerPorID", database.connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@IDKiosko", idKiosko);

                SqlDataReader dataReader;
                dataReader = command.ExecuteReader(CommandBehavior.SingleRow);
                command.Dispose();
                command = null;

                return CargarPropiedades(dataReader);
            }
            catch (Exception ex)
            {
                CardonerSistemas.Error.ProcessError(ex, "Error al cargar el Kiosko por Id.");
                return false;
            }
        }

        public bool CargarPorMacAddress(SQLServer database, string macAddress)
        {
            try
            {
                SqlCommand command = new SqlCommand("usp_Kiosko_ObtenerPorMAC", database.connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@MACAddress", macAddress);

                SqlDataReader dataReader;
                dataReader = command.ExecuteReader(CommandBehavior.SingleRow);
                command.Dispose();
                command = null;

                return CargarPropiedades(dataReader);
            }
            catch (Exception ex)
            {
                CardonerSistemas.Error.ProcessError(ex, "Error al cargar el Kiosko por MAC Address.");
                return false;
            }
        }

        private bool CargarPropiedades(SqlDataReader dataReader)
        {
            try
            {
                if (dataReader.HasRows)
                {
                    dataReader.Read();

                    IdKiosko = dataReader.GetByte(dataReader.GetOrdinal("IDKiosko"));
                    Nombre = dataReader.GetString(dataReader.GetOrdinal("Nombre"));
                    MacAddress = dataReader.GetString(dataReader.GetOrdinal("MACAddress"));
                    IdEmpresa = dataReader.GetByte(dataReader.GetOrdinal("IDEmpresa"));
                    IdLugar = dataReader.GetInt32(dataReader.GetOrdinal("IDLugar"));
                    IdKioskoConfiguracion = dataReader.GetByte(dataReader.GetOrdinal("IDKioskoConfiguracion"));
                    IdTicketPlantilla = dataReader.GetByte(dataReader.GetOrdinal("IDTicketPlantilla"));
                    Activo = dataReader.GetBoolean(dataReader.GetOrdinal("Activo"));
                    UltimaConexion = dataReader.GetDateTime(dataReader.GetOrdinal("UltimaConexion"));
                    UltimaOperacion = dataReader.GetDateTime(dataReader.GetOrdinal("UltimaOperacion"));

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
            catch (Exception ex)
            {
                CardonerSistemas.Error.ProcessError(ex, "Error al cargar el Kiosko por Id.");
                return false;
            }
        }
    }
}
