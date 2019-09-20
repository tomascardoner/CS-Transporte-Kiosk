using CardonerSistemas.Database.ADO;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CSTransporteKiosko
{
    class ViajeDetalle
    {
    
        #region Entity definition properties
            
        private const string EntityDBName = "ViajeDetalle";

        private const string EntityFieldNameIdViajeDetalle = "IDViajeDetalle";
        private const string EntityFieldNameIdViaje = "IDViaje";
        private const string EntityFieldNameFechaHora = "FechaHora";
        private const string EntityFieldNameIDRuta = "IDRuta";
        private const string EntityFieldNameIndice = "Indice";
        private const string EntityFieldNameIDPersona = "IDPersona";
        private const string EntityFieldNameAsientoIdentificacion = "AsientoIdentificacion";

        private const bool EntityDisplayNameIsFemale = false;
        private const string EntityDisplayName = "Detalle del Viaje";

        private string EntityLoadErrorMessage;
        private string EntityLoadPropertiesErrorMessage;

        public ViajeDetalle()
        {
            EntityLoadErrorMessage = CardonerSistemas.Database.Framework.Lite.GetEntityLoadErrorMessage(EntityDisplayName, EntityDisplayNameIsFemale);
            EntityLoadPropertiesErrorMessage = CardonerSistemas.Database.Framework.Lite.GetEntityLoadPropertiesErrorMessage(EntityDisplayName, EntityDisplayNameIsFemale);
        }

        #endregion

        #region Object private properties

        private int _IdViajeDetalle;
        private int _IdViaje;
        private DateTime _FechaHora;
        private string _IdRuta;
        private int _Indice;
        private int _IdPersona;
        private string _AsientoIdentificacion;

        private bool _IsFound = false;

        #endregion

        #region Object public properties

        public int IdViajeDetalle { get => _IdViajeDetalle; }
        public int IdViaje { get => _IdViaje; set => _IdViaje = value; }
        public DateTime FechaHora { get => _FechaHora; set => _FechaHora = value; }
        public string IdRuta { get => _IdRuta; set => _IdRuta = value; }
        public int Indice { get => _Indice; set => _Indice = value; }
        public int IdPersona { get => _IdPersona; set => _IdPersona = value; }
        public string AsientoIdentificacion { get => _AsientoIdentificacion; set => _AsientoIdentificacion = value; }

        public bool IsFound { get => _IsFound; }

        #endregion

        #region Load data from database

        public bool CargarPorID(SqlConnection connection, int idViajeDetalle)
        {
            Cursor.Current = Cursors.WaitCursor;

            try
            {
                SqlCommand command = new SqlCommand("usp_ViajeDetalle_ObtenerPorID", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@IDViajeDetalle", idViajeDetalle);

                Cursor.Current = Cursors.Default;
                return CargarEjecutar(command, EntityLoadErrorMessage);
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                CardonerSistemas.Error.ProcessError(ex, EntityLoadErrorMessage);
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

        public bool CargarPropiedades(SqlDataReader dataReader)
        {
            try
            {
                _IdViajeDetalle = SQLServer.DataReaderGetInteger(dataReader, EntityFieldNameIdViajeDetalle);
                _IdViaje = SQLServer.DataReaderGetInteger(dataReader, EntityFieldNameIdViaje);
                _FechaHora = SQLServer.DataReaderGetDateTime(dataReader, EntityFieldNameFechaHora);
                _IdRuta = SQLServer.DataReaderGetString(dataReader, EntityFieldNameIDRuta);
                _Indice = SQLServer.DataReaderGetInteger(dataReader, EntityFieldNameIndice);
                _IdPersona = SQLServer.DataReaderGetInteger(dataReader, EntityFieldNameIDPersona);
                _AsientoIdentificacion = SQLServer.DataReaderGetStringSafeAsNull(dataReader, EntityFieldNameAsientoIdentificacion);
                return true;
            }
            catch (Exception ex)
            {
                CardonerSistemas.Error.ProcessError(ex, EntityLoadPropertiesErrorMessage);
                return false;
            }
        }

        #endregion

        #region CheckIn

        public bool RealizarCheckIn(SqlConnection connection, byte idEmpresa, int idViajeDetalle)
        {
            Cursor.Current = Cursors.WaitCursor;

            try
            {
                SqlCommand command = new SqlCommand("usp_ViajeDetalle_RealizarCheckIn", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@IDEmpresa", idEmpresa);
                command.Parameters.AddWithValue("@IDViajeDetalle", idViajeDetalle);

                command.ExecuteNonQuery();

                command.Dispose();
                command = null;

                Cursor.Current = Cursors.Default;
                return true;
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                CardonerSistemas.Error.ProcessError(ex, "Error al hacer el check-in de la Reserva.");
                return false;
            }
        }

        #endregion

    }
}
