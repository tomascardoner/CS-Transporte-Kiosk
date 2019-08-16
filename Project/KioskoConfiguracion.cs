using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace CSTransporteKiosko
{
    public class KioskoConfiguracion
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

        // Media
        private string IdValorCompaniaSoftwareLogotipoIDImagen = "CompaniaSoftwareLogotipoIDImagen";
        private string IdValorEmpresaLogotipoIDImagen = "EmpresaLogotipoIDImagen";
        private string IdValorVideo = "Video";

        // Apariencia
        private string IdValorScreenBackColor = "ScreenBackColor";
        private string IdValorInformacionLeyendaFontStyle = "InformacionLeyendaFontStyle";
        private string IdValorInformacionLeyendaForeColor = "InformacionLeyendaForeColor";
        private string IdValorInformacionPrincipalFontStyle = "InformacionPrincipalFontStyle";
        private string IdValorInformacionPrincipalForeColor = "InformacionPrincipalForeColor";
        private string IdValorInformacionSecundariaFontStyle = "InformacionSecundariaFontStyle";
        private string IdValorInformacionSecundariaForeColor = "InformacionSecundariaForeColor";

        // Botón anterior
        private string IdValorButtonPreviousFontStyle = "ButtonPreviousFontStyle";
        private string IdValorButtonPreviousBackColor = "ButtonPreviousBackColor";
        private string IdValorButtonPreviousForeColor = "ButtonPreviousForeColor";

        // Botón siguiente
        private string IdValorButtonNextFontStyle = "ButtonNextFontStyle";
        private string IdValorButtonNextBackColor = "ButtonNextBackColor";
        private string IdValorButtonNextForeColor = "ButtonNextForeColor";

        // Mesage box
        private string IdValorMessageBoxFontStyle = "MessageBoxFontStyle";
        private string IdValorMessageBoxBackColor = "MessageBoxBackColor";
        private string IdValorMessageBoxForeColor = "MessageBoxForeColor";
        private string IdValorMessageBoxButtonFontStyle = "MessageBoxButtonFontStyle";
        private string IdValorMessageBoxButtonBackColor = "MessageBoxButtonBackColor";
        private string IdValorMessageBoxButtonForeColor = "MessageBoxButtonForeColor";

        // Numeric Keyborad
        private string IdValorKeyboardNumericNumberFontStyle = "KeyboardNumericNumberFontStyle";
        private string IdValorKeyboardNumericSpecialFontStyle = "KeyboardNumericSpecialFontStyle";

        // POS Printer
        private string IdValorPOSPrinterClaimTimeoutSeconds = "POSPrinterClaimTimeoutSeconds";
        private string IdValorPOSPrinterReleaseTimeoutSeconds = "POSPrinterReleaseTimeoutSeconds";

        // Timeouts
        private string IdValorInactivityTimeoutSeconds = "InactivityTimeoutSeconds";
        private string IdValorLugarDuracionPreviaMaximaMinutos = "LugarDuracionPreviaMaximaMinutos";
        private string IdValorLugarDuracionPreviaMinimaMinutos = "LugarDuracionPreviaMinimaMinutos";

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

        // Media
        public short? ValorCompaniaSoftwareLogotipoIDImagen { get => GetValorIdImagen(IdValorCompaniaSoftwareLogotipoIDImagen); }
        public Image ValorCompaniaSoftwareLogotipo(SqlConnection connection)
        {
            return GetValorImagenDataAsBitmap(connection, IdValorCompaniaSoftwareLogotipoIDImagen);
        }
        public short? ValorEmpresaLogotipoIDImagen { get => GetValorIdImagen(IdValorEmpresaLogotipoIDImagen); }
        public Image ValorEmpresaLogotipo(SqlConnection connection)
        {
            return GetValorImagenDataAsBitmap(connection, IdValorEmpresaLogotipoIDImagen);
        }
        public string ValorVideo { get => GetValorString(IdValorVideo); }

        // Apariencia
        public int? ValorScreenBackColor { get => GetValorNumeroEnteroAsInteger(IdValorScreenBackColor); }
        public Color? ValorScreenBackColorAsColor { get => GetValorColor(IdValorScreenBackColor); }

        public string ValorInformacionLeyendaFontStyleString { get => GetValorString(IdValorInformacionLeyendaFontStyle); }
        public Font ValorInformacionLeyendaFontStyle { get => GetValorFont(IdValorInformacionLeyendaFontStyle); }
        public int? ValorInformacionLeyendaForeColor { get => GetValorNumeroEnteroAsInteger(IdValorInformacionLeyendaForeColor); }
        public Color? ValorInformacionLeyendaForeColorAsColor { get => GetValorColor(IdValorInformacionLeyendaForeColor); }

        public string ValorInformacionPrincipalFontStyleString { get => GetValorString(IdValorInformacionPrincipalFontStyle); }
        public Font ValorInformacionPrincipalFontStyle { get => GetValorFont(IdValorInformacionPrincipalFontStyle); }
        public int? ValorInformacionPrincipalForeColor { get => GetValorNumeroEnteroAsInteger(IdValorInformacionPrincipalForeColor); }
        public Color? ValorInformacionPrincipalForeColorAsColor { get => GetValorColor(IdValorInformacionPrincipalForeColor); }

        public string ValorInformacionSecundariaFontStyleString { get => GetValorString(IdValorInformacionSecundariaFontStyle); }
        public Font ValorInformacionSecundariaFontStyle { get => GetValorFont(IdValorInformacionSecundariaFontStyle); }
        public int? ValorInformacionSecundariaForeColor { get => GetValorNumeroEnteroAsInteger(IdValorInformacionSecundariaForeColor); }
        public Color? ValorInformacionSecundariaForeColorAsColor { get => GetValorColor(IdValorInformacionSecundariaForeColor); }

        // Botón anterior
        public string ValorButtonPreviousFontStyleString { get => GetValorString(IdValorButtonPreviousFontStyle); }
        public Font ValorButtonPreviousFontStyle { get => GetValorFont(IdValorButtonPreviousFontStyle); }
        public int? ValorButtonPreviousBackColor { get => GetValorNumeroEnteroAsInteger(IdValorButtonPreviousBackColor); }
        public Color? ValorButtonPreviousBackColorAsColor { get => GetValorColor(IdValorButtonPreviousBackColor);  }
        public int? ValorButtonPreviousForeColor { get => GetValorNumeroEnteroAsInteger(IdValorButtonPreviousForeColor); }
        public Color? ValorButtonPreviousForeColorAsColor { get => GetValorColor(IdValorButtonPreviousBackColor); }

        // Botón siguiente
        public string ValorButtonNextFontStyleString { get => GetValorString(IdValorButtonNextFontStyle); }
        public Font ValorButtonNextFontStyle { get => GetValorFont(IdValorButtonNextFontStyle); }
        public int? ValorButtonNextBackColor { get => GetValorNumeroEnteroAsInteger(IdValorButtonNextBackColor); }
        public Color? ValorButtonNextBackColorAsColor { get => GetValorColor(IdValorButtonNextBackColor); }
        public int? ValorButtonNextForeColor { get => GetValorNumeroEnteroAsInteger(IdValorButtonNextForeColor); }
        public Color? ValorButtonNextForeColorAsColor { get => GetValorColor(IdValorButtonNextBackColor); }

        // Mesage box
        public string ValorMessageBoxFontStyleString { get => GetValorString(IdValorMessageBoxFontStyle); }
        public Font ValorMessageBoxFontStyle { get => GetValorFont(IdValorMessageBoxFontStyle); }
        public int? ValorMessageBoxBackColor { get => GetValorNumeroEnteroAsInteger(IdValorMessageBoxBackColor); }
        public Color? ValorMessageBoxBackColorAsColor { get => GetValorColor(IdValorMessageBoxBackColor); }
        public int? ValorMessageBoxForeColor { get => GetValorNumeroEnteroAsInteger(IdValorMessageBoxForeColor); }
        public Color? ValorMessageBoxForeColorAsColor { get => GetValorColor(IdValorMessageBoxForeColor); }

        public string ValorMessageBoxButtonFontStyleString { get => GetValorString(IdValorMessageBoxButtonFontStyle); }
        public Font ValorMessageBoxButtonFontStyle { get => GetValorFont(IdValorMessageBoxButtonFontStyle); }
        public int? ValorMessageBoxButtonBackColor { get => GetValorNumeroEnteroAsInteger(IdValorMessageBoxButtonBackColor); }
        public Color? ValorMessageBoxButtonBackColorAsColor { get => GetValorColor(IdValorMessageBoxButtonBackColor); }
        public int? ValorMessageBoxButtonForeColor { get => GetValorNumeroEnteroAsInteger(IdValorMessageBoxButtonForeColor); }
        public Color? ValorMessageBoxButtonForeColorAsColor { get => GetValorColor(IdValorMessageBoxButtonForeColor); }

        // Numeric Keyborad
        public string ValorKeyboardNumericNumberFontString { get => GetValorString(IdValorKeyboardNumericNumberFontStyle); }
        public Font ValorKeyboardNumericNumberFont { get => GetValorFont(IdValorKeyboardNumericNumberFontStyle); }
        public string ValorKeyboardNumericSpecialFontString { get => GetValorString(IdValorKeyboardNumericSpecialFontStyle); }
        public Font ValorKeyboardNumericSpecialFont { get => GetValorFont(IdValorKeyboardNumericSpecialFontStyle); }

        // POS Printer
        public int ValorPOSPrinterClaimTimeoutSeconds { get => GetValorNumeroEnteroAsInteger(IdValorPOSPrinterClaimTimeoutSeconds, 2); }
        public int ValorPOSPrinterReleaseTimeoutSeconds { get => GetValorNumeroEnteroAsInteger(IdValorPOSPrinterReleaseTimeoutSeconds, 5); }

        // Timeouts
        public int ValorInactivityTimeoutSeconds { get => GetValorNumeroEnteroAsInteger(IdValorInactivityTimeoutSeconds, 60); }
        public short ValorLugarDuracionPreviaMaximaMinutos { get => GetValorNumeroEnteroAsShort(IdValorLugarDuracionPreviaMaximaMinutos, 0); }
        public short ValorLugarDuracionPreviaMinimaMinutos { get => GetValorNumeroEnteroAsShort(IdValorLugarDuracionPreviaMinimaMinutos, 0); }

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
                        valor.CargarPropiedadesDesdeArray(values);
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

        private KioskoConfiguracionValor GetValor(string idValor)
        {
            return _KioskoConfiguracionValores.Find(kcv => kcv.IdValor == idValor);
        }

        private string GetValorString(string idValor)
        {
            KioskoConfiguracionValor valor = GetValor(idValor);
            if (valor == null)
            {
                return null;
            }
            else
            {
                return valor.ValorTexto;
            }
        }

        private Font GetValorFont(string idValor)
        {
            KioskoConfiguracionValor valor = GetValor(idValor);
            if (valor == null)
            {
                return null;
            }
            else
            {
                return valor.ValorFont;
            }
        }

        private int? GetValorNumeroEnteroAsInteger(string idValor)
        {
            KioskoConfiguracionValor valor = GetValor(idValor);
            if (valor == null)
            {
                return null;
            }
            else
            {
                return valor.ValorNumeroEnteroAsInteger;
            }
        }

        private int GetValorNumeroEnteroAsInteger(string idValor, int valorPredeterminado)
        {
            int? valor = GetValorNumeroEnteroAsInteger(idValor);
            if (valor.HasValue)
            {
                return valor.Value;
            }
            else
            {
                return valorPredeterminado;
            }
        }

        private short? GetValorNumeroEnteroAsShort(string idValor)
        {
            KioskoConfiguracionValor valor = GetValor(idValor);
            if (valor == null)
            {
                return null;
            }
            else
            {
                return valor.ValorNumeroEnteroAsShort;
            }
        }

        private short GetValorNumeroEnteroAsShort(string idValor, short valorPredeterminado)
        {
            short? valor = GetValorNumeroEnteroAsShort(idValor);
            if (valor.HasValue)
            {
                return valor.Value;
            }
            else
            {
                return valorPredeterminado;
            }
        }

        private byte? GetValorNumeroEnteroAsByte(string idValor)
        {
            KioskoConfiguracionValor valor = GetValor(idValor);
            if (valor == null)
            {
                return null;
            }
            else
            {
                return valor.ValorNumeroEnteroAsByte;
            }
        }

        private byte GetValorNumeroEnteroAsByte(string idValor, byte valorPredeterminado)
        {
            byte? valor = GetValorNumeroEnteroAsByte(idValor);
            if (valor.HasValue)
            {
                return valor.Value;
            }
            else
            {
                return valorPredeterminado;
            }
        }

        private Color? GetValorColor(string idValor)
        {
            KioskoConfiguracionValor valor = GetValor(idValor);
            if (valor == null)
            {
                return null;
            }
            else
            {
                return valor.ValorColor;
            }
        }

        private decimal? GetValorNumeroDecimal(string idValor)
        {
            KioskoConfiguracionValor valor = GetValor(idValor);
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
            KioskoConfiguracionValor valor = GetValor(idValor);
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
            KioskoConfiguracionValor valor = GetValor(idValor);
            if (valor == null)
            {
                return null;
            }
            else
            {
                return valor.ValorSiNo;
            }
        }

        private short? GetValorIdImagen(string idValor)
        {
            KioskoConfiguracionValor valor = GetValor(idValor);
            if (valor == null)
            {
                return null;
            }
            else
            {
                return valor.ValorIdImagen;
            }
        }

        private Imagen GetValorImagen(SqlConnection connection, string idValor)
        {
            KioskoConfiguracionValor valor = GetValor(idValor);
            if (valor == null)
            {
                return null;
            }
            else
            {
                return valor.ValorImagen(connection);
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