using CardonerSistemas.Database.ADO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CSTransporteKiosko
{
    class VehiculoConfiguracion
    {

        #region Entity definition properties

        private const string EntityDBName = "VehiculoConfiguracion";

        private const string EntityFieldNameIdVehiculoConfiguracion = "IDVehiculoConfiguracion";
        private const string EntityFieldNameNombre = "Nombre";
        private const string EntityFieldNameUnidadAncho = "UnidadAncho";
        private const string EntityFieldNameActivo = "Activo";

        private const bool EntityDisplayNameIsFemale = true;
        private const string EntityDisplayName = "Configuración del Vehículo";

        private string EntityLoadErrorMessage;
        private string EntityLoadPropertiesErrorMessage;
        private string EntityLoadRelatedVehiculoConfiguracionDetalleErrorMessage;

        public VehiculoConfiguracion()
        {
            EntityLoadErrorMessage = CardonerSistemas.Database.Framework.Lite.GetEntityLoadErrorMessage(EntityDisplayName, EntityDisplayNameIsFemale);
            EntityLoadPropertiesErrorMessage = CardonerSistemas.Database.Framework.Lite.GetEntityLoadPropertiesErrorMessage(EntityDisplayName, EntityDisplayNameIsFemale);
            EntityLoadRelatedVehiculoConfiguracionDetalleErrorMessage = CardonerSistemas.Database.Framework.Lite.GetEntityRelatedLoadErrorMessage(EntityDisplayName, EntityDisplayNameIsFemale, "Detalles", false, true);
        }

        #endregion

        #region Object private properties

        private byte _IdVehiculoConfiguracion;
        private string _Nombre;
        private byte _UnidadAncho;
        private bool _Activo;

        private bool _IsFound = false;

        #endregion

        #region Object public properties

        public byte IdVehiculoConfiguracion { get => _IdVehiculoConfiguracion; }
        public string Nombre { get => _Nombre; set => _Nombre = value; }
        public byte UnidadAncho { get => _UnidadAncho; set => _UnidadAncho = value; }
        public byte UnidadLargo
        {
            get
            {
                if (_VehiculoConfiguracionDetalles != null && _VehiculoConfiguracionDetalles.Count > 0)
                {
                    return (byte)Math.Ceiling(_VehiculoConfiguracionDetalles.Count / (double)_UnidadAncho);
                }
                else
                {
                    return 0;
                }
            }
        }
        public bool Activo { get => _Activo; set => _Activo = value; }

        public bool IsFound { get => _IsFound; }

        #endregion

        #region Load data from database

        public bool CargarPorID(SqlConnection connection, byte idVehiculoConfiguracion)
        {
            Cursor.Current = Cursors.WaitCursor;

            try
            {
                SqlCommand command = new SqlCommand("usp_VehiculoConfiguracion_ObtenerPorID", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@IDVehiculoConfiguracion", idVehiculoConfiguracion);

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
                _IdVehiculoConfiguracion = SQLServer.DataReaderGetByte(dataReader, EntityFieldNameIdVehiculoConfiguracion);
                _Nombre = SQLServer.DataReaderGetString(dataReader, EntityFieldNameNombre);
                _UnidadAncho = SQLServer.DataReaderGetByte(dataReader, EntityFieldNameUnidadAncho);
                _Activo = SQLServer.DataReaderGetBoolean(dataReader, EntityFieldNameActivo);
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

        private List<VehiculoConfiguracionDetalle> _VehiculoConfiguracionDetalles = new List<VehiculoConfiguracionDetalle>();

        public List<VehiculoConfiguracionDetalle> VehiculoConfiguracionDetalles { get => _VehiculoConfiguracionDetalles; }

        public bool VehiculoConfiguracionDetallesCargar(SqlConnection connection)
        {
            Cursor.Current = Cursors.WaitCursor;

            try
            {
                SqlCommand command = new SqlCommand("usp_VehiculoConfiguracion_ObtenerDetalles", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@IDVehiculoConfiguracion", _IdVehiculoConfiguracion);

                SqlDataReader dataReader;
                dataReader = command.ExecuteReader(CommandBehavior.SingleResult);
                command.Dispose();
                command = null;

                _VehiculoConfiguracionDetalles.Clear();

                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        VehiculoConfiguracionDetalle detalle = new VehiculoConfiguracionDetalle();

                        detalle.CargarPropiedades(dataReader);
                        _VehiculoConfiguracionDetalles.Add(detalle);

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
                CardonerSistemas.Error.ProcessError(ex, EntityLoadRelatedVehiculoConfiguracionDetalleErrorMessage);
                return false;
            }
        }

        #endregion

    }
}
