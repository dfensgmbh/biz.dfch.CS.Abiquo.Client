﻿/**
 * Copyright 2016 d-fens GmbH
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

namespace biz.dfch.CS.Abiquo.Client.v1
{
    public static class VersionedAbiquoMediaDataTypes
    {
		private const string VERSION_SUFFIX = "; version=" + AbiquoClient.ABIQUO_API_VERSION;

		 
		public const string VND_ABIQUO_ACCEPTEDREQUEST = AbiquoMediaDataTypes.VND_ABIQUO_ACCEPTEDREQUEST + VERSION_SUFFIX; 
		public const string VND_ABIQUO_ACCEPTEDREQUEST2 = AbiquoMediaDataTypes.VND_ABIQUO_ACCEPTEDREQUEST2 + VERSION_SUFFIX; 
		public const string VND_ABIQUO_APPLICATIONS = AbiquoMediaDataTypes.VND_ABIQUO_APPLICATIONS + VERSION_SUFFIX; 
		public const string VND_ABIQUO_APPLICATION = AbiquoMediaDataTypes.VND_ABIQUO_APPLICATION + VERSION_SUFFIX; 
		public const string VND_ABIQUO_BACKUPS = AbiquoMediaDataTypes.VND_ABIQUO_BACKUPS + VERSION_SUFFIX; 
		public const string VND_ABIQUO_BACKUP = AbiquoMediaDataTypes.VND_ABIQUO_BACKUP + VERSION_SUFFIX; 
		public const string VND_ABIQUO_CATEGORY = AbiquoMediaDataTypes.VND_ABIQUO_CATEGORY + VERSION_SUFFIX; 
		public const string VND_ABIQUO_CATEGORIES = AbiquoMediaDataTypes.VND_ABIQUO_CATEGORIES + VERSION_SUFFIX; 
		public const string VND_ABIQUO_CLOUDUSAGE = AbiquoMediaDataTypes.VND_ABIQUO_CLOUDUSAGE + VERSION_SUFFIX; 
		public const string VND_ABIQUO_CLOUDUSAGES = AbiquoMediaDataTypes.VND_ABIQUO_CLOUDUSAGES + VERSION_SUFFIX; 
		public const string VND_ABIQUO_COSTCODE = AbiquoMediaDataTypes.VND_ABIQUO_COSTCODE + VERSION_SUFFIX; 
		public const string VND_ABIQUO_COSTCODES = AbiquoMediaDataTypes.VND_ABIQUO_COSTCODES + VERSION_SUFFIX; 
		public const string VND_ABIQUO_COSTCODECURRENCY = AbiquoMediaDataTypes.VND_ABIQUO_COSTCODECURRENCY + VERSION_SUFFIX; 
		public const string VND_ABIQUO_COSTCODECURRENCIES = AbiquoMediaDataTypes.VND_ABIQUO_COSTCODECURRENCIES + VERSION_SUFFIX; 
		public const string VND_ABIQUO_CURRENCY = AbiquoMediaDataTypes.VND_ABIQUO_CURRENCY + VERSION_SUFFIX; 
		public const string VND_ABIQUO_CURRENCIES = AbiquoMediaDataTypes.VND_ABIQUO_CURRENCIES + VERSION_SUFFIX; 
		public const string VND_ABIQUO_DATACENTER = AbiquoMediaDataTypes.VND_ABIQUO_DATACENTER + VERSION_SUFFIX; 
		public const string VND_ABIQUO_DATACENTERS = AbiquoMediaDataTypes.VND_ABIQUO_DATACENTERS + VERSION_SUFFIX; 
		public const string VND_ABIQUO_LIMIT = AbiquoMediaDataTypes.VND_ABIQUO_LIMIT + VERSION_SUFFIX; 
		public const string VND_ABIQUO_LIMITS = AbiquoMediaDataTypes.VND_ABIQUO_LIMITS + VERSION_SUFFIX; 
		public const string VND_ABIQUO_DATACENTERREPOSITORY = AbiquoMediaDataTypes.VND_ABIQUO_DATACENTERREPOSITORY + VERSION_SUFFIX; 
		public const string VND_ABIQUO_DATACENTERREPOSITORIES = AbiquoMediaDataTypes.VND_ABIQUO_DATACENTERREPOSITORIES + VERSION_SUFFIX; 
		public const string VND_ABIQUO_DATACENTERRESOURCES = AbiquoMediaDataTypes.VND_ABIQUO_DATACENTERRESOURCES + VERSION_SUFFIX; 
		public const string VND_ABIQUO_DATACENTERSRESOURCES = AbiquoMediaDataTypes.VND_ABIQUO_DATACENTERSRESOURCES + VERSION_SUFFIX; 
		public const string VND_ABIQUO_DATASTORE = AbiquoMediaDataTypes.VND_ABIQUO_DATASTORE + VERSION_SUFFIX; 
		public const string VND_ABIQUO_DATASTORES = AbiquoMediaDataTypes.VND_ABIQUO_DATASTORES + VERSION_SUFFIX; 
		public const string VND_ABIQUO_DHCPOPTION = AbiquoMediaDataTypes.VND_ABIQUO_DHCPOPTION + VERSION_SUFFIX; 
		public const string VND_ABIQUO_DHCPOPTIONS = AbiquoMediaDataTypes.VND_ABIQUO_DHCPOPTIONS + VERSION_SUFFIX; 
		public const string VND_ABIQUO_HARDDISK = AbiquoMediaDataTypes.VND_ABIQUO_HARDDISK + VERSION_SUFFIX; 
		public const string VND_ABIQUO_HARDDISKS = AbiquoMediaDataTypes.VND_ABIQUO_HARDDISKS + VERSION_SUFFIX; 
		public const string VND_ABIQUO_DISKFORMATTYPES = AbiquoMediaDataTypes.VND_ABIQUO_DISKFORMATTYPES + VERSION_SUFFIX; 
		public const string VND_ABIQUO_DISKFORMATTYPE = AbiquoMediaDataTypes.VND_ABIQUO_DISKFORMATTYPE + VERSION_SUFFIX; 
		public const string VND_ABIQUO_ENTERPRISE = AbiquoMediaDataTypes.VND_ABIQUO_ENTERPRISE + VERSION_SUFFIX; 
		public const string VND_ABIQUO_ENTERPRISES = AbiquoMediaDataTypes.VND_ABIQUO_ENTERPRISES + VERSION_SUFFIX; 
		public const string VND_ABIQUO_ENTERPRISEEXCLUSIONRULE = AbiquoMediaDataTypes.VND_ABIQUO_ENTERPRISEEXCLUSIONRULE + VERSION_SUFFIX; 
		public const string VND_ABIQUO_ENTERPRISEEXCLUSIONRULES = AbiquoMediaDataTypes.VND_ABIQUO_ENTERPRISEEXCLUSIONRULES + VERSION_SUFFIX; 
		public const string VND_ABIQUO_ENTERPRISEPROPERTIES = AbiquoMediaDataTypes.VND_ABIQUO_ENTERPRISEPROPERTIES + VERSION_SUFFIX; 
		public const string VND_ABIQUO_ENTERPRISERESOURCES = AbiquoMediaDataTypes.VND_ABIQUO_ENTERPRISERESOURCES + VERSION_SUFFIX; 
		public const string VND_ABIQUO_ENTERPRISESRESOURCES = AbiquoMediaDataTypes.VND_ABIQUO_ENTERPRISESRESOURCES + VERSION_SUFFIX; 
		public const string VND_ABIQUO_ERROR = AbiquoMediaDataTypes.VND_ABIQUO_ERROR + VERSION_SUFFIX; 
		public const string VND_ABIQUO_ERRORS = AbiquoMediaDataTypes.VND_ABIQUO_ERRORS + VERSION_SUFFIX; 
		public const string VND_ABIQUO_EXTERNALIP = AbiquoMediaDataTypes.VND_ABIQUO_EXTERNALIP + VERSION_SUFFIX; 
		public const string VND_ABIQUO_EXTERNALIPS = AbiquoMediaDataTypes.VND_ABIQUO_EXTERNALIPS + VERSION_SUFFIX; 
		public const string VND_ABIQUO_FITPOLICYRULES = AbiquoMediaDataTypes.VND_ABIQUO_FITPOLICYRULES + VERSION_SUFFIX; 
		public const string VND_ABIQUO_FITPOLICYRULE = AbiquoMediaDataTypes.VND_ABIQUO_FITPOLICYRULE + VERSION_SUFFIX; 
		public const string VND_ABIQUO_FSM = AbiquoMediaDataTypes.VND_ABIQUO_FSM + VERSION_SUFFIX; 
		public const string VND_ABIQUO_FSMS = AbiquoMediaDataTypes.VND_ABIQUO_FSMS + VERSION_SUFFIX; 
		public const string VND_ABIQUO_HYPERVISORTYPE = AbiquoMediaDataTypes.VND_ABIQUO_HYPERVISORTYPE + VERSION_SUFFIX; 
		public const string VND_ABIQUO_HYPERVISORTYPES = AbiquoMediaDataTypes.VND_ABIQUO_HYPERVISORTYPES + VERSION_SUFFIX; 
		public const string VND_ABIQUO_INITIATORMAPPING = AbiquoMediaDataTypes.VND_ABIQUO_INITIATORMAPPING + VERSION_SUFFIX; 
		public const string VND_ABIQUO_INITIATORMAPPINGS = AbiquoMediaDataTypes.VND_ABIQUO_INITIATORMAPPINGS + VERSION_SUFFIX; 
		public const string VND_ABIQUO_IP = AbiquoMediaDataTypes.VND_ABIQUO_IP + VERSION_SUFFIX; 
		public const string VND_ABIQUO_IPS = AbiquoMediaDataTypes.VND_ABIQUO_IPS + VERSION_SUFFIX; 
		public const string VND_ABIQUO_JOB = AbiquoMediaDataTypes.VND_ABIQUO_JOB + VERSION_SUFFIX; 
		public const string VND_ABIQUO_JOBS = AbiquoMediaDataTypes.VND_ABIQUO_JOBS + VERSION_SUFFIX; 
		public const string VND_ABIQUO_LICENSE = AbiquoMediaDataTypes.VND_ABIQUO_LICENSE + VERSION_SUFFIX; 
		public const string VND_ABIQUO_LICENSES = AbiquoMediaDataTypes.VND_ABIQUO_LICENSES + VERSION_SUFFIX; 
		public const string VND_ABIQUO_LINKS = AbiquoMediaDataTypes.VND_ABIQUO_LINKS + VERSION_SUFFIX; 
		public const string VND_ABIQUO_LOGICSERVER = AbiquoMediaDataTypes.VND_ABIQUO_LOGICSERVER + VERSION_SUFFIX; 
		public const string VND_ABIQUO_LOGICSERVERS = AbiquoMediaDataTypes.VND_ABIQUO_LOGICSERVERS + VERSION_SUFFIX; 
		public const string VND_ABIQUO_MACHINE = AbiquoMediaDataTypes.VND_ABIQUO_MACHINE + VERSION_SUFFIX; 
		public const string VND_ABIQUO_MACHINES = AbiquoMediaDataTypes.VND_ABIQUO_MACHINES + VERSION_SUFFIX; 
		public const string VND_ABIQUO_MACHINELOADRULE = AbiquoMediaDataTypes.VND_ABIQUO_MACHINELOADRULE + VERSION_SUFFIX; 
		public const string VND_ABIQUO_MACHINELOADRULES = AbiquoMediaDataTypes.VND_ABIQUO_MACHINELOADRULES + VERSION_SUFFIX; 
		public const string VND_ABIQUO_MACHINESTATE = AbiquoMediaDataTypes.VND_ABIQUO_MACHINESTATE + VERSION_SUFFIX; 
		public const string VND_ABIQUO_NIC = AbiquoMediaDataTypes.VND_ABIQUO_NIC + VERSION_SUFFIX; 
		public const string VND_ABIQUO_NICS = AbiquoMediaDataTypes.VND_ABIQUO_NICS + VERSION_SUFFIX; 
		public const string VND_ABIQUO_ORGANIZATION = AbiquoMediaDataTypes.VND_ABIQUO_ORGANIZATION + VERSION_SUFFIX; 
		public const string VND_ABIQUO_ORGANIZATIONS = AbiquoMediaDataTypes.VND_ABIQUO_ORGANIZATIONS + VERSION_SUFFIX; 
		public const string VND_ABIQUO_PRICINGCOSTCODE = AbiquoMediaDataTypes.VND_ABIQUO_PRICINGCOSTCODE + VERSION_SUFFIX; 
		public const string VND_ABIQUO_PRICINGCOSTCODES = AbiquoMediaDataTypes.VND_ABIQUO_PRICINGCOSTCODES + VERSION_SUFFIX; 
		public const string VND_ABIQUO_PRICINGTEMPLATE = AbiquoMediaDataTypes.VND_ABIQUO_PRICINGTEMPLATE + VERSION_SUFFIX; 
		public const string VND_ABIQUO_PRICINGTEMPLATES = AbiquoMediaDataTypes.VND_ABIQUO_PRICINGTEMPLATES + VERSION_SUFFIX; 
		public const string VND_ABIQUO_PRICINGTIER = AbiquoMediaDataTypes.VND_ABIQUO_PRICINGTIER + VERSION_SUFFIX; 
		public const string VND_ABIQUO_PRICINGTIERS = AbiquoMediaDataTypes.VND_ABIQUO_PRICINGTIERS + VERSION_SUFFIX; 
		public const string VND_ABIQUO_PRIVATEIP = AbiquoMediaDataTypes.VND_ABIQUO_PRIVATEIP + VERSION_SUFFIX; 
		public const string VND_ABIQUO_PRIVATEIPS = AbiquoMediaDataTypes.VND_ABIQUO_PRIVATEIPS + VERSION_SUFFIX; 
		public const string VND_ABIQUO_PRIVILEGE = AbiquoMediaDataTypes.VND_ABIQUO_PRIVILEGE + VERSION_SUFFIX; 
		public const string VND_ABIQUO_PRIVILEGES = AbiquoMediaDataTypes.VND_ABIQUO_PRIVILEGES + VERSION_SUFFIX; 
		public const string VND_ABIQUO_PUBLICIP = AbiquoMediaDataTypes.VND_ABIQUO_PUBLICIP + VERSION_SUFFIX; 
		public const string VND_ABIQUO_PUBLICIPS = AbiquoMediaDataTypes.VND_ABIQUO_PUBLICIPS + VERSION_SUFFIX; 
		public const string VND_ABIQUO_RACK = AbiquoMediaDataTypes.VND_ABIQUO_RACK + VERSION_SUFFIX; 
		public const string VND_ABIQUO_RACKS = AbiquoMediaDataTypes.VND_ABIQUO_RACKS + VERSION_SUFFIX; 
		public const string VND_ABIQUO_REMOTESERVICE = AbiquoMediaDataTypes.VND_ABIQUO_REMOTESERVICE + VERSION_SUFFIX; 
		public const string VND_ABIQUO_REMOTESERVICES = AbiquoMediaDataTypes.VND_ABIQUO_REMOTESERVICES + VERSION_SUFFIX; 
		public const string VND_ABIQUO_ROLE = AbiquoMediaDataTypes.VND_ABIQUO_ROLE + VERSION_SUFFIX; 
		public const string VND_ABIQUO_ROLES = AbiquoMediaDataTypes.VND_ABIQUO_ROLES + VERSION_SUFFIX; 
		public const string VND_ABIQUO_ROLELDAP = AbiquoMediaDataTypes.VND_ABIQUO_ROLELDAP + VERSION_SUFFIX; 
		public const string VND_ABIQUO_ROLESLDAP = AbiquoMediaDataTypes.VND_ABIQUO_ROLESLDAP + VERSION_SUFFIX; 
		public const string VND_ABIQUO_ROLEWITHLDAP = AbiquoMediaDataTypes.VND_ABIQUO_ROLEWITHLDAP + VERSION_SUFFIX; 
		public const string VND_ABIQUO_EXTENDED_RUNLIST = AbiquoMediaDataTypes.VND_ABIQUO_EXTENDED_RUNLIST + VERSION_SUFFIX; 
		public const string VND_ABIQUO_EXTENDED_RUNLISTS = AbiquoMediaDataTypes.VND_ABIQUO_EXTENDED_RUNLISTS + VERSION_SUFFIX; 
		public const string VND_ABIQUO_SEEOTHER = AbiquoMediaDataTypes.VND_ABIQUO_SEEOTHER + VERSION_SUFFIX; 
		public const string VND_ABIQUO_STORAGEDEVICE = AbiquoMediaDataTypes.VND_ABIQUO_STORAGEDEVICE + VERSION_SUFFIX; 
		public const string VND_ABIQUO_STORAGEDEVICES = AbiquoMediaDataTypes.VND_ABIQUO_STORAGEDEVICES + VERSION_SUFFIX; 
		public const string VND_ABIQUO_STORAGEPOOL = AbiquoMediaDataTypes.VND_ABIQUO_STORAGEPOOL + VERSION_SUFFIX; 
		public const string VND_ABIQUO_STORAGEPOOLS = AbiquoMediaDataTypes.VND_ABIQUO_STORAGEPOOLS + VERSION_SUFFIX; 
		public const string VND_ABIQUO_STORAGEPOOLWITHTIER = AbiquoMediaDataTypes.VND_ABIQUO_STORAGEPOOLWITHTIER + VERSION_SUFFIX; 
		public const string VND_ABIQUO_STORAGEPOOLSWITHTIER = AbiquoMediaDataTypes.VND_ABIQUO_STORAGEPOOLSWITHTIER + VERSION_SUFFIX; 
		public const string VND_ABIQUO_STORAGEPOOLWITHDEVICE = AbiquoMediaDataTypes.VND_ABIQUO_STORAGEPOOLWITHDEVICE + VERSION_SUFFIX; 
		public const string VND_ABIQUO_STORAGEPOOLSWITHDEVICE = AbiquoMediaDataTypes.VND_ABIQUO_STORAGEPOOLSWITHDEVICE + VERSION_SUFFIX; 
		public const string VND_ABIQUO_SYSTEMPROPERTY = AbiquoMediaDataTypes.VND_ABIQUO_SYSTEMPROPERTY + VERSION_SUFFIX; 
		public const string VND_ABIQUO_SYSTEMPROPERTIES = AbiquoMediaDataTypes.VND_ABIQUO_SYSTEMPROPERTIES + VERSION_SUFFIX; 
		public const string VND_ABIQUO_TASK = AbiquoMediaDataTypes.VND_ABIQUO_TASK + VERSION_SUFFIX; 
		public const string VND_ABIQUO_TASKS = AbiquoMediaDataTypes.VND_ABIQUO_TASKS + VERSION_SUFFIX; 
		public const string VND_ABIQUO_TEMPLATEDEFINITION = AbiquoMediaDataTypes.VND_ABIQUO_TEMPLATEDEFINITION + VERSION_SUFFIX; 
		public const string VND_ABIQUO_TEMPLATEDEFINITIONS = AbiquoMediaDataTypes.VND_ABIQUO_TEMPLATEDEFINITIONS + VERSION_SUFFIX; 
		public const string VND_ABIQUO_TEMPLATEDEFINITIONLIST = AbiquoMediaDataTypes.VND_ABIQUO_TEMPLATEDEFINITIONLIST + VERSION_SUFFIX; 
		public const string VND_ABIQUO_TEMPLATEDEFINITIONLISTS = AbiquoMediaDataTypes.VND_ABIQUO_TEMPLATEDEFINITIONLISTS + VERSION_SUFFIX; 
		public const string VND_ABIQUO_TIER = AbiquoMediaDataTypes.VND_ABIQUO_TIER + VERSION_SUFFIX; 
		public const string VND_ABIQUO_TIERS = AbiquoMediaDataTypes.VND_ABIQUO_TIERS + VERSION_SUFFIX; 
		public const string VND_ABIQUO_UCSRACK = AbiquoMediaDataTypes.VND_ABIQUO_UCSRACK + VERSION_SUFFIX; 
		public const string VND_ABIQUO_UCSRACKS = AbiquoMediaDataTypes.VND_ABIQUO_UCSRACKS + VERSION_SUFFIX; 
		public const string VND_ABIQUO_USER = AbiquoMediaDataTypes.VND_ABIQUO_USER + VERSION_SUFFIX; 
		public const string VND_ABIQUO_USERS = AbiquoMediaDataTypes.VND_ABIQUO_USERS + VERSION_SUFFIX; 
		public const string VND_ABIQUO_USERWITHROLES = AbiquoMediaDataTypes.VND_ABIQUO_USERWITHROLES + VERSION_SUFFIX; 
		public const string VND_ABIQUO_USERSWITHROLES = AbiquoMediaDataTypes.VND_ABIQUO_USERSWITHROLES + VERSION_SUFFIX; 
		public const string VND_ABIQUO_VIRTUALAPPLIANCE = AbiquoMediaDataTypes.VND_ABIQUO_VIRTUALAPPLIANCE + VERSION_SUFFIX; 
		public const string VND_ABIQUO_VIRTUALAPPLIANCES = AbiquoMediaDataTypes.VND_ABIQUO_VIRTUALAPPLIANCES + VERSION_SUFFIX; 
		public const string VND_ABIQUO_VIRTUALAPPLIANCESTATE = AbiquoMediaDataTypes.VND_ABIQUO_VIRTUALAPPLIANCESTATE + VERSION_SUFFIX; 
		public const string VND_ABIQUO_VIRTUALAPPLIANCEPRICE = AbiquoMediaDataTypes.VND_ABIQUO_VIRTUALAPPLIANCEPRICE + VERSION_SUFFIX; 
		public const string VND_ABIQUO_VIRTUALAPPRESOURCES = AbiquoMediaDataTypes.VND_ABIQUO_VIRTUALAPPRESOURCES + VERSION_SUFFIX; 
		public const string VND_ABIQUO_VIRTUALAPPSRESOURCES = AbiquoMediaDataTypes.VND_ABIQUO_VIRTUALAPPSRESOURCES + VERSION_SUFFIX; 
		public const string VND_ABIQUO_VIRTUALDATACENTER = AbiquoMediaDataTypes.VND_ABIQUO_VIRTUALDATACENTER + VERSION_SUFFIX; 
		public const string VND_ABIQUO_VIRTUALDATACENTERS = AbiquoMediaDataTypes.VND_ABIQUO_VIRTUALDATACENTERS + VERSION_SUFFIX; 
		public const string VND_ABIQUO_VIRTUALDATACENTERRESOURCES = AbiquoMediaDataTypes.VND_ABIQUO_VIRTUALDATACENTERRESOURCES + VERSION_SUFFIX; 
		public const string VND_ABIQUO_VIRTUALDATACENTERSRESOURCES = AbiquoMediaDataTypes.VND_ABIQUO_VIRTUALDATACENTERSRESOURCES + VERSION_SUFFIX; 
		public const string VND_ABIQUO_VIRTUALMACHINE = AbiquoMediaDataTypes.VND_ABIQUO_VIRTUALMACHINE + VERSION_SUFFIX; 
		public const string VND_ABIQUO_VIRTUALMACHINES = AbiquoMediaDataTypes.VND_ABIQUO_VIRTUALMACHINES + VERSION_SUFFIX; 
		public const string VND_ABIQUO_VIRTUALMACHINETASK = AbiquoMediaDataTypes.VND_ABIQUO_VIRTUALMACHINETASK + VERSION_SUFFIX; 
		public const string VND_ABIQUO_VIRTUALMACHINEWITHNODE = AbiquoMediaDataTypes.VND_ABIQUO_VIRTUALMACHINEWITHNODE + VERSION_SUFFIX; 
		public const string VND_ABIQUO_VIRTUALMACHINESWITHNODE = AbiquoMediaDataTypes.VND_ABIQUO_VIRTUALMACHINESWITHNODE + VERSION_SUFFIX; 
		public const string VND_ABIQUO_VIRTUALMACHINEWITHNODEEXTENDED = AbiquoMediaDataTypes.VND_ABIQUO_VIRTUALMACHINEWITHNODEEXTENDED + VERSION_SUFFIX; 
		public const string VND_ABIQUO_VIRTUALMACHINESWITHNODEEXTENDED = AbiquoMediaDataTypes.VND_ABIQUO_VIRTUALMACHINESWITHNODEEXTENDED + VERSION_SUFFIX; 
		public const string VND_ABIQUO_VIRTUALMACHINETEMPLATE = AbiquoMediaDataTypes.VND_ABIQUO_VIRTUALMACHINETEMPLATE + VERSION_SUFFIX; 
		public const string VND_ABIQUO_VIRTUALMACHINETEMPLATES = AbiquoMediaDataTypes.VND_ABIQUO_VIRTUALMACHINETEMPLATES + VERSION_SUFFIX; 
		public const string VND_ABIQUO_VIRTUALMACHINESTATE = AbiquoMediaDataTypes.VND_ABIQUO_VIRTUALMACHINESTATE + VERSION_SUFFIX; 
		public const string VND_ABIQUO_VIRTUALMACHINEINSTANCE = AbiquoMediaDataTypes.VND_ABIQUO_VIRTUALMACHINEINSTANCE + VERSION_SUFFIX; 
		public const string VND_ABIQUO_VLAN = AbiquoMediaDataTypes.VND_ABIQUO_VLAN + VERSION_SUFFIX; 
		public const string VND_ABIQUO_VLANS = AbiquoMediaDataTypes.VND_ABIQUO_VLANS + VERSION_SUFFIX; 
		public const string VND_ABIQUO_VLANTAGAVAILABILITY = AbiquoMediaDataTypes.VND_ABIQUO_VLANTAGAVAILABILITY + VERSION_SUFFIX; 
		public const string VND_ABIQUO_VIRTUALMACHINENETWORKCONFIGURATION = AbiquoMediaDataTypes.VND_ABIQUO_VIRTUALMACHINENETWORKCONFIGURATION + VERSION_SUFFIX; 
		public const string VND_ABIQUO_VIRTUALMACHINENETWORKCONFIGURATIONS = AbiquoMediaDataTypes.VND_ABIQUO_VIRTUALMACHINENETWORKCONFIGURATIONS + VERSION_SUFFIX; 
		public const string VND_ABIQUO_ISCSIVOLUME = AbiquoMediaDataTypes.VND_ABIQUO_ISCSIVOLUME + VERSION_SUFFIX; 
		public const string VND_ABIQUO_ISCSIVOLUMES = AbiquoMediaDataTypes.VND_ABIQUO_ISCSIVOLUMES + VERSION_SUFFIX; 
		public const string VND_ABIQUO_ISCSIVOLUMEWITHVIRTUALMACHINE = AbiquoMediaDataTypes.VND_ABIQUO_ISCSIVOLUMEWITHVIRTUALMACHINE + VERSION_SUFFIX; 
		public const string VND_ABIQUO_ISCSIVOLUMESWITHVIRTUALMACHINE = AbiquoMediaDataTypes.VND_ABIQUO_ISCSIVOLUMESWITHVIRTUALMACHINE + VERSION_SUFFIX; 
	}
}