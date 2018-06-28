/* Options:
Date: 2018-06-29 01:37:52
Version: 5.10
Tip: To override a DTO option, remove "//" prefix before updating
BaseUrl: https://smsgw.intele.no/dev-pushsms/rest

//GlobalNamespace: 
//MakePartial: True
//MakeVirtual: True
//MakeInternal: False
//MakeDataContractsExtensible: False
//AddReturnMarker: True
//AddDescriptionAsComments: True
//AddDataContractAttributes: False
//AddIndexesToDataMembers: False
//AddGeneratedCodeAttributes: False
//AddResponseStatus: False
//AddImplicitVersion: 
//InitializeCollections: True
//ExportValueTypes: False
//IncludeTypes: 
//ExcludeTypes: 
//AddNamespaces: 
//AddDefaultXmlNamespace: http://schemas.servicestack.net/types
*/

using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using ServiceStack;
using ServiceStack.DataAnnotations;
using PushSmsLib.Dto;


namespace PushSmsLib.Dto
{

    public partial class RestSmsMessageReq
    {
        public RestSmsMessageReq()
        {
            CustomData = new Dictionary<string, string>{};
        }

        ///<summary>
        ///Gateway number. Default 99700999 for cross country delivery, non premium messages
        ///</summary>
        [ApiMember(Description="Gateway number. Default 99700999 for cross country delivery, non premium messages", IsRequired=true, ParameterType="form")]
        public virtual long Gateway { get; set; }

        ///<summary>
        ///Originator address. Defaults to gateway number if not set. Maximum 11 chars if using alphanumeric value. See documentation for full details.
        ///</summary>
        [ApiMember(Description="Originator address. Defaults to gateway number if not set. Maximum 11 chars if using alphanumeric value. See documentation for full details.", ParameterType="form")]
        [StringLength(25)]
        public virtual string OriginatorAddress { get; set; }

        ///<summary>
        ///Destination address.The recipient of the message. Must be a valid MSISDN
        ///</summary>
        [ApiMember(Description="Destination address.The recipient of the message. Must be a valid MSISDN", IsRequired=true, ParameterType="form")]
        public virtual long DestinationAddress { get; set; }

        ///<summary>
        ///Price to bill recipient. Premium messaging. Leave value to 0 if not using premium. Premium is only available on short number gateway number for each country available in documentation
        ///</summary>
        [ApiMember(Description="Price to bill recipient. Premium messaging. Leave value to 0 if not using premium. Premium is only available on short number gateway number for each country available in documentation", IsRequired=true, ParameterType="form")]
        public virtual int Price { get; set; }

        ///<summary>
        ///Message type according to documentation. Defaults to 00 if not set. If text length is above 160 chars, it defaults to value 11
        ///</summary>
        [ApiMember(Description="Message type according to documentation. Defaults to 00 if not set. If text length is above 160 chars, it defaults to value 11", ParameterType="form")]
        [StringLength(2)]
        public virtual string MessageType { get; set; }

        ///<summary>
        ///Delivery expire timestamp (yyyymmddhhmmss) or relative value. See documentation and default value if not defined
        ///</summary>
        [ApiMember(Description="Delivery expire timestamp (yyyymmddhhmmss) or relative value. See documentation and default value if not defined", ParameterType="form")]
        [StringLength(14)]
        public virtual string ValidationPeriod { get; set; }

        ///<summary>
        ///Your unique message id to track delivery status and response from sending process
        ///</summary>
        [ApiMember(Description="Your unique message id to track delivery status and response from sending process", ParameterType="form")]
        [StringLength(32)]
        public virtual string MessageId { get; set; }

        ///<summary>
        ///GSM User Data Header (HEX)
        ///</summary>
        [ApiMember(Description="GSM User Data Header (HEX)", ParameterType="form")]
        [StringLength(32)]
        public virtual string UserDataHeader { get; set; }

        ///<summary>
        ///GSM User Data. Plain text or hex encoded. Depending on the used MessageType
        ///</summary>
        [ApiMember(Description="GSM User Data. Plain text or hex encoded. Depending on the used MessageType", IsRequired=true, ParameterType="form")]
        [StringLength(1024)]
        public virtual string UserData { get; set; }

        ///<summary>
        ///Parameter to categorize messages on payment bill from Intele
        ///</summary>
        [ApiMember(Description="Parameter to categorize messages on payment bill from Intele", ParameterType="form")]
        [StringLength(32)]
        public virtual string Category { get; set; }

        ///<summary>
        ///Custom key/value attributes for the Sms Text Message. See documentation for further details
        ///</summary>
        [ApiMember(Description="Custom key/value attributes for the Sms Text Message. See documentation for further details", ParameterType="form")]
        public virtual Dictionary<string, string> CustomData { get; set; }

        ///<summary>
        ///Url where Intele should send delivery report. See documentation for url formatting
        ///</summary>
        [ApiMember(Description="Url where Intele should send delivery report. See documentation for url formatting", ParameterType="form")]
        [StringLength(2048)]
        public virtual string DeliveryReportUrl { get; set; }

        ///<summary>
        ///For Premium messaging only. See documentation for further details
        ///</summary>
        [ApiMember(Description="For Premium messaging only. See documentation for further details", ParameterType="form")]
        [StringLength(128)]
        public virtual string ServiceCode { get; set; }

        ///<summary>
        ///For Premium messaging only. See documentation for further details
        ///</summary>
        [ApiMember(Description="For Premium messaging only. See documentation for further details", ParameterType="form")]
        [StringLength(512)]
        public virtual string ServiceDescription { get; set; }
    }

    public partial class RestSmsMessageResp
    {
        public RestSmsMessageResp()
        {
            ExtraInfo = new Dictionary<string, string>{};
        }

        ///<summary>
        ///Result of sending message. 0 if success. See documentation for full list of codes
        ///</summary>
        [ApiMember(Description="Result of sending message. 0 if success. See documentation for full list of codes", IsRequired=true, ParameterType="form")]
        public virtual int StatusCode { get; set; }

        ///<summary>
        ///Describes the result of sending Sms text message
        ///</summary>
        [ApiMember(Description="Describes the result of sending Sms text message", IsRequired=true, ParameterType="form")]
        [StringLength(2048)]
        public virtual string StatusDescription { get; set; }

        ///<summary>
        ///Your unique message id from send request message item. Will be empty if you did not provide any id in the request item.
        ///</summary>
        [ApiMember(Description="Your unique message id from send request message item. Will be empty if you did not provide any id in the request item.", ParameterType="form")]
        [StringLength(32)]
        public virtual string MessageId { get; set; }

        ///<summary>
        ///Unique transaction id from server
        ///</summary>
        [ApiMember(Description="Unique transaction id from server", IsRequired=true, ParameterType="form")]
        [StringLength(32)]
        public virtual string TransactionId { get; set; }

        ///<summary>
        ///Key/Value attributes returned from server. E.g. subnumref and the server name that processed the message. Eg. subnumref=19331234567891,server=smsgw1
        ///</summary>
        [ApiMember(Description="Key/Value attributes returned from server. E.g. subnumref and the server name that processed the message. Eg. subnumref=19331234567891,server=smsgw1", ParameterType="form")]
        public virtual Dictionary<string, string> ExtraInfo { get; set; }
    }

    public partial class RestSmsRequest
        : IReturn<RestSmsResponse>
    {
        public RestSmsRequest()
        {
            Messages = new RestSmsMessageReq[]{};
        }

        ///<summary>
        ///API Username. Usually your customer id
        ///</summary>
        [ApiMember(Description="API Username. Usually your customer id", IsRequired=true, ParameterType="form")]
        [StringLength(128)]
        public virtual string Username { get; set; }

        ///<summary>
        ///API Password
        ///</summary>
        [ApiMember(Description="API Password", IsRequired=true, ParameterType="form")]
        [StringLength(128)]
        public virtual string Password { get; set; }

        ///<summary>
        ///Collection of messages to send
        ///</summary>
        [ApiMember(Description="Collection of messages to send", IsRequired=true, ParameterType="form")]
        public virtual RestSmsMessageReq[] Messages { get; set; }
    }

    public partial class RestSmsResponse
    {
        public RestSmsResponse()
        {
            Messages = new RestSmsMessageResp[]{};
        }

        ///<summary>
        ///Overall status of processing the request. Each message will have it's own status. This value indicates if any other error occured or not
        ///</summary>
        [ApiMember(Description="Overall status of processing the request. Each message will have it's own status. This value indicates if any other error occured or not", IsRequired=true, ParameterType="form")]
        public virtual bool ProcessResult { get; set; }

        ///<summary>
        ///Description of any error occured, if ProcessResult equals false
        ///</summary>
        [ApiMember(Description="Description of any error occured, if ProcessResult equals false", ParameterType="form")]
        [StringLength(2048)]
        public virtual string ProcessResultDescription { get; set; }

        ///<summary>
        ///Collection of messages sent
        ///</summary>
        [ApiMember(Description="Collection of messages sent", ParameterType="form")]
        public virtual RestSmsMessageResp[] Messages { get; set; }
    }
}

