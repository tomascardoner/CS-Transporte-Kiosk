using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using CardonerSistemas.Database.ADO;

namespace CSTransporteKiosko
{
    class BusquedaReservas
    {
        public class Persona
        {
            public int IDPersona { get; set; } = 0;
            public string Apellido { get; set; } = string.Empty;
            public string Nombre { get; set; } = string.Empty;
            public string ApellidoNombre
            {
                get
                {
                    if (Nombre == null)
                    {
                        return Apellido;
                    }
                    else
                    {
                        return Apellido + ", " + Nombre;
                    }
                }
            }
            public string DocumentoTipo { get; set; } = string.Empty;
            public string DocumentoNumero { get; set; } = string.Empty;
            public string LugarOrigen { get; set; } = string.Empty;
            public string LugarGrupoOrigen { get; set; } = string.Empty;
            public DateTime FechaHoraOrigen { get; set; } = DateTime.MinValue;
            public string LugarDestino { get; set; } = string.Empty;
            public string LugarGrupoDestino { get; set; } = string.Empty;
            public DateTime FechaHoraDestino { get; set; } = DateTime.MinValue;
            public string Vehiculo { get; set; } = string.Empty;
        }

        private bool ConectarABaseDeDatos(SQLServer database)
        {
            if (!database.IsConnected())
            {
                return database.Connect();
            }
            else
            {
                return true;
            }
        }

        public bool CerrarConexionABaseDeDatos(SQLServer database)
        {
            if (!database.IsConnected())
            {
                return database.Close();
            }
            else
            {
                return true;
            }
        }

        public bool BuscarViajesPorDocumento(SQLServer database, string Documento, List<BusquedaReservas.Persona> personaList)
        {
            int IDViaje = 0;
            int IDViajeDetalle = 0;
            string ReservaCodigo = null;
            byte GrupoNumero = 0;

            if (ConectarABaseDeDatos(database))
            {
                if (BuscarReservasPorDocumento(database, Documento, ref IDViaje, ref IDViajeDetalle, ref ReservaCodigo, ref GrupoNumero))
                {
                    return BuscarPersonasPorReserva(database, IDViaje, IDViajeDetalle, ReservaCodigo, GrupoNumero, personaList);
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

        private bool BuscarReservasPorDocumento(SQLServer database, string documento, ref int idViaje, ref int idViajeDetalle, ref string reservaCodigo, ref byte grupoNumero)
        {
            SqlCommand sqlCommand = new SqlCommand();
            SqlDataReader sqlDataReader;

            try
            {
                sqlCommand.Connection = database.connection;
                sqlCommand.CommandText = "usp_ReservasPorDocumento";
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@IDLugar", 2);
                sqlCommand.Parameters.AddWithValue("@LugarDuracionPreviaMaxima", Properties.Settings.Default.LugarDuracionPreviaMaximaMinutos);
                sqlCommand.Parameters.AddWithValue("@LugarDuracionPreviaMinima", Properties.Settings.Default.LugarDuracionPreviaMinimaMinutos);
                sqlCommand.Parameters.AddWithValue("@DocumentoNumero", documento);

                sqlDataReader = sqlCommand.ExecuteReader(CommandBehavior.SingleRow);
                sqlCommand.Dispose();
                sqlCommand = null;

                if (sqlDataReader.HasRows)
                {
                    sqlDataReader.Read();
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

        private bool BuscarPersonasPorReserva(SQLServer database, int IDViaje, int IDViajeDetalle, string ReservaCodigo, byte GrupoNumero, List<BusquedaReservas.Persona> personaList)
        {
            SqlCommand sqlCommand = new SqlCommand();
            SqlDataReader sqlDataReader;

            try
            {
                sqlCommand.Connection = database.connection;
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
                        nuevaPersona.LugarOrigen = sqlDataReader.GetString(sqlDataReader.GetOrdinal("LugarOrigen"));
                        nuevaPersona.LugarGrupoOrigen = sqlDataReader.GetString(sqlDataReader.GetOrdinal("LugarGrupoOrigen"));
                        nuevaPersona.FechaHoraOrigen = sqlDataReader.GetDateTime(sqlDataReader.GetOrdinal("FechaHoraOrigen"));
                        nuevaPersona.LugarDestino = sqlDataReader.GetString(sqlDataReader.GetOrdinal("LugarDestino"));
                        nuevaPersona.LugarGrupoDestino = sqlDataReader.GetString(sqlDataReader.GetOrdinal("LugarGrupoDestino"));
                        nuevaPersona.FechaHoraDestino = sqlDataReader.GetDateTime(sqlDataReader.GetOrdinal("FechaHoraDestino"));
                        nuevaPersona.Vehiculo = sqlDataReader.GetString(sqlDataReader.GetOrdinal("Vehiculo"));

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