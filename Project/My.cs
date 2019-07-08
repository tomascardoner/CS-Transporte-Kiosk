﻿// Simular (en parte) el objeto My de Visual Basic 2005 (o superior)

using System.Reflection;
using System.Diagnostics;

namespace CSTransporteKiosk
{
    // My.Settings y My.Application.Info
    static class My
    {
        // My.Settings
        public static Properties.Settings Settings
        {
            get
            {
                return Properties.Settings.Default;
            }
        }

        // My.Application.Info
        public static class Application
        {

            public static class Info
            {
                static System.Diagnostics.FileVersionInfo fvi;
                static System.Reflection.Assembly ensamblado;
                static AssemblyName an;

                static Info()
                {
                    ensamblado = System.Reflection.Assembly.GetExecutingAssembly();
                    fvi = FileVersionInfo.GetVersionInfo(ensamblado.Location);
                    an = ensamblado.GetName();
                }

                /// <summary>
                /// La versión del ensamblado
                /// Equivale al atributo AssemblyVersion
                /// </summary>
                public static System.Version Version
                {
                    get
                    {
                        return an.Version;
                    }
                }

                /// <summary>
                /// La versión del ensamblado (FileVersion)
                /// equivale al atributo: AssemblyFileVersion
                /// </summary>
                public static System.Version FileVersion
                {
                    get
                    {
                        return new System.Version(fvi.FileVersion);
                    }
                }

                public static string Title
                {
                    get
                    {
                        return fvi.FileDescription;
                        // antes mostraba esto: fvi.ProductName;
                    }
                }
                public static string Copyright
                {
                    get
                    {
                        return fvi.LegalCopyright;
                    }
                }
                public static string ProductName
                {
                    get
                    {
                        return fvi.ProductName;
                    }
                }
                public static string CompanyName
                {
                    get
                    {
                        return fvi.CompanyName;
                    }
                }
                public static string Trademark
                {
                    get
                    {
                        return fvi.LegalTrademarks;
                    }
                }
                public static string Description
                {
                    get
                    {
                        return fvi.Comments;
                    }
                }

            }
        }
    }
}