using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using CardonerSistemas.Database.ADO;

namespace CSTransporteKiosko
{
    class KioskoConfiguracion
    {
        #region Entity definition properties

        private const string EntityDBName = "KioskoConfiguracion";

        private const string EntityFieldNameIdKioskoConfiguracion = "IDKioskoConfiguracion";
        private const string EntityFieldNameNombre = "Nombre";

        private const bool EntityDisplayNameIsFemale = true;
        private const string EntityDisplayName = "Configuración del Kiosko";

        private string EntityLoadErrorMessage = String.Format("Error al cargar {0} {1} por Id.", EntityDisplayNameIsFemale ? " la " : " el ", EntityDisplayName);
        private string EntityLoadPropertiesErrorMessage = String.Format("Error al cargar las propiedades de {0} {1} por Id.", EntityDisplayNameIsFemale ? " la " : " el ", EntityDisplayName);
        private string EntityLoadRelatedKioskoConfiguracionValorErrorMessage = String.Format("Error al cargar los valores de {0} {1} por Id.", EntityDisplayNameIsFemale ? " la " : " el ", EntityDisplayName);

        private string IdValorCompaniaSoftwareLogotipoIDImagen = "CompaniaSoftwareLogotipoIDImagen";
        private string IdValorEmpresaLogotipoIDImagen = "EmpresaLogotipoIDImagen";
        private string IdValorFontStyle = "FontStyle";
        private string IdValorInactivityTimeoutSeconds = "InactivityTimeoutSeconds";
        private string IdValorKeyboardNumericNumberFont = "KeyboardNumericNumberFont";
        private string IdValorKeyboardNumericSpecialFont = "KeyboardNumericSpecialFont";
        private string IdValorLugarDuracionPreviaMaximaMinutos = "LugarDuracionPreviaMaximaMinutos";
        private string IdValorLugarDuracionPreviaMinimaMinutos = "LugarDuracionPreviaMinimaMinutos";
        private string IdValorMessageBoxBackColor = "MessageBoxBackColor";
        private string IdValorMessageBoxButtonBackColor = "MessageBoxButtonBackColor";
        private string IdValorMessageBoxButtonForeColor = "MessageBoxButtonForeColor";
        private string IdValorMessageBoxForeColor = "MessageBoxForeColor";
        private string IdValorPOSPrinterClaimTimeoutMilliseconds = "POSPrinterClaimTimeoutMilliseconds";
        private string IdValorPOSPrinterReleaseTimeoutSeconds = "POSPrinterReleaseTimeoutSeconds";
        private string IdValorVideo = "Video";

        #endregion

        #region Object private properties

        private byte _IdKioskoConfiguracion;

        private bool _IsFound = false;

        #endregion

        #region Object public properties

        public byte IdKioskoConfiguracion { get => _IdKioskoConfiguracion; }
        public string Nombre { get; set; }

        public bool IsFound { get => _IsFound; }

        #endregion

        #region Related entities

        private List<KioskoConfiguracionValor> _KioskoConfiguracionValores = new List<KioskoConfiguracionValor>();

        public List<KioskoConfiguracionValor> KioskoConfiguracionValores { get => _KioskoConfiguracionValores; }

        public short? ValorCompaniaSoftwareLogotipoIDImagen { get => GetValorNumeroEnteroAsShort(IdValorCompaniaSoftwareLogotipoIDImagen); }
        public Image ValorCompaniaSoftwareLogotipo(SqlConnection connection)
        {
            return GetValorImagenDataAsBitmap(connection, IdValorCompaniaSoftwareLogotipoIDImagen);
        }
        public short? ValorEmpresaLogotipoIDImagen { get => GetValorNumeroEnteroAsShort(IdValorEmpresaLogotipoIDImagen); }
        public Image ValorEmpresaLogotipo(SqlConnection connection)
        {
            return GetValorImagenDataAsBitmap(connection, IdValorEmpresaLogotipoIDImagen);
        }
        public string ValorFontStyle { get => GetValorString(IdValorFontStyle); }
        public int? ValorInactivityTimeoutSeconds { get => GetValorNumeroEnteroAsInteger(IdValorInactivityTimeoutSeconds); }
        public string ValorKeyboardNumericNumberFont { get => GetValorString(IdValorKeyboardNumericNumberFont); }
        public string ValorKeyboardNumericSpecialFont { get => GetValorString(IdValorKeyboardNumericSpecialFont); }
        public int? ValorLugarDuracionPreviaMaximaMinutos { get => GetValorNumeroEnteroAsInteger(IdValorLugarDuracionPreviaMaximaMinutos); }
        public int? ValorLugarDuracionPreviaMinimaMinutos { get => GetValorNumeroEnteroAsInteger(IdValorLugarDuracionPreviaMinimaMinutos); }
        public int? ValorMessageBoxBackColor { get => GetValorNumeroEnteroAsInteger(IdValorMessageBoxBackColor); }
        public int? ValorMessageBoxButtonBackColor { get => GetValorNumeroEnteroAsInteger(IdValorMessageBoxButtonBackColor); }
        public int? ValorMessageBoxButtonForeColor { get => GetValorNumeroEnteroAsInteger(IdValorMessageBoxButtonForeColor); }
        public int? ValorMessageBoxForeColor { get => GetValorNumeroEnteroAsInteger(IdValorMessageBoxForeColor); }
        public int? ValorPOSPrinterClaimTimeoutMilliseconds { get => GetValorNumeroEnteroAsInteger(IdValorPOSPrinterClaimTimeoutMilliseconds); }
        public int? ValorPOSPrinterReleaseTimeoutSeconds { get => GetValorNumeroEnteroAsInteger(IdValorPOSPrinterReleaseTimeoutSeconds); }
        public string ValorVideo { get => GetValorString(IdValorVideo); }

        #endregion

        #region Carga de datos desde la base

        public bool CargarPorID(SqlConnection connection, byte idKioskoConfiguracion)
        {
            Cursor.Current = Cursors.WaitCursor;

            try
            {
                SqlCommand command = new SqlCommand("usp_KioskoConfiguracion_ObtenerPorID", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@IDKioskoConfiguracion", idKioskoConfiguracion);

                Cursor.Current = Cursors.Default;
                return CargarComun(command, EntityLoadErrorMessage);
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                CardonerSistemas.Error.ProcessError(ex, EntityLoadErrorMessage);
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
                _IdKioskoConfiguracion = dataReader.GetByte(dataReader.GetOrdinal(EntityFieldNameIdKioskoConfiguracion));
                Nombre = dataReader.GetString(dataReader.GetOrdinal(EntityFieldNameNombre));
                return true;
            }
            catch (Exception ex)
            {
                CardonerSistemas.Error.ProcessError(ex, EntityLoadPropertiesErrorMessage);
                return false;
            }
        }

        #endregion

        #region Cargar entidades relacionadas

        public bool CargarRelacionadoKioscoConfiguracionValores(SqlConnection connection)
        {
            Cursor.Current = Cursors.WaitCursor;

            try
            {
                SqlCommand command = new SqlCommand("usp_KioskoConfiguracion_ObtenerValores", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@IDKioskoConfiguracion", IdKioskoConfiguracion);

                SqlDataReader dataReader;
                dataReader = command.ExecuteReader(CommandBehavior.SingleResult);
                command.Dispose();
                command = null;

                _KioskoConfiguracionValores.Clear();

                if (dataReader.HasRows)
                {
                    while(dataReader.Read())
                    {
                        KioskoConfiguracionValor valor = new KioskoConfiguracionValor();

                        object[] values = new object[dataReader.FieldCount];
                        int fieldCount = dataReader.GetValues(values);
                        valor.CargarDesdeArray(values);
                        _KioskoConfiguracionValores.Add(valor);

                        valor = null;
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
                CardonerSistemas.Error.ProcessError(ex, EntityLoadRelatedKioskoConfiguracionValorErrorMessage);
                return false;
            }
        }

        private string GetValorString(string idValor)
        {
            KioskoConfiguracionValor valor = _KioskoConfiguracionValores.Find(kcv => kcv.IdValor == idValor);
            if (valor == null)
            {
                return null;
            }
            else
            {
                return valor.ValorTexto;
            }
        }

        private int? GetValorNumeroEnteroAsInteger(string idValor)
        {
            KioskoConfiguracionValor valor = _KioskoConfiguracionValores.Find(kcv => kcv.IdValor == idValor);
            if (valor == null)
            {
                return null;
            }
            else
            {
                return valor.ValorNumeroEntero;
            }
        }

        private short? GetValorNumeroEnteroAsShort(string idValor)
        {
            KioskoConfiguracionValor valor = _KioskoConfiguracionValores.Find(kcv => kcv.IdValor == idValor);
            if (valor == null || !valor.ValorNumeroEntero.HasValue)
            {
                return null;
            }
            else
            {
                return (short)valor.ValorNumeroEntero;
            }
        }

        private byte? GetValorNumeroEnteroAsByte(string idValor)
        {
            KioskoConfiguracionValor valor = _KioskoConfiguracionValores.Find(kcv => kcv.IdValor == idValor);
            if (valor == null || !valor.ValorNumeroEntero.HasValue)
            {
                return null;
            }
            else
            {
                return (byte)valor.ValorNumeroEntero;
            }
        }

        private decimal? GetValorNumeroDecimal(string idValor)
        {
            KioskoConfiguracionValor valor = _KioskoConfiguracionValores.Find(kcv => kcv.IdValor == idValor);
            if (valor == null)
            {
                return null;
            }
            else
            {
                return valor.ValorNumeroDecimal;
            }
        }

        private DateTime? GetValorFechaHora(string idValor)
        {
            KioskoConfiguracionValor valor = _KioskoConfiguracionValores.Find(kcv => kcv.IdValor == idValor);
            if (valor == null)
            {
                return null;
            }
            else
            {
                return valor.ValorFechaHora;
            }
        }

        private bool? GetValorSiNo(string idValor)
        {
            KioskoConfiguracionValor valor = _KioskoConfiguracionValores.Find(kcv => kcv.IdValor == idValor);
            if (valor == null)
            {
                return null;
            }
            else
            {
                return valor.ValorSiNo;
            }
        }

        private Imagen GetValorImagen(SqlConnection connection, string idValor)
        {
            short? IdImagen = GetValorNumeroEnteroAsShort(idValor);
            if (IdImagen.HasValue)
            {
                Imagen imagen = new Imagen();
                if (imagen.CargarPorID(connection, IdImagen.Value))
                {
                    return imagen;
                }
                else
                {
                    imagen = null;
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        private Stream GetValorImagenDataAsStream(SqlConnection connection, string idValor)
        {
            Imagen imagen = GetValorImagen(connection, idValor);
            if (imagen != null && imagen.IsFound)
            {
                return imagen.ImagenData;
            }
            else
            {
                imagen = null;
                return null;
            }
        }

        private Image GetValorImagenDataAsBitmap(SqlConnection connection, string idValor)
        {
            Imagen imagen = GetValorImagen(connection, idValor);
            if (imagen != null && imagen.IsFound)
            {
                return imagen.ImagenDataAsBitmap;
            }
            else
            {
                imagen = null;
                return null;
            }
        }

        #endregion
    }
}