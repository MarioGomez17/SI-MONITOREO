﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WS_Altura_Planta
{
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://WebServices/", ConfigurationName="WS_Altura_Planta.CapturarAltura")]
    public interface CapturarAltura
    {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://WebServices/CapturarAltura/CapturarAlturaValorRequest", ReplyAction="http://WebServices/CapturarAltura/CapturarAlturaValorResponse")]
        System.Threading.Tasks.Task<WS_Altura_Planta.CapturarAlturaValorResponse> CapturarAlturaValorAsync(WS_Altura_Planta.CapturarAlturaValorRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://WebServices/CapturarAltura/AlturaValorClienteRequest", ReplyAction="http://WebServices/CapturarAltura/AlturaValorClienteResponse")]
        System.Threading.Tasks.Task<WS_Altura_Planta.AlturaValorClienteResponse> AlturaValorClienteAsync(WS_Altura_Planta.AlturaValorClienteRequest request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class CapturarAlturaValorRequest
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="CapturarAlturaValor", Namespace="http://WebServices/", Order=0)]
        public WS_Altura_Planta.CapturarAlturaValorRequestBody Body;
        
        public CapturarAlturaValorRequest()
        {
        }
        
        public CapturarAlturaValorRequest(WS_Altura_Planta.CapturarAlturaValorRequestBody Body)
        {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="")]
    public partial class CapturarAlturaValorRequestBody
    {
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=0)]
        public int AlturaInicial;
        
        public CapturarAlturaValorRequestBody()
        {
        }
        
        public CapturarAlturaValorRequestBody(int AlturaInicial)
        {
            this.AlturaInicial = AlturaInicial;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class CapturarAlturaValorResponse
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="CapturarAlturaValorResponse", Namespace="http://WebServices/", Order=0)]
        public WS_Altura_Planta.CapturarAlturaValorResponseBody Body;
        
        public CapturarAlturaValorResponse()
        {
        }
        
        public CapturarAlturaValorResponse(WS_Altura_Planta.CapturarAlturaValorResponseBody Body)
        {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="")]
    public partial class CapturarAlturaValorResponseBody
    {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string @return;
        
        public CapturarAlturaValorResponseBody()
        {
        }
        
        public CapturarAlturaValorResponseBody(string @return)
        {
            this.@return = @return;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="AlturaValorCliente", WrapperNamespace="http://WebServices/", IsWrapped=true)]
    public partial class AlturaValorClienteRequest
    {
        
        public AlturaValorClienteRequest()
        {
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="AlturaValorClienteResponse", WrapperNamespace="http://WebServices/", IsWrapped=true)]
    public partial class AlturaValorClienteResponse
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="", Order=0)]
        public double @return;
        
        public AlturaValorClienteResponse()
        {
        }
        
        public AlturaValorClienteResponse(double @return)
        {
            this.@return = @return;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    public interface CapturarAlturaChannel : WS_Altura_Planta.CapturarAltura, System.ServiceModel.IClientChannel
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    public partial class CapturarAlturaClient : System.ServiceModel.ClientBase<WS_Altura_Planta.CapturarAltura>, WS_Altura_Planta.CapturarAltura
    {
        
        /// <summary>
        /// Implemente este método parcial para configurar el punto de conexión de servicio.
        /// </summary>
        /// <param name="serviceEndpoint">El punto de conexión para configurar</param>
        /// <param name="clientCredentials">Credenciales de cliente</param>
        static partial void ConfigureEndpoint(System.ServiceModel.Description.ServiceEndpoint serviceEndpoint, System.ServiceModel.Description.ClientCredentials clientCredentials);
        
        public CapturarAlturaClient() : 
                base(CapturarAlturaClient.GetDefaultBinding(), CapturarAlturaClient.GetDefaultEndpointAddress())
        {
            this.Endpoint.Name = EndpointConfiguration.CapturarAlturaPort.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public CapturarAlturaClient(EndpointConfiguration endpointConfiguration) : 
                base(CapturarAlturaClient.GetBindingForEndpoint(endpointConfiguration), CapturarAlturaClient.GetEndpointAddress(endpointConfiguration))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public CapturarAlturaClient(EndpointConfiguration endpointConfiguration, string remoteAddress) : 
                base(CapturarAlturaClient.GetBindingForEndpoint(endpointConfiguration), new System.ServiceModel.EndpointAddress(remoteAddress))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public CapturarAlturaClient(EndpointConfiguration endpointConfiguration, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(CapturarAlturaClient.GetBindingForEndpoint(endpointConfiguration), remoteAddress)
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public CapturarAlturaClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress)
        {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<WS_Altura_Planta.CapturarAlturaValorResponse> WS_Altura_Planta.CapturarAltura.CapturarAlturaValorAsync(WS_Altura_Planta.CapturarAlturaValorRequest request)
        {
            return base.Channel.CapturarAlturaValorAsync(request);
        }
        
        public System.Threading.Tasks.Task<WS_Altura_Planta.CapturarAlturaValorResponse> CapturarAlturaValorAsync(int AlturaInicial)
        {
            WS_Altura_Planta.CapturarAlturaValorRequest inValue = new WS_Altura_Planta.CapturarAlturaValorRequest();
            inValue.Body = new WS_Altura_Planta.CapturarAlturaValorRequestBody();
            inValue.Body.AlturaInicial = AlturaInicial;
            return ((WS_Altura_Planta.CapturarAltura)(this)).CapturarAlturaValorAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<WS_Altura_Planta.AlturaValorClienteResponse> WS_Altura_Planta.CapturarAltura.AlturaValorClienteAsync(WS_Altura_Planta.AlturaValorClienteRequest request)
        {
            return base.Channel.AlturaValorClienteAsync(request);
        }
        
        public System.Threading.Tasks.Task<WS_Altura_Planta.AlturaValorClienteResponse> AlturaValorClienteAsync()
        {
            WS_Altura_Planta.AlturaValorClienteRequest inValue = new WS_Altura_Planta.AlturaValorClienteRequest();
            return ((WS_Altura_Planta.CapturarAltura)(this)).AlturaValorClienteAsync(inValue);
        }
        
        public virtual System.Threading.Tasks.Task OpenAsync()
        {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginOpen(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndOpen));
        }
        
        private static System.ServiceModel.Channels.Binding GetBindingForEndpoint(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.CapturarAlturaPort))
            {
                System.ServiceModel.BasicHttpBinding result = new System.ServiceModel.BasicHttpBinding();
                result.MaxBufferSize = int.MaxValue;
                result.ReaderQuotas = System.Xml.XmlDictionaryReaderQuotas.Max;
                result.MaxReceivedMessageSize = int.MaxValue;
                result.AllowCookies = true;
                return result;
            }
            throw new System.InvalidOperationException(string.Format("No se pudo encontrar un punto de conexión con el nombre \"{0}\".", endpointConfiguration));
        }
        
        private static System.ServiceModel.EndpointAddress GetEndpointAddress(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.CapturarAlturaPort))
            {
                return new System.ServiceModel.EndpointAddress("http://192.168.28.26:8080/ModuloAltura/CapturarAltura");
            }
            throw new System.InvalidOperationException(string.Format("No se pudo encontrar un punto de conexión con el nombre \"{0}\".", endpointConfiguration));
        }
        
        private static System.ServiceModel.Channels.Binding GetDefaultBinding()
        {
            return CapturarAlturaClient.GetBindingForEndpoint(EndpointConfiguration.CapturarAlturaPort);
        }
        
        private static System.ServiceModel.EndpointAddress GetDefaultEndpointAddress()
        {
            return CapturarAlturaClient.GetEndpointAddress(EndpointConfiguration.CapturarAlturaPort);
        }
        
        public enum EndpointConfiguration
        {
            
            CapturarAlturaPort,
        }
    }
}
