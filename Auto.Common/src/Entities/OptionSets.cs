
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
// Created via this command line: "C:\Users\mpolikarpov\AppData\Roaming\MscrmTools\XrmToolBox\Plugins\DLaB.EarlyBoundGenerator\crmsvcutil.exe" /url:"https://orgee44da84.api.crm4.dynamics.com" /namespace:"Auto.Common.src.Entities" /SuppressGeneratedCodeAttribute /out:"C:\Work\repos\dotnetCrmLearn\Auto\Auto.Common\src\Entities\OptionSets.cs" /codecustomization:"DLaB.CrmSvcUtilExtensions.OptionSet.CustomizeCodeDomService,DLaB.CrmSvcUtilExtensions" /codegenerationservice:"DLaB.CrmSvcUtilExtensions.OptionSet.CustomCodeGenerationService,DLaB.CrmSvcUtilExtensions" /codewriterfilter:"DLaB.CrmSvcUtilExtensions.OptionSet.CodeWriterFilterService,DLaB.CrmSvcUtilExtensions" /namingservice:"DLaB.CrmSvcUtilExtensions.NamingService,DLaB.CrmSvcUtilExtensions" /metadataproviderservice:"DLaB.CrmSvcUtilExtensions.BaseMetadataProviderService,DLaB.CrmSvcUtilExtensions" 
//------------------------------------------------------------------------------

namespace Auto.Common.src.Entities
{
	
	
	[System.Runtime.Serialization.DataContractAttribute()]
	public enum Contact_AccountRoleCode
	{
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Decision Maker", 0)]
		DecisionMaker = 1,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Employee", 1)]
		Employee = 2,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Influencer", 2)]
		Influencer = 3,
	}
	
	[System.Runtime.Serialization.DataContractAttribute()]
	public enum Contact_Address1_AddressTypeCode
	{
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Bill To", 0)]
		BillTo = 1,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Other", 3)]
		Other = 4,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Primary", 2)]
		Primary = 3,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Ship To", 1)]
		ShipTo = 2,
	}
	
	[System.Runtime.Serialization.DataContractAttribute()]
	public enum Contact_Address1_FreightTermsCode
	{
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("FOB", 0)]
		FOB = 1,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("No Charge", 1)]
		NoCharge = 2,
	}
	
	[System.Runtime.Serialization.DataContractAttribute()]
	public enum Contact_Address1_ShippingMethodCode
	{
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Airborne", 0)]
		Airborne = 1,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("DHL", 1)]
		DHL = 2,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("FedEx", 2)]
		FedEx = 3,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Full Load", 5)]
		FullLoad = 6,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Postal Mail", 4)]
		PostalMail = 5,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("UPS", 3)]
		UPS = 4,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Will Call", 6)]
		WillCall = 7,
	}
	
	[System.Runtime.Serialization.DataContractAttribute()]
	public enum Contact_Address2_AddressTypeCode
	{
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Default Value", 0)]
		DefaultValue = 1,
	}
	
	[System.Runtime.Serialization.DataContractAttribute()]
	public enum Contact_Address2_FreightTermsCode
	{
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Default Value", 0)]
		DefaultValue = 1,
	}
	
	[System.Runtime.Serialization.DataContractAttribute()]
	public enum Contact_Address2_ShippingMethodCode
	{
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Default Value", 0)]
		DefaultValue = 1,
	}
	
	[System.Runtime.Serialization.DataContractAttribute()]
	public enum Contact_Address3_AddressTypeCode
	{
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Default Value", 0)]
		DefaultValue = 1,
	}
	
	[System.Runtime.Serialization.DataContractAttribute()]
	public enum Contact_Address3_FreightTermsCode
	{
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Default Value", 0)]
		DefaultValue = 1,
	}
	
	[System.Runtime.Serialization.DataContractAttribute()]
	public enum Contact_Address3_ShippingMethodCode
	{
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Default Value", 0)]
		DefaultValue = 1,
	}
	
	[System.Runtime.Serialization.DataContractAttribute()]
	public enum Contact_CustomerSizeCode
	{
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Default Value", 0)]
		DefaultValue = 1,
	}
	
	[System.Runtime.Serialization.DataContractAttribute()]
	public enum Contact_CustomerTypeCode
	{
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Default Value", 0)]
		DefaultValue = 1,
	}
	
	[System.Runtime.Serialization.DataContractAttribute()]
	public enum Contact_EducationCode
	{
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Default Value", 0)]
		DefaultValue = 1,
	}
	
	[System.Runtime.Serialization.DataContractAttribute()]
	public enum Contact_FamilyStatusCode
	{
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Divorced", 2)]
		Divorced = 3,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Married", 1)]
		Married = 2,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Single", 0)]
		Single = 1,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Widowed", 3)]
		Widowed = 4,
	}
	
	[System.Runtime.Serialization.DataContractAttribute()]
	public enum Contact_GenderCode
	{
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Female", 1)]
		Female = 2,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Male", 0)]
		Male = 1,
	}
	
	[System.Runtime.Serialization.DataContractAttribute()]
	public enum Contact_HasChildrenCode
	{
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Default Value", 0)]
		DefaultValue = 1,
	}
	
	[System.Runtime.Serialization.DataContractAttribute()]
	public enum Contact_LeadSourceCode
	{
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Default Value", 0)]
		DefaultValue = 1,
	}
	
	[System.Runtime.Serialization.DataContractAttribute()]
	public enum Contact_msdyn_orgchangestatus
	{
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Ignore", 2, "#0000ff")]
		Ignore = 2,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("No Feedback", 0, "#0000ff")]
		NoFeedback = 0,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Not at Company", 1, "#0000ff")]
		NotatCompany = 1,
	}
	
	[System.Runtime.Serialization.DataContractAttribute()]
	public enum Contact_PaymentTermsCode
	{
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("2% 10, Net 30", 1)]
		_210Net30 = 2,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Net 30", 0)]
		Net30 = 1,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Net 45", 2)]
		Net45 = 3,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Net 60", 3)]
		Net60 = 4,
	}
	
	[System.Runtime.Serialization.DataContractAttribute()]
	public enum Contact_PreferredAppointmentDayCode
	{
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Friday", 5)]
		Friday = 5,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Monday", 1)]
		Monday = 1,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Saturday", 6)]
		Saturday = 6,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Sunday", 0)]
		Sunday = 0,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Thursday", 4)]
		Thursday = 4,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Tuesday", 2)]
		Tuesday = 2,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Wednesday", 3)]
		Wednesday = 3,
	}
	
	[System.Runtime.Serialization.DataContractAttribute()]
	public enum Contact_PreferredAppointmentTimeCode
	{
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Afternoon", 1)]
		Afternoon = 2,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Evening", 2)]
		Evening = 3,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Morning", 0)]
		Morning = 1,
	}
	
	[System.Runtime.Serialization.DataContractAttribute()]
	public enum Contact_PreferredContactMethodCode
	{
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Any", 0)]
		Any = 1,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Email", 1)]
		Email = 2,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Fax", 3)]
		Fax = 4,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Mail", 4)]
		Mail = 5,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Phone", 2)]
		Phone = 3,
	}
	
	[System.Runtime.Serialization.DataContractAttribute()]
	public enum Contact_ShippingMethodCode
	{
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Default Value", 0)]
		DefaultValue = 1,
	}
	
	[System.Runtime.Serialization.DataContractAttribute()]
	public enum Contact_StatusCode
	{
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Active", 0)]
		Active = 1,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Inactive", 1)]
		Inactive = 2,
	}
	
	[System.Runtime.Serialization.DataContractAttribute()]
	public enum Contact_TerritoryCode
	{
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Default Value", 0)]
		DefaultValue = 1,
	}
	
	[System.Runtime.Serialization.DataContractAttribute()]
	public enum nav_agreement_StatusCode
	{
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Active", 0)]
		Active = 1,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Inactive", 1)]
		Inactive = 2,
	}
	
	[System.Runtime.Serialization.DataContractAttribute()]
	public enum nav_auto_StatusCode
	{
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Active", 0)]
		Active = 1,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Inactive", 1)]
		Inactive = 2,
	}
	
	[System.Runtime.Serialization.DataContractAttribute()]
	public enum nav_brand_StatusCode
	{
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Active", 0)]
		Active = 1,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Inactive", 1)]
		Inactive = 2,
	}
	
	[System.Runtime.Serialization.DataContractAttribute()]
	public enum nav_communication_nav_type
	{
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("??????????????", 0, "#0000ff")]
		_ = 808630000,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("E-mail", 1, "#0000ff")]
		Email = 808630001,
	}
	
	[System.Runtime.Serialization.DataContractAttribute()]
	public enum nav_communication_StatusCode
	{
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Active", 0)]
		Active = 1,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Inactive", 1)]
		Inactive = 2,
	}
	
	[System.Runtime.Serialization.DataContractAttribute()]
	public enum nav_credit_StatusCode
	{
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Active", 0)]
		Active = 1,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Inactive", 1)]
		Inactive = 2,
	}
	
	[System.Runtime.Serialization.DataContractAttribute()]
	public enum nav_invoice_nav_type
	{
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("auto", 1, "#0000ff")]
		auto = 808630001,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("manual", 0, "#0000ff")]
		manual = 808630000,
	}
	
	[System.Runtime.Serialization.DataContractAttribute()]
	public enum nav_invoice_StatusCode
	{
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Active", 0)]
		Active = 1,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Inactive", 1)]
		Inactive = 2,
	}
	
	[System.Runtime.Serialization.DataContractAttribute()]
	public enum nav_model_nav_KP
	{
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("????????????????????????????", 0, "#0000ff")]
		@__808630000 = 808630000,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("????????????????????????", 1, "#0000ff")]
		@__808630001 = 808630001,
	}
	
	[System.Runtime.Serialization.DataContractAttribute()]
	public enum nav_model_StatusCode
	{
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Active", 0)]
		Active = 1,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Inactive", 1)]
		Inactive = 2,
	}
	
	[System.Runtime.Serialization.DataContractAttribute()]
	public enum appaction_ClientType
	{
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Browser", 0, "#0000ff")]
		Browser = 0,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Mobile", 1, "#0000ff")]
		Mobile = 1,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Mail App", 2, "#0000ff")]
		MailApp = 2,
	}
	
	[System.Runtime.Serialization.DataContractAttribute()]
	public enum card_Sizes
	{
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Small", 0, "#0000ff")]
		Small = 200000000,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Medium", 1, "#0000ff")]
		Medium = 200000001,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Large", 2, "#0000ff")]
		Large = 200000002,
	}
	
	[System.Runtime.Serialization.DataContractAttribute()]
	public enum msdyn_forecastsettingsandsummary_msdyn_ForecastJobStatus
	{
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Success", 0, "#0000ff")]
		Success = 192350000,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Data Failure", 1, "#0000ff")]
		DataFailure = 192350001,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Pipeline Failure", 2, "#0000ff")]
		PipelineFailure = 192350002,
	}
	
	[System.Runtime.Serialization.DataContractAttribute()]
	public enum msdyn_knowledgemanagementsetting_msdyn_actionlist
	{
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Link / unlink article", 0, "#0000ff")]
		Linkunlinkarticle = 0,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Copy URL", 1, "#0000ff")]
		CopyURL = 1,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Link article and email URL", 2, "#0000ff")]
		LinkarticleandemailURL = 2,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Link article and send article content", 3, "#0000ff")]
		Linkarticleandsendarticlecontent = 3,
	}
	
	[System.Runtime.Serialization.DataContractAttribute()]
	public enum msdyn_oc_daysofweek
	{
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Sun", 0, "#0000ff", "Sunday")]
		Sun = 192350000,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Mon", 1, "#0000ff", "Monday")]
		Mon = 192350001,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Tue", 2, "#0000ff", "Tuesday")]
		Tue = 192350002,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Wed", 3, "#0000ff", "Wednesday")]
		Wed = 192350003,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Thu", 4, "#0000ff", "Thursday")]
		Thu = 192350004,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Fri", 5, "#0000ff", "Friday")]
		Fri = 192350005,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Sat", 6, "#0000ff", "Saturday")]
		Sat = 192350006,
	}
}
