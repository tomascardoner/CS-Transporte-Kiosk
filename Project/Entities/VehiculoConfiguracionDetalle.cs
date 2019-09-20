using CardonerSistemas.Database.ADO;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace CSTransporteKiosko
{
    class VehiculoConfiguracionDetalle
    {

        #region Entity definition properties

        private const string EntityDBName = "VehiculoConfiguracionDetalle";

        private const string EntityFieldNameIdVehiculoConfiguracion = "IDVehiculoConfiguracion";
        private const string EntityFieldNameIdDetalle = "IDDetalle";
        private const string EntityFieldNameTipo = "Tipo";
        private const string EntityFieldNameAsientoIdentificacion = "AsientoIdentificacion";

        private const bool EntityDisplayNameIsFemale = false;
        private const string EntityDisplayName = "Detalle de Configuración del Vehículo";

        private string EntityLoadErrorMessage;
        private string EntityLoadPropertiesErrorMessage;

        public VehiculoConfiguracionDetalle()
        {
            EntityLoadErrorMessage = CardonerSistemas.Database.Framework.Lite.GetEntityLoadErrorMessage(EntityDisplayName, EntityDisplayNameIsFemale);
            EntityLoadPropertiesErrorMessage = CardonerSistemas.Database.Framework.Lite.GetEntityLoadPropertiesErrorMessage(EntityDisplayName, EntityDisplayNameIsFemale);
        }

        #endregion

        #region Constants

        public const string TipoPuerta = "P";
        public const string TipoEspacio = "E";
        public const string TipoConductor = "C";
        public const string TipoBanio = "B";
        public const string TipoAsiento = "A";
        public const string TipoAsientoOcupado = "AO";
        public const string TipoAsientoSeleccionado = "AS";

        #endregion

        #region Object private properties

        private byte _IdVehiculoConfiguracion;
        private byte _IdDetalle;
        private string _Tipo;
        private string _AsientoIdentificacion;

        private bool _IsFound = false;

        #endregion

        #region Object public properties

        public byte IdVehiculoConfiguracion { get => _IdVehiculoConfiguracion; }
        public byte IdDetalle { get => _IdDetalle; set => _IdDetalle = value; }
        public string Tipo { get => _Tipo; set => _Tipo = value; }
        public string AsientoIdentificacion { get => _AsientoIdentificacion; set => _AsientoIdentificacion = value; }

        public bool IsFound { get => _IsFound; }

        #endregion

        #region Public methods

        public Image TipoImagen(ref Kiosko kiosko)
        {
            switch (_Tipo)
            {
                case TipoPuerta:
                    return kiosko.KioskoConfiguracion.ValorVehiculoConfiguracionPuerta;
                case TipoEspacio:
                    return null;
                case TipoConductor:
                    return kiosko.KioskoConfiguracion.ValorVehiculoConfiguracionConductor;
                case TipoBanio:
                    return null;
                case TipoAsiento:
                    return kiosko.KioskoConfiguracion.ValorVehiculoConfiguracionAsientoLibre;
                default:
                    return null;
            }
        }

        #endregion

        #region Load data from database

        public bool CargarPorID(SqlConnection connection, byte idVehiculoConfiguracion, byte idDetalle)
        {
            Cursor.Current = Cursors.WaitCursor;

            try
            {
                SqlCommand command = new SqlCommand("usp_VehiculoConfiguracionDetalle_ObtenerPorID", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@IDVehiculoConfiguracion", idVehiculoConfiguracion);
                command.Parameters.AddWithValue("@IDDetalle", idDetalle);

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
                _IdVehiculoConfiguracion = SQLServer.DataReaderGetByte(dataReader, EntityFieldNameIdVehiculoConfiguracion);
                _IdDetalle = SQLServer.DataReaderGetByte(dataReader, EntityFieldNameIdDetalle);
                _Tipo = SQLServer.DataReaderGetString(dataReader, EntityFieldNameTipo);
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

    }
}
