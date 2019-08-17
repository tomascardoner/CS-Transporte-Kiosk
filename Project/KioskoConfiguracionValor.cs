using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using CardonerSistemas.Database.ADO;

namespace CSTransporteKiosko
{
    public class KioskoConfiguracionValor
    {
        #region Entity definition properties

        private const string EntityDBName = "KioskoConfiguracionValor";

        private const string EntityFieldNameIdKioskoConfiguracion = "IDKioskoConfiguracion";
        private const string EntityFieldNameIdValor = "IDValor";
        private const string EntityFieldNameValorTexto = "ValorTexto";
        private const string EntityFieldNameValorNumeroEntero = "ValorNumeroEntero";
        private const string EntityFieldNameValorNumeroDecimal = "ValorNumeroDecimal";
        private const string EntityFieldNameValorFechaHora = "ValorFechaHora";
        private const string EntityFieldNameValorSiNo = "ValorSiNo";
        private const string EntityFieldNameValorIdImagen = "ValorIDImagen";
        private const string EntityFieldNameValorImagenData = "ValorImagenData";

        private const bool EntityDisplayNameIsFemale = false;
        private const string EntityDisplayName = "Valor de Configuración del Kiosko";

        private string EntityLoadErrorMessage;
        private string EntityLoadPropertiesErrorMessage;

        public KioskoConfiguracionValor()
        {
            EntityLoadErrorMessage = CardonerSistemas.Database.Framework.Lite.GetEntityLoadErrorMessage(EntityDisplayName, EntityDisplayNameIsFemale);
            EntityLoadPropertiesErrorMessage = CardonerSistemas.Database.Framework.Lite.GetEntityLoadPropertiesErrorMessage(EntityDisplayName, EntityDisplayNameIsFemale);
        }

        #endregion

        #region Object private properties

        private byte _IdKioskoConfiguracion;
        private string _IdValor;
        private string _ValorTexto;
        private int? _ValorNumeroEntero;
        private decimal? _ValorNumeroDecimal;
        private DateTime? _ValorFechaHora;
        private bool? _ValorSiNo;
        private short? _ValorIdImagen;
        private Stream _ValorImagenData;

        private bool _IsFound = false;

        #endregion

        #region Object public properties

        public byte IdKioskoConfiguracion { get => _IdKioskoConfiguracion; }
        public string IdValor { get => _IdValor; }
        public string ValorTexto { get => _ValorTexto; set => _ValorTexto = value; }
        public Font ValorFont
        {
            get
            {
                try
                {
                    TypeConverter converter = TypeDescriptor.GetConverter(typeof(Font));
                    Font font = (Font)converter.ConvertFromString(_ValorTexto);
                    return font;
                }
                catch (Exception)
                {
                    return null;
                }
            }
            set
            {
                TypeConverter converter = TypeDescriptor.GetConverter(typeof(Font));
                _ValorTexto = converter.ConvertToString(value);
            }
        }
        public int? ValorNumeroEnteroAsInteger{ get => _ValorNumeroEntero; set => _ValorNumeroEntero = value; }
        public short? ValorNumeroEnteroAsShort
        {
            get
            {
                if (_ValorNumeroEntero.HasValue && _ValorNumeroEntero >= Int16.MinValue && _ValorNumeroEntero <= Int16.MaxValue)
                {
                    return Convert.ToInt16(_ValorNumeroEntero);
                }
                else
                {
                    return null;
                }
            }
            set => _ValorNumeroEntero = (int?)value;
        }
        public byte? ValorNumeroEnteroAsByte
        {
            get
            {
                if (_ValorNumeroEntero.HasValue && _ValorNumeroEntero >= Byte.MinValue && _ValorNumeroEntero <= Byte.MaxValue)
                {
                    return Convert.ToByte(_ValorNumeroEntero);
                }
                else
                {
                    return null;
                }
            }
            set => _ValorNumeroEntero = (int?)value;
        }
        public Color? ValorColor
        {
            get
            {
                if (_ValorNumeroEntero.HasValue && _ValorNumeroEntero >= Color.Black.ToArgb() && _ValorNumeroEntero <= Color.White.ToArgb())
                {
                    return Color.FromArgb(_ValorNumeroEntero.Value);
                }
                else
                {
                    return null;
                }
            }
            set
            {
                if (value.HasValue)
                {
                    _ValorNumeroEntero = value.Value.ToArgb();
                }
                else
                {
                    _ValorNumeroEntero = null;
                }
            }
        }
        public decimal? ValorNumeroDecimal { get => _ValorNumeroDecimal; set => _ValorNumeroDecimal = value; }
        public DateTime? ValorFechaHora { get => _ValorFechaHora; set => _ValorFechaHora = value; }
        public bool? ValorSiNo { get => _ValorSiNo; set => _ValorSiNo = value; }
        public short? ValorIdImagen { get => _ValorIdImagen; set => _ValorIdImagen = value; }
        public Stream ValorImagenData { get => _ValorImagenData; }
        public Image ValorImagenDataAsBitmap
        {
            get
            {
                try
                {
                    return Bitmap.FromStream(_ValorImagenData);
                }
                catch (Exception)
                {
                    return null;
                }
            }
        }

        public bool IsFound { get => _IsFound; }

        #endregion

        #region Related entities

        private Imagen _Imagen;

        public bool ImagenCargar(SqlConnection connection)
        {
            if (_ValorIdImagen.HasValue)
            {
                _Imagen = new Imagen();
                return _Imagen.CargarPorID(connection, _ValorIdImagen.Value);
            }
            else
            {
                return false;
            }
        }

        public Imagen Imagen { get => _Imagen; }

        #endregion

        #region Load data from database

        public bool CargarPorID(SqlConnection connection, byte idKioskoConfiguracion, string idValor)
        {
            Cursor.Current = Cursors.WaitCursor;

            try
            {
                SqlCommand command = new SqlCommand("usp_KioskoConfiguracionValor_ObtenerPorID", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@IDKioskoConfiguracion", idKioskoConfiguracion);
                command.Parameters.AddWithValue("@IDValor", idValor);

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
                _IdKioskoConfiguracion = SQLServer.DataReaderGetByte(dataReader, EntityFieldNameIdKioskoConfiguracion);
                _IdValor = SQLServer.DataReaderGetString(dataReader, EntityFieldNameIdValor).TrimEnd();
                _ValorTexto = SQLServer.DataReaderGetStringSafeAsNull(dataReader, EntityFieldNameValorTexto);
                _ValorNumeroEntero = SQLServer.DataReaderGetIntegerSafeAsNull(dataReader, EntityFieldNameValorNumeroEntero);
                _ValorNumeroDecimal = SQLServer.DataReaderGetDecimalSafeAsNull(dataReader, EntityFieldNameValorNumeroDecimal);
                _ValorFechaHora = SQLServer.DataReaderGetDateTimeSafeAsNull(dataReader, EntityFieldNameValorFechaHora);
                _ValorSiNo = SQLServer.DataReaderGetBooleanSafeAsNull(dataReader, EntityFieldNameValorSiNo);
                _ValorIdImagen = SQLServer.DataReaderGetShortSafeAsNull(dataReader, EntityFieldNameValorIdImagen);
                _ValorImagenData = SQLServer.DataReaderGetStream(dataReader, EntityFieldNameValorImagenData);
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