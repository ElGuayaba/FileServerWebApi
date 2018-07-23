﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FileServer.Common.Layer.Resources {
    using System;
    
    
    /// <summary>
    ///   Clase de recurso fuertemente tipado, para buscar cadenas traducidas, etc.
    /// </summary>
    // StronglyTypedResourceBuilder generó automáticamente esta clase
    // a través de una herramienta como ResGen o Visual Studio.
    // Para agregar o quitar un miembro, edite el archivo .ResX y, a continuación, vuelva a ejecutar ResGen
    // con la opción /str o recompile su proyecto de VS.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "15.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class FMResources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal FMResources() {
        }
        
        /// <summary>
        ///   Devuelve la instancia de ResourceManager almacenada en caché utilizada por esta clase.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("FileServer.Common.Layer.Resources.FMResources", typeof(FMResources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Reemplaza la propiedad CurrentUICulture del subproceso actual para todas las
        ///   búsquedas de recursos mediante esta clase de recurso fuertemente tipado.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a Argumento No Nulo Inválido.
        /// </summary>
        internal static string Argument {
            get {
                return ResourceManager.GetString("Argument", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a Argumento Nulo.
        /// </summary>
        internal static string ArgumentNull {
            get {
                return ResourceManager.GetString("ArgumentNull", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a Error de Lectura/Escritura.
        /// </summary>
        internal static string IO {
            get {
                return ResourceManager.GetString("IO", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a Directorio No Encontrado.
        /// </summary>
        internal static string NotFound {
            get {
                return ResourceManager.GetString("NotFound", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a Operación No Soportada.
        /// </summary>
        internal static string NotSupported {
            get {
                return ResourceManager.GetString("NotSupported", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a Ruta Excesivamente Larga.
        /// </summary>
        internal static string PathTooLong {
            get {
                return ResourceManager.GetString("PathTooLong", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a Acceso no autorizado.
        /// </summary>
        internal static string Unauthorized {
            get {
                return ResourceManager.GetString("Unauthorized", resourceCulture);
            }
        }
    }
}
