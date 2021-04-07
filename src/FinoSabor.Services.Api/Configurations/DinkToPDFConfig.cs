using DinkToPdf;
using DinkToPdf.Contracts;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.Loader;

namespace FinoSabor.Services.Api.Configurations
{
    public static class DinkToPDFConfig
    {

        public static void AddDinkToPDFConfiguration(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            /*
            // Verifica qual a arquiterura para utilizar os arquivos necessários
            var architectureFolder = (IntPtr.Size == 8) ? "64 bit" : "32 bit";
            // Encontra o caminho onde estão os arquivos
            var wkHtmlToPdfPath = Path.Combine(AppContext.BaseDirectory, $"v0.12.4\\{architectureFolder}\\libwkhtmltox.dll");
            // Carrega os arquivos necessários, passadas as configurações
            CustomAssemblyLoadContext context = new CustomAssemblyLoadContext();
            context.LoadUnmanagedLibrary(wkHtmlToPdfPath);

            // Configuração do DinkToPdf
            services.AddSingleton(typeof(IConverter), new SynchronizedConverter(new PdfTools()));
            */


            var architectureFolder = (IntPtr.Size == 8) ? "64 bit" : "32 bit";
            var wkHtmlToPdfFileName = "libwkhtmltox";

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                wkHtmlToPdfFileName += ".so";
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                wkHtmlToPdfFileName += ".dylib";
            }

            var wkHtmlToPdfPath = Path.Combine(AppContext.BaseDirectory, "v0.12.4", architectureFolder, wkHtmlToPdfFileName);


            CustomAssemblyLoadContext context = new CustomAssemblyLoadContext();
            context.LoadUnmanagedLibrary(wkHtmlToPdfPath);
            services.AddSingleton(typeof(IConverter), new SynchronizedConverter(new PdfTools()));

        }


    }

    // Classe resposnsável por carregar os arquivos necessários para o DinkToPDF
    internal class CustomAssemblyLoadContext : AssemblyLoadContext
    {
        public IntPtr LoadUnmanagedLibrary(string absolutePath)
        {
            return LoadUnmanagedDll(absolutePath);
        }
        protected override IntPtr LoadUnmanagedDll(String unmanagedDllName)
        {
            return LoadUnmanagedDllFromPath(unmanagedDllName);
        }

        protected override Assembly Load(AssemblyName assemblyName)
        {
            throw new NotImplementedException();
        }
    }
}
