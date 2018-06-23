﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace InteleSmsMessagingKit.NumberplanService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="intele.services", ConfigurationName="NumberplanService.NumberplanPublicSoap")]
    public interface NumberplanPublicSoap {
        
        // CODEGEN: Generating message contract since message QueryRequest has headers
        [System.ServiceModel.OperationContractAttribute(Action="intele.services/Query", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        InteleSmsMessagingKit.NumberplanService.QueryResponse Query(InteleSmsMessagingKit.NumberplanService.QueryRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="intele.services/Query", ReplyAction="*")]
        System.Threading.Tasks.Task<InteleSmsMessagingKit.NumberplanService.QueryResponse> QueryAsync(InteleSmsMessagingKit.NumberplanService.QueryRequest request);
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.3056.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="intele.services")]
    public partial class Authorizer : object, System.ComponentModel.INotifyPropertyChanged {
        
        private int apiCustomerIdField;
        
        private string apiPasswordField;
        
        private System.Xml.XmlAttribute[] anyAttrField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public int ApiCustomerId {
            get {
                return this.apiCustomerIdField;
            }
            set {
                this.apiCustomerIdField = value;
                this.RaisePropertyChanged("ApiCustomerId");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string ApiPassword {
            get {
                return this.apiPasswordField;
            }
            set {
                this.apiPasswordField = value;
                this.RaisePropertyChanged("ApiPassword");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAnyAttributeAttribute()]
        public System.Xml.XmlAttribute[] AnyAttr {
            get {
                return this.anyAttrField;
            }
            set {
                this.anyAttrField = value;
                this.RaisePropertyChanged("AnyAttr");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.3056.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="intele.services")]
    public partial class NumberInfo : object, System.ComponentModel.INotifyPropertyChanged {
        
        private long number_rangeField;
        
        private int country_codeField;
        
        private string national_significant_numberField;
        
        private string iso_3166_alpha_2Field;
        
        private string iso_3166_alpha_3Field;
        
        private string destinationField;
        
        private string number_typeField;
        
        private string locationField;
        
        private string registrarField;
        
        private int area_code_lengthField;
        
        private int country_idField;
        
        private int min_number_lengthField;
        
        private int max_number_lengthField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public long number_range {
            get {
                return this.number_rangeField;
            }
            set {
                this.number_rangeField = value;
                this.RaisePropertyChanged("number_range");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public int country_code {
            get {
                return this.country_codeField;
            }
            set {
                this.country_codeField = value;
                this.RaisePropertyChanged("country_code");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public string national_significant_number {
            get {
                return this.national_significant_numberField;
            }
            set {
                this.national_significant_numberField = value;
                this.RaisePropertyChanged("national_significant_number");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        public string iso_3166_alpha_2 {
            get {
                return this.iso_3166_alpha_2Field;
            }
            set {
                this.iso_3166_alpha_2Field = value;
                this.RaisePropertyChanged("iso_3166_alpha_2");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
        public string iso_3166_alpha_3 {
            get {
                return this.iso_3166_alpha_3Field;
            }
            set {
                this.iso_3166_alpha_3Field = value;
                this.RaisePropertyChanged("iso_3166_alpha_3");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=5)]
        public string destination {
            get {
                return this.destinationField;
            }
            set {
                this.destinationField = value;
                this.RaisePropertyChanged("destination");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=6)]
        public string number_type {
            get {
                return this.number_typeField;
            }
            set {
                this.number_typeField = value;
                this.RaisePropertyChanged("number_type");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=7)]
        public string location {
            get {
                return this.locationField;
            }
            set {
                this.locationField = value;
                this.RaisePropertyChanged("location");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=8)]
        public string registrar {
            get {
                return this.registrarField;
            }
            set {
                this.registrarField = value;
                this.RaisePropertyChanged("registrar");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=9)]
        public int area_code_length {
            get {
                return this.area_code_lengthField;
            }
            set {
                this.area_code_lengthField = value;
                this.RaisePropertyChanged("area_code_length");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=10)]
        public int country_id {
            get {
                return this.country_idField;
            }
            set {
                this.country_idField = value;
                this.RaisePropertyChanged("country_id");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=11)]
        public int min_number_length {
            get {
                return this.min_number_lengthField;
            }
            set {
                this.min_number_lengthField = value;
                this.RaisePropertyChanged("min_number_length");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=12)]
        public int max_number_length {
            get {
                return this.max_number_lengthField;
            }
            set {
                this.max_number_lengthField = value;
                this.RaisePropertyChanged("max_number_length");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="Query", WrapperNamespace="intele.services", IsWrapped=true)]
    public partial class QueryRequest {
        
        [System.ServiceModel.MessageHeaderAttribute(Namespace="intele.services")]
        public InteleSmsMessagingKit.NumberplanService.Authorizer Authorizer;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="intele.services", Order=0)]
        public long msisdn;
        
        public QueryRequest() {
        }
        
        public QueryRequest(InteleSmsMessagingKit.NumberplanService.Authorizer Authorizer, long msisdn) {
            this.Authorizer = Authorizer;
            this.msisdn = msisdn;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="QueryResponse", WrapperNamespace="intele.services", IsWrapped=true)]
    public partial class QueryResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="intele.services", Order=0)]
        public InteleSmsMessagingKit.NumberplanService.NumberInfo QueryResult;
        
        public QueryResponse() {
        }
        
        public QueryResponse(InteleSmsMessagingKit.NumberplanService.NumberInfo QueryResult) {
            this.QueryResult = QueryResult;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface NumberplanPublicSoapChannel : InteleSmsMessagingKit.NumberplanService.NumberplanPublicSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class NumberplanPublicSoapClient : System.ServiceModel.ClientBase<InteleSmsMessagingKit.NumberplanService.NumberplanPublicSoap>, InteleSmsMessagingKit.NumberplanService.NumberplanPublicSoap {
        
        public NumberplanPublicSoapClient() {
        }
        
        public NumberplanPublicSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public NumberplanPublicSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public NumberplanPublicSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public NumberplanPublicSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        InteleSmsMessagingKit.NumberplanService.QueryResponse InteleSmsMessagingKit.NumberplanService.NumberplanPublicSoap.Query(InteleSmsMessagingKit.NumberplanService.QueryRequest request) {
            return base.Channel.Query(request);
        }
        
        public InteleSmsMessagingKit.NumberplanService.NumberInfo Query(InteleSmsMessagingKit.NumberplanService.Authorizer Authorizer, long msisdn) {
            InteleSmsMessagingKit.NumberplanService.QueryRequest inValue = new InteleSmsMessagingKit.NumberplanService.QueryRequest();
            inValue.Authorizer = Authorizer;
            inValue.msisdn = msisdn;
            InteleSmsMessagingKit.NumberplanService.QueryResponse retVal = ((InteleSmsMessagingKit.NumberplanService.NumberplanPublicSoap)(this)).Query(inValue);
            return retVal.QueryResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<InteleSmsMessagingKit.NumberplanService.QueryResponse> InteleSmsMessagingKit.NumberplanService.NumberplanPublicSoap.QueryAsync(InteleSmsMessagingKit.NumberplanService.QueryRequest request) {
            return base.Channel.QueryAsync(request);
        }
        
        public System.Threading.Tasks.Task<InteleSmsMessagingKit.NumberplanService.QueryResponse> QueryAsync(InteleSmsMessagingKit.NumberplanService.Authorizer Authorizer, long msisdn) {
            InteleSmsMessagingKit.NumberplanService.QueryRequest inValue = new InteleSmsMessagingKit.NumberplanService.QueryRequest();
            inValue.Authorizer = Authorizer;
            inValue.msisdn = msisdn;
            return ((InteleSmsMessagingKit.NumberplanService.NumberplanPublicSoap)(this)).QueryAsync(inValue);
        }
    }
}
