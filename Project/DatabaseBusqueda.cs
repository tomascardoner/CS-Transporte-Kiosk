using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace CSTransporteKiosk
{
    static class DatabaseBusqueda
    {
        public class Persona
        {
            public int IDPersona { get; set; } = 0;
            public string Apellido { get; set; } = string.Empty;
            public string Nombre { get; set; } = string.Empty;
            public string DocumentoTipo { get; set; } = string.Empty;
            public string DocumentoNumero { get; set; } = string.Empty;
        }

        static public CardonerSistemas.Database_ADO_SQLServer Database;

        static public void PrepararConexionABaseDeDatos()
        {
            Database = new CardonerSistemas.Database_ADO_SQLServer();
            Database.applicationName = CardonerSistemas.My.Application.Info.Title;
            Database.datasource = ThisMachine.Default.DatabaseDatasource;
            Database.initialCatalog = ThisMachine.Default.DatabaseDatabase;
            Database.userID = ThisMachine.Default.DatabaseUserID;
            if (ThisMachine.Default.DatabasePassword.Trim().Length == 0)
            {
                Database.password = "";
            }
            else
            {
                CardonerSistemas.Encrypt_TripleDES decrypter = new CardonerSistemas.Encrypt_TripleDES(CardonerSistemas.Constants.PublicEncryptionPassword);
                string decryptedPassword = "";
                if (decrypter.Decrypt(ThisMachine.Default.DatabasePassword, ref decryptedPassword))
                {
                    Database.password = decryptedPassword;
                }
                decrypter = null;
            }
            Database.workstationID = "";
            Database.CreateConnectionString();
        }

        static private bool ConnectToDatabase()
        {
            if (Database.connection == null || Database.connection.State != System.Data.ConnectionState.Open)
            {
                return Database.Connect();
            }
            else
            {
                return true;
            }
        }

        static public bool BuscarViajesPorDocumento(string Documento, ref DateTime fechaHora, ref string Ruta, List<DatabaseBusqueda.Persona> personaList)
        {
            int IDViaje = 0;
            int IDViajeDetalle = 0;
            string ReservaCodigo = null;
            byte GrupoNumero = 0;

            if (ConnectToDatabase())
            {
                if (BuscarReservasPorDocumento(Documento, ref fechaHora, ref Ruta, ref IDViaje, ref IDViajeDetalle, ref ReservaCodigo, ref GrupoNumero))
                {
                    if (BuscarPersonasPorReserva(IDViaje, IDViajeDetalle, ReservaCodigo, GrupoNumero, personaList))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        static private bool BuscarReservasPorDocumento(string documento, ref DateTime fechaHora, ref string Ruta, ref int idViaje, ref int idViajeDetalle, ref string reservaCodigo, ref byte grupoNumero)
        {
            SqlCommand sqlCommand = new SqlCommand();
            SqlDataReader sqlDataReader;

            try
            {
                sqlCommand.Connection = Database.connection;
                sqlCommand.CommandText = "usp_ReservasPorDocumento";
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@IDLugar", ThisMachine.Default.LugarID);
                sqlCommand.Parameters.AddWithValue("@LugarDuracionPreviaMaxima", Properties.Settings.Default.LugarDuracionPreviaMaxima);
                sqlCommand.Parameters.AddWithValue("@LugarDuracionPreviaMinima", Properties.Settings.Default.LugarDuracionPreviaMinima);
                sqlCommand.Parameters.AddWithValue("@DocumentoNumero", documento);

                sqlDataReader = sqlCommand.ExecuteReader(CommandBehavior.SingleRow);
                sqlCommand.Dispose();
                sqlCommand = null;

                if (sqlDataReader.HasRows)
                {
                    sqlDataReader.Read();
                    fechaHora = sqlDataReader.GetDateTime(sqlDataReader.GetOrdinal("FechaHora"));
                    Ruta = sqlDataReader.GetString(sqlDataReader.GetOrdinal("Ruta"));
                    idViaje = sqlDataReader.GetInt32(sqlDataReader.GetOrdinal("IDViaje"));
                    idViajeDetalle = sqlDataReader.GetInt32(sqlDataReader.GetOrdinal("IDViajeDetalle"));
                    reservaCodigo = sqlDataReader.GetString(sqlDataReader.GetOrdinal("ReservaCodigo"));
                    grupoNumero = sqlDataReader.GetByte(sqlDataReader.GetOrdinal("GrupoNumero"));

                    sqlDataReader.Close();
                    sqlDataReader = null;

                    return true;
                }
                else
                {
                    MessageBox.Show("No se han encontrado reservas.");

                    sqlDataReader.Close();
                    sqlDataReader = null;

                    return false;
                }

            }
            catch (Exception)
            {
                MessageBox.Show("No se pudo obtener la información.");

                sqlCommand = null;

                sqlDataReader = null;

                return false;
            }
        }

        static private bool BuscarPersonasPorReserva(int IDViaje, int IDViajeDetalle, string ReservaCodigo, byte GrupoNumero, List<DatabaseBusqueda.Persona> personaList)
        {
            SqlCommand sqlCommand = new SqlCommand();
            SqlDataReader sqlDataReader;

            try
            {
                sqlCommand.Connection = Database.connection;
                sqlCommand.CommandText = "usp_PersonasPorReserva";
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@IDViaje", IDViaje);
                sqlCommand.Parameters.AddWithValue("@IDViajeDetalle", IDViajeDetalle);
                sqlCommand.Parameters.AddWithValue("@ReservaCodigo", ReservaCodigo);
                sqlCommand.Parameters.AddWithValue("@GrupoNumero", GrupoNumero);

                sqlDataReader = sqlCommand.ExecuteReader(CommandBehavior.SingleResult);
                sqlCommand.Dispose();
                sqlCommand = null;

                if (sqlDataReader.HasRows)
                {
                    while (sqlDataReader.Read())
                    {
                        Persona nuevaPersona = new Persona();

                        nuevaPersona.IDPersona = sqlDataReader.GetInt32(sqlDataReader.GetOrdinal("IDPersona"));
                        nuevaPersona.Apellido = sqlDataReader.GetString(sqlDataReader.GetOrdinal("Apellido"));
                        if (!sqlDataReader.IsDBNull(sqlDataReader.GetOrdinal("Nombre")))
                        {
                            nuevaPersona.Nombre = sqlDataReader.GetString(sqlDataReader.GetOrdinal("Nombre"));
                        }
                        if (!sqlDataReader.IsDBNull(sqlDataReader.GetOrdinal("DocumentoTipo")))
                        {
                            nuevaPersona.DocumentoTipo = sqlDataReader.GetString(sqlDataReader.GetOrdinal("DocumentoTipo"));
                        }
                        if (!sqlDataReader.IsDBNull(sqlDataReader.GetOrdinal("DocumentoNumero")))
                        {
                            nuevaPersona.DocumentoNumero = sqlDataReader.GetString(sqlDataReader.GetOrdinal("DocumentoNumero"));
                        }
                        personaList.Add(nuevaPersona);
                        nuevaPersona = null;
                    }
                    sqlDataReader.Close();
                    sqlDataReader = null;

                    return true;
                }
                else
                {
                    MessageBox.Show("No se han encontrado reservas.");

                    sqlDataReader.Close();
                    sqlDataReader = null;

                    return false;
                }

            }
            catch (Exception)
            {
                MessageBox.Show("No se pudo obtener la información.");

                sqlCommand = null;

                sqlDataReader = null;

                return false;
            }
        }
    }
}
