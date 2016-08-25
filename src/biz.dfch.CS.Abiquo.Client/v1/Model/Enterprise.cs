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
 
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace biz.dfch.CS.Abiquo.Client.v1.Model
{
    public class Enterprise : AbiquoBaseDto
    {
        public int RamSoftLimitInMb { get; set; }
        public int RamHardLimitInMb { get; set; }
        public int CpuCountSoftLimit { get; set; }
        public int CpuCountHardLimit { get; set; }
        public int DiskSoftLimitInMb { get; set; }
        public int DiskHardLimitInMb { get; set; }
        public int StorageSoftInMb { get; set; }
        public int StorageHardInMb { get; set; }
        public int VlansSoft { get; set; }
        public int VlansHard { get; set; }
        public int PublicIpsSoft { get; set; }
        public int PublicIpsHard { get; set; }
        public int RepositorySoftInMb { get; set; }
        public int RepositoryHardInMb { get; set; }
        public bool IsReservationRestricted { get; set; }
        public bool Workflow { get; set; }
        public bool TwoFactorAuthenticationMandatory { get; set; }
        public string ChefClient { get; set; }
        public string ChefClientCertificate { get; set; }
        public string ChefUrl { get; set; }
        public string ChefValidator { get; set; }
        public string ChefValidatorCertificate { get; set; }
        public int IdPricingTemplate { get; set; }
    }
}
