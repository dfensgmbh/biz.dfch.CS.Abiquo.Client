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
 
﻿using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace biz.dfch.CS.Abiquo.Client.v1.Model
{
    public class Vlan : AbiquoBaseDto
    {
        public string Address { get; set; }
        public bool DefaultNetwork { get; set; }
        public DhcpOptions DhcpOptions { get; set; }
        public string Gateway { get; set; }
        public int Mask { get; set; }
        public string PrimaryDns { get; set; }
        public string SecondaryDns { get; set; }
        public string SufixDns { get; set; }
        public int Tag { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public NetworkType Type { get; set; }
        public bool Ipv6 { get; set; }
        public bool Strict { get; set; }
        public bool Unmanaged { get; set; }
    }
}