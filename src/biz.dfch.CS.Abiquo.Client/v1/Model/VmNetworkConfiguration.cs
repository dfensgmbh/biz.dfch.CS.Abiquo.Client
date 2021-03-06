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

namespace biz.dfch.CS.Abiquo.Client.v1.Model
{
    public class VmNetworkConfiguration : AbiquoLinkBaseDto
    {
        public string Gateway { get; set; }

        public int? Id { get; set; }

        public string PrimaryDNS { get; set; }

        public string SecondaryDNS { get; set; }
        
        public string SuffixDNS { get; set; }

        public bool Used { get; set; }
    }
}
