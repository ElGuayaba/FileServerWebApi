﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FileServer.Infrastructure.Repository {
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
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Devuelve la instancia de ResourceManager almacenada en caché utilizada por esta clase.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("FileServer.Infrastructure.Repository.Resources", typeof(Resources).Assembly);
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
        ///   Busca una cadena traducida similar a Error al añadir el objeto en el fichero de almacenamiento..
        /// </summary>
        internal static string AddError {
            get {
                return ResourceManager.GetString("AddError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a Error al vaciar la base de datos..
        /// </summary>
        internal static string ClearError {
            get {
                return ResourceManager.GetString("ClearError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a Error al eliminar el objeto..
        /// </summary>
        internal static string DeleteError {
            get {
                return ResourceManager.GetString("DeleteError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a Error al obtener datos del fichero de almacenamiento..
        /// </summary>
        internal static string GetError {
            get {
                return ResourceManager.GetString("GetError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a Error al actualizar el objeto..
        /// </summary>
        internal static string UpdateError {
            get {
                return ResourceManager.GetString("UpdateError", resourceCulture);
            }
        }
    }
}
