using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using CardonerSistemas.Database.ADO;

namespace CSTransporteKiosko
{
    public class BusquedaReservas
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
            public int IDViaje { get; set; } = 0;
            public int IDViajeDetalle { get; set; } = 0;
            public string LugarOrigen { get; set; } = string.Empty;
            public string LugarGrupoOrigen { get; set; } = string.Empty;
            public DateTime FechaHoraOrigen { get; set; } = DateTime.MinValue;
            public string LugarDestino { get; set; } = string.Empty;
            public string LugarGrupoDestino { get; set; } = string.Empty;
            public DateTime FechaHoraDestino { get; set; } = DateTime.MinValue;
            public string Vehiculo { get; set; } = string.Empty;
            public bool Realizado { get; set; } = false;
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

        public bool BuscarViajesPorDocumento(SQLServer database, byte idEmpresa, int idLugar, string Documento, List<BusquedaReservas.Persona> personaList, KioskoConfiguracion configuracion)
        {
            int IDViaje = 0;
            int IDViajeDetalle = 0;
            string ReservaCodigo = null;
            byte GrupoNumero = 0;

            if (ConectarABaseDeDatos(database))
            {
                if (BuscarReservasPorDocumento(database, idEmpresa, idLugar, Documento, ref IDViaje, ref IDViajeDetalle, ref ReservaCodigo, ref GrupoNumero, configuracion))
                {
                    return BuscarPersonasPorReserva(database, idEmpresa, IDViaje, IDViajeDetalle, ReservaCodigo, GrupoNumero, personaList, configuracion);
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

        private bool BuscarReservasPorDocumento(SQLServer database, byte idEmpresa, int idLugar, string documento, ref int idViaje, ref int idViajeDetalle, ref string reservaCodigo, ref byte grupoNumero, KioskoConfiguracion configuracion)
        {
            SqlCommand command = new SqlCommand();
            SqlDataReader dataReader;

            try
            {
                command.Connection = database.Connection;
                command.CommandText = "usp_ReservasPorDocumento";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@IDEmpresa", idEmpresa);
                command.Parameters.AddWithValue("@IDLugar", idLugar);
                command.Parameters.AddWithValue("@LugarDuracionPreviaMaxima", configuracion.ValorLugarDuracionPreviaMaximaMinutos);
                command.Parameters.AddWithValue("@LugarDuracionPreviaMinima", configuracion.ValorLugarDuracionPreviaMinimaMinutos);
                command.Parameters.AddWithValue("@DocumentoNumero", documento);

                dataReader = command.ExecuteReader(CommandBehavior.SingleRow);
                command.Dispose();
                command = null;

                if (dataReader.HasRows)
                {
                    dataReader.Read();
                    idViaje = SQLServer.DataReaderGetInteger(dataReader, "IDViaje");
                    idViajeDetalle = SQLServer.DataReaderGetInteger(dataReader, "IDViajeDetalle");
                    reservaCodigo = SQLServer.DataReaderGetString(dataReader, "ReservaCodigo");
                    grupoNumero = SQLServer.DataReaderGetByte(dataReader, "GrupoNumero");

                    dataReader.Close();
                    dataReader = null;

                    return true;
                }
                else
                {
                    MessageBox.Show("No se han encontrado reservas.", configuracion);

                    dataReader.Close();
                    dataReader = null;

                    return false;
                }

            }
            catch (Exception)
            {
                MessageBox.Show("No se pudo obtener la información.", configuracion);

                command.Dispose();
                command = null;

                dataReader = null;

                return false;
            }
        }

        private bool BuscarPersonasPorReserva(SQLServer database, byte idEmpresa, int IDViaje, int IDViajeDetalle, string ReservaCodigo, byte GrupoNumero, List<BusquedaReservas.Persona> personaList, KioskoConfiguracion configuracion)
        {
            SqlCommand command = new SqlCommand();
            SqlDataReader dataReader;

            try
            {
                command.Connection = database.Connection;
                command.CommandText = "usp_PersonasPorReserva";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@IDEmpresa", idEmpresa);
                command.Parameters.AddWithValue("@IDViaje", IDViaje);
                command.Parameters.AddWithValue("@IDViajeDetalle", IDViajeDetalle);
                command.Parameters.AddWithValue("@ReservaCodigo", ReservaCodigo);
                command.Parameters.AddWithValue("@GrupoNumero", GrupoNumero);

                dataReader = command.ExecuteReader(CommandBehavior.SingleResult);
                command.Dispose();
                command = null;

                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        Persona nuevaPersona = new Persona();

                        nuevaPersona.IDPersona = SQLServer.DataReaderGetInteger(dataReader, "IDPersona");
                        nuevaPersona.Apellido = SQLServer.DataReaderGetString(dataReader, "Apellido");
                        nuevaPersona.Nombre = SQLServer.DataReaderGetStringSafeAsEmpty(dataReader, "Nombre");
                        nuevaPersona.DocumentoTipo = SQLServer.DataReaderGetStringSafeAsEmpty(dataReader, "DocumentoTipo");
                        nuevaPersona.DocumentoNumero = SQLServer.DataReaderGetStringSafeAsNull(dataReader, "DocumentoNumero");
                        nuevaPersona.IDViaje = IDViaje;
                        nuevaPersona.IDViajeDetalle = IDViajeDetalle;
                        nuevaPersona.LugarOrigen = SQLServer.DataReaderGetString(dataReader, "LugarOrigen");
                        nuevaPersona.LugarGrupoOrigen = SQLServer.DataReaderGetString(dataReader, "LugarGrupoOrigen");
                        nuevaPersona.FechaHoraOrigen = SQLServer.DataReaderGetDateTime(dataReader, "FechaHoraOrigen");
                        nuevaPersona.LugarDestino = SQLServer.DataReaderGetString(dataReader, "LugarDestino");
                        nuevaPersona.LugarGrupoDestino = SQLServer.DataReaderGetString(dataReader, "LugarGrupoDestino");
                        nuevaPersona.FechaHoraDestino = SQLServer.DataReaderGetDateTime(dataReader, "FechaHoraDestino");
                        nuevaPersona.Vehiculo = SQLServer.DataReaderGetString(dataReader, "Vehiculo");

                        personaList.Add(nuevaPersona);
                        nuevaPersona = null;
                    }
                    dataReader.Close();
                    dataReader = null;

                    return true;
                }
                else
                {
                    MessageBox.Show("No se han encontrado reservas.", configuracion);
                    dataReader.Close();
                    dataReader = null;
                    return false;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("No se pudo obtener la información.", configuracion);
                command = null;
                dataReader = null;
                return false;
            }
        }
    }
}