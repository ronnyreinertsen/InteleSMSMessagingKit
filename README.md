# InteleSMSMessagingKit
Intele Sms Messaging Kit

Send and receive Sms messages world wide. Premium messaging supported in Norway, Sweden, Denmark and Finland. Bulk messaging supported world wide.

This assembly also includes code for checking MSISDN against the Norwegian number portability register, and also check if a MSISDN is valid according to the international numbering plan.

You will need a customer account to access these services. Please contact us for details. http://intele.no/bestilling


Changes:
20.06.2018 - Added new REST API for SMS Gateway. Minor changes to directory structure and code samples added
29.06.2018 - Changed default REST API url in client code to use production instead of test address
21.10.2019 - Upgraded project to .NET Framework 4.8
22.10.2019 - Bug fix on CustomData variable result in null exception if not set using REST API
16.11.2022 - Upgraded project to .NET Framework 4.8.1 and upgraded referenced libs
11.05.2023 - Downgrade project to .NET Framework 4.8 and removed ServiceStack dependencies
