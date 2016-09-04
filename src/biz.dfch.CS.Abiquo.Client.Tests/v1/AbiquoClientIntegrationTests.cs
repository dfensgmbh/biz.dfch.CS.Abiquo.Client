/**
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
 
﻿using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
﻿using System.Net.Http;
﻿using System.Runtime.CompilerServices;
﻿using System.Text;
using System.Threading.Tasks;
﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using biz.dfch.CS.Abiquo.Client.Authentication;
﻿using biz.dfch.CS.Abiquo.Client.Communication;
﻿using biz.dfch.CS.Abiquo.Client.Factory;
using biz.dfch.CS.Abiquo.Client.v1;
﻿using Newtonsoft.Json;
using biz.dfch.CS.Abiquo.Client.General;
﻿using biz.dfch.CS.Abiquo.Client.v1.Model;
﻿using HttpMethod = biz.dfch.CS.Web.Utilities.Rest.HttpMethod;

namespace biz.dfch.CS.Abiquo.Client.Tests.v1
{
    [TestClass]
    public class AbiquoClientIntegrationTests
    {
        private readonly IAuthenticationInformation BasicAuthenticationInformation = new BasicAuthenticationInformation(IntegrationTestEnvironment.Username, IntegrationTestEnvironment.Password, IntegrationTestEnvironment.TenantId);
        private const string SAMPLE_VIRTUAL_MACHINE_PASSWORD = "SamplePw";
        private const string SAMPLE_VIRTUAL_MACHINE_NAME = "Abiquo Client TestVM";

        #region Login

        [TestMethod]
        [TestCategory("SkipOnTeamCity")]
        public void LoginWithValidBasicAuthenticationInformationReturnsTrue()
        {
            // Arrange
            var abiquoClient = AbiquoClientFactory.GetByVersion(AbiquoClientFactory.ABIQUO_CLIENT_VERSION_V1);

            // Act
            var loginSucceeded = abiquoClient.Login(IntegrationTestEnvironment.AbiquoApiBaseUri, BasicAuthenticationInformation);

            // Assert
            Assert.IsTrue(loginSucceeded);
        }

        [TestMethod]
        [TestCategory("SkipOnTeamCity")]
        public void LoginWithInValidBasicAuthenticationInformationReturnsFalse()
        {
            // Arrange
            var abiquoClient = AbiquoClientFactory.GetByVersion(AbiquoClientFactory.ABIQUO_CLIENT_VERSION_V1);
            var basicAuthInfo = new BasicAuthenticationInformation("invalid-username", "invalid-password", IntegrationTestEnvironment.TenantId);

            // Act
            var loginSucceeded = abiquoClient.Login(IntegrationTestEnvironment.AbiquoApiBaseUri, basicAuthInfo);

            // Assert
            Assert.IsFalse(loginSucceeded);
        }

        #endregion Login


        #region Enterprises

        [TestMethod]
        [TestCategory("SkipOnTeamCity")]
        public void InvokeGetEnterprisesReturnsAbiquoEnterprises()
        {
            // Arrange
            var abiquoClient = AbiquoClientFactory.GetByVersion(AbiquoClientFactory.ABIQUO_CLIENT_VERSION_V1);
            var loginSucceeded = abiquoClient.Login(IntegrationTestEnvironment.AbiquoApiBaseUri, BasicAuthenticationInformation);

            var headers = new HeaderBuilder().BuildAccept(AbiquoMediaDataTypes.VND_ABIQUO_ENTERPRISES).GetHeaders();

            // Act
            var result = abiquoClient.Invoke(HttpMethod.Get, AbiquoUriSuffixes.ENTERPRISES, null, headers);

            // Assert
            Assert.IsTrue(loginSucceeded);
            Assert.IsNotNull(result);
        }

        [TestMethod]
        [TestCategory("SkipOnTeamCity")]
        public void GetEnterprisesReturnsAbiquoEnterprises()
        {
            // Arrange
            var abiquoClient = AbiquoClientFactory.GetByVersion(AbiquoClientFactory.ABIQUO_CLIENT_VERSION_V1);
            var loginSucceeded = abiquoClient.Login(IntegrationTestEnvironment.AbiquoApiBaseUri, BasicAuthenticationInformation);

            // Act
            var enterprises = abiquoClient.GetEnterprises();

            // Assert
            Assert.IsTrue(loginSucceeded);
            Assert.IsNotNull(enterprises);
            Assert.IsNotNull(enterprises.Collection);
            Assert.IsTrue(0 < enterprises.TotalSize);
            Assert.IsTrue(0 < enterprises.Links.Count);
        }

        [TestMethod]
        [TestCategory("SkipOnTeamCity")]
        public void GetCurrentEnterpriseReturnsCurrentAbiquoEnterprise()
        {
            // Arrange
            var abiquoClient = AbiquoClientFactory.GetByVersion(AbiquoClientFactory.ABIQUO_CLIENT_VERSION_V1);
            var loginSucceeded = abiquoClient.Login(IntegrationTestEnvironment.AbiquoApiBaseUri, BasicAuthenticationInformation);

            // Act
            var currentEnterprise = abiquoClient.GetCurrentEnterprise();

            // Assert
            Assert.IsTrue(loginSucceeded);
            Assert.IsNotNull(currentEnterprise);
            Assert.AreEqual(BasicAuthenticationInformation.GetTenantId(), currentEnterprise.Id);
        }

        [TestMethod]
        [TestCategory("SkipOnTeamCity")]
        public void GetEnterpriseReturnsAbiquoEnterprise()
        {
            // Arrange
            var abiquoClient = AbiquoClientFactory.GetByVersion(AbiquoClientFactory.ABIQUO_CLIENT_VERSION_V1);
            var loginSucceeded = abiquoClient.Login(IntegrationTestEnvironment.AbiquoApiBaseUri, BasicAuthenticationInformation);

            // Act
            var enterprise = abiquoClient.GetEnterprise(BasicAuthenticationInformation.GetTenantId());

            // Assert
            Assert.IsTrue(loginSucceeded);
            Assert.IsNotNull(enterprise);
            Assert.AreEqual(BasicAuthenticationInformation.GetTenantId(), enterprise.Id);
        }

        [TestMethod]
        [TestCategory("SkipOnTeamCity")]
        [ExpectedException(typeof(HttpRequestException))]
        public void GetInexistentEnterpriseThrowsException()
        {
            // Arrange
            var abiquoClient = AbiquoClientFactory.GetByVersion(AbiquoClientFactory.ABIQUO_CLIENT_VERSION_V1);
            abiquoClient.Login(IntegrationTestEnvironment.AbiquoApiBaseUri, BasicAuthenticationInformation);

            // Act
            abiquoClient.GetEnterprise(5000);

            // Assert
        }

        [TestMethod]
        [TestCategory("SkipOnTeamCity")]
        public void InvokeNewAbiquoEnterpriseAndDeleteTheNewCreatedEnterpriseSucceeds()
        {
            // Arrange
            var abiquoClient = AbiquoClientFactory.GetByVersion(AbiquoClientFactory.ABIQUO_CLIENT_VERSION_V1);
            var loginSucceeded = abiquoClient.Login(IntegrationTestEnvironment.AbiquoApiBaseUri, BasicAuthenticationInformation);

            var headers = new Dictionary<string, string>()
            {
                { AbiquoHeaderKeys.ACCEPT_HEADER_KEY, AbiquoMediaDataTypes.VND_ABIQUO_ENTERPRISE }
                ,
                { AbiquoHeaderKeys.CONTENT_TYPE_HEADER_KEY, AbiquoMediaDataTypes.VND_ABIQUO_ENTERPRISE }
            };

            var enterpriseName = Guid.NewGuid().ToString();

            var body = new Dictionary<string, object>()
            {
                { "cpuCountHardLimit", 2 }
                ,
                { "diskHardLimitInMb", 2 }
                ,
                { "isReservationRestricted", false }
                ,
                { "twoFactorAuthenticationMandatory", false }
                ,
                { "ramSoftLimitInMb", 1 }
                ,
                { "links", new string[0] }
                ,
                { "workflow", false }
                ,
                { "vlansHard", 0 }
                ,
                { "publicIpsHard", 0 }
                ,
                { "publicIpsSoft", 0 }
                ,
                { "ramHardLimitInMb", 2 }
                ,
                { "vlansSoft", 0 }
                ,
                { "cpuCountSoftLimit", 1 }
                ,
                { "diskSoftLimitInMb", 1 }
                ,
                { "name", enterpriseName }
            };

            var jsonBody = JsonConvert.SerializeObject(body);

            // Act
            var creationResult = abiquoClient.Invoke(HttpMethod.Post, AbiquoUriSuffixes.ENTERPRISES, null, headers, jsonBody);

            var resultingEnterprise = JsonConvert.DeserializeObject<dynamic>(creationResult);

            var requestUriSuffix = string.Format(AbiquoUriSuffixes.ENTERPRISE_BY_ID, resultingEnterprise.id.ToString());
            var deletionResult = abiquoClient.Invoke(HttpMethod.Delete, requestUriSuffix, null, headers);

            // Assert
            Assert.IsTrue(loginSucceeded);

            Assert.IsNotNull(creationResult);
            Assert.IsNotNull(deletionResult);
        }

        #endregion Enterprises


        #region Users

        [TestMethod]
        [TestCategory("SkipOnTeamCity")]
        public void InvokeGetUsersReturnsAbiquoUsersWithRoles()
        {
            // Arrange
            var abiquoClient = AbiquoClientFactory.GetByVersion(AbiquoClientFactory.ABIQUO_CLIENT_VERSION_V1);
            var loginSucceeded = abiquoClient.Login(IntegrationTestEnvironment.AbiquoApiBaseUri, BasicAuthenticationInformation);

            var headers = new HeaderBuilder().BuildAccept(AbiquoMediaDataTypes.VND_ABIQUO_USERSWITHROLES).GetHeaders();

            // Act
            var requestUriSuffix = string.Format(AbiquoUriSuffixes.USERSWITHROLES_BY_ENTERPRISE_ID, IntegrationTestEnvironment.TenantId);
            var result = abiquoClient.Invoke(HttpMethod.Get, requestUriSuffix, null, headers);

            // Assert
            Assert.IsTrue(loginSucceeded);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        [TestCategory("SkipOnTeamCity")]
        public void GetUsersWithRolesOfCurrentEnterpriseReturnsAbiquoUsersWithRolesOfCurrentEnterprise()
        {
            // Arrange
            var abiquoClient = AbiquoClientFactory.GetByVersion(AbiquoClientFactory.ABIQUO_CLIENT_VERSION_V1);
            var loginSucceeded = abiquoClient.Login(IntegrationTestEnvironment.AbiquoApiBaseUri, BasicAuthenticationInformation);

            // Act
            var usersWithRoles = abiquoClient.GetUsersWithRolesOfCurrentEnterprise();

            // Assert
            Assert.IsTrue(loginSucceeded);
            Assert.IsNotNull(usersWithRoles);
            Assert.IsNotNull(usersWithRoles.Collection);
            Assert.IsTrue(0 < usersWithRoles.TotalSize);
            Assert.IsTrue(0 < usersWithRoles.Links.Count);

            var userWithRole = usersWithRoles.Collection.FirstOrDefault();
            Assert.IsNotNull(userWithRole);
            Assert.AreEqual(IntegrationTestEnvironment.TenantId, userWithRole.Enterprise.Id);
        }

        [TestMethod]
        [TestCategory("SkipOnTeamCity")]
        public void GetUsersWithRolesReturnsAbiquoUsersWithRoles()
        {
            // Arrange
            var abiquoClient = AbiquoClientFactory.GetByVersion(AbiquoClientFactory.ABIQUO_CLIENT_VERSION_V1);
            var loginSucceeded = abiquoClient.Login(IntegrationTestEnvironment.AbiquoApiBaseUri, BasicAuthenticationInformation);

            // Act
            var usersWithRoles = abiquoClient.GetUsersWithRoles(IntegrationTestEnvironment.TenantId);

            // Assert
            Assert.IsTrue(loginSucceeded);
            Assert.IsNotNull(usersWithRoles);
            Assert.IsNotNull(usersWithRoles.Collection);
            Assert.IsTrue(0 < usersWithRoles.TotalSize);
            Assert.IsTrue(0 < usersWithRoles.Links.Count);

            var user = usersWithRoles.Collection.FirstOrDefault();
            Assert.IsNotNull(user);
            Assert.AreEqual(IntegrationTestEnvironment.TenantId, user.Enterprise.Id);
        }

        [TestMethod]
        [TestCategory("SkipOnTeamCity")]
        public void GetUserOfCurrentEnterpriseReturnsAbiquoUserOfCurrentEnterprise()
        {
            // Arrange
            var abiquoClient = AbiquoClientFactory.GetByVersion(AbiquoClientFactory.ABIQUO_CLIENT_VERSION_V1);
            var loginSucceeded = abiquoClient.Login(IntegrationTestEnvironment.AbiquoApiBaseUri, BasicAuthenticationInformation);

            var usersWithRoles = abiquoClient.GetUsersWithRoles(IntegrationTestEnvironment.TenantId);
            var expectedUserWithRoles = usersWithRoles.Collection.FirstOrDefault();
            Contract.Assert(null != expectedUserWithRoles);

            // Act
            var userWithRoles = abiquoClient.GetUserOfCurrentEnterprise(expectedUserWithRoles.Id);

            // Assert
            Assert.IsTrue(loginSucceeded);

            Assert.IsNotNull(userWithRoles);
            Assert.AreEqual(expectedUserWithRoles.Id, userWithRoles.Id);
            Assert.AreEqual(expectedUserWithRoles.Active, userWithRoles.Active);
            Assert.AreEqual(expectedUserWithRoles.AuthType, userWithRoles.AuthType);
            Assert.AreEqual(expectedUserWithRoles.AvailableVirtualDatacenters, userWithRoles.AvailableVirtualDatacenters);
            Assert.AreEqual(expectedUserWithRoles.Description, userWithRoles.Description);
            Assert.AreEqual(expectedUserWithRoles.Email, userWithRoles.Email);
            Assert.AreEqual(expectedUserWithRoles.Locale, userWithRoles.Locale);
            Assert.AreEqual(expectedUserWithRoles.FirstLogin, userWithRoles.FirstLogin);
            Assert.AreEqual(expectedUserWithRoles.Nick, userWithRoles.Nick);
            Assert.AreEqual(expectedUserWithRoles.Password, userWithRoles.Password);
            Assert.AreEqual(expectedUserWithRoles.Surname, userWithRoles.Surname);
            Assert.AreEqual(expectedUserWithRoles.Locked, userWithRoles.Locked);
        }

        [TestMethod]
        [TestCategory("SkipOnTeamCity")]
        public void GetUserReturnsAbiquoUser()
        {
            // Arrange
            var abiquoClient = AbiquoClientFactory.GetByVersion(AbiquoClientFactory.ABIQUO_CLIENT_VERSION_V1);
            var loginSucceeded = abiquoClient.Login(IntegrationTestEnvironment.AbiquoApiBaseUri, BasicAuthenticationInformation);

            var usersWithRoles = abiquoClient.GetUsersWithRoles(IntegrationTestEnvironment.TenantId);
            var expectedUserWithRoles = usersWithRoles.Collection.FirstOrDefault();
            Contract.Assert(null != expectedUserWithRoles);

            // Act
            var userWithRoles = abiquoClient.GetUser(IntegrationTestEnvironment.TenantId, expectedUserWithRoles.Id);

            // Assert
            Assert.IsTrue(loginSucceeded);

            Assert.IsNotNull(userWithRoles);
            Assert.AreEqual(expectedUserWithRoles.Id, userWithRoles.Id);
            Assert.AreEqual(expectedUserWithRoles.Active, userWithRoles.Active);
            Assert.AreEqual(expectedUserWithRoles.AuthType, userWithRoles.AuthType);
            Assert.AreEqual(expectedUserWithRoles.AvailableVirtualDatacenters, userWithRoles.AvailableVirtualDatacenters);
            Assert.AreEqual(expectedUserWithRoles.Description, userWithRoles.Description);
            Assert.AreEqual(expectedUserWithRoles.Email, userWithRoles.Email);
            Assert.AreEqual(expectedUserWithRoles.Locale, userWithRoles.Locale);
            Assert.AreEqual(expectedUserWithRoles.FirstLogin, userWithRoles.FirstLogin);
            Assert.AreEqual(expectedUserWithRoles.Nick, userWithRoles.Nick);
            Assert.AreEqual(expectedUserWithRoles.Password, userWithRoles.Password);
            Assert.AreEqual(expectedUserWithRoles.Surname, userWithRoles.Surname);
            Assert.AreEqual(expectedUserWithRoles.Locked, userWithRoles.Locked);
        }

        #endregion Users


        #region Roles

        [TestMethod]
        [TestCategory("SkipOnTeamCity")]
        public void InvokeGetRolesSucceedsReturnsAbiquoRoles()
        {
            // Arrange
            var abiquoClient = AbiquoClientFactory.GetByVersion(AbiquoClientFactory.ABIQUO_CLIENT_VERSION_V1);
            var loginSucceeded = abiquoClient.Login(IntegrationTestEnvironment.AbiquoApiBaseUri, BasicAuthenticationInformation);

            var headers = new HeaderBuilder().BuildAccept(AbiquoMediaDataTypes.VND_ABIQUO_ROLES).GetHeaders();

            // Act
            var result = abiquoClient.Invoke(HttpMethod.Get, AbiquoUriSuffixes.ROLES, null, headers);

            // Assert
            Assert.IsTrue(loginSucceeded);
            Assert.IsNotNull(result);
        }

        [TestMethod]
        [TestCategory("SkipOnTeamCity")]
        public void GetRolesReturnsAbiquoRoles()
        {
            // Arrange
            var abiquoClient = AbiquoClientFactory.GetByVersion(AbiquoClientFactory.ABIQUO_CLIENT_VERSION_V1);
            var loginSucceeded = abiquoClient.Login(IntegrationTestEnvironment.AbiquoApiBaseUri, BasicAuthenticationInformation);

            // Act
            var roles = abiquoClient.GetRoles();

            // Assert
            Assert.IsTrue(loginSucceeded);

            Assert.IsNotNull(roles);
            Assert.IsNotNull(roles.Collection);
            Assert.IsTrue(0 < roles.TotalSize);
            Assert.IsTrue(0 < roles.Links.Count);
        }

        [TestMethod]
        [TestCategory("SkipOnTeamCity")]
        public void GetRoleReturnsAbiquoRole()
        {
            // Arrange
            var abiquoClient = AbiquoClientFactory.GetByVersion(AbiquoClientFactory.ABIQUO_CLIENT_VERSION_V1);
            var loginSucceeded = abiquoClient.Login(IntegrationTestEnvironment.AbiquoApiBaseUri, BasicAuthenticationInformation);

            var roles = abiquoClient.GetRoles();
            var expectedRole = roles.Collection.FirstOrDefault();
            Contract.Assert(null != expectedRole);

            // Act
            var role = abiquoClient.GetRole(expectedRole.Id);

            // Assert
            Assert.IsTrue(loginSucceeded);

            Assert.IsNotNull(role);
            Assert.AreEqual(expectedRole.Id, role.Id);
            Assert.AreEqual(expectedRole.Blocked, role.Blocked);
            Assert.AreEqual(expectedRole.IdEnterprise, role.IdEnterprise);
            Assert.AreEqual(expectedRole.Ldap, role.Ldap);
        }

        #endregion Roles


        #region VirtualMachines

        [TestMethod]
        [TestCategory("SkipOnTeamCity")]
        public void GetAllVirtualMachinesReturnsAllAbiquoVirtualMachinesOfUser()
        {
            // Arrange
            var abiquoClient = AbiquoClientFactory.GetByVersion(AbiquoClientFactory.ABIQUO_CLIENT_VERSION_V1);
            var loginSucceeded = abiquoClient.Login(IntegrationTestEnvironment.AbiquoApiBaseUri, BasicAuthenticationInformation);

            // Act
            var virtualMachines = abiquoClient.GetAllVirtualMachines();

            // Assert
            Assert.IsTrue(loginSucceeded);

            Assert.IsNotNull(virtualMachines);
            Assert.IsNotNull(virtualMachines.Collection);
            Assert.IsTrue(0 < virtualMachines.TotalSize);
            Assert.IsTrue(0 < virtualMachines.Links.Count);

            var virtualMachine = virtualMachines.Collection.FirstOrDefault();
            Assert.IsNotNull(virtualMachine);
            Assert.IsTrue(0 < virtualMachine.Id);
            Assert.IsNotNull(virtualMachine.Name);
            Assert.IsTrue(0 < virtualMachine.Cpu);
            Assert.IsTrue(0 < virtualMachine.Ram);
        }

        [TestMethod]
        [TestCategory("SkipOnTeamCity")]
        public void GetVirtualMachinesReturnsAbiquoVirtualMachines()
        {
            // Arrange
            var abiquoClient = AbiquoClientFactory.GetByVersion(AbiquoClientFactory.ABIQUO_CLIENT_VERSION_V1);
            var loginSucceeded = abiquoClient.Login(IntegrationTestEnvironment.AbiquoApiBaseUri, BasicAuthenticationInformation);

            var virtualDataCenters = abiquoClient.GetVirtualDataCenters();
            var virtualDataCenter = virtualDataCenters.Collection.FirstOrDefault();
            Contract.Assert(null != virtualDataCenter);

            var virtualAppliances = abiquoClient.GetVirtualAppliances(virtualDataCenter.Id);
            var virtualAppliance = virtualAppliances.Collection.FirstOrDefault();
            Contract.Assert(null != virtualAppliance);

            // Act
            var virtualMachines = abiquoClient.GetVirtualMachines(virtualDataCenter.Id, virtualAppliance.Id);

            // Assert
            Assert.IsTrue(loginSucceeded);

            Assert.IsNotNull(virtualMachines);
            Assert.IsNotNull(virtualMachines.Collection);
            Assert.IsTrue(0 < virtualMachines.TotalSize);
            Assert.IsTrue(0 < virtualMachines.Links.Count);

            var virtualMachine = virtualMachines.Collection.FirstOrDefault();
            Assert.IsNotNull(virtualMachine);
            Assert.IsTrue(0 < virtualMachine.Id);
            Assert.IsNotNull(virtualMachine.Name);
            Assert.IsTrue(0 < virtualMachine.Cpu);
            Assert.IsTrue(0 < virtualMachine.Ram);
        }

        [TestMethod]
        [TestCategory("SkipOnTeamCity")]
        public void GetVirtualMachineReturnsAbiquoVirtualMachine()
        {
            // Arrange
            var abiquoClient = AbiquoClientFactory.GetByVersion(AbiquoClientFactory.ABIQUO_CLIENT_VERSION_V1);
            var loginSucceeded = abiquoClient.Login(IntegrationTestEnvironment.AbiquoApiBaseUri, BasicAuthenticationInformation);

            var virtualDataCenters = abiquoClient.GetVirtualDataCenters();
            var virtualDataCenter = virtualDataCenters.Collection.FirstOrDefault();
            Contract.Assert(null != virtualDataCenter);

            var virtualAppliances = abiquoClient.GetVirtualAppliances(virtualDataCenter.Id);
            var virtualAppliance = virtualAppliances.Collection.FirstOrDefault();
            Contract.Assert(null != virtualAppliance);
            
            var virtualMachines = abiquoClient.GetVirtualMachines(virtualDataCenter.Id, virtualAppliance.Id);
            var expectedVirtualMachine = virtualMachines.Collection.FirstOrDefault();
            Contract.Assert(null != expectedVirtualMachine);

            // Act
            var virtualMachine = abiquoClient.GetVirtualMachine(virtualDataCenter.Id, virtualAppliance.Id,
                expectedVirtualMachine.Id.GetValueOrDefault());

            // Assert
            Assert.IsTrue(loginSucceeded);

            Assert.IsNotNull(virtualMachine);
            Assert.IsTrue(0 < virtualMachine.Id);
            Assert.AreEqual(expectedVirtualMachine.Id, virtualMachine.Id);
            Assert.AreEqual(expectedVirtualMachine.Name, virtualMachine.Name);
            Assert.AreEqual(expectedVirtualMachine.CoresPerSocket, virtualMachine.CoresPerSocket);
            Assert.AreEqual(expectedVirtualMachine.Cpu, virtualMachine.Cpu);
            Assert.AreEqual(expectedVirtualMachine.Ram, virtualMachine.Ram);
            Assert.AreEqual(expectedVirtualMachine.Description, virtualMachine.Description);
            Assert.AreEqual(expectedVirtualMachine.HighDisponibility, virtualMachine.HighDisponibility);
            Assert.AreEqual(expectedVirtualMachine.IdState, virtualMachine.IdState);
            Assert.AreEqual(expectedVirtualMachine.IdType, virtualMachine.IdType);
            Assert.AreEqual(expectedVirtualMachine.Label, virtualMachine.Label);
            Assert.AreEqual(expectedVirtualMachine.Monitored, virtualMachine.Monitored);
            Assert.AreEqual(expectedVirtualMachine.Protected, virtualMachine.Protected);
            Assert.AreEqual(expectedVirtualMachine.State, virtualMachine.State);
            Assert.AreEqual(expectedVirtualMachine.Uuid, virtualMachine.Uuid);
            Assert.AreEqual(expectedVirtualMachine.VdrpIp, virtualMachine.VdrpIp);
            Assert.AreEqual(expectedVirtualMachine.VdrpEnabled, virtualMachine.VdrpEnabled);
            Assert.AreEqual(expectedVirtualMachine.VdrpPort, virtualMachine.VdrpPort);
        }

        [TestMethod]
        [TestCategory("SkipOnTeamCity")]
        public void CreateVirtualMachineWithoutCustomConfigurationCreatesVirtualMachineBasedOnTemplate()
        {
            // Arrange
            var abiquoClient = AbiquoClientFactory.GetByVersion(AbiquoClientFactory.ABIQUO_CLIENT_VERSION_V1);
            var loginSucceeded = abiquoClient.Login(IntegrationTestEnvironment.AbiquoApiBaseUri, BasicAuthenticationInformation);

            var virtualDataCenters = abiquoClient.GetVirtualDataCenters();
            var virtualDataCenter = virtualDataCenters.Collection.FirstOrDefault();
            Contract.Assert(null != virtualDataCenter);

            var virtualAppliances = abiquoClient.GetVirtualAppliances(virtualDataCenter.Id);
            var virtualAppliance = virtualAppliances.Collection.FirstOrDefault();
            Contract.Assert(null != virtualAppliance);

            var dataCenterRepositories = abiquoClient.GetDataCenterRepositoriesOfCurrentEnterprise();
            var dataCenterRepository = dataCenterRepositories.Collection.FirstOrDefault();
            Contract.Assert(null != dataCenterRepository);

            var editLink = dataCenterRepository.GetLinkByRel("edit");
            var dataCenterRepositoryId = UriHelper.ExtractIdFromHref(editLink.Href);

            var virtualMachineTemplates = abiquoClient.GetVirtualMachineTemplates(IntegrationTestEnvironment.TenantId,
                dataCenterRepositoryId);
            var virtualMachineTemplate = virtualMachineTemplates.Collection.LastOrDefault();
            Contract.Assert(null != virtualMachineTemplate);

            // Act
            var virtualMachine = abiquoClient.CreateVirtualMachine(virtualDataCenter.Id, virtualAppliance.Id,
                IntegrationTestEnvironment.TenantId, dataCenterRepositoryId, virtualMachineTemplate.Id);

            // Assert
            Assert.IsTrue(loginSucceeded);

            Assert.IsNotNull(virtualMachine);
            Assert.IsTrue(0 < virtualMachine.Id);
            Assert.AreNotEqual(virtualMachineTemplate.Name, virtualMachine.Name);
            Assert.AreEqual(virtualMachineTemplate.CpuRequired, virtualMachine.Cpu);
            Assert.AreEqual(virtualMachineTemplate.RamRequired, virtualMachine.Ram);
            Assert.IsNotNull(virtualMachine.Password);

            // Cleanup
            var deletionResult = abiquoClient.DeleteVirtualMachine(virtualDataCenter.Id, virtualAppliance.Id,
                virtualMachine.Id.GetValueOrDefault(), true);
            Assert.IsTrue(deletionResult);
        }
        
        [TestMethod]
        [TestCategory("SkipOnTeamCity")]
        public void CreateVirtualMachineWithCustomConfigurationCreatesVirtualMachineBasedOnTemplateAndCustomConfiguration()
        {
            // Arrange
            var abiquoClient = AbiquoClientFactory.GetByVersion(AbiquoClientFactory.ABIQUO_CLIENT_VERSION_V1);
            var loginSucceeded = abiquoClient.Login(IntegrationTestEnvironment.AbiquoApiBaseUri, BasicAuthenticationInformation);

            var virtualDataCenters = abiquoClient.GetVirtualDataCenters();
            var virtualDataCenter = virtualDataCenters.Collection.FirstOrDefault();
            Contract.Assert(null != virtualDataCenter);

            var virtualAppliances = abiquoClient.GetVirtualAppliances(virtualDataCenter.Id);
            var virtualAppliance = virtualAppliances.Collection.FirstOrDefault();
            Contract.Assert(null != virtualAppliance);

            var dataCenterRepositories = abiquoClient.GetDataCenterRepositoriesOfCurrentEnterprise();
            var dataCenterRepository = dataCenterRepositories.Collection.FirstOrDefault();
            Contract.Assert(null != dataCenterRepository);

            var editLink = dataCenterRepository.GetLinkByRel("edit");
            var dataCenterRepositoryId = UriHelper.ExtractIdFromHref(editLink.Href);

            var virtualMachineTemplates = abiquoClient.GetVirtualMachineTemplates(IntegrationTestEnvironment.TenantId,
                dataCenterRepositoryId);
            var virtualMachineTemplate = virtualMachineTemplates.Collection.LastOrDefault();
            Contract.Assert(null != virtualMachineTemplate);

            var virtualMachineToBeCreated = new VirtualMachine()
            {
                Cpu = 2
                ,
                Ram = 1024
                ,
                Password = SAMPLE_VIRTUAL_MACHINE_PASSWORD
                ,
                Name = SAMPLE_VIRTUAL_MACHINE_NAME
            };

            // Act
            var virtualMachine = abiquoClient.CreateVirtualMachine(virtualDataCenter.Id, virtualAppliance.Id,
                IntegrationTestEnvironment.TenantId, dataCenterRepositoryId, virtualMachineTemplate.Id, virtualMachineToBeCreated);

            // Assert
            Assert.IsTrue(loginSucceeded);

            Assert.IsNotNull(virtualMachine);
            Assert.IsTrue(0 < virtualMachine.Id);
            Assert.AreEqual(virtualMachineToBeCreated.Cpu, virtualMachine.Cpu);
            Assert.AreEqual(virtualMachineToBeCreated.Ram, virtualMachine.Ram);
            Assert.IsNotNull(virtualMachine.Password);

            // Cleanup
            var deletionResult = abiquoClient.DeleteVirtualMachine(virtualDataCenter.Id, virtualAppliance.Id,
                virtualMachine.Id.GetValueOrDefault(), true);
            Assert.IsTrue(deletionResult);
        }

        [TestMethod]
        [TestCategory("SkipOnTeamCity")]
        public void GetAllTasksOfVirtualMachineReturnsAbiquoTasksOfVirtualMachine()
        {
            // Arrange
            var abiquoClient = AbiquoClientFactory.GetByVersion(AbiquoClientFactory.ABIQUO_CLIENT_VERSION_V1);
            var loginSucceeded = abiquoClient.Login(IntegrationTestEnvironment.AbiquoApiBaseUri, BasicAuthenticationInformation);

            var virtualDataCenters = abiquoClient.GetVirtualDataCenters();
            var virtualDataCenter = virtualDataCenters.Collection.FirstOrDefault();
            Contract.Assert(null != virtualDataCenter);

            var virtualAppliances = abiquoClient.GetVirtualAppliances(virtualDataCenter.Id);
            var virtualAppliance = virtualAppliances.Collection.FirstOrDefault();
            Contract.Assert(null != virtualAppliance);

            var virtualMachines = abiquoClient.GetVirtualMachines(virtualDataCenter.Id, virtualAppliance.Id);
            var expectedVirtualMachine = virtualMachines.Collection.LastOrDefault();
            Contract.Assert(null != expectedVirtualMachine);

            var virtualMachine = abiquoClient.GetVirtualMachine(virtualDataCenter.Id, virtualAppliance.Id,
                expectedVirtualMachine.Id.GetValueOrDefault());
            
            // Act
            var tasksOfVirtualMachine = abiquoClient.GetAllTasksOfVirtualMachine(virtualDataCenter.Id, virtualAppliance.Id,
                virtualMachine.Id.GetValueOrDefault());

            // Assert
            Assert.IsTrue(loginSucceeded);

            Assert.IsNotNull(tasksOfVirtualMachine);
            Assert.IsNotNull(tasksOfVirtualMachine.Collection);
            Assert.IsTrue(0 < tasksOfVirtualMachine.Collection.Count);
            Assert.IsNotNull(tasksOfVirtualMachine.Links);
            Assert.IsTrue(0 < tasksOfVirtualMachine.Links.Count);

            var taskOfVirtualMachine = tasksOfVirtualMachine.Collection.FirstOrDefault();
            Assert.IsNotNull(taskOfVirtualMachine);
            Assert.IsFalse(string.IsNullOrWhiteSpace(taskOfVirtualMachine.OwnerId));
            Assert.IsFalse(string.IsNullOrWhiteSpace(taskOfVirtualMachine.TaskId));
            Assert.IsTrue(0 < taskOfVirtualMachine.Timestamp);
        }

        [TestMethod]
        [TestCategory("SkipOnTeamCity")]
        public void GetTaskOfVirtualMachineReturnsAbiquoTasksOfVirtualMachine()
        {
            // Arrange
            var abiquoClient = AbiquoClientFactory.GetByVersion(AbiquoClientFactory.ABIQUO_CLIENT_VERSION_V1);
            var loginSucceeded = abiquoClient.Login(IntegrationTestEnvironment.AbiquoApiBaseUri, BasicAuthenticationInformation);

            var virtualDataCenters = abiquoClient.GetVirtualDataCenters();
            var virtualDataCenter = virtualDataCenters.Collection.FirstOrDefault();
            Contract.Assert(null != virtualDataCenter);

            var virtualAppliances = abiquoClient.GetVirtualAppliances(virtualDataCenter.Id);
            var virtualAppliance = virtualAppliances.Collection.FirstOrDefault();
            Contract.Assert(null != virtualAppliance);

            var virtualMachines = abiquoClient.GetVirtualMachines(virtualDataCenter.Id, virtualAppliance.Id);
            var expectedVirtualMachine = virtualMachines.Collection.LastOrDefault();
            Contract.Assert(null != expectedVirtualMachine);

            var virtualMachine = abiquoClient.GetVirtualMachine(virtualDataCenter.Id, virtualAppliance.Id,
                expectedVirtualMachine.Id.GetValueOrDefault());

            var tasksOfVirtualMachine = abiquoClient.GetAllTasksOfVirtualMachine(virtualDataCenter.Id, virtualAppliance.Id,
                virtualMachine.Id.GetValueOrDefault());

            var expectedTaskOfVirtualMachine = tasksOfVirtualMachine.Collection.FirstOrDefault();
            Contract.Assert(null != expectedTaskOfVirtualMachine);
            
            // Act
            var taskOfVirtualMachine = abiquoClient.GetTaskOfVirtualMachine(virtualDataCenter.Id, virtualAppliance.Id,
                virtualMachine.Id.GetValueOrDefault(), expectedTaskOfVirtualMachine.TaskId);

            // Assert
            Assert.IsTrue(loginSucceeded);

            Assert.IsNotNull(taskOfVirtualMachine);
            Assert.AreEqual(expectedTaskOfVirtualMachine.OwnerId, taskOfVirtualMachine.OwnerId);
            Assert.AreEqual(expectedTaskOfVirtualMachine.State, taskOfVirtualMachine.State);
            Assert.AreEqual(expectedTaskOfVirtualMachine.TaskId, taskOfVirtualMachine.TaskId);
            Assert.AreEqual(expectedTaskOfVirtualMachine.Timestamp, taskOfVirtualMachine.Timestamp);
            Assert.AreEqual(expectedTaskOfVirtualMachine.Type, taskOfVirtualMachine.Type);
            Assert.AreEqual(expectedTaskOfVirtualMachine.Jobs.Collection.Count, taskOfVirtualMachine.Jobs.Collection.Count);
            Assert.AreEqual(expectedTaskOfVirtualMachine.UserId, taskOfVirtualMachine.UserId);
        }

        #endregion VirtualMachines


        #region VirtualMachineTemplates

        [TestMethod]
        [TestCategory("SkipOnTeamCity")]
        public void GetVirtualMachineTemplatesReturnsAbiquoVirtualMachineTemplates()
        {
            // Arrange
            var abiquoClient = AbiquoClientFactory.GetByVersion(AbiquoClientFactory.ABIQUO_CLIENT_VERSION_V1);
            var loginSucceeded = abiquoClient.Login(IntegrationTestEnvironment.AbiquoApiBaseUri, BasicAuthenticationInformation);

            var dataCenterRepositories = abiquoClient.GetDataCenterRepositoriesOfCurrentEnterprise();
            var dataCenterRepository = dataCenterRepositories.Collection.FirstOrDefault();
            Contract.Assert(null != dataCenterRepository);

            var editLink = dataCenterRepository.GetLinkByRel("edit");
            var dataCenterRepositoryId = UriHelper.ExtractIdFromHref(editLink.Href);

            // Act
            var virtualMachineTemplates = abiquoClient.GetVirtualMachineTemplates(IntegrationTestEnvironment.TenantId,
                dataCenterRepositoryId);

            // Assert
            Assert.IsTrue(loginSucceeded);

            Assert.IsNotNull(virtualMachineTemplates);
            Assert.IsNotNull(virtualMachineTemplates.Collection);
            Assert.IsTrue(0 < virtualMachineTemplates.TotalSize);
            Assert.IsTrue(0 < virtualMachineTemplates.Links.Count);

            var virtualMachineTemplate = virtualMachineTemplates.Collection.FirstOrDefault();
            Assert.IsNotNull(virtualMachineTemplate);
            Assert.IsTrue(0 < virtualMachineTemplate.Id);
            Assert.IsNotNull(virtualMachineTemplate.Name);
            Assert.IsTrue(0 < virtualMachineTemplate.CpuRequired);
            Assert.IsTrue(0 < virtualMachineTemplate.RamRequired);
        }

        [TestMethod]
        [TestCategory("SkipOnTeamCity")]
        public void GetVirtualMachineTemplateReturnsAbiquoVirtualMachineTemplate()
        {
            // Arrange
            var abiquoClient = AbiquoClientFactory.GetByVersion(AbiquoClientFactory.ABIQUO_CLIENT_VERSION_V1);
            var loginSucceeded = abiquoClient.Login(IntegrationTestEnvironment.AbiquoApiBaseUri, BasicAuthenticationInformation);

            var dataCenterRepositories = abiquoClient.GetDataCenterRepositoriesOfCurrentEnterprise();
            var dataCenterRepository = dataCenterRepositories.Collection.FirstOrDefault();
            Contract.Assert(null != dataCenterRepository);

            var editLink = dataCenterRepository.GetLinkByRel("edit");
            var dataCenterRepositoryId = UriHelper.ExtractIdFromHref(editLink.Href);

            var virtualMachineTemplates = abiquoClient.GetVirtualMachineTemplates(IntegrationTestEnvironment.TenantId,
                dataCenterRepositoryId);
            var expectedVirtualMachineTemplate = virtualMachineTemplates.Collection.FirstOrDefault();
            Contract.Assert(null != expectedVirtualMachineTemplate);

            // Act
            var virtualMachineTemplate = abiquoClient.GetVirtualMachineTemplate(IntegrationTestEnvironment.TenantId,
                dataCenterRepositoryId, expectedVirtualMachineTemplate.Id);

            // Assert
            Assert.IsTrue(loginSucceeded);

            Assert.IsNotNull(virtualMachineTemplate);
            Assert.IsTrue(0 < virtualMachineTemplate.Id);
            Assert.IsNotNull(virtualMachineTemplate.Name);
            Assert.IsTrue(0 < virtualMachineTemplate.CpuRequired);
            Assert.IsTrue(0 < virtualMachineTemplate.RamRequired);
        }

        #endregion VirtualMachineTemplates


        #region VirtualDataCenters

        [TestMethod]
        [TestCategory("SkipOnTeamCity")]
        public void GetVirtualDataCentersReturnsAbiquoVirtualDataCenters()
        {
            // Arrange
            var abiquoClient = AbiquoClientFactory.GetByVersion(AbiquoClientFactory.ABIQUO_CLIENT_VERSION_V1);
            var loginSucceeded = abiquoClient.Login(IntegrationTestEnvironment.AbiquoApiBaseUri, BasicAuthenticationInformation);

            // Act
            var virtualDataCenters = abiquoClient.GetVirtualDataCenters();

            // Assert
            Assert.IsTrue(loginSucceeded);

            Assert.IsNotNull(virtualDataCenters);
            Assert.IsNotNull(virtualDataCenters.Collection);
            Assert.IsTrue(0 < virtualDataCenters.TotalSize);
            Assert.IsTrue(0 < virtualDataCenters.Links.Count);

            var virtualDataCenter = virtualDataCenters.Collection.FirstOrDefault();
            Assert.IsNotNull(virtualDataCenter);
            Assert.IsTrue(0 < virtualDataCenter.Id);
            Assert.IsNotNull(virtualDataCenter.Name);
            Assert.AreEqual(0, virtualDataCenter.CpuCountHardLimit);
            Assert.AreEqual(0, virtualDataCenter.CpuCountSoftLimit);
            Assert.AreEqual(0, virtualDataCenter.PublicIpsSoft);
            Assert.AreEqual(0, virtualDataCenter.PublicIpsHard);
            Assert.AreEqual(0, virtualDataCenter.DiskSoftLimitInMb);
            Assert.AreEqual(0, virtualDataCenter.DiskHardLimitInMb);
            Assert.AreEqual(0, virtualDataCenter.RamHardLimitInMb);
            Assert.AreEqual(0, virtualDataCenter.RamSoftLimitInMb);
            Assert.IsNotNull(virtualDataCenter.Vlan);
        }

        [TestMethod]
        [TestCategory("SkipOnTeamCity")]
        public void GetVirtualDataCenterReturnsAbiquoVirtualDataCenter()
        {
            // Arrange
            var abiquoClient = AbiquoClientFactory.GetByVersion(AbiquoClientFactory.ABIQUO_CLIENT_VERSION_V1);
            var loginSucceeded = abiquoClient.Login(IntegrationTestEnvironment.AbiquoApiBaseUri, BasicAuthenticationInformation);

            var virtualDataCenters = abiquoClient.GetVirtualDataCenters();
            var expectedVirtualDataCenter = virtualDataCenters.Collection.FirstOrDefault();
            Contract.Assert(null != expectedVirtualDataCenter);

            // Act
            var virtualDataCenter = abiquoClient.GetVirtualDataCenter(expectedVirtualDataCenter.Id);

            // Assert
            Assert.IsTrue(loginSucceeded);

            Assert.IsNotNull(virtualDataCenter);
            Assert.IsTrue(0 < virtualDataCenter.Id);
            Assert.IsNotNull(virtualDataCenter.Name);
            Assert.AreEqual(0, virtualDataCenter.CpuCountHardLimit);
            Assert.AreEqual(0, virtualDataCenter.CpuCountSoftLimit);
            Assert.AreEqual(0, virtualDataCenter.PublicIpsSoft);
            Assert.AreEqual(0, virtualDataCenter.PublicIpsHard);
            Assert.AreEqual(0, virtualDataCenter.DiskSoftLimitInMb);
            Assert.AreEqual(0, virtualDataCenter.DiskHardLimitInMb);
            Assert.AreEqual(0, virtualDataCenter.RamHardLimitInMb);
            Assert.AreEqual(0, virtualDataCenter.RamSoftLimitInMb);
            
            Assert.IsNotNull(virtualDataCenter.Vlan);
            Assert.IsTrue(0 < virtualDataCenter.Vlan.Id);
            Assert.IsNotNull(virtualDataCenter.Vlan.Name);
            Assert.IsNotNull(virtualDataCenter.Vlan.DhcpOptions);
            Assert.IsNotNull(virtualDataCenter.Vlan.DhcpOptions.Collection);
        }

        #endregion VirtualDataCenters


        #region VirtualAppliances

        [TestMethod]
        [TestCategory("SkipOnTeamCity")]
        public void GetVirtualAppliancesReturnsAbiquoVirtualAppliances()
        {
            // Arrange
            var abiquoClient = AbiquoClientFactory.GetByVersion(AbiquoClientFactory.ABIQUO_CLIENT_VERSION_V1);
            var loginSucceeded = abiquoClient.Login(IntegrationTestEnvironment.AbiquoApiBaseUri, BasicAuthenticationInformation);

            var virtualDataCenters = abiquoClient.GetVirtualDataCenters();
            var virtualDataCenterToBeLoaded = virtualDataCenters.Collection.FirstOrDefault();
            Contract.Assert(null != virtualDataCenterToBeLoaded);
            var virtualDataCenter = abiquoClient.GetVirtualDataCenter(virtualDataCenterToBeLoaded.Id);

            // Act
            var virtualAppliances = abiquoClient.GetVirtualAppliances(virtualDataCenter.Id);

            // Assert
            Assert.IsTrue(loginSucceeded);

            Assert.IsNotNull(virtualAppliances);
            Assert.IsNotNull(virtualAppliances.Collection);
            Assert.IsTrue(0 < virtualAppliances.TotalSize);
            Assert.IsTrue(0 < virtualAppliances.Links.Count);

            var virtualAppliance = virtualAppliances.Collection.FirstOrDefault();
            Assert.IsNotNull(virtualAppliance);
            Assert.IsTrue(0 < virtualAppliance.Id);
            Assert.IsNotNull(virtualAppliance.Name);
        }

        [TestMethod]
        [TestCategory("SkipOnTeamCity")]
        public void GetVirtualApplianceReturnsAbiquoVirtualAppliance()
        {
            // Arrange
            var abiquoClient = AbiquoClientFactory.GetByVersion(AbiquoClientFactory.ABIQUO_CLIENT_VERSION_V1);
            var loginSucceeded = abiquoClient.Login(IntegrationTestEnvironment.AbiquoApiBaseUri, BasicAuthenticationInformation);

            var virtualDataCenters = abiquoClient.GetVirtualDataCenters();
            var virtualDataCenterToBeLoaded = virtualDataCenters.Collection.FirstOrDefault();
            Contract.Assert(null != virtualDataCenterToBeLoaded);

            var virtualDataCenter = abiquoClient.GetVirtualDataCenter(virtualDataCenterToBeLoaded.Id);
            
            var virtualAppliances = abiquoClient.GetVirtualAppliances(virtualDataCenter.Id);
            var expectedVirtualApplicance = virtualAppliances.Collection.FirstOrDefault();
            Contract.Assert(null != expectedVirtualApplicance);

            // Act
            var virtualAppliance = abiquoClient.GetVirtualAppliance(virtualDataCenter.Id, expectedVirtualApplicance.Id);

            // Assert
            Assert.IsTrue(loginSucceeded);

            Assert.IsNotNull(virtualAppliance);
            Assert.AreEqual(expectedVirtualApplicance.Id, virtualAppliance.Id);
            Assert.AreEqual(expectedVirtualApplicance.Error, virtualAppliance.Error);
            Assert.AreEqual(expectedVirtualApplicance.HighDisponibility, virtualAppliance.HighDisponibility);
            Assert.AreEqual(expectedVirtualApplicance.NodeConnections, virtualAppliance.NodeConnections);
            Assert.AreEqual(expectedVirtualApplicance.State, virtualAppliance.State);
            Assert.AreEqual(expectedVirtualApplicance.SubState, virtualAppliance.SubState);
            Assert.AreEqual(expectedVirtualApplicance.PublicApp, virtualAppliance.PublicApp);
        }

        #endregion VirtualAppliances


        #region DataCenterRepositories

        [TestMethod]
        [TestCategory("SkipOnTeamCity")]
        public void GetDataCenterRepositoriesReturnsAbiquoDataCenterRepositories()
        {
            // Arrange
            var abiquoClient = AbiquoClientFactory.GetByVersion(AbiquoClientFactory.ABIQUO_CLIENT_VERSION_V1);
            var loginSucceeded = abiquoClient.Login(IntegrationTestEnvironment.AbiquoApiBaseUri, BasicAuthenticationInformation);

            // Act
            var dataCenterRepositories = abiquoClient.GetDataCenterRepositories(IntegrationTestEnvironment.TenantId);

            // Assert
            Assert.IsTrue(loginSucceeded);

            Assert.IsNotNull(dataCenterRepositories);
            Assert.IsNotNull(dataCenterRepositories.Collection);
            Assert.IsNotNull(dataCenterRepositories.Links);
            //Assert.IsTrue(0 < dataCenterRepositories.TotalSize);
            //Assert.IsTrue(0 < dataCenterRepositories.Links.Count);

            var dataCenterRepository = dataCenterRepositories.Collection.FirstOrDefault();
            Assert.IsNotNull(dataCenterRepository);
            Assert.IsNotNull(dataCenterRepository.Links);
            Assert.IsTrue(0 < dataCenterRepository.Links.Count);
            Assert.IsFalse(string.IsNullOrWhiteSpace(dataCenterRepository.Name));
            Assert.IsFalse(string.IsNullOrWhiteSpace(dataCenterRepository.RepositoryLocation));
        }

        [TestMethod]
        [TestCategory("SkipOnTeamCity")]
        public void GetDataCenterRepositoriesOfCurrentEnterpriseReturnsAbiquoDataCenterRepositoriesOfCurrentEnterprise()
        {
            // Arrange
            var abiquoClient = AbiquoClientFactory.GetByVersion(AbiquoClientFactory.ABIQUO_CLIENT_VERSION_V1);
            var loginSucceeded = abiquoClient.Login(IntegrationTestEnvironment.AbiquoApiBaseUri, BasicAuthenticationInformation);

            // Act
            var dataCenterRepositories = abiquoClient.GetDataCenterRepositoriesOfCurrentEnterprise();

            // Assert
            Assert.IsTrue(loginSucceeded);

            Assert.IsNotNull(dataCenterRepositories);
            Assert.IsNotNull(dataCenterRepositories.Collection);
            Assert.IsNotNull(dataCenterRepositories.Links);
            //Assert.IsTrue(0 < dataCenterRepositories.TotalSize);
            //Assert.IsTrue(0 < dataCenterRepositories.Links.Count);

            var dataCenterRepository = dataCenterRepositories.Collection.FirstOrDefault();
            Assert.IsNotNull(dataCenterRepository);
            Assert.IsNotNull(dataCenterRepository.Links);
            Assert.IsTrue(0 < dataCenterRepository.Links.Count);
            Assert.IsFalse(string.IsNullOrWhiteSpace(dataCenterRepository.Name));
            Assert.IsFalse(string.IsNullOrWhiteSpace(dataCenterRepository.RepositoryLocation));
        }

        [TestMethod]
        [TestCategory("SkipOnTeamCity")]
        public void GetDataCenterRepositoryOfCurrentEnterpriseReturnsAbiquoDataCenterRepositoryOfCurrentEnterprise()
        {
            // Arrange
            var abiquoClient = AbiquoClientFactory.GetByVersion(AbiquoClientFactory.ABIQUO_CLIENT_VERSION_V1);
            var loginSucceeded = abiquoClient.Login(IntegrationTestEnvironment.AbiquoApiBaseUri, BasicAuthenticationInformation);

            var dataCenterRepositories = abiquoClient.GetDataCenterRepositoriesOfCurrentEnterprise();
            var expectedDataCenterRepository = dataCenterRepositories.Collection.FirstOrDefault();
            Contract.Assert(null != expectedDataCenterRepository);

            var editLink = expectedDataCenterRepository.GetLinkByRel("edit");
            var dataCenterRepositoryId = UriHelper.ExtractIdFromHref(editLink.Href);

            // Act
            var dataCenterRepository = abiquoClient.GetDataCenterRepositoryOfCurrentEnterprise(dataCenterRepositoryId);

            // Assert
            Assert.IsTrue(loginSucceeded);

            Assert.IsNotNull(dataCenterRepository);
            Assert.IsNotNull(dataCenterRepository.Links);
            Assert.IsTrue(0 < dataCenterRepository.Links.Count);
            Assert.IsFalse(string.IsNullOrWhiteSpace(dataCenterRepository.Name));
            Assert.IsFalse(string.IsNullOrWhiteSpace(dataCenterRepository.RepositoryLocation));

            Assert.AreEqual(expectedDataCenterRepository.Error, dataCenterRepository.Error);
            Assert.AreEqual(expectedDataCenterRepository.Name, dataCenterRepository.Name);
            Assert.AreEqual(expectedDataCenterRepository.RepositoryCapacityMb, dataCenterRepository.RepositoryCapacityMb);
            Assert.AreEqual(expectedDataCenterRepository.RepositoryLocation, dataCenterRepository.RepositoryLocation);
            Assert.AreEqual(expectedDataCenterRepository.RepositoryRemainingMb, dataCenterRepository.RepositoryRemainingMb);
        }

        [TestMethod]
        [TestCategory("SkipOnTeamCity")]
        public void GetDataCenterRepositoryReturnsAbiquoDataCenterRepository()
        {
            // Arrange
            var abiquoClient = AbiquoClientFactory.GetByVersion(AbiquoClientFactory.ABIQUO_CLIENT_VERSION_V1);
            var loginSucceeded = abiquoClient.Login(IntegrationTestEnvironment.AbiquoApiBaseUri, BasicAuthenticationInformation);

            var dataCenterRepositories = abiquoClient.GetDataCenterRepositoriesOfCurrentEnterprise();
            var expectedDataCenterRepository = dataCenterRepositories.Collection.FirstOrDefault();
            Contract.Assert(null != expectedDataCenterRepository);

            var editLink = expectedDataCenterRepository.GetLinkByRel("edit");
            var dataCenterRepositoryId = UriHelper.ExtractIdFromHref(editLink.Href);

            // Act
            var dataCenterRepository = abiquoClient.GetDataCenterRepository(IntegrationTestEnvironment.TenantId, dataCenterRepositoryId);

            // Assert
            Assert.IsTrue(loginSucceeded);

            Assert.IsNotNull(dataCenterRepository);
            Assert.IsNotNull(dataCenterRepository.Links);
            Assert.IsTrue(0 < dataCenterRepository.Links.Count);
            Assert.IsFalse(string.IsNullOrWhiteSpace(dataCenterRepository.Name));
            Assert.IsFalse(string.IsNullOrWhiteSpace(dataCenterRepository.RepositoryLocation));

            Assert.AreEqual(expectedDataCenterRepository.Error, dataCenterRepository.Error);
            Assert.AreEqual(expectedDataCenterRepository.Name, dataCenterRepository.Name);
            Assert.AreEqual(expectedDataCenterRepository.RepositoryCapacityMb, dataCenterRepository.RepositoryCapacityMb);
            Assert.AreEqual(expectedDataCenterRepository.RepositoryLocation, dataCenterRepository.RepositoryLocation);
            Assert.AreEqual(expectedDataCenterRepository.RepositoryRemainingMb, dataCenterRepository.RepositoryRemainingMb);
        }

        #endregion DataCenterRepositories
    }
}
