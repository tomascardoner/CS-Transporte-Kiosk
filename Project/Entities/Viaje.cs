using CardonerSistemas.Database.ADO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CSTransporteKiosko
{
    class Viaje
    {

        #region Entity definition properties

        private const string EntityDBName = "Viaje";

        private const string EntityFieldNameIdViaje = "IDViaje";
        private const string EntityFieldNameFechaHora = "FechaHora";
        private const string EntityFieldNameIDRuta = "IDRuta";

        private const bool EntityDisplayNameIsFemale = false;
        private const string EntityDisplayName = "Viaje";

        private string EntityLoadErrorMessage;
        private string EntityLoadPropertiesErrorMessage;

        private string EntityLoadRelatedViajeDetalleErrorMessage = String.Format("Error al cargar los detalles de {0} {1} por Id.", EntityDisplayNameIsFemale ? " la " : " el ", EntityDisplayName);

        public Viaje()
        {
            EntityLoadErrorMessage = CardonerSistemas.Database.Framework.Lite.GetEntityLoadErrorMessage(EntityDisplayName, EntityDisplayNameIsFemale);
            EntityLoadPropertiesErrorMessage = CardonerSistemas.Database.Framework.Lite.GetEntityLoadPropertiesErrorMessage(EntityDisplayName, EntityDisplayNameIsFemale);
        }

        #endregion

        #region Object private properties

        private int _IdViaje;
        private DateTime _FechaHora;
        private string _IdRuta;

        private bool _IsFound = false;

        #endregion

        #region Object public properties

        public int IdViaje { get => _IdViaje; set => _IdViaje = value; }
        public DateTime FechaHora { get => _FechaHora; set => _FechaHora = value; }
        public string IdRuta { get => _IdRuta; set => _IdRuta = value; }

        public bool IsFound { get => _IsFound; }

        #endregion

        #region Load data from database

        public bool CargarPorID(SqlConnection connection, int idViaje)
        {
            Cursor.Current = Cursors.WaitCursor;

            try
            {
                SqlCommand command = new SqlCommand("usp_Viaje_ObtenerPorID", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@IDViaje", idViaje);

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

        private bool CargarPropiedades(SqlDataReader dataReader)
        {
            try
            {
                _IdViaje = SQLServer.DataReaderGetInteger(dataReader, EntityFieldNameIdViaje);
                _FechaHora = SQLServer.DataReaderGetDateTime(dataReader, EntityFieldNameFechaHora);
                _IdRuta = SQLServer.DataReaderGetString(dataReader, EntityFieldNameIDRuta);
                return true;
            }
            catch (Exception ex)
            {
                CardonerSistemas.Error.ProcessError(ex, EntityLoadPropertiesErrorMessage);
                return false;
            }
        }

        #endregion

        #region Related entities

        private List<ViajeDetalle> _ViajeDetalles = new List<ViajeDetalle>();

        public List<ViajeDetalle> ViajeDetalles { get => _ViajeDetalles; }

        public bool ViajeDetallesCargar(SqlConnection connection)
        {
            Cursor.Current = Cursors.WaitCursor;

            try
            {
                SqlCommand command = new SqlCommand("usp_Viaje_ObtenerDetalles", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@IDViaje", _IdViaje);

                SqlDataReader dataReader;
                dataReader = command.ExecuteReader(CommandBehavior.SingleResult);
                command.Dispose();
                command = null;

                _ViajeDetalles.Clear();

                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        ViajeDetalle detalle = new ViajeDetalle();

                        detalle.CargarPropiedades(dataReader);
                        _ViajeDetalles.Add(detalle);

                        detalle = null;
                    }
                }

                dataReader.Close();
                dataReader = null;
                Cursor.Current = Cursors.Default;
                return true;
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                CardonerSistemas.Error.ProcessError(ex, EntityLoadRelatedViajeDetalleErrorMessage);
                return false;
            }
        }

        #endregion

    }
}
